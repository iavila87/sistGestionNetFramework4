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

    public partial class Clientes : System.Web.UI.Page
    {

        private DataTable tb = new DataTable();
        private DataRow dr;
        private bool isEdit = false;
        private List<Cliente> selCli = new List<Cliente>() { };
        private Datos d = new Datos();
        //private IEnumerable<Cliente> clients;
        private IEnumerable<Cliente> cliList;
        private IEnumerable<ClientTable> cliTable;

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

            cliList = d.GetClientes();
            cliTable = cliList.Where(p => p.habilitado == true)
                .Select(p => new ClientTable()
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

            foreach (var p in cliTable)
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

        protected void lbtnBorrar_Click(object sender, EventArgs e)
        {
            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string nomClient = Gv1.Rows[rowindex].Cells[1].Text;
            selCli = cliList.Where(p => p.nombre.Equals(nomClient)).ToList();
            Session["selCli"] = selCli;

            if (d.setDeleteClientWeb(selCli[0]))
            {
                setMessage("Cliente borrado con exito");
            }
            else
            {
                setMessage("No se puede borrar, el cliente esta en uso");
            }
           

            cliList = d.GetClientes();
            cliTable = cliList.Where(p => p.habilitado == true)
                .Select(p => new ClientTable()
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
            titParrafo.InnerText = "Editar cliente seleccionado";
            btnAgregarProd.Text = "Editar";

            int rowindex = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string nomClient = Gv1.Rows[rowindex].Cells[1].Text;

            selCli = cliList.Where(p => p.nombre.Equals(nomClient)).ToList();
            Session["selCli"] = selCli;
            txtNombre.Text = selCli[0].nombre;
            txtDireccion.Text = selCli[0].direccion;
            txtMail.Text = selCli[0].mail;
            txtTelefono.Text = selCli[0].telefono;

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
                string nombre = txtNombre.Text;
                string direccion = txtDireccion.Text;
                string mail = txtMail.Text;
                string telefono = txtTelefono.Text;

                if (cliList.Where(p => p.nombre.Equals(nombre)).Count() == 0)
                {
                    d.setNewClient(nombre,
                        direccion,
                        mail,
                        telefono);
                    setMessage("Se agrego el cliente con exito");
                    refreshValues();

                }
                else
                {
                    txtNombre.Text = "";
                    setMessage("Él cliente ya existe");
                }

            }
            else
            {
                if (Session["selCli"] != null)
                {
                    selCli = Session["selCli"] as List<Cliente>;
                }

                selCli[0].nombre = txtNombre.Text;
                selCli[0].direccion = txtDireccion.Text;
                selCli[0].mail = txtMail.Text;
                selCli[0].telefono = txtTelefono.Text;

                d.setEditClient(selCli[0]);
                setMessage("Se edito el cliente con exito");
                refreshValues();
            }

            cliList = d.GetClientes();
            cliTable = cliList.Where(p => p.habilitado == true)
                .Select(p => new ClientTable()
                {
                    nombre = p.nombre,
                    direccion = p.direccion,
                    mail = p.mail,
                    telefono = p.telefono
                });

            tb = new DataTable();
            createtable();

            Session["isEdit"] = false;

            titParrafo.InnerText = "Agregar nuevo cliente";
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