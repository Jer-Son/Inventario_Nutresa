using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using IndexAttribute = Microsoft.EntityFrameworkCore.IndexAttribute;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    [Index(nameof(Serial), IsUnique = true)]
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }
        [Required]
        [StringLength(50)]
        public string? NombreMaquina { get; set; }
        public string? Modelo { get; set; }
        public string? Serial { get; set; }
        public string? Marca { get; set; }
        public string? Procesador { get; set; }
        
        public int? Ram { get; set; }

        public string? Referencia { get; set; }
        public int? Disco { get; set; }
        public string? Tipo { get; set; }

        public Contrato? Contrato { get; set; }
        public int ContratoId { get; set; }

    }
}
