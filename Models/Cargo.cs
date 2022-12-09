using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }
        [Required]
        public string? NameCargo { get; set; }

        public List<Usuario>? Usuarios { get; set; }

    }
}
