using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DataDB;
using DataDB.Models;

namespace SistemaIndumaq
{
    public partial class FormLogin : Form
    {
        Datos d = new Datos();

        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "Usuario")
            {
                if (txtPass.Text != "Contraseña")
                {
                    if (d.login(txtUser.Text, txtPass.Text))
                    {
                        Console.WriteLine("Usuario y contrseña ok");
                        List<User> userAux = d.GetUser(txtUser.Text);
                        FormMain frmMain = new FormMain();
                        frmMain.lblUser.Text = userAux[0].alias;
                        frmMain.lblRol.Text = userAux[0].rol;
                        frmMain.Show();
                        // sobre cargamos el evento formClosed del main con con logout
                        frmMain.FormClosed += Logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o Contraseña invalido");
                        txtUser.Focus();
                        txtPass.Text = "Contraseña";
                        Console.WriteLine("Usuario y contrseña error");
                    }
                }
                else 
                {
                    msgError("Ingrese una contraseña por favor");
                }
            }
            else
            {
                msgError("Ingrese un usuario por favor");
            }
    
        }

        private void Logout(object sender, FormClosedEventArgs e) {
            txtUser.Text = "Usuario";
            txtPass.Text = "Contraseña";
            txtPass.UseSystemPasswordChar = false;
            lblLError.Visible = false;
            this.Show();
            
        }

        private void msgError(string msg) 
        {
            lblLError.Text = msg;
            lblLError.Visible = true;
        }
    }
}
