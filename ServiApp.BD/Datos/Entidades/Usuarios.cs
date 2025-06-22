using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace ServiApp.BD.Datos.Entidades
{
    public class Usuarios : EntityBase
    {
        
       
        public required string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(42, ErrorMessage = "El campo tiene como máximo 42 caracteres.")]
        public required string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [MaxLength(42, ErrorMessage = "El campo tiene como máximo 42 caracteres.")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [MaxLength(64, ErrorMessage = "El campo tiene como máximo 64 caracteres.")]

        public required DateTime FechaRegistroUsuario { get; set; }


    }
}