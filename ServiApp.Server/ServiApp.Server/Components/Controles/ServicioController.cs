using Microsoft.AspNetCore.Mvc;
using ServiApp.BD.Datos;
using ServiApp.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos.Entidades;

namespace ServiApp.Server.Components.Controles
{

    [ApiController]
    [Route("api/servicioController")]
    public class ServicioController : ControllerBase
    {
        private readonly AppDbContext context;

        public ServicioController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/servicio/categoria/3
        [HttpGet("categoria/{IdCategoria}")]
        public async Task<ActionResult<IEnumerable<ServicioDTO>>> GetServiciosPorCategoria(int IdCategoria)
        {
            var servicios = await context.Servicios
                .Where(s => s.IdCategoria == IdCategoria)
                .Select(s => new ServicioDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    NombrePrestador = s.NombrePrestador,
                    Ubicacion = s.Ubicacion,
                    PrecioBase = s.PrecioBase
                })
                .ToListAsync();

            if (!servicios.Any())
                return NotFound($"No se encontraron servicios para la categoría con Id {IdCategoria}");

            return Ok(servicios);
        }
    }
}

