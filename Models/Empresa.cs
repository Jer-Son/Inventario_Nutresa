using System.ComponentModel.DataAnnotations;

namespace Sitio_Web_Core_MVC_CRUD_EF.Models
{
    public class Empresa
    {

        [Key]
        public int IdEmpresa { get; set; } 

        public String? Nombre { get; set; }  

        public String? Responsable { get; set; }

        public virtual List<Sede>? Sedes { get; set; }

    }
}
