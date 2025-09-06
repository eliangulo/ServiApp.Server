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
        public required int IDnumberoMatricula { get; set; }
        public Prestador? Prestador{ get; set; }
        public required int IDServicio { get; set; }
        public Servico? Servicio { get; set; }


    }
}
