using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiApp.BD.Datos.Entidades
{
    public class Prestador : EntityBase
    {
        public required int IdNumberoMatricula { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo tiene como máximo 50 caracteres.")]
        public required string NombrePrestador { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo tiene como máximo 50 caracteres.")]
        public required string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "El campo Password es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]
        public required string Password { get; set; }

        public List<PrestadorServicio> PrestadorServicios { get; set; } = [];
    }
}
