using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    [Index(nameof(Cedula), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int Cedula { get; set; }

        public string? Name { get; set; }
        [EmailAddress]
        public String? Correo { get; set; }
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public String? celular { get; set; }
        public int? extenseion { get; set; }

        public Operacion? Operacion { get; set; }
        public int OperacionId { get; set; }
        public Sede? Sede { get; set; }
        public int SedeId { get; set; }
        public Cargo? Cargo { get; set; }
        public int CargoId { get; set; }
        
    }
}
