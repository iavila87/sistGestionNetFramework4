using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Models
{
    public class SaleTable
    {
        // Propiedades
        public int nroVenta { get; set; }
        public string cliente { get; set; }
        public DateTime fecha { get; set; }
        public double total { get; set; }
    }
}
