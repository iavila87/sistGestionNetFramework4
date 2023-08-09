using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaIndumaqWeb
{
    public partial class Main1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                List<User> userLog = Session["User"] as List<User>;

                lblUserValue.Text = userLog[0].alias;
                lblRolValue.Text = userLog[0].rol;

                if (!IsPostBack)
                {
                    
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
    }
}