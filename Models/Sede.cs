using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Sede
    {
        [Key]
        public int IdSede { get; set; }
        public String? Nombre { get; set; }
        public String? Ciudad { get; set; }
        public String? ResponsableTI { get; set; }
        public String? Contacto { get; set; }
        public String?  Pa { get; set; }
        public int? OrdenInt { get; set; }
        public int? Cuenta { get; set; }

        public int EmpresaId { get; set; }

        public virtual Empresa? Empresa { get; set; }
       


        public List<Usuario>? Usuarios { get; set; }

    }
}
