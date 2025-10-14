using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Shared.ENUM;
using System;
using System.Collections.Generic;

namespace ServiApp.BD.Datos
{
    public class AppDbContext : DbContext
    {
        // Tablas
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<ServicioEnti> Servicios { get; set; }
        public DbSet<Prestador> Prestadores { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<PrestadorServicio> PrestadoresServicios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación: una Categoría tiene muchos Servicios
            modelBuilder.Entity<ServicioEnti>()
                .HasOne(s => s.Categoria)
                .WithMany( c => c.ServicioEnti)
                .HasForeignKey(s => s.IdCategoria);

            // Precargar categorías
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, NombreCategoria = "Plomería", Descripcion = "Servicios de cañerías y grifos" },
                new Categoria { Id = 2, NombreCategoria = "Electricidad", Descripcion = "Instalaciones y reparaciones eléctricas" },
                new Categoria { Id = 3, NombreCategoria = "Pintura", Descripcion = "Pintado de interiores y exteriores" },
                new Categoria { Id = 4, NombreCategoria = "Limpieza", Descripcion = "Servicios de limpieza para el hogar y oficina" }
            );

            // Precargar servicios
            modelBuilder.Entity<ServicioEnti>().HasData(
                new ServicioEnti
                {
                    Id = 1,
                    Nombre = "Reparación de caños",
                    Descripcion = "Arreglo de pérdidas de agua y caños rotos",
                    NombrePrestador = "Carlos López",
                    Ubicacion = "Buenos Aires",
                    PrecioBase = 10,
                    IdCategoria = 1
                },
                new ServicioEnti
                {
                    Id = 2,
                    Nombre = "Instalación de enchufes",
                    Descripcion = "Colocación y reparación de enchufes eléctricos",
                    NombrePrestador = "María Fernández",
                    Ubicacion = "Rosario",
                    PrecioBase = 20,
                    IdCategoria = 2
                }
            );
        }
    }
}
