using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataDB;
using DataDB.Models;

namespace SistemaIndumaqWeb
{
    public partial class Index : System.Web.UI.Page
    {
        Datos d = new Datos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "")
            {
                if (txtPass.Text != "")
                {
                    if (d.login(txtUser.Text, txtPass.Text))
                    {
                        // creamos una sesion para identificar que heos iniciado sesion
                        Session["User"] = d.GetUser(txtUser.Text);
                        Response.Redirect("Main.aspx");
                        /*List<User> userAux = d.GetUser(txtUser.Text);
                        FormMain frmMain = new FormMain();
                        frmMain.lblUser.Text = userAux[0].alias;
                        frmMain.lblRol.Text = userAux[0].rol;
                        frmMain.Show();
                        // sobre cargamos el evento formClosed del main con con logout
                        frmMain.FormClosed += Logout;
                        this.Hide();*/
                    }
                    else
                    {
                        lblError.Text = "Usuario o Contraseña invalido";
                        /*msgError("Usuario o Contraseña invalido");
                        txtUser.Focus();
                        txtPass.Text = "Contraseña";*/
                        Console.WriteLine("Usuario y contrseña error");
                    }
                }
                else
                {
                    lblError.Text = "Ingrese una contraseña por favor";
                    /*msgError("Ingrese una contraseña por favor");*/
                }
            }
            else
            {
                lblError.Text = "Ingrese un usuario por favor";
                /*msgError("Ingrese un usuario por favor");*/
            }
        }
    }
}