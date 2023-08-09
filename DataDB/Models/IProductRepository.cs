using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Models
{
    public interface IProductRepository
    {
        void add(ProductTable p);
        void update(ProductTable p);
        void delete(int id);
        /*IEnumerable<ProductTable> GetAll();
        IEnumerable<ProductTable> GetByValue(string s);*/
    }
}
