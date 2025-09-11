using ServiApp.BD.Datos;

namespace ServiApp.Repositorio.Repositorio
{
    public interface ICategoriaRepo<E> where E : class, IEntityBase
    {
        Task<List<E>> Select();
        Task<E?> SelectById(int id);

    }        
    
}
    
