using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Shared.ENUM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiApp.BD.Datos
{
    
    public class AppDbContext : DbContext
    {
        //Tablas
        public DbSet<Usuarios> Usuarios { get; set; }
       
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Servico> Servicos{ get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<PrestadorServicio> PrestadorServicio { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            //var estado = EstadoRegistro.activo
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }           
    }
}


