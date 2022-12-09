using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Periferico
    {
        [Key]
        public int IdPeriferico { get; set; }
        
        public string? PerifericoName { get; set; }
        public string? Serial { get; set; }
        public List<LeasingPerifericos>? LeasingPeriferico { get; set; }
    }
}
