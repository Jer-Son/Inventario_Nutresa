using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Software
    {
        [Key]
        public int IdSoftware { get; set; }
        public string? SoftwareName { get; set; }
        public string? Softwarelicencia { get; set; }
        public string? SoftwareVersion { get; set; }
        public List<LeasingSoftware>? LeasingSoftware { get; set; }
    }
}
