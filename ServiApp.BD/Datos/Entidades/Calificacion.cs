using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
    public class Calificacion : EntityBase
    {   //FK
        public required int IdSolicitud { get; set; }
        public Solicitud? Solicitud { get; set; }

        public required int IDCalificacion { get; set; }
        
        public required int Puntuacion { get; set; }
        [Required(ErrorMessage = "El campo Puntuacion es obligatorio")]
        [MaxLength(5, ErrorMessage = "El campo tiene como máximo 5 caracteres.")]
        public  string Comentario { get; set; }
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]

        public required DateTime FechaCalificacion{ get; set; }


    }
}
