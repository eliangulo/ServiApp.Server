using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiApp.Repositorio.Repositorio
{
    public class PrestadorRepo<E> : IPrestadorRepo<E> where E : class, IEntityBase
    {
        private readonly AppDbContext context;

        public PrestadorRepo(AppDbContext context)
        {
            this.context = context;
        }

        // Obtener todos los prestadores con sus servicios
        public async Task<List<E>> Select()
        {
            if (typeof(E) == typeof(Prestador))
            {
                var prestadores = await context.Prestadores
                    .Include(p => p.PrestadorServicios)
                        .ThenInclude(ps => ps.Servicio)
                    .ToListAsync();

                return prestadores as List<E>;
            }

            return await context.Set<E>().ToListAsync();
        }

        // Obtener prestador por ID con sus servicios
        public async Task<E?> SelectById(int id)
        {
            if (typeof(E) == typeof(Prestador))
            {
                var prestador = await context.Prestadores
                    .Include(p => p.PrestadorServicios)
                        .ThenInclude(ps => ps.Servicio)
                    .FirstOrDefaultAsync(p => p.Id == id);

                return prestador as E;
            }

            return await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
        }

        // MÉTODO CLAVE: Obtener prestadores por categoría
        public async Task<List<E>> SelectPorCategoria(int categoriaId)
        {
            if (typeof(E) == typeof(Prestador))
            {
                // Buscar prestadores que tienen servicios en la categoría especificada
                var prestadores = await context.PrestadoresServicios
                    .Include(ps => ps.Prestador)
                    .Include(ps => ps.Servicio)
                        .ThenInclude(s => s.Categoria)
                    .Where(ps => ps.Servicio.IdCategoria == categoriaId)
                    .Select(ps => ps.Prestador)
                    .Distinct()
                    .ToListAsync();

                return prestadores as List<E>;
            }

            return new List<E>();
        }

        // Insertar prestador
        public async Task<bool> Insert(E entity)
        {
            try
            {
                await context.Set<E>().AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Actualizar prestador
        public async Task<bool> Update(int id, E entity)
        {
            try
            {
                var existingEntity = await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
                if (existingEntity == null)
                    return false;

                context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Eliminar prestador
        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    return false;

                context.Set<E>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}