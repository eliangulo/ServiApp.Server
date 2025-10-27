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
    public class ServicioController(IServicioRepo<ServicioEnti> servicioRepo) : ControllerBase
    {
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

            if (servicios.Count == 0)
                return NotFound("No se encontraron servicios");

            return Ok(servicios);
        }

        // GET: api/servicioController/5 (OBTENER POR ID)
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioDTO>> GetServicio(int id)
        {
            var servicio = await servicioRepo.SelectById(id);

            if (servicio == null)
                return NotFound($"No se encontró el servicio con Id {id}");

            var servicioDTO = new ServicioDTO
            {
                Id = servicio.Id,
                Nombre = servicio.Nombre,
                Descripcion = servicio.Descripcion,
                NombrePrestador = servicio.NombrePrestador,
                Ubicacion = servicio.Ubicacion,
                PrecioBase = servicio.PrecioBase
            };

            return Ok(servicioDTO);
        }

        // GET: api/servicioController/categoria/3
        [HttpGet("categoria/{IdCategoria}")]
        public async Task<ActionResult<IEnumerable<ServicioDTO>>> GetServiciosPorCategoria(int IdCategoria)
        {
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

            if (servicios.Count == 0)
                return NotFound($"No se encontraron servicios para la categoría con Id {IdCategoria}");

            return Ok(servicios);
        }
    }
}