using ServiApp.Servicio.ServicioHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiApp.Servicio.ServicioHTTP
{
    public class HttpServicio : IHttpServicio
    {
        private readonly HttpClient http;

        public HttpServicio(HttpClient http)
        {
            this.http = http;
        }
        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerialize<T>(response);
                return new HttpRespuesta<T>(respuesta, false, response);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, response);
            }
        }
        private async Task<T?> DesSerialize<T>(HttpResponseMessage response)
        {
            var respuestaString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuestaString,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
