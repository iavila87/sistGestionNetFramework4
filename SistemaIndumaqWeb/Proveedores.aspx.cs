using DataDB.Models;
using DataDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaIndumaqWeb
{
    public partial class Proveedores : System.Web.UI.Page
    {
        private DataTable tb = new DataTable();
        private DataRow dr;
        private bool isEdit = false;
        private List<Proveedor> selProv = new List<Proveedor>() { };
        private Datos d = new Datos();
        //private IEnumerable<Proveedor> providers;
        private IEnumerable<Proveedor> provList;
        private IEnumerable<ProviderTable> provTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                List<User> userLog = Session["User"] as List<User>;

                lblUserValue1.Text = userLog[0].alias;
                lblRolValue1.Text = userLog[0].rol;

                if (!IsPostBack)
                {
                    //Response.Redirect("Productos.aspx");
                }

            }
            else
            {
                Response.Redirect("Index.aspx");
            }
            //if (!IsPostBack)
            //{

            provList = d.GetProveedores();
            provTable = provList.Where(p => p.habilitado == true)
                .Select(p => new ProviderTable()
                {
                    nombre = p.nombre,
                    direccion = p.direccion,
                    mail = p.mail,
                    telefono = p.telefono
                });

            createtable();
            //}
            conterror.Visible = false;
        }

        public void createtable()
        {
            tb.Columns.Add("Nombre", typeof(string));
            tb.Columns.Add("Direccion", typeof(string));
            tb.Columns.Add("Mail", typeof(string));
            tb.Columns.Add("Telefono", typeof(string));

            foreach (var p in provTable)
            {
                dr = tb.NewRow();
                dr["Nombre"] = p.nombre;
                dr["Direccion"] = p.direccion;
                dr["Mail"] = p.mail;
                dr["Telefono"] = p.telefono;
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
            string nomProvider = Gv1.Rows[rowindex].Cells[1].Text;
            selProv = provList.Where(p => p.nombre.Equals(nomProvider)).ToList();
            Session["selProv"] = selProv;

            if (d.setDeleteProviderWeb(selProv[0]))
            {
                setMessage("Proveedor borrado con exito");
            }
            else
            {
                setMessage("No se puede borrar, el proveedor esta en uso");
            }

            provList = d.GetProveedores();
            provTable = provList.Where(p => p.habilitado == true)
                .Select(p => new ProviderTable()
                {
                    nombre = p.nombre,
                    direccion = p.direccion,
                    mail = p.mail,
                    telefono = p.telefono
                });

            tb = new DataTable();
            createtable();

            refreshValues();
        }

        protected void lbtnEditar_Click1(object sender, EventArgs e)
        {
            titParrafo.InnerText = "Editar proveedor seleccionado";
            btnAgregarProd.Text = "Editar";

            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string nomProvider = Gv1.Rows[rowindex].Cells[1].Text;

            selProv = provList.Where(p => p.nombre.Equals(nomProvider)).ToList();
            Session["selProv"] = selProv;
            txtNombre.Text = selProv[0].nombre;
            txtDireccion.Text = selProv[0].direccion;
            txtMail.Text = selProv[0].mail;
            txtTelefono.Text = selProv[0].telefono;

            Session["isEdit"] = true;
        }

        private void setMessage(string s)
        {
            Gv1.Enabled = false;
            txtNombre.Enabled = false;
            txtDireccion.Enabled = false;
            txtMail.Enabled = false;
            txtTelefono.Enabled = false;

            btnAgregarProd.Visible = false;
            btnLimpiar.Visible = false;
            btnCancelar.Visible = false;

            conterror.Visible = true;
            lblError.Text = s;
        }

        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (Session["isEdit"] != null)
            {
                isEdit = (bool)Session["isEdit"];
            }

            if (!isEdit)
            {
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                string mail = txtMail.Text;
                string telefono = txtTelefono.Text;

                if (provList.Where(p => p.nombre.Equals(nombre)).Count() == 0)
                {
                    d.setNewProvider(nombre,
                        direccion,
                        mail,
                        telefono);
                    setMessage("Se agrego el proveedor con exito");
                    refreshValues();

                }
                else
                {
                    txtNombre.Text = "";
                    setMessage("Él proveedor ya existe");
                }
                
            }
            else
            {
                if (Session["selProv"] != null)
                {
                    selProv = Session["selProv"] as List<Proveedor>;
                }

                selProv[0].nombre = txtNombre.Text;
                selProv[0].direccion = txtDireccion.Text;
                selProv[0].mail = txtMail.Text;
                selProv[0].telefono = txtTelefono.Text;

                d.setEditProvider(selProv[0]);
                setMessage("Se edito el proveedor con exito");
                refreshValues();
            }

            provList = d.GetProveedores();
            provTable = provList.Where(p => p.habilitado == true)
                .Select(p => new ProviderTable()
                {
                    nombre = p.nombre,
                    direccion = p.direccion,
                    mail = p.mail,
                    telefono = p.telefono
                });

            tb = new DataTable();
            createtable();

            Session["isEdit"] = false;

            titParrafo.InnerText = "Agregar nuevo proveedor";
            btnAgregarProd.Text = "Agregar";
        }

        protected void refreshValues()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            refreshValues();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            refreshValues();
            titParrafo.InnerText = "Agregar nuevo proveedor";
            btnAgregarProd.Text = "Agregar";
            Session["isEdit"] = false;
        }

        protected void btnAceptarError_Click(object sender, EventArgs e)
        {
            Gv1.Enabled = true;
            txtNombre.Enabled = true;
            txtDireccion.Enabled = true;
            txtMail.Enabled = true;
            txtTelefono.Enabled = true;
            
            btnAgregarProd.Visible = true;
            btnLimpiar.Visible = true;
            btnCancelar.Visible = true;

            conterror.Visible = false;
        }
    }
}