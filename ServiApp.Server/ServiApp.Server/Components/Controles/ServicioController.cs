using Microsoft.AspNetCore.Mvc;
using ServiApp.BD.Datos;
using ServiApp.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Repositorio.Repositorio;

namespace ServiApp.Server.Components.Controles
{

    [ApiController]
    [Route("api/servicioController")]
    public class ServicioController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IServicioRepo<ServicioEnti> servicioRepo;

        public ServicioController(AppDbContext context,
                                 IServicioRepo<ServicioEnti> servicioRepo)
        {
            this.context = context;
            this.servicioRepo = servicioRepo;
        }

        // GET: api/servicioController (OBTENER TODOS)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioDTO>>> GetServicios()
        {
            var serviciosList = await servicioRepo.Select();
            var servicios = serviciosList
                .Select(s => new ServicioDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    NombrePrestador = s.NombrePrestador,
                    Ubicacion = s.Ubicacion,
                    PrecioBase = s.PrecioBase
                })
                .ToList();

            if (!servicios.Any())
                return NotFound("No se encontraron servicios");

            return Ok(servicios);
        }

        // GET: api/servicio/categoria/3
        [HttpGet("categoria/IdCategoria")]
        public async Task<ActionResult<IEnumerable<ServicioDTO>>> GetServiciosPorCategoria(int IdCategoria)
        {
            // Await the Task<List<Servicio>> before applying LINQ methods
            var serviciosList = await servicioRepo.Select();

            var servicios = serviciosList
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
                .ToList();

            if (!servicios.Any())
                return NotFound($"No se encontraron servicios para la categoría con Id {IdCategoria}");

            return Ok(servicios);
        }
    }
}

