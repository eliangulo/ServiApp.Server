using ServiApp.BD.Datos;
using ServiApp.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServiApp.Repositorio.Repositorios
{
    public class Repositorio<E> where E : class, IEntityBase
    {
        private readonly AppDbContext context;
        public Repositorio(AppDbContext context) 
        {
            this.context = context;
        }

        //select
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

    }
}
