using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataDB
{
    public class Datos
    {
        private DataClasses1DataContext data = new DataClasses1DataContext();
        

        public bool login(String user, String pass)
        {
            var usertable = data.Usuario
                .Where(u => u.alias == user 
                    && u.contrasenia == pass
                    && u.habilitado == true).ToList();

            if (usertable.Count != 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public List<User> GetUser(string userValid) {
            return data.Usuario
                    .Where(u => u.alias.Equals(userValid) && u.habilitado == true)
                    .Select(u => new User() { 
                        alias = u.alias,
                        contrasenia = u.contrasenia,
                        rol = u.Rol.nombre
                    }).ToList();
        }

        public IEnumerable<Producto> GetProductos() 
        {
            return data.Producto
                .Where(p => p.habilitado == true)
                .Select(p => p);
        }

        public IEnumerable<Proveedor> GetProveedores()
        {
            
            return data.Proveedor
                .Where(p => p.habilitado == true)
                .Select(p => p);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            return data.Cliente
                .Where(c => c.habilitado == true)
                .Select(c => c);
        }

        public IEnumerable<Venta> GetVentas()
        {
            return data.Venta
                .Select(v => v);
        }

        public IEnumerable<ProductoVenta> GetProdVentas()
        {
            return data.ProductoVenta
                .Select(v => v);
        }

        public void setNewProduct(string descripcion,
                        string codigo,
                        string stock,
                        string precio,
                        string proveedor)
        {
            Producto nuevoProducto = new Producto();
            nuevoProducto.habilitado = true;
            nuevoProducto.descripcion = descripcion;
            nuevoProducto.codigo = codigo;
            nuevoProducto.stock = Convert.ToInt32(stock);
            nuevoProducto.precio = Convert.ToDouble(precio);
            
            IEnumerable<Proveedor> provaux =
                data.Proveedor
                .Where(p => p.nombre.Equals(proveedor))
                .Select(p => p);

            nuevoProducto.Proveedor = provaux.ToList()[0];
            data.Producto.InsertOnSubmit(nuevoProducto);
            data.SubmitChanges();
        }

        public void setNewClient(string nombre, string dirección, string email, string telefono) { 
            Cliente nuevoCliente= new Cliente();
            nuevoCliente.habilitado = true;
            nuevoCliente.nombre= nombre;
            nuevoCliente.direccion= dirección;
            nuevoCliente.mail= email;
            nuevoCliente.telefono= telefono;

            data.Cliente.InsertOnSubmit(nuevoCliente);
            data.SubmitChanges();
        }

        public void setNewProvider(string nombre, string direccion, string email, string telefono)
        {
            Proveedor nuevoProveedor = new Proveedor();
            nuevoProveedor.habilitado = true;
            nuevoProveedor.nombre = nombre;
            nuevoProveedor.direccion = direccion;
            nuevoProveedor.mail = email;
            nuevoProveedor.telefono = telefono;

            data.Proveedor.InsertOnSubmit(nuevoProveedor);
            data.SubmitChanges();
        }

        public void setNewSaleProducts(ProductoVenta prodVenta)
        {
            ProductoVenta nuevoProdVenta = prodVenta;
            
            data.ProductoVenta.InsertOnSubmit(nuevoProdVenta);
            data.SubmitChanges();
        }

        public void setEditProduct(Producto prodToDB, string strProveedor)
        {
            Producto aux = data.Producto.First(prod => prod.idProducto.Equals(prodToDB.idProducto));
            aux.habilitado = true;
            aux.descripcion = prodToDB.descripcion;
            aux.codigo = prodToDB.codigo;
            aux.stock = prodToDB.stock;
            aux.precio = prodToDB.precio;

            IEnumerable<Proveedor> provaux =
                data.Proveedor
                .Where(p => p.nombre.Equals(strProveedor))
                .Select(p => p);

            aux.Proveedor = provaux.ToList()[0];

            data.SubmitChanges();
        }

        public void setUpdateProduct(List <Producto> pUpdatedList)
        {
            foreach (Producto pu in pUpdatedList) {
                Producto aux = data.Producto.First(prod => prod.idProducto.Equals(pu.idProducto));
                aux.stock = pu.stock;
                data.SubmitChanges();
            }
        }

        public void setEditProvider(Proveedor p) 
        {
            Proveedor aux= data.Proveedor.First(prov =>prov.idProveedor.Equals(p.idProveedor));
            aux.habilitado = true;
            aux.nombre = p.nombre;
            aux.direccion =p.direccion;
            aux.mail = p.mail;
            aux.telefono = p.telefono;
            data.SubmitChanges();
        }

        public void setEditClient(Cliente cl) 
        {
            Cliente aux = data.Cliente.First(cli => cli.idCliente.Equals(cl.idCliente));
            aux.habilitado = true;
            aux.nombre = cl.nombre;
            aux.direccion = cl.direccion;
            aux.mail = cl.mail;
            aux.telefono = cl.telefono;
            data.SubmitChanges();
        }

        public void setDeleteProvider(Proveedor p)
        {
            try 
            { 
                Proveedor aux = data.Proveedor.First(pv => pv.idProveedor.Equals(p.idProveedor));
                data.Proveedor.DeleteOnSubmit(aux);
                data.SubmitChanges();
            }
            catch (Exception e) {
                Console.WriteLine("Error:" + e);
                MessageBox.Show("Él proveedor no puede ser eliminado.\nEsta siendo utilizado.",
                    "Borrar", MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }

        public bool setDeleteProviderWeb(Proveedor p)
        {
            try
            {
                Proveedor aux = data.Proveedor.First(pv => pv.idProveedor.Equals(p.idProveedor));
                data.Proveedor.DeleteOnSubmit(aux);
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void setDeleteClient(Cliente c)
        {
            try
            {
                Cliente aux = data.Cliente.First(cl => cl.idCliente.Equals(c.idCliente));
                data.Cliente.DeleteOnSubmit(aux);
                data.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e);
                MessageBox.Show("Él cliente no puede ser eliminado.\nEsta siendo utilizado.",
                    "Borrar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
        }

        public bool setDeleteClientWeb(Cliente c)
        {
            try
            {
                Cliente aux = data.Cliente.First(cl => cl.idCliente.Equals(c.idCliente));
                data.Cliente.DeleteOnSubmit(aux);
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void setDeleteProduct(Producto p) {
            try
            {
                Producto aux = data.Producto.First(pr => pr.idProducto.Equals(p.idProducto));
                data.Producto.DeleteOnSubmit(aux);
                data.SubmitChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e);
                MessageBox.Show("Él producto no puede ser eliminado.\nEsta siendo utilizado.",
                    "Borrar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public bool setDeleteProductWeb(Producto p)
        {
            try
            {
                Producto aux = data.Producto.First(pr => pr.idProducto.Equals(p.idProducto));
                data.Producto.DeleteOnSubmit(aux);
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void setDeleteSale(Venta v)
        {
            try
            {
                foreach (ProductoVenta pv in GetProdVentas())
                {
                    if (pv.idVenta.Equals(v.idVenta))
                    {
                        data.ProductoVenta.DeleteOnSubmit(pv);
                        data.SubmitChanges();
                    }
                }

                Venta aux = data.Venta.First(venta => venta.idVenta.Equals(v.idVenta));
                data.Venta.DeleteOnSubmit(aux);
                data.SubmitChanges();
                MessageBox.Show("La venta se ha eliminado con éxito.",
                    "Borrar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch( Exception e) {
                Console.WriteLine("Error:" + e);
                MessageBox.Show("La venta no puede ser eliminada.\nTiene productos asociados.",
                    "Borrar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        public bool setDeleteSaleWeb(Venta v)
        {
            try
            {
                foreach (ProductoVenta pv in GetProdVentas())
                {
                    if (pv.idVenta.Equals(v.idVenta))

                    {
                        data.ProductoVenta.DeleteOnSubmit(pv);
                        data.SubmitChanges();
                    }
                }
                Venta aux = data.Venta.First(venta => venta.idVenta.Equals(v.idVenta));
                data.Venta.DeleteOnSubmit(aux);
                data.SubmitChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /*
        public IEnumerable SearchOn(string word, int table)
        {
            word= word.Trim();
            switch (table)
            {
                case 1:
                    if (word.Equals(""))
                    {
                        return GetProductos()
                            .Select(p => new ProductTable()
                            {
                                codigo = p.codigo,
                                descripcion = p.descripcion,
                                stock = p.stock,
                                precio = p.precio,
                                proveedor = p.Proveedor.nombre
                            }); ;
                    }
                    else
                    {
                        return data.Producto
                            .Where(p => (p.habilitado == true) && (p.descripcion.Contains(word) || p.codigo.Contains(word)))
                            .Select(p => new ProductTable()
                            {
                                codigo = p.codigo,
                                descripcion = p.descripcion,
                                stock = p.stock,
                                precio = p.precio,
                                proveedor = p.Proveedor.nombre
                            });
                           
                    }
                case 2:
                    if (word.Equals(""))
                    {
                        return GetProveedores()
                            .Select(p => new ProviderTable()
                            {
                                nombre = p.nombre,
                                direccion = p.direccion,
                                mail = p.mail,
                                telefono = p.telefono
                            });
                    }
                    else
                    {
                        return data.Proveedor
                            .Where(p => (p.habilitado == true) && p.nombre.Contains(word))
                            .Select(p => new ProviderTable()
                            {
                                nombre = p.nombre,
                                direccion = p.direccion,
                                mail = p.mail,
                                telefono = p.telefono
                            });
                    }
                case 3:
                    if (word.Equals(""))
                    {
                        return GetClientes()
                            .Select(p => new ClientTable()
                            {
                                nombre = p.nombre,
                                direccion = p.direccion,
                                mail = p.mail,
                                telefono = p.telefono
                            });

                    }
                    else
                    {
                        return data.Cliente
                           .Where(p => (p.habilitado == true) && p.nombre.Contains(word))
                           .Select(p => new ClientTable()
                           {
                               nombre = p.nombre,
                               direccion = p.direccion,
                               mail = p.mail,
                               telefono = p.telefono
                           });
                    }

                default: return null;


            }
        }
        */
    }
}
