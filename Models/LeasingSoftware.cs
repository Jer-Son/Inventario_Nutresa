using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class LeasingSoftware
    {
        [Key]
        public int IdLeasingSoftware { get; set; }
        public Software? Software { get; set; }
        public int SoftwareId { get; set; }
        public Leasing? Leasing { get; set; }
        public int LeasingId { get; set; }
    }
}
