using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaIndumaqWeb
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["isEdit"] = false;

            if (Session["User"] != null)
            {
                List<User> userLog = Session["User"] as List<User>;

                lblUserValue1.Text = userLog[0].alias;
                lblRolValue1.Text = userLog[0].rol;

                if (!IsPostBack) {
                    //Response.Redirect("Main.aspx");
                }
                
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("User");
            Response.Redirect("Index.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            //mvMain.SetActiveView(vwProductos);
            
        }

        protected void btnProveedores_Click(object sender, EventArgs e)
        {
            //mvMain.SetActiveView(vwProveedores);
        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            //mvMain.SetActiveView(vwClientes);
        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            //mvMain.SetActiveView(vwVentas);
        }
    }
}