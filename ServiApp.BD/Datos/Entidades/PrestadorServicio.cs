using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
   public class PrestadorServicio:EntityBase
   {
        //FK
        public required int IdPrestador { get; set; }
        public Prestador? Prestador{ get; set; }
        public required int IdServicio  { get; set; }
        public Servico? Servicio { get; set; }


    }
}
