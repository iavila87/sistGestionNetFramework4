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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SistemaIndumaq.Resources.Vistas
{
    public partial class FormVentas : Form
    {
        
        private Datos d = new Datos();
        private BindingSource saleProductTableBS = new BindingSource();
        private BindingSource saleTableBS = new BindingSource();
        private BindingSource idSaleProdTableBS = new BindingSource();
        private List<SaleProductTable> idSaleProdTable;
        private IEnumerable<Producto> products;
        private IEnumerable<Cliente> clients;
        private IEnumerable<Venta> sales;
        private IEnumerable<SaleProductTable> saleProdTable;
        private List<SaleProductTable> saleProdTable2;
        private IEnumerable<SaleTable> saleTable;
        private IEnumerable<ProductoVenta> prodsales;
        private Producto productSel;
        private Cliente clientSel;
        private int primera = 0;
        private Venta saleToDB;
        private List<Producto> productsUpdated = new List<Producto> { };

        public FormVentas()
        {
            InitializeComponent();
            // Ocultamos la pestaña editar
            tabVentas.TabPages.Remove(tabEditar);
            tabVentas.TabPages.Remove(tabDetalle);
            // Cargamos el combobox con los datos de productos
            products = d.GetProductos();
            foreach (Producto p in products)
            {
                cbProducto.Items.Add(p.descripcion);
            }
            // Cargamos el combobox con los datos de clientes
            clients = d.GetClientes();
            foreach (Cliente c in clients)
            {
                cbCliente.Items.Add(c.nombre);
            }
            // enalazamos la tabla con el bindingsource
            dgvProductoVentas.DataSource = saleProductTableBS;

            sales = d.GetVentas();

            prodsales = d.GetProdVentas();

            saleTable = sales.Select(s =>

                new SaleTable()
                {
                    nroVenta = s.idVenta,
                    cliente = s.Cliente.nombre,
                    fecha = s.fecha,
                    total = prodsales.Where(sp => sp.idVenta == s.idVenta)
                                    .Select(ps => ps.subtotal).Sum()
                }
            );
            saleTableBS.DataSource = saleTable;
            dgvVentas.DataSource = saleTableBS;

            cbProducto.Enabled = false;
            txtCantidad.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabVentas.TabPages.Remove(tabCatalogo);
            tabVentas.TabPages.Remove(tabDetalle);
            tabVentas.TabPages.Add(tabEditar);
            tabEditar.Text = "Agregar";
            txtId.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void limpiarCampos()
        {
            txtId.Enabled = true;
            txtId.Text = "";
            cbCliente.SelectedIndex = -1;
            cbCliente.Text = "- Seleccione -";
            //cbCliente.Items.Clear();

            cbProducto.SelectedIndex = -1;
            cbProducto.Text = "- Seleccione -";
            //cbProducto.Items.Clear();

            lblStockNumber.Text = "";
            txtCantidad.Text = "";

            cbCliente.Enabled = true;
        }

        private void resetProductos()
        {
            cbProducto.SelectedIndex = -1;
            cbProducto.Text = "- Seleccione -";
            
            lblStockNumber.Text = "";
            txtCantidad.Text = "";

            txtCantidad.Enabled = false;
        }

        private void cbCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string cliente = cbCliente.SelectedItem.ToString();
            foreach (Cliente c in clients) 
            {
                if (cliente.Equals(c.nombre)) 
                {
                    clientSel = c;
                }
            }

            cbCliente.Enabled = false;
            cbProducto.Enabled = true;
        }

        private void cbProducto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string producto = cbProducto.SelectedItem.ToString();
            foreach (Producto p in products)
            {
                if (producto.Equals(p.descripcion))
                {
                    productSel = p;
                }
            }

            lblStockNumber.Text = productSel.stock.ToString();
            txtCantidad.Enabled = true;
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (!txtCantidad.Text.Equals(""))
            {
                if (Convert.ToInt32(txtCantidad.Text) > 0 && productSel.stock >= Convert.ToInt32(txtCantidad.Text))
                {
                    if (primera == 0)
                    {
                        saleProdTable = (products.Where(p => p.descripcion.Equals(productSel.descripcion))
                           .Select(p => new SaleProductTable()
                           {
                               cantidad = Convert.ToInt32(txtCantidad.Text),
                               producto = productSel.descripcion,
                               precio = productSel.precio,
                               subtotal = productSel.precio * Convert.ToInt32(txtCantidad.Text)
                           })).ToList();
                        primera++;
                    }
                    else
                    {
                        saleProdTable2 = (products.Where(p => p.descripcion.Equals(productSel.descripcion))
                           .Select(p => new SaleProductTable()
                           {
                               cantidad = Convert.ToInt32(txtCantidad.Text),
                               producto = productSel.descripcion,
                               precio = productSel.precio,
                               subtotal = productSel.precio * Convert.ToInt32(txtCantidad.Text)
                           })).ToList();
                        saleProdTable = saleProdTable.Concat(saleProdTable2);
                    }

                    foreach (Producto p in products) {
                        if (productSel.idProducto.Equals(p.idProducto))
                        {
                            p.stock -= Convert.ToInt32(txtCantidad.Text);
                            lblStockNumber.Text= p.stock.ToString();
                            productsUpdated.Add(p);
                        }
                    }

                    d.setUpdateProduct(productsUpdated);

                    saleProductTableBS.DataSource = saleProdTable;
                    
                    resetProductos();

                }
                else 
                {
                    MessageBox.Show("Ingrese una cantidad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show("Ingrese una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            Venta venta = new Venta();
            venta.Cliente = clientSel;
            venta.fecha = DateTime.Today;

            var prodList = saleProdTable;

            foreach (SaleProductTable s in prodList) 
            {
                ProductoVenta productoVenta = new ProductoVenta();
                productoVenta.Producto = products.Where(p => p.descripcion.Equals(s.producto)).ToList().First();
                productoVenta.cantidad = s.cantidad;
                productoVenta.subtotal = s.subtotal;
                productoVenta.Venta = venta;

                d.setNewSaleProducts(productoVenta);
            }

            MessageBox.Show("La venta se ha agregado con éxito", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tabVentas.TabPages.Remove(tabEditar);
            tabVentas.TabPages.Remove(tabDetalle);
            tabVentas.TabPages.Add(tabCatalogo);
            
            productsUpdated.Clear();
            saleProdTable = saleProdTable.Where(p => false);
            saleProductTableBS.DataSource = saleProdTable;

            limpiarCampos();
            txtCantidad.Enabled = false;
            cbProducto.Enabled = false;

            //actualizo tabla
            sales = d.GetVentas();

            prodsales = d.GetProdVentas();

            saleTable = sales.Select(s =>

                new SaleTable()
                {
                    nroVenta = s.idVenta,
                    cliente = s.Cliente.nombre,
                    fecha = s.fecha,
                    total = prodsales.Where(sp => sp.idVenta == s.idVenta)
                                    .Select(ps => ps.subtotal).Sum()
                }
            );
            saleTableBS.DataSource = saleTable;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            saleTableBS.DataSource = saleTable
                .Where(s => (s.nroVenta.ToString().Contains(txtBuscar.Text) || s.cliente.Contains(txtBuscar.Text)));

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            saleTableBS.DataSource = saleTable
                .Where(s => (s.nroVenta.ToString().Contains(txtBuscar.Text) || s.cliente.Contains(txtBuscar.Text)));

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que desea borrar?", "Borrar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                tabVentas.TabPages.Remove(tabEditar);
                tabVentas.TabPages.Remove(tabDetalle);

                var salesCurrent = (SaleTable)saleTableBS.Current;

                foreach (Venta v in sales)
                {
                    if (v.idVenta.Equals(salesCurrent.nroVenta))
                    {
                        saleToDB = v;
                    }
                }

                d.setDeleteSale(saleToDB);
                // actualizamos la tabla
                sales = d.GetVentas();

                prodsales = d.GetProdVentas();

                saleTable = sales.Select(s =>

                    new SaleTable()
                    {
                        nroVenta = s.idVenta,
                        cliente = s.Cliente.nombre,
                        fecha = s.fecha,
                        total = prodsales.Where(sp => sp.idVenta == s.idVenta)
                                        .Select(ps => ps.subtotal).Sum()
                    }
                );
                saleTableBS.DataSource = saleTable;
                //

            }
        }

        private void btnBorrarProd_Click(object sender, EventArgs e)
        {
            var saleProductCurrent = (SaleProductTable)saleProductTableBS.Current;
            foreach (Producto p in products) 
            {
                if (p.descripcion.Equals(saleProductCurrent.producto)) 
                {
                    p.stock += saleProductCurrent.cantidad;
                }
            }
            /*foreach (Producto p in productsUpdated) 
            {
                if (p.descripcion.Equals(saleProductCurrent.producto))
                {
                    productsUpdated.Remove(p);
                }
            }*/
            var itemremove = productsUpdated.Single(r => r.descripcion.Equals(saleProductCurrent.producto));
            productsUpdated.Remove(itemremove);
            saleProdTable = saleProdTable.Where(p => !saleProductCurrent.producto.Equals(p.producto));
            saleProductTableBS.DataSource = saleProdTable;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            tabVentas.TabPages.Remove(tabEditar);
            tabVentas.TabPages.Remove(tabDetalle);
            tabVentas.TabPages.Add(tabCatalogo);
            limpiarCampos();
            txtCantidad.Enabled = false;
            cbProducto.Enabled = false;
            productsUpdated.Clear();
            saleProdTable = saleProdTable.Where(p => false);
            saleProductTableBS.DataSource = saleProdTable;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            tabVentas.TabPages.Remove(tabCatalogo);
            tabVentas.TabPages.Remove(tabEditar);
            tabVentas.TabPages.Add(tabDetalle);

            var salesCurrent = (SaleTable)saleTableBS.Current;

            
                    lblIdVentaValue.Text = salesCurrent.nroVenta.ToString();
                    lblClienteVValue.Text = salesCurrent.cliente;
                    lblFechaVValue.Text = salesCurrent.fecha.ToShortDateString();
                    lblTotalVValue.Text = salesCurrent.total.ToString();

                    List<ProductoVenta> prodsales = d.GetProdVentas().ToList();

                    idSaleProdTable = prodsales
                        .Where(sp => sp.idVenta.Equals(Convert.ToInt32(salesCurrent.nroVenta)))
                        .Select(s => new SaleProductTable()
                        {
                            cantidad = s.cantidad,
                            producto = s.Producto.descripcion,
                            precio = s.Producto.precio,
                            subtotal = s.subtotal,
                        }).ToList();
        

                    idSaleProdTableBS.DataSource = idSaleProdTable;
                    dgvProductoVentasV.DataSource = idSaleProdTableBS;
       
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            tabVentas.TabPages.Add(tabCatalogo);
            tabVentas.TabPages.Remove(tabEditar);
            tabVentas.TabPages.Remove(tabDetalle);
        }
    }
}
