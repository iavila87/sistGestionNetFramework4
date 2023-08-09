using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Models
{
    public class SaleProductTable
    {
        // Propiedades
        public int cantidad { get; set; }
        public string producto { get; set; }
        public double precio { get; set; }
        public double subtotal { get; set; }
        
    }
}
