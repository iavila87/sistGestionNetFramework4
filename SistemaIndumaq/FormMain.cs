using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataDB;
using SistemaIndumaq.Resources.Vistas;


namespace SistemaIndumaq
{

    public partial class FormMain : Form
    {
        //public string usuario;
        //public string rol;

        public Datos d = new Datos();

        public event EventHandler ShowProductView;
        public event EventHandler ShowProviderView;
        public event EventHandler ShowClientView;

        public FormMain()
        {
            InitializeComponent();
            //lblUser.Text = usuario;
            //lblRol.Text = rol;

            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            btnProductos.Click += delegate { ShowProductView?.Invoke(this, EventArgs.Empty); };
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);
            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<ProductCatalog> = d.GetProductos();
            //dGV.AutoGenerateColumns = false;
           
            
            //dGV.Refresh();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLout_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea cerrar sesión?", "Advertencia",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // capturamos en estas variables la posicion y la locacion de la ventana
        int lx, ly;
        int sw, sh;

        private void panelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnMaximizar.Visible=false;
            btnRestaurar.Visible= true;
        }

        

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProductos>();
            btnProductos.BackColor = Color.FromArgb(10, 60, 87);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormProveedores>();
            btnProveedores.BackColor = Color.FromArgb(10, 60, 87);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormClientes>();
            btnClientes.BackColor = Color.FromArgb(10, 60, 87);
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormVentas>();
            btnVentas.BackColor = Color.FromArgb(10, 60, 87);
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelData.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                     //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                Console.WriteLine("nombre del form:" + formulario.Name);
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelData.Controls.Add(formulario);
                panelData.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(closeForms);

                if (lblRol.Text.Equals("User")) {
                    if (formulario.Name.Equals("FormProductos"))
                    {
                        ((FormProductos)formulario).btnAgregar.Visible = false;
                        ((FormProductos)formulario).btnEditar.Visible = false;
                        ((FormProductos)formulario).btnBorrar.Visible = false;
                    }
                    else {
                        if (formulario.Name.Equals("FormProveedores"))
                        {
                            ((FormProveedores)formulario).btnAgregar.Visible = false;
                            ((FormProveedores)formulario).btnEditar.Visible = false;
                            ((FormProveedores)formulario).btnBorrar.Visible = false;
                        }
                        else {
                            if (formulario.Name.Equals("FormClientes"))
                            {
                                ((FormClientes)formulario).btnAgregar.Visible = false;
                                ((FormClientes)formulario).btnEditar.Visible = false;
                                ((FormClientes)formulario).btnBorrar.Visible = false;
                            }
                            else 
                            {
                                if (formulario.Name.Equals("FormVentas")) 
                                {
                                    ((FormVentas)formulario).btnAgregar.Visible = false;
                                    ((FormVentas)formulario).btnEditar.Visible = false;
                                    ((FormVentas)formulario).btnBorrar.Visible = false;
                                }
                            }
                        }
                    }
                }


            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void closeForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FormProductos"] == null)
            {
                btnProductos.BackColor = Color.FromArgb(4, 41, 68);
            }
            if (Application.OpenForms["FormProveedores"] == null)
            {
                btnProveedores.BackColor = Color.FromArgb(4, 41, 68);
            }
            if (Application.OpenForms["FormClientes"] == null)
            {
                btnClientes.BackColor = Color.FromArgb(4, 41, 68);
            }
        }
    }
}
