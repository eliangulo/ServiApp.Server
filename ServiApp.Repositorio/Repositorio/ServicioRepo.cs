using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.Repositorio.Repositorio
{
    //servisioRepo es mi clase generica que va a implementar la interfaz IEntityBase
    //IServicioRepo es la interfaz generica que contiene el metodo Selec
    public class ServicioRepo<E>(AppDbContext context) : IServicioRepo<E> where E : class, IEntityBase
    {
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        //select id 
        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FindAsync(id);
        }
    }
}
