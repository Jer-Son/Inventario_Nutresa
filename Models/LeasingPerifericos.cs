using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class LeasingPerifericos
    {
        [Key]
        public int IdLeasingPerifericos { get; set; }
        public Periferico? Periferico { get; set; }
        public int PerifericoId { get; set; }
        public Leasing? Leasing { get; set; }
        public int LeasingId { get; set; }
    }
}
