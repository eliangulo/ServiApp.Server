using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{    public class Categoria : EntityBase
    {
        public required int IdCategoria { get; set; }
        public required string nombre_categoria { get; set; }
        [Required(ErrorMessage = "El campo nombre categoria es obligatorio")]
       
        public required string descripcion { get; set; }
       
    }

}
