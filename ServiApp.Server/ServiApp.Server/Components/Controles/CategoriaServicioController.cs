using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Repositorio.Repositorio;
using ServiApp.Shared.DTO;

namespace ServiApp.Server.Components.Controles
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaServicioController(AppDbContext context,
                                             ICategoriaRepo<Categoria> categoriaRepo) : ControllerBase
    {
        [HttpGet] //api/categoria/listaCategoria
        public async Task<ActionResult<List<CategoriaDTO>>> GetListaCategoria()
        {
            var lista = await categoriaRepo.Select();

            if (lista == null || lista.Count == 0)
            {
                return NotFound("No se encontraron categorías.");
            }

            // Mapear a DTO
            var categoriasDTO = lista.Select(c => new CategoriaDTO
            {
                Id = c.Id,
                NombreCategoria = c.NombreCategoria,
                Descripcion = c.Descripcion,
                Servicios = [..c.ServicioEnti.Select(s => new ServicioDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                })]
            }).ToList();

            return Ok(categoriasDTO);
        }

        [HttpGet("{id}/servicio")]
        public async Task<ActionResult<CategoriaDTO>> GetServicioPorCategoria(int id)
        {
            var categoria = await context.Categorias
                .Include(c => c.ServicioEnti)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
                return NotFound($"No se encontró la categoría con Id {id}");

            var categoriaDto = new CategoriaDTO
            {
                Id = categoria.Id,
                NombreCategoria = categoria.NombreCategoria,
                Descripcion = categoria.Descripcion,
                Servicios = [..categoria.ServicioEnti.Select(s => new ServicioDTO
                {
                    Id = s.Id,
                    Nombre = s.Nombre,
                    Descripcion = s.Descripcion,
                })]
            };

            return Ok(categoriaDto);
        }
    }
}