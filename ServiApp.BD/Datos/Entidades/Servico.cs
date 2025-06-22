using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos.Entidades
{
    public class Servico : EntityBase
    {
        public required int IDServicio { get; set; }
        
        public required string Nombre{ get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo tiene como máximo 20 caracteres.")]

        public required string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        [MaxLength(100, ErrorMessage = "El campo tiene como máximo 100 caracteres.")]

        public required string Categoria { get; set; }
        [Required(ErrorMessage = "El campo Categoria es obligatorio")]
        [MaxLength(20, ErrorMessage = "El campo tiene como máximo 20 caracteres.")]

        public required int FechaRegistro { get; set; }
        
    }
}
