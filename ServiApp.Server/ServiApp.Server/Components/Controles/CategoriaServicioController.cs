using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Shared.DTO;
using System.Diagnostics.CodeAnalysis;

namespace ServiApp.Server.Components.Controles
{
    [ApiController]
    [Route("api/CategoriaServicioController")]
    public class CategoriaServicioController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriaServicioController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet] //api/categoria
        public async Task<ActionResult<List<Categoria>>> GetListaCategoria()
        {
            var lista = await context.Categorias.ToListAsync();
            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista.");
            }
            if (lista.Count == 0)
            {
                return Ok("Lista no contiene registro.");
            }

            return Ok(lista);
        }
        
        [HttpGet("{id}/servicio")]
        public async Task<ActionResult<CategoriaDTO>> GetServicioPorCategoria(int id)
        {
            var categoria = await context.Categorias
                .Include(c => c.Servicios) // importante incluir los servicios
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
                return NotFound($"No se encontró la categoría con Id {id}");

            var categoriaDto = new CategoriaDTO
            {
                Id = categoria.Id,
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
                Servicios = categoria.Servicios.Select(s => new ServicioDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                    FechaRegistro = s.FechaRegistro
                }).ToList()
            };

            return Ok(categoriaDto);
        }
    }
}
