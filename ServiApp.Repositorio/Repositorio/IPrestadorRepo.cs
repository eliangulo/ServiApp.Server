using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiApp.Repositorio.Repositorio
{
    public interface IPrestadorRepo<E> where E : class, IEntityBase
    {
        Task<List<E>> Select();
        Task<E?> SelectById(int id);
        Task<List<E>> SelectPorCategoria(int categoriaId);
        Task<bool> Insert(E entity);
        Task<bool> Update(int id, E entity);
        Task<bool> Delete(int id);
    }
}