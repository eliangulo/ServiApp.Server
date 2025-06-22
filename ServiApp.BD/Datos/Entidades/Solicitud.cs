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
        public required int IdPrestador { get; set; }
        public Prestador? Prestador { get; set; }
        public required int IdServico { get; set; }
        public Servico? Servicio { get; set; }

        public required int IDSolicitud { get; set; }
        [Required(ErrorMessage = "El codigo es obligatorio")]
        [MaxLength(4, ErrorMessage = "El campo tiene como máximo {4} caracteres.")]
      
        public required string descripcion { get; set; }
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo {100} caracteres.")]
        public required bool Estado { get; set; }
        public required DateTime Fecha_solicitud { get; set; }

    }
}
