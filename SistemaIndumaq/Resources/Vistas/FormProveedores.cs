using DataDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DataDB.Models;
using System.Collections;

namespace SistemaIndumaq
{
    public partial class FormProveedores : Form
    {
        private Datos d = new Datos();
        private BindingSource providerTableBS = new BindingSource();
        private IEnumerable<Proveedor> provList;
        private IEnumerable<ProviderTable> provTable;
        private Proveedor provToDB;
        private bool isEdit = false;

        public FormProveedores()
        {
            InitializeComponent();
            //AssociateAndRaiseProviderViewEvent();
            tabProveedores.TabPages.Remove(tabEditar);
            provList = d.GetProveedores();
            provTable = provList.Where(p => p.habilitado == true)
                .Select(p => new ProviderTable() { 
                    nombre = p.nombre,
                    direccion= p.direccion,
                    mail= p.mail,
                    telefono = p.telefono
                });
            providerTableBS.DataSource = provTable;
            //SetProductListBindingSource(lista);
            dgvProveedor.DataSource = providerTableBS;
        }

        private void FormProveedores_Load(object sender, EventArgs e)
        {

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
            txtMail.Text = "";
            txtTel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Referido al botón agregar
            if (!isEdit)
            {
                string nombre = txtNombre.Text;
                string dirección = txtDir.Text;
                string email = txtMail.Text;
                string telefono = txtTel.Text;

                if (provList.Where(p => p.nombre.Equals(nombre)).Count() == 0)
                {
                    d.setNewProvider(nombre, dirección, email, telefono);
                    MessageBox.Show("Él proveedor se ha agregado con éxito", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    tabProveedores.TabPages.Remove(tabEditar);
                    tabProveedores.TabPages.Add(Catalogo);

                }
                else
                {
                    txtNombre.Text = "";
                    MessageBox.Show("Él proveedor ya existe", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // Referido al botón editar
                provToDB.direccion = txtDir.Text;
                provToDB.nombre = txtNombre.Text;
                provToDB.mail = txtMail.Text;
                provToDB.telefono = txtTel.Text;
                d.setEditProvider(provToDB);
                MessageBox.Show("Él proveedor se ha editado con éxito", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
                tabProveedores.TabPages.Remove(tabEditar);
                tabProveedores.TabPages.Add(Catalogo);
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
            providerTableBS.DataSource = provTable;
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            isEdit = false;
            tabProveedores.TabPages.Remove(Catalogo);
            tabProveedores.TabPages.Add(tabEditar);
            tabEditar.Text = "Agregar";
            txtId.Enabled = false;
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            isEdit = true;
            tabProveedores.TabPages.Remove(Catalogo);
            tabProveedores.TabPages.Add(tabEditar);
            tabEditar.Text = "Editar";
            
            var provider = (ProviderTable)providerTableBS.Current;
            txtNombre.Text = provider.nombre;
            txtDir.Text = provider.direccion;
            txtMail.Text = provider.mail;
            txtTel.Text = provider.telefono;
            foreach(Proveedor p in provList)
            {
                if (p.nombre.Equals(provider.nombre)) { 
                    provToDB = p;
                }
            }
            txtId.Text = provToDB.idProveedor.ToString();
            txtId.Enabled = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea borrar?", "Borrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                tabProveedores.TabPages.Remove(tabEditar);

                var provider = (ProviderTable)providerTableBS.Current;

                foreach (Proveedor p in provList)
                {
                    if (p.nombre.Equals(provider.nombre))
                    {
                        provToDB = p;
                    }
                }

                d.setDeleteProvider(provToDB);
                // recargo la lista
                provList = d.GetProveedores();
                provTable = provList.Where(p => p.habilitado == true)
                    .Select(p => new ProviderTable()
                    {
                        nombre = p.nombre,
                        direccion = p.direccion,
                        mail = p.mail,
                        telefono = p.telefono
                    });
                providerTableBS.DataSource = provTable;
            }
            



        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //providerTableBS.DataSource = d.SearchOn(txtBuscar.Text, 2);
                providerTableBS.DataSource = provTable
                .Where(p => (p.nombre.Contains(txtBuscar.Text)));
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //providerTableBS.DataSource = d.SearchOn(txtBuscar.Text, 2);
            providerTableBS.DataSource = provTable
                .Where(p => (p.nombre.Contains(txtBuscar.Text)));
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //providerTableBS.DataSource = d.SearchOn(txtBuscar.Text, 2);
            providerTableBS.DataSource = provTable
                .Where(p => (p.nombre.Contains(txtBuscar.Text)));
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabProveedores.TabPages.Remove(tabEditar);
            tabProveedores.TabPages.Add(Catalogo);
        }
    }
}
