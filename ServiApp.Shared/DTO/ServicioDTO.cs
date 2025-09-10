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
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string NombrePrestador { get; set; }
        public string Ubicacion { get; set; }
        public decimal PrecioBase { get; set; }

    }
}