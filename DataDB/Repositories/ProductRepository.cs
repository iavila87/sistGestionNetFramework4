using DataDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DataClasses1DataContext data;

        public ProductRepository()
        {
            data = new DataClasses1DataContext();
        }

        public void add(ProductTable p)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        /*public IEnumerable<ProductTable> GetAll()
        {
            var productList = (from p in data.Producto
                               join pv in data.Proveedor on p.idProveedor equals pv.idProveedor
                               select new ProductTable()
                               {
                                   ID = p.idProducto,
                                   codigo = p.codigo,
                                   descripcion = p.descripcion,
                                   stock = p.stock,
                                   precio = p.precio,
                                   habilitado = p.habilitado,
                                   proveedor = p.Proveedor

                               });
            return productList;
        }*/

        /*public IEnumerable<ProductTable> GetByValue(string s)
        {
            var productList = data.Producto
                                .Where(p => p.descripcion == s 
                                || p.codigo == s)
                                .Select (pdt => new ProductTable()
                                {
                                    ID = pdt.idProducto,
                                    codigo = pdt.codigo,
                                    descripcion = pdt.descripcion,
                                    stock = pdt.stock,
                                    precio = pdt.precio,
                                    habilitado = pdt.habilitado,
                                    proveedor = pdt.Proveedor

                                });

            return productList;
        }*/

        public void update(ProductTable p)
        {
            throw new NotImplementedException();
        }
    }
}
