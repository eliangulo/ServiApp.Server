using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.Shared.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set;}
        public string NombreCategoria { get; set; } = "";

        public string Descripcion { get; set; } = "";
        public List<ServicioDTO> Servicios { get; set; }
    }
}
