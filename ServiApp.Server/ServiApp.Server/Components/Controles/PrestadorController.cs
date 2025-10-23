using Microsoft.AspNetCore.Mvc;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Repositorio.Repositorio;
using ServiApp.Shared.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiApp.Server.Components.Controles
{
    [ApiController]
    [Route("api/prestador")]
    public class PrestadorController : ControllerBase
    {
        private readonly IPrestadorRepo<Prestador> prestadorRepo;

        public PrestadorController(IPrestadorRepo<Prestador> prestadorRepo)
        {
            this.prestadorRepo = prestadorRepo;
        }

        // GET: api/prestador
        [HttpGet]
        public async Task<ActionResult<List<PrestadorDTO>>> GetPrestadores()
        {
            var prestadoresList = await prestadorRepo.Select();

            if (prestadoresList == null || !prestadoresList.Any())
                return NotFound("No se encontraron prestadores");

            var prestadoresDTO = prestadoresList.Select(p => new PrestadorDTO
            {
                Id = p.Id,
                IDnumberoMatricula = p.IDnumberoMatricula,
                NombrePrestador = p.NombrePrestador,
                Apellido = p.Apellido,
                Email = p.Email,
                Servicios = p.PrestadorServicios?.Select(ps => new ServicioDTO
                {
                    Id = ps.Servicio.Id,
                    Nombre = ps.Servicio.Nombre,
                    Descripcion = ps.Servicio.Descripcion,
                    PrecioBase = ps.Servicio.PrecioBase
                }).ToList()
            }).ToList();

            return Ok(prestadoresDTO);
        }

        // GET: api/prestador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrestadorDTO>> GetPrestador(int id)
        {
            var prestador = await prestadorRepo.SelectById(id);

            if (prestador == null)
                return NotFound($"No se encontró el prestador con Id {id}");

            var prestadorDTO = new PrestadorDTO
            {
                Id = prestador.Id,
                IDnumberoMatricula = prestador.IDnumberoMatricula,
                NombrePrestador = prestador.NombrePrestador,
                Apellido = prestador.Apellido,
                Email = prestador.Email,
                Servicios = prestador.PrestadorServicios?.Select(ps => new ServicioDTO
                {
                    Id = ps.Servicio.Id,
                    Nombre = ps.Servicio.Nombre,
                    Descripcion = ps.Servicio.Descripcion,
                    PrecioBase = ps.Servicio.PrecioBase
                }).ToList()
            };

            return Ok(prestadorDTO);
        }

        // GET: api/prestador/categoria/1
        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<List<PrestadorDTO>>> GetPrestadoresPorCategoria(int categoriaId)
        {
            var prestadoresList = await prestadorRepo.SelectPorCategoria(categoriaId);

            if (prestadoresList == null || !prestadoresList.Any())
                return NotFound($"No se encontraron prestadores para la categoría con Id {categoriaId}");

            var prestadoresDTO = prestadoresList.Select(p => new PrestadorDTO
            {
                Id = p.Id,
                IDnumberoMatricula = p.IDnumberoMatricula,
                NombrePrestador = p.NombrePrestador,
                Apellido = p.Apellido,
                Email = p.Email
            }).ToList();

            return Ok(prestadoresDTO);
        }

        // POST: api/prestador
        [HttpPost]
        public async Task<ActionResult> CreatePrestador([FromBody] PrestadorDTO prestadorDTO)
        {
            var prestador = new Prestador
            {
                IDnumberoMatricula = prestadorDTO.IDnumberoMatricula,
                NombrePrestador = prestadorDTO.NombrePrestador,
                Apellido = prestadorDTO.Apellido,
                Email = prestadorDTO.Email,
                Password = "defaultPassword123" // Deberías manejar esto de otra forma
            };

            var resultado = await prestadorRepo.Insert(prestador);

            if (!resultado)
                return BadRequest("No se pudo crear el prestador");

            return Ok("Prestador creado exitosamente");
        }

        // PUT: api/prestador/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePrestador(int id, [FromBody] PrestadorDTO prestadorDTO)
        {
            var prestador = new Prestador
            {
                Id = id,
                IDnumberoMatricula = prestadorDTO.IDnumberoMatricula,
                NombrePrestador = prestadorDTO.NombrePrestador,
                Apellido = prestadorDTO.Apellido,
                Email = prestadorDTO.Email,
                Password = "defaultPassword123" // Mantener password existente
            };

            var resultado = await prestadorRepo.Update(id, prestador);

            if (!resultado)
                return NotFound($"No se encontró el prestador con Id {id}");

            return Ok("Prestador actualizado exitosamente");
        }

        // DELETE: api/prestador/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrestador(int id)
        {
            var resultado = await prestadorRepo.Delete(id);

            if (!resultado)
                return NotFound($"No se encontró el prestador con Id {id}");

            return Ok("Prestador eliminado exitosamente");
        }
    }
}