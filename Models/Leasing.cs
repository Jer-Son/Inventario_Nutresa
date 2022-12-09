using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Leasing
    {
        [Key]
        public int IdLeasing { get; set; }
        public string? Analista { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "fecha inicio")]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "fecha final")]
        public DateTime FechaFinal { get; set; }

        public string? Propiedad { get; set; }
        
        public Boolean? Estado { get; set; }

        public string? UsuarioRed { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "fecha leasing")]
        public DateTime Fecha { get; set; }
        public string? Observacion { get; set; }

        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Equipo? Equipo { get; set; }
        public int EquipoId { get; set; }
        public List<LeasingPerifericos>? LeasingPeriferico { get; set; }
        public List<LeasingSoftware>? LeasingSoftware { get; set; }
    }
}
