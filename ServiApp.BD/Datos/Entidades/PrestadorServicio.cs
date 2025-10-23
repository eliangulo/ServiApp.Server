using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
   public class PrestadorServicio:EntityBase
   {
            public int PrestadorId { get; set; }

            [ForeignKey("PrestadorId")]
            public Prestador Prestador { get; set; } = null!;

            public int ServicioId { get; set; }

            [ForeignKey("ServicioId")]
            public ServicioEnti Servicio { get; set; } = null!;

            // Propiedades adicionales opcionales
            public DateTime FechaAsignacion { get; set; } = DateTime.Now;
        
    }
}
