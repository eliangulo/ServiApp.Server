using ServiApp.BD.Datos;
using ServiApp.BD.Datos.Entidades;

namespace ServiApp.Repositorio.Repositorio
{
    public interface IServicioRepo<E> where E : class, IEntityBase
    {
        Task<List<E>> Select();
        Task<E?> SelectById(int id);
    }
}