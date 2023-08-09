using DataDB;
using DataDB.Models;
using SistemaIndumaq.Resources.Vistas;
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

namespace SistemaIndumaq
{
    public partial class FormProductos : Form
    {
        private bool isEdit;
        private Datos d = new Datos();
        private BindingSource productTableBS= new BindingSource();
        private IEnumerable<Producto> prodList;
        private IEnumerable<ProductTable> prodTable;
        private IEnumerable<Proveedor> providers;
        private Producto prodToDB;

        public FormProductos()
        {
            InitializeComponent();
            tabProductos.TabPages.Remove(tabEditar);
            prodList = d.GetProductos();
            prodTable = prodList.Where (p => p.habilitado ==true)
                .Select(p => new ProductTable ()
                { codigo = p.codigo,
                    descripcion = p.descripcion,
                    stock = p.stock,
                    precio = p.precio,
                    proveedor = p.Proveedor.nombre });
            productTableBS.DataSource = prodTable;
            dgvProducto.DataSource = productTableBS;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void limpiarCampos()
        {
            txtId.Enabled = true;
            txtId.Text = "";
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            cbProveedor.SelectedIndex = -1;
            cbProveedor.Text = "- Seleccione -";
            cbProveedor.Items.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabProductos.TabPages.Remove(tabCatalogo);
            tabProductos.TabPages.Add(tabEditar);
            tabEditar.Text = "Agregar";
            txtId.Enabled = false;
            /** Cargamos el nombre de los proveedores en el combobox. */
            providers = d.GetProveedores();
            foreach (Proveedor p in providers) 
            { 
                cbProveedor.Items.Add(p.nombre);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Referido al botón agregar
            if (!isEdit)
            {
                string descripcion = txtDescripcion.Text;
                string codigo = txtCodigo.Text;
                string stock = txtStock.Text;
                string precio = txtPrecio.Text;
                string proveedor = cbProveedor.SelectedItem.ToString();

                if (prodList.Where(p => p.codigo.Equals(codigo)).Count() == 0)
                {
                    d.setNewProduct(descripcion,
                        codigo,
                        stock,
                        precio,
                        proveedor);
                    MessageBox.Show("Él producto se ha agregado con éxito", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                    tabProductos.TabPages.Remove(tabEditar);
                    tabProductos.TabPages.Add(tabCatalogo);

                }
                else 
                {
                    txtCodigo.Text = "";
                    MessageBox.Show("Él codigo ya existe", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }
            else
            {
                // Referido al botón editar
                prodToDB.descripcion = txtDescripcion.Text;
                prodToDB.codigo = txtCodigo.Text;
                prodToDB.stock = Convert.ToInt32(txtStock.Text);
                prodToDB.precio = Convert.ToDouble(txtPrecio.Text);
                string strProveedor = cbProveedor.SelectedItem.ToString();
                d.setEditProduct(prodToDB, strProveedor);
                MessageBox.Show("Él producto se ha editado con éxito", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
                tabProductos.TabPages.Remove(tabEditar);
                tabProductos.TabPages.Add(tabCatalogo);
                
            }

            // actualizamos la tabla
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
            productTableBS.DataSource = prodTable;

            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            isEdit = true;
            tabProductos.TabPages.Remove(tabCatalogo);
            tabProductos.TabPages.Add(tabEditar);
            tabEditar.Text = "Editar";

            var product = (ProductTable)productTableBS.Current;
            txtDescripcion.Text = product.descripcion;
            txtCodigo.Text = product.codigo;
            txtStock.Text = product.stock.ToString();
            txtPrecio.Text = product.precio.ToString();
            providers = d.GetProveedores();
            foreach (Producto p in prodList)
            {
                if (p.codigo.Equals(product.codigo))
                {
                    prodToDB = p;
                }
            }

            foreach (Proveedor p in providers)
            {
                cbProveedor.Items.Add(p.nombre);
            }

            cbProveedor.SelectedItem = product.proveedor;

            txtId.Text = prodToDB.idProducto.ToString();
            txtId.Enabled = false;
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea borrar?", "Borrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabProductos.TabPages.Remove(tabEditar);

                var product = (ProductTable)productTableBS.Current;

                foreach (Producto p in prodList)
                {
                    if (p.codigo.Equals(product.codigo))
                    {
                        prodToDB = p;
                    }
                }

                d.setDeleteProduct(prodToDB);
                // actualizamos la tabla
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
                productTableBS.DataSource = prodTable;
                //
                
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //productTableBS.DataSource = d.SearchOn(txtBuscar.Text,1);
                productTableBS.DataSource = prodTable
                .Where(p => (p.descripcion.Contains(txtBuscar.Text) || p.codigo.Contains(txtBuscar.Text)));

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            productTableBS.DataSource = prodTable
                .Where(p => (p.descripcion.Contains(txtBuscar.Text) || p.codigo.Contains(txtBuscar.Text)));

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //productTableBS.DataSource = d.SearchOn(txtBuscar.Text, 1);
            productTableBS.DataSource = prodTable
                .Where(p => (p.descripcion.Contains(txtBuscar.Text) || p.codigo.Contains(txtBuscar.Text)));

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            tabProductos.TabPages.Remove(tabEditar);
            tabProductos.TabPages.Add(tabCatalogo);
        }
    }
}
