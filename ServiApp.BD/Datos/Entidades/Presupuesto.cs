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
        //FK
        public required int IdSolicitud { get; set; }
        public Solicitud? Solicitud { get; set; }

        public required int IdPago { get; set; }
        public Pago? Pagos { get; set; }



        public required int ID  { get; set; }
        
        public required int Monto { get; set; } //en numeros
        [Required(ErrorMessage = "El campo Monto es obligatorio")]
        [MaxLength(42, ErrorMessage = "El campo tiene como máximo 42 caracteres.")]
        public required int tiempoEstimado { get; set; } //dias estimado
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(30, ErrorMessage = "El campo tiene como máximo 30 caracteres.")]
        public required string descripcion { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]
        public required bool estado{ get; set; } //recibido,en curso,finalizado
        public required DateTime FechaRegistro { get; set; }

    }
}
