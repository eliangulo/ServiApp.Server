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
                .WithMany(c => c.ServicioEnti)
                .HasForeignKey(s => s.IdCategoria);

            // Precargar categorías
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, NombreCategoria = "Plomería", Descripcion = "Servicios de cañerías y grifos" },
                new Categoria { Id = 2, NombreCategoria = "Electricidad", Descripcion = "Instalaciones y reparaciones eléctricas" },
                new Categoria { Id = 3, NombreCategoria = "Pintura", Descripcion = "Pintado de interiores y exteriores" },
                new Categoria { Id = 4, NombreCategoria = "Limpieza", Descripcion = "Servicios de limpieza para el hogar y oficina" }
            );

            // Precargar prestadores
            modelBuilder.Entity<Prestador>().HasData(
                new Prestador
                {
                    Id = 1,
                    IDnumberoMatricula = 12345,
                    NombrePrestador = "Carlos",
                    Apellido = "López",
                    Email = "carlos.lopez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 2,
                    IDnumberoMatricula = 67890,
                    NombrePrestador = "María",
                    Apellido = "Fernández",
                    Email = "maria.fernandez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 3,
                    IDnumberoMatricula = 11111,
                    NombrePrestador = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@email.com",
                    Password = "password123"
                }
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
                },
                new ServicioEnti
                {
                    Id = 3,
                    Nombre = "Destape de cañerías",
                    Descripcion = "Limpieza y destape de desagües y cañerías",
                    NombrePrestador = "Juan Pérez",
                    Ubicacion = "Córdoba",
                    PrecioBase = 15,
                    IdCategoria = 1
                }
            );

            // Precargar relaciones PrestadorServicio
            modelBuilder.Entity<PrestadorServicio>().HasData(
                new PrestadorServicio
                {
                    Id = 1,
                    PrestadorId = 1,
                    ServicioId = 1,
                    FechaAsignacion = new DateTime(2024, 1, 1)
                },
                new PrestadorServicio
                {
                    Id = 2,
                    PrestadorId = 2,
                    ServicioId = 2,
                    FechaAsignacion = new DateTime(2024, 1, 1)
                },
                new PrestadorServicio
                {
                    Id = 3,
                    PrestadorId = 3,
                    ServicioId = 3,
                    FechaAsignacion = new DateTime(2024, 1, 1)
                }
            );
        }
    }
}