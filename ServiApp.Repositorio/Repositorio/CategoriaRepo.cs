using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.Repositorio.Repositorio
{
    public class CategoriaRepo<E> : ICategoriaRepo<E> where E : class, IEntityBase
    {
        private readonly AppDbContext context;
        public CategoriaRepo(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        //select id
        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
