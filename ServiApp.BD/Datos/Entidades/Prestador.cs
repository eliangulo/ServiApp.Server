using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
    public class Prestador :EntityBase
    {
        public required int IDnumberoMatricula { get; set; }
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo tiene como máximo 20 caracteres.")]
        public required string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo tiene como máximo 20 caracteres.")]
        public required string Emial{ get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]
        public required string Password { get; set; }
       
    }
}
