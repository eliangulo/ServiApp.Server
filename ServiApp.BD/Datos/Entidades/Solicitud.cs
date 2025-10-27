using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
    public class Solicitud : EntityBase
    {
        //FK
        public required int IdUsaurio { get; set; }
        public Usuarios? Usuarios { get; set; }

        public required int IdServicio { get; set; }

        public ServicioEnti? Servicio { get; set; }

        public required int IDSolicitud { get; set; } //PK
       
        public required string Descripcion { get; set; }
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo {100} caracteres.")]
        public required bool Estado { get; set; }
        public required DateTime Fecha_solicitud { get; set; }

    }
}
