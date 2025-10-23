using System.Collections.Generic;

namespace ServiApp.Shared.DTO
{
    public class PrestadorDTO
    {
        public int Id { get; set; }
        public int IDnumberoMatricula { get; set; }
        public string NombrePrestador { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; } 
        public List<ServicioDTO>? Servicios { get; set; }
    }
}