using ServiApp.BD.Datos;

namespace ServiApp.Repositorio.Repositorio
{
    public interface IServicioRepo<E> where E : class, IEntityBase
    {
        Task<List<E>> Select();
    }
}