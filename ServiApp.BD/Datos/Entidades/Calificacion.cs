using System.ComponentModel.DataAnnotations;

namespace ServiApp.BD.Datos.Entidades
{
    public class Calificacion : EntityBase
    {   //FK
        public required int idUsuario { get; set; }
        public Usuarios? Usuarios { get; set; }
        public required int IDnumberoMatricula { get; set; }
        public Prestador? Prestador { get; set; }

        public required int IDCalificacion { get; set; }

        public required int Puntuacion { get; set; }
        [Required(ErrorMessage = "El campo Puntuacion es obligatorio")]
        [MaxLength(5, ErrorMessage = "El campo tiene como máximo 5 caracteres.")]
        public string Comentario { get; set; }
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]

        public required DateTime FechaCalificacion { get; set; }


    }
}
