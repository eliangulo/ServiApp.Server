using ServiApp.Servicio.ServicioHttp;

namespace ServiApp.Servicio.ServicioHTTP
{
    public interface IHttpServicio
    {
        Task<HttpRespuesta<T>> Get<T>(string url);
    }
}