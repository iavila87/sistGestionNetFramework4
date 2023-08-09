using DataDB.Models;
using DataDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SistemaIndumaqWeb
{
    public partial class Ventas : System.Web.UI.Page
    {

        private Datos d = new Datos();
        private DataTable tb = new DataTable();
        private DataTable tb2 = new DataTable();
        private DataRow dr;
        private DataRow dr2;
        private bool isEdit = false;
        private Producto selProd;
        private Cliente selCli = new Cliente();
        private Venta selSale;
        private SaleProductTable selProdSale;
        private List<Producto> prodList = new List<Producto>() { };
        private List<Cliente> cliList = new List<Cliente>() { };
        private List<Venta> salesList = new List<Venta>() { };
        private List<ProductoVenta> prodsalesList = new List<ProductoVenta>() { };
        private List<SaleProductTable> saleProdTable = new List<SaleProductTable>() { };
        private List<SaleTable> saleTable = new List<SaleTable>() { };

        private List<Producto> productsUpdated = new List<Producto> { };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                List<User> userLog = Session["User"] as List<User>;

                lblUserValue1.Text = userLog[0].alias;
                lblRolValue1.Text = userLog[0].rol;


            }
            else
            {
                Response.Redirect("Index.aspx");
            }

            if (!IsPostBack) {
                
                prodList = d.GetProductos().ToList();
                Session["prodList"] = prodList;
                ddProdl.Items.Clear();
                ddProdl.SelectedIndex = -1;
                ddProdl.Items.Add("- Seleccione -");
                foreach (var p in prodList)
                {
                    ddProdl.Items.Add(p.descripcion);
                }

                cliList = d.GetClientes().ToList();
                Session["cliList"] = cliList;
                ddClil.Items.Clear();
                ddClil.SelectedIndex = -1;
                ddClil.Items.Add("- Seleccione -");
                foreach (var c in cliList)
                {
                    ddClil.Items.Add(c.nombre);
                }

            }

            
            salesList=d.GetVentas().ToList();
            List <ProductoVenta> prodsales = d.GetProdVentas().ToList();

            saleTable = salesList.Select(s =>

                new SaleTable()
                {
                    nroVenta = s.idVenta,
                    cliente = s.Cliente.nombre,
                    fecha = s.fecha,
                    total = prodsales.Where(sp => sp.idVenta == s.idVenta)
                                    .Select(ps => ps.subtotal).Sum()
                }
            ).ToList();
            createSalesTable();

            conterror.Visible = false;
        }

        private void UpdateStock()
        {
            foreach (SaleProductTable sp in saleProdTable) {
                Producto prodAux= prodList.Where(p => p.descripcion.Equals(sp.producto)).First();
                //prodAux.stock -= sp.cantidad;
                d.setEditProduct(prodAux, prodAux.Proveedor.nombre);
            }
            prodList = d.GetProductos().ToList();
        }

        private void createSalesTable()
        {
            tb.Columns.Add("Número de venta", typeof(string));
            tb.Columns.Add("Cliente", typeof(string));
            tb.Columns.Add("Fecha", typeof(string));
            tb.Columns.Add("Total", typeof(string));

            foreach (var s in saleTable)
            {
                dr = tb.NewRow();
                dr["Número de venta"] = s.nroVenta;
                dr["Cliente"] = s.cliente;
                dr["Fecha"] = s.fecha;
                dr["Total"] = s.total;
                tb.Rows.Add(dr);
            }

            Gv1.DataSource = tb;
            Gv1.DataBind();
            ViewState["table1"] = tb;

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("Index.aspx");
        }

        protected void lbtnBorrar_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string numVentas = Gv1.Rows[rowindex].Cells[1].Text;
            selSale = salesList.Where(p => p.idVenta.Equals(Convert.ToInt32(numVentas))).ToList()[0];
            //Session["selCli"] = selCli;
            // falta logica del borrado de ventas

            if (d.setDeleteSaleWeb(selSale))
            {
                setMessage("Venta borrada con exito");
            }
            else
            {
                setMessage("No se puede borrar, la venta esta en uso");
            }

            salesList = d.GetVentas().ToList();
            List<ProductoVenta> prodsales = d.GetProdVentas().ToList();

            saleTable = salesList.Select(s =>

                new SaleTable()
                {
                    nroVenta = s.idVenta,
                    cliente = s.Cliente.nombre,
                    fecha = s.fecha,
                    total = prodsales.Where(sp => sp.idVenta == s.idVenta)
                                    .Select(ps => ps.subtotal).Sum()
                }
            ).ToList();

            tb = new DataTable();
            createSalesTable();

            refreshValues();
        }

        protected void lbtnVer_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string numVentas = Gv1.Rows[rowindex].Cells[1].Text;
            selSale = salesList.Where(p => p.idVenta.Equals(Convert.ToInt32(numVentas))).ToList()[0];
            List<ProductoVenta> prodsales = d.GetProdVentas().ToList();

            saleProdTable = prodsales
                .Where(sp => sp.idVenta.Equals(Convert.ToInt32(selSale.idVenta)))
                .Select(s => new SaleProductTable()
                {
                    cantidad = s.cantidad,
                    producto = s.Producto.descripcion,
                    precio = s.Producto.precio,
                    subtotal = s.subtotal,
                }

                ).ToList();
            tb = new DataTable();
            createSPtable();
            setMessage("Acepte para continuar");
        }

        private void setMessage(string s)
        {
            Gv1.Enabled = false;
            ddClil.Enabled = false;
            ddProdl.Enabled = false;
            txtCantidad.Enabled = false;
            Gv2.Enabled = false;

            btnAgregarProd.Visible = false;
            btnLimpiar.Visible = false;
            btnCancelar.Visible = false;
            btnAgregarVenta.Visible = false;

            conterror.Visible = true;
            lblError.Text = s;
        }

        protected void lbtnBorrarProd_Click(object sender, EventArgs e)
        {
            if (Session["saleProdTable"] != null)
            {
                saleProdTable = Session["saleProdTable"] as List<SaleProductTable>;
            }

            if (Session["prodList"] != null)
            {
                prodList = Session["prodList"] as List<Producto>;
            }

            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string nomProd = Gv2.Rows[rowindex].Cells[2].Text;
            selProdSale = saleProdTable.Where(p => p.producto.Equals(nomProd)).ToList()[0];
            saleProdTable = saleProdTable.Where(p => !p.producto.Equals(nomProd)).ToList();
            Session["saleProdTable"] = saleProdTable;
            foreach (Producto p in prodList) 
            {
                if (p.descripcion.Equals(selProdSale.producto))
                {
                    p.stock += selProdSale.cantidad;
                }
            }
            Session["prodList"] = prodList;
            tb = new DataTable();
            createSPtable();
            /*
            foreach (SaleProductTable sp in saleProdTable)
            {
                Producto prodAux = prodList.Where(p => p.descripcion.Equals(sp.producto)).First();
                prodAux.stock -= sp.cantidad;
                d.setEditProduct(prodAux, prodAux.Proveedor.nombre);
            }
            prodList = d.GetProductos().ToList();*/
        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {

            if (Session["saleProdTable"] != null)
            {
                saleProdTable = Session["saleProdTable"] as List<SaleProductTable>;
            }

            if (Session["selProd"] != null)
            {
                selProd = Session["selProd"] as Producto;
            }

            if (Session["prodList"] != null)
            {
                prodList = Session["prodList"] as List<Producto>;
            }

            string prodsel = ddProdl.SelectedItem.Text;
            int quantity=0;
            if (!txtCantidad.Text.Equals("")) {
                quantity = Convert.ToInt32(txtCantidad.Text);

            }
            else
            {
                quantity = -1;
            }
            
            
            foreach (Producto p in prodList)
            {
                if (prodsel.Equals(p.descripcion)) {
                    selProd = p;
                }
            }
            if (selProd.stock >=quantity && quantity>0) {
                saleProdTable.Add(new SaleProductTable()
                {
                    cantidad = Convert.ToInt32(txtCantidad.Text),
                    producto = selProd.descripcion,
                    precio = selProd.precio,
                    subtotal = selProd.precio * Convert.ToInt32(txtCantidad.Text)
                });
               
               Session["saleProdTable"]=saleProdTable;
                    
            }
            foreach (Producto p in prodList) 
            {
                if (p.descripcion.Equals(selProd.descripcion)) 
                {
                    p.stock -= Convert.ToInt32(txtCantidad.Text);
                } 
            }
            Session["prodList"] = prodList;

            tb = new DataTable();
            createSPtable();

            refreshValues();

        }

        public void createSPtable()
        {
            tb.Columns.Add("Cantidad", typeof(string));
            tb.Columns.Add("Producto", typeof(string));
            tb.Columns.Add("Precio", typeof(string));
            tb.Columns.Add("Subtotal", typeof(string));


            foreach (var sp in saleProdTable)
            {
                dr = tb.NewRow();
                dr["Cantidad"] = sp.cantidad;
                dr["Producto"] = sp.producto;
                dr["Precio"] = sp.precio;
                dr["Subtotal"] = sp.subtotal;
                tb.Rows.Add(dr);
            }

            Gv2.DataSource = tb;
            Gv2.DataBind();
            ViewState["table2"] = tb;

        }

        protected void refreshValues()
        {
            txtCantidad.Text = "";
            ddProdl.SelectedIndex = -1;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ddClil.SelectedIndex = -1;
            ddProdl.SelectedIndex= -1;
            txtCantidad.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            saleProdTable.Clear();
            tb.Rows.Clear();
            ddClil.SelectedIndex = -1;
            ddProdl.SelectedIndex = -1;
            txtCantidad.Text = "";
            Gv2.DataSource = tb;
            Gv2.DataBind();
            ViewState["table2"] = tb;
            Session["saleProdTable"] = saleProdTable;


        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            if (Session["cliList"] != null)
            {
                cliList = Session["cliList"] as List<Cliente>;
            }

            if (Session["prodList"] != null)
            {
                prodList = Session["prodList"] as List<Producto>;
            }

            Venta venta = new Venta();
            string clientAux=ddClil.SelectedItem.ToString();
            foreach(Cliente c in cliList)
            {
                if (clientAux.Equals(c.nombre)) {
                    selCli = c;
                }
            }
            venta.Cliente = d.GetClientes().Where(c => c.nombre.Equals(selCli.nombre)).First();
            venta.fecha = DateTime.Today;


            if (Session["saleProdTable"] != null)
            {
                saleProdTable = Session["saleProdTable"] as List<SaleProductTable>;
            }

            foreach (SaleProductTable s in saleProdTable)
            {
                ProductoVenta productoVenta = new ProductoVenta();
                productoVenta.Producto = d.GetProductos().Where(p => p.descripcion.Equals(s.producto)).ToList().First();
                productoVenta.cantidad = s.cantidad;
                productoVenta.subtotal = s.subtotal;
                productoVenta.Venta = venta;

                d.setNewSaleProducts(productoVenta);
            }

            UpdateStock();

            ddClil.SelectedIndex = -1;
            ddProdl.SelectedIndex = -1;
            txtCantidad.Text = "";
            saleProdTable.Clear();
            tb.Rows.Clear();
            Gv2.DataSource = tb;
            Gv2.DataBind();
            ViewState["table2"] = tb;
            Session["saleProdTable"] = saleProdTable;
            salesList = d.GetVentas().ToList();
            List<ProductoVenta> prodsales = d.GetProdVentas().ToList();

            saleTable = salesList.Select(s =>

                new SaleTable()
                {
                    nroVenta = s.idVenta,
                    cliente = s.Cliente.nombre,
                    fecha = s.fecha,
                    total = prodsales.Where(sp => sp.idVenta == s.idVenta)
                                    .Select(ps => ps.subtotal).Sum()
                }
            ).ToList();

            tb = new DataTable();
            createSalesTable();


        }

        protected void ddProdl_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (Session["prodList"] != null)
            {
                prodList = Session["prodList"] as List<Producto>;
            }
            string selectedP = ddProdl.SelectedItem.Text;
            foreach (Producto p in prodList)
            {
                if (selectedP.Equals(p.descripcion))
                {
                    selProd = p;
                    Session["selProd"] = selProd;
                }
            }*/
        }

        protected void btnAceptarError_Click(object sender, EventArgs e)
        {
            Gv1.Enabled = true;
            ddClil.Enabled = true;
            ddProdl.Enabled = true;
            txtCantidad.Enabled = true;
            Gv2.Enabled = true;

            btnAgregarProd.Visible = true;
            btnLimpiar.Visible = true;
            btnCancelar.Visible = true;
            btnAgregarVenta.Visible = true;

            saleProdTable.Clear();
            tb.Rows.Clear();
            Gv2.DataSource = tb;
            Gv2.DataBind();
            ViewState["table2"] = tb;
            Session["saleProdTable"] = saleProdTable;

            conterror.Visible = false;
        }
    }
}