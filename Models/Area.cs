
using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Area
    {
        [Key]
        public int IdArea { get; set; } 
        [Required]
        public string? AreaName { get; set; }

        public List<Operacion>? Operaciones { get; set; }
    }
}
