using DataDB;
using DataDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndumaq
{
    public partial class FormClientes : Form
    {
        private Datos d = new Datos();
        private BindingSource clientTableBS = new BindingSource();
        private IEnumerable<Cliente> clientList;
        private IEnumerable<ClientTable> clientTable;
        private bool isEdit = false;
        private Cliente cliToDB;

        public FormClientes()
        {
            InitializeComponent();
            tabClientes.TabPages.Remove(tabEditar);
            clientList = d.GetClientes();
            clientTable = clientList.Where(p => p.habilitado == true)
                .Select(p => new ClientTable()
                {
                    nombre = p.nombre,
                    direccion = p.direccion,
                    mail = p.mail,
                    telefono = p.telefono
                });
            clientTableBS.DataSource = clientTable;
            dgvCliente.DataSource = clientTableBS;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void limpiarCampos()
        {
            txtId.Enabled = true;
            txtId.Text = "";
            txtNombre.Text = "";
            txtDir.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabClientes.TabPages.Remove(Catalogo);
            tabClientes.TabPages.Add(tabEditar);
            tabEditar.Text = "Agregar";
            txtId.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Referido al botón agregar
            if (!isEdit)
            {
                string nombre = txtNombre.Text;
                string dirección = txtDir.Text;
                string email = txtEmail.Text;
                string telefono = txtTel.Text;

                if (clientList.Where(p => p.nombre.Equals(nombre)).Count() == 0)
                {
                    d.setNewClient(nombre, dirección, email, telefono);
                    MessageBox.Show("Él cliente se ha agregado con éxito", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    tabClientes.TabPages.Remove(tabEditar);
                    tabClientes.TabPages.Add(Catalogo);

                }
                else
                {
                    txtNombre.Text = "";
                    MessageBox.Show("Él cliente ya existe", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                // Referido al botón editar
                cliToDB.direccion = txtDir.Text;
                cliToDB.nombre = txtNombre.Text;
                cliToDB.mail = txtEmail.Text;
                cliToDB.telefono = txtTel.Text;
                d.setEditClient(cliToDB);
                MessageBox.Show("Él cliente se ha editado con éxito", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
                tabClientes.TabPages.Remove(tabEditar);
                tabClientes.TabPages.Add(Catalogo);

            }
            // actualizamos la tabla
            clientList = d.GetClientes();
            clientTable = clientList.Where(p => p.habilitado == true)
                .Select(p => new ClientTable()
                {
                    nombre = p.nombre,
                    direccion = p.direccion,
                    mail = p.mail,
                    telefono = p.telefono
                });
            clientTableBS.DataSource = clientTable;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            isEdit = true;
            tabClientes.TabPages.Remove(Catalogo);
            tabClientes.TabPages.Add(tabEditar);
            tabEditar.Text = "Editar";

            var client = (ClientTable)clientTableBS.Current;
            txtNombre.Text = client.nombre;
            txtDir.Text = client.direccion;
            txtEmail.Text = client.mail;
            txtTel.Text = client.telefono;
            foreach (Cliente c in clientList)
            {
                if (c.nombre.Equals(client.nombre))
                {
                    cliToDB = c;
                }
            }
            txtId.Text = cliToDB.idCliente.ToString();
            txtId.Enabled = false;

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
        
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Esta seguro que desea borrar?", "Borrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                tabClientes.TabPages.Remove(tabEditar);

                var client = (ClientTable)clientTableBS.Current;

                foreach (Cliente c in clientList)
                {
                    if (c.nombre.Equals(client.nombre))
                    {
                        cliToDB = c;
                    }
                }

                d.setDeleteClient(cliToDB);

                clientList = d.GetClientes();
                clientTable = clientList.Where(p => p.habilitado == true)
                    .Select(p => new ClientTable()
                    {
                        nombre = p.nombre,
                        direccion = p.direccion,
                        mail = p.mail,
                        telefono = p.telefono
                    });
                clientTableBS.DataSource = clientTable;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //clientTableBS.DataSource = d.SearchOn(txtBuscar.Text, 3);
                clientTableBS.DataSource = clientTable
                .Where(c => (c.nombre.Contains(txtBuscar.Text)));

            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //clientTableBS.DataSource = d.SearchOn(txtBuscar.Text, 3);
            clientTableBS.DataSource = clientTable
                .Where(c => (c.nombre.Contains(txtBuscar.Text)));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //clientTableBS.DataSource = d.SearchOn(txtBuscar.Text, 3);
            clientTableBS.DataSource = clientTable
                .Where(c => (c.nombre.Contains(txtBuscar.Text)));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabClientes.TabPages.Remove(tabEditar);
            tabClientes.TabPages.Add(Catalogo);
        }
    }
}
