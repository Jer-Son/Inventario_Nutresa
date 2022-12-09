using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Contrato
    {

        [Key]
        public int IdContrato { get; set; }
        [Required]
        public string? NameContrato { get; set; }

        public List<Equipo>? Equipos { get; set; }
    }
}
