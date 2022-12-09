using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Operacion
    {


        [Key]
        public int IdOperacion { get; set; }
        [Required]
        public string? OperacionName { get; set; }

        public Area? Area { get; set; }
        public int AreaId { get; set; }

        public List<Usuario>? Usuarios { get; set; }
    }
}
