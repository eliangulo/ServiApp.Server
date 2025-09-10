using ServiApp.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos
{
    public class EntityBase : IEntityBase
    {
        public required int Id { get; set; }
       // public EstadoRegistro EstadoRegistro { get; set; }
    }

}
