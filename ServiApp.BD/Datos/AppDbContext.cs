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
        public DbSet<Servicio> Servicos{ get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Presupuesto> Presupuesto { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<PrestadorServicio> PrestadorServicio { get; set; }
        public DbSet<Categoria> Categorias { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
            //var estado = EstadoRegistro.activo
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación: una Categoría tiene muchos Servicios
            modelBuilder.Entity<Servicio>()
                .HasOne(s => s.Categoria)
                .WithMany(c => c.Servicios)
                .HasForeignKey(s => s.IdCategoria);

            // Precargar categorías (seeding)
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, NombreCategoria = "Plomería", Descripcion = "Servicios de cañerías y grifos" },
                new Categoria { Id = 2, NombreCategoria = "Electricidad", Descripcion = "Instalaciones y reparaciones eléctricas" },
                new Categoria { Id = 3, NombreCategoria = "Pintura", Descripcion = "Pintado de interiores y exteriores" },
                new Categoria { Id = 4, NombreCategoria = "Limpieza", Descripcion = "Servicios de limpieza para el hogar y oficina" }
            );
        }
    }
}


