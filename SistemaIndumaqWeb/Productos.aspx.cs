using DataDB.Models;
using DataDB;
using System;
using System.Timers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;
using System.EnterpriseServices;

namespace SistemaIndumaqWeb
{
    public partial class Productos : System.Web.UI.Page
    {
        private DataTable tb = new DataTable();
        private DataRow dr;
        private bool isEdit = false;
        private List<Producto> selProd = new List<Producto>() { };
        private Datos d = new Datos();
        private IEnumerable<Proveedor> providers;
        private IEnumerable<Producto> prodList;
        private IEnumerable<ProductTable> prodTable;

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
            //if (!IsPostBack)
            //{

            prodList = d.GetProductos();
                prodTable = prodList.Where(p => p.habilitado == true)
                    .Select(p => new ProductTable()
                    {
                        codigo = p.codigo,
                        descripcion = p.descripcion,
                        stock = p.stock,
                        precio = p.precio,
                        proveedor = p.Proveedor.nombre
                    });

                createtable();

            //}
            conterror.Visible = false;

        }

        public void createtable()
        {
            tb.Columns.Add("Codigo", typeof(string));
            tb.Columns.Add("Descripcion", typeof(string));
            tb.Columns.Add("Stock", typeof(string));
            tb.Columns.Add("Precio", typeof(string));
            tb.Columns.Add("Proveedor", typeof(string));
            

            foreach (var p in prodTable)
            {
                dr = tb.NewRow();
                dr["Codigo"] = p.codigo;
                dr["Descripcion"] = p.descripcion;
                dr["Stock"] = p.stock;
                dr["Precio"] = p.precio;
                dr["Proveedor"] = p.proveedor;
                tb.Rows.Add(dr);
            }
            
            Gv1.DataSource = tb;
            Gv1.DataBind();
            ViewState["table1"] = tb;

            providers = d.GetProveedores();

            if (!IsPostBack) 
            {
                //ddProvl.Items.Insert(0, new ListItem("- Seleccione -", "0"));
                ddProvl.SelectedIndex = -1;
                ddProvl.Items.Clear();
                ddProvl.Items.Add("- Seleccione -");
                foreach (var p in providers)
                {
                    ddProvl.Items.Add(p.nombre);
                }
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("Index.aspx");
        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (Session["isEdit"] != null)
            {
                isEdit = (bool)Session["isEdit"];
            }

            if (!isEdit)
            {
                string descripcion = txtDescripcion.Text;
                string codigo = txtCodigo.Text;
                string stock = txtStock.Text;
                string precio = txtPrecio.Text;
                string proveedor = ddProvl.SelectedItem.ToString();

                if (prodList.Where(p => p.codigo.Equals(codigo)).Count() == 0)
                {
                    d.setNewProduct(descripcion,
                        codigo,
                        stock,
                        precio,
                        proveedor);
                    setMessage("Se agrego el producto con exito");
                    refreshValues();

                }
                else
                {
                    txtCodigo.Text = "";
                    setMessage("Él codigo ya existe");
                }
 
            }
            else 
            {
                if (Session["selProd"] != null)
                {
                    selProd = Session["selProd"] as List<Producto>;
                }

                selProd[0].descripcion = txtDescripcion.Text;
                selProd[0].codigo = txtCodigo.Text;
                selProd[0].stock = Convert.ToInt32(txtStock.Text);
                selProd[0].precio = Convert.ToDouble(txtPrecio.Text);
                d.setEditProduct(selProd[0], ddProvl.SelectedItem.ToString());

                setMessage("Se edito el producto con exito");
                refreshValues();
            }

            prodList = d.GetProductos();
            prodTable = prodList.Where(p => p.habilitado == true)
                .Select(p => new ProductTable()
                {
                    codigo = p.codigo,
                    descripcion = p.descripcion,
                    stock = p.stock,
                    precio = p.precio,
                    proveedor = p.Proveedor.nombre
                });

            tb = new DataTable();
            createtable();

            

            Session["isEdit"] = false;

            titParrafo.InnerText = "Agregar nuevo producto";
            btnAgregarProd.Text = "Agregar";
            
        }

        protected void refreshValues() {
            txtDescripcion.Text = "";
            txtCodigo.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";
            ddProvl.SelectedIndex = -1;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            refreshValues();
        }

        protected void lbtnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void lbtnEditar_Click1(object sender, EventArgs e)
        {
            titParrafo.InnerText = "Editar producto seleccionado";
            btnAgregarProd.Text = "Editar";

            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string codProduct = Gv1.Rows[rowindex].Cells[1].Text;

            selProd = prodList.Where(p => p.codigo.Equals(codProduct)).ToList();
            Session["selProd"] = selProd;
            txtDescripcion.Text = selProd[0].descripcion;
            txtCodigo.Text = selProd[0].codigo;
            txtStock.Text = selProd[0].stock.ToString();
            txtPrecio.Text = selProd[0].precio.ToString();

            ddProvl.ClearSelection(); //making sure the previous selection has been cleared
            ddProvl.Items.FindByValue(selProd[0].Proveedor.nombre).Selected = true;

            Session["isEdit"] = true;
            
        }

        private void setMessage(string s) 
        {
            Gv1.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;
            ddProvl.Enabled = false;
            
            btnAgregarProd.Visible = false;
            btnLimpiar.Visible = false;
            btnCancelar.Visible = false;

            conterror.Visible = true;
            lblError.Text = s;
        }

        protected void lbtnBorrar_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string codProduct = Gv1.Rows[rowindex].Cells[1].Text;
            selProd = prodList.Where(p => p.codigo.Equals(codProduct)).ToList();
            Session["selProd"] = selProd;

            if (d.setDeleteProductWeb(selProd[0]))
            {
                setMessage("Producto borrado con exito");
            }
            else
            {
                setMessage("No se puede borrar, el producto esta en uso");
            }

            prodList = d.GetProductos();
            prodTable = prodList.Where(p => p.habilitado == true)
                .Select(p => new ProductTable()
                {
                    codigo = p.codigo,
                    descripcion = p.descripcion,
                    stock = p.stock,
                    precio = p.precio,
                    proveedor = p.Proveedor.nombre
                });

            tb = new DataTable();
            createtable();

            refreshValues();

            //Session["isEdit"] = false;
        }

        protected void lbtnAgregar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            refreshValues();
            titParrafo.InnerText = "Agregar nuevo producto";
            btnAgregarProd.Text = "Agregar";
            Session["isEdit"] = false;
        }

        protected void btnAceptarError_Click(object sender, EventArgs e)
        {
            Gv1.Enabled = true;
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;
            ddProvl.Enabled = true;
            btnAgregarProd.Visible = true;
            btnLimpiar.Visible = true;
            btnCancelar.Visible = true;

            conterror.Visible = false;

        }
    }
}