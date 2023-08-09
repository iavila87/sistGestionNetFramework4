using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDB.Models
{
    public class ProductTable
    {
        // Propiedades
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public double precio { get; set; }
        public string proveedor { get; set; }
    }
}
