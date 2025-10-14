using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.Servicio.ServicioHttp
{
    public class HttpRespuesta <T> 
    {
        public HttpRespuesta(T? respuesta, bool error, HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public T? Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; set;}
    }
}
