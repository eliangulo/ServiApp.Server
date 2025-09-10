using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{    public class Categoria : EntityBase
    {     
        public required string NombreCategoria { get; set; }
        [Required(ErrorMessage = "El campo nombre categoria es obligatorio")]
        public required string Descripcion { get; set; }
        // Relación: una categoría tiene muchos servicios
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
    }

}
