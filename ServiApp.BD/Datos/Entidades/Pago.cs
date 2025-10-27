using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
    public class Pago : EntityBase
    {
        public required int IDPago { get; set; }
        public required int MontoTotal { get; set; }
        [Required(ErrorMessage = "El campo MontoTotal es obligatorio")]
        [MaxLength(42, ErrorMessage = "El campo tiene como máximo 42 caracteres.")]
        public required int Comision { get; set; } //5%
        public required string MetodoPago { get; set; }
        [Required(ErrorMessage = "El campo MetodoPago es obligatorio")]
        [MaxLength(42, ErrorMessage = "El campo tiene como máximo 42 caracteres.")]
        public required bool Estado { get; set; } //aprobado-pendiente-rechado
        public required DateTime FechaPago { get; set; }
        //FK
        public required int IDnumeroMatricula { get; set; }
        public Prestador? Prestador { get; set; }
        public required int IdUsuario{ get; set; }
        public Usuarios? Usuarios { get; set; }

    }
}
