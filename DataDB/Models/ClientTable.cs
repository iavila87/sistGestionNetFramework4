using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace DataDB.Models
{
    public class ClientTable
    {
        
        [DisplayName("Nombre")]
        [Required(ErrorMessage ="El nombre del cliente no puede estar vacío")]
        [StringLength(30,MinimumLength =2,ErrorMessage ="El nombre del cliente debe tener entre 2 y 30 caracteres")]
        public string nombre { get; set; }
        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección no puede estar vacía")]
        public string direccion { get; set; }
        [Required (ErrorMessage ="El Email es requerido")]
        [EmailAddress(ErrorMessage ="El Email ingresado es inválido")]
        public string mail { get; set; }
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono no puede estar vacío")]
        [StringLength(20, MinimumLength = 7, ErrorMessage = "El teléfono debe tener como mínimo 7 dígitos")]
        public string telefono { get; set; }
    }
}
