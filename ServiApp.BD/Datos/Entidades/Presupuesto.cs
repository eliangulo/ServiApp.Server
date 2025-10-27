using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
    public class Presupuesto : EntityBase
    {
        public required int IdNumberoMatricula { get; set; }
        public Prestador? Prestador { get; set; }  //fk

        public required int IDpresupuesto  { get; set; }
        [Required(ErrorMessage = "El campo Monto es obligatorio")]
        public required int Monto { get; set; } //en numeros
        [Required(ErrorMessage = "El campo Monto es obligatorio")]
        [MaxLength(42, ErrorMessage = "El campo tiene como máximo 42 caracteres.")]

        public required int TiempoDuracion { get; set; } //dias estimado
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo tiene como máximo 30 caracteres.")]
        public required string Detalle_materiales { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]
        
        public required DateTime FechaCreacion { get; set; }
        public required DateTime FechaVto { get; set; }

    }
}
