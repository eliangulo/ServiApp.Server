using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
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

        // GET: api/categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            var categorias = await this.context.Categorias.ToListAsync();

            if (categorias == null || !categorias.Any())
            {
                return NotFound("No hay categorías cargadas.");
            }

            return Ok(categorias);
        }
    }
}
