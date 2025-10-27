using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.Shared.DTO
{
    public class ServicioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string NombrePrestador { get; set; } = string.Empty;
        public string Ubicacion { get; set; } = string.Empty;
        public decimal PrecioBase { get; set; }

    }
}