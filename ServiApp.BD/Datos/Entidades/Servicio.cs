using System;
using System.ComponentModel.DataAnnotations;

namespace ServiApp.BD.Datos.Entidades
{
    public class ServicioEnti : EntityBase
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        [MaxLength(500, ErrorMessage = "El campo tiene como máximo 500 caracteres.")] 
        public required string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo NombrePrestador es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo tiene como máximo 200 caracteres.")] 
        public required string NombrePrestador { get; set; }

        [Required(ErrorMessage = "El campo Ubicacion es obligatorio")]
        [MaxLength(200, ErrorMessage = "El campo tiene como máximo 200 caracteres.")] 
        public required string Ubicacion { get; set; } 

        public decimal PrecioBase { get; set; }

        // FK
        public required int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
    }
}