using Microsoft.EntityFrameworkCore;
using ServiApp.BD.Datos.Entidades;
using ServiApp.Shared.ENUM;
using System;
using System.Collections.Generic;

namespace ServiApp.BD.Datos
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
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
                new Categoria { Id = 1, NombreCategoria = "Plomería", Descripcion = "Reparacion de caños, grifos, desagues y sanitarios." },
                new Categoria { Id = 2, NombreCategoria = "Electricidad", Descripcion = "Instalaciones, reparacion y mantenimiento de sistemas electricos, enchufes, iluminacion y tableros eléctricas." },
                new Categoria { Id = 3, NombreCategoria = "Pintura", Descripcion = "Pintado de interiores y exteriores, reparacion de paredes." },
                new Categoria { Id = 4, NombreCategoria = "Limpieza", Descripcion = "Servicios de limpieza para el hogar y oficina" },
                new Categoria { Id = 5, NombreCategoria = "Niñera", Descripcion = "Servicio de cuidado de niños y adultos mayores" },
                new Categoria { Id = 6, NombreCategoria = "Gasista", Descripcion = "Instalacion y mantenimiento de artefactos de gas y deteccion de fugas." },
                new Categoria { Id = 7, NombreCategoria = "Albañileria", Descripcion = "Construccion, refaccion y reparacion de paredes, pisos,techos y estructuras" },
                new Categoria { Id = 8, NombreCategoria = "Cerrajeria", Descripcion = "Apertura de cerraduras, duplicado de llaves." }
            );

            // Precargar prestadores
            modelBuilder.Entity<Prestador>().HasData(
                new Prestador
                {
                    Id = 1,
                    IdNumberoMatricula = 12345,
                    NombrePrestador = "Carlos",
                    Apellido = "López",
                    Email = "carlos.lopez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 2,
                    IdNumberoMatricula = 67890,
                    NombrePrestador = "María",
                    Apellido = "Fernández",
                    Email = "maria.fernandez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 3,
                    IdNumberoMatricula = 11111,
                    NombrePrestador = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                     Id = 4,
                    IdNumberoMatricula = 22222,
                     NombrePrestador = "Ana",
                     Apellido = "González",
                     Email = "ana.gonzalez@email.com",
                     Password = "password123"
                },
                new Prestador
                {
                    Id = 5,
                    IdNumberoMatricula = 33333,
                    NombrePrestador = "Roberto",
                    Apellido = "Martínez",
                    Email = "roberto.martinez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 6,
                    IdNumberoMatricula = 44444,
                    NombrePrestador = "Laura",
                    Apellido = "Rodríguez",
                    Email = "laura.rodriguez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 7,
                    IdNumberoMatricula = 55555,
                    NombrePrestador = "Diego",
                    Apellido = "Sánchez",
                    Email = "diego.sanchez@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 8,
                    IdNumberoMatricula = 66666,
                    NombrePrestador = "Valeria",
                    Apellido = "Torres",
                    Email = "valeria.torres@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 9,
                    IdNumberoMatricula = 77777,
                    NombrePrestador = "Martín",
                    Apellido = "Romero",
                    Email = "martin.romero@email.com",
                    Password = "password123"
                },
                new Prestador
                {
                    Id = 10,
                    IdNumberoMatricula = 88888,
                    NombrePrestador = "Claudia",
                    Apellido = "Morales",
                    Email = "claudia.morales@email.com",
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
                },
                new ServicioEnti
                {
                    Id = 4,
                    Nombre = "Pintura de interiores",
                    Descripcion = "Pintura profesional de ambientes interiores",
                    NombrePrestador = "Ana González",
                    Ubicacion = "Buenos Aires",
                    PrecioBase = 25,
                    IdCategoria = 3
                },
                new ServicioEnti
                {
                    Id = 5,
                    Nombre = "Limpieza profunda",
                    Descripcion = "Limpieza completa de hogar u oficina",
                    NombrePrestador = "Roberto Martínez",
                    Ubicacion = "La Plata",
                    PrecioBase = 18,
                    IdCategoria = 4
                },
                new ServicioEnti
                {
                    Id = 6,
                    Nombre = "Cuidado de niños",
                    Descripcion = "Servicio de niñera con experiencia",
                    NombrePrestador = "Laura Rodríguez",
                    Ubicacion = "Buenos Aires",
                    PrecioBase = 12,
                    IdCategoria = 5
                },
                new ServicioEnti
                {
                    Id = 7,
                    Nombre = "Instalación de gas",
                    Descripcion = "Instalación segura de artefactos a gas",
                    NombrePrestador = "Diego Sánchez",
                    Ubicacion = "Rosario",
                    PrecioBase = 30,
                    IdCategoria = 6
                },
                new ServicioEnti
                {
                    Id = 8,
                    Nombre = "Refacción de paredes",
                    Descripcion = "Reparación y construcción de paredes",
                    NombrePrestador = "Valeria Torres",
                    Ubicacion = "Córdoba",
                    PrecioBase = 28,
                    IdCategoria = 7
                },
                new ServicioEnti
                {
                    Id = 9,
                    Nombre = "Apertura de cerraduras",
                    Descripcion = "Servicio de cerrajería 24 horas",
                    NombrePrestador = "Martín Romero",
                    Ubicacion = "Mendoza",
                    PrecioBase = 22,
                    IdCategoria = 8
                },
                new ServicioEnti
                {
                    Id = 10,
                    Nombre = "Mantenimiento eléctrico",
                    Descripcion = "Revisión y mantenimiento preventivo de instalaciones eléctricas",
                    NombrePrestador = "Claudia Morales",
                    Ubicacion = "Buenos Aires",
                    PrecioBase = 24,
                    IdCategoria = 2
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
                },
                new PrestadorServicio
                {
                    Id = 4,
                    PrestadorId = 4,
                    ServicioId = 4,
                    FechaAsignacion = new DateTime(2024, 1, 15)
                },
                new PrestadorServicio
                {
                    Id = 5,
                    PrestadorId = 5,
                    ServicioId = 5,
                    FechaAsignacion = new DateTime(2024, 1, 20)
                },
                new PrestadorServicio
                {
                    Id = 6,
                    PrestadorId = 6,
                    ServicioId = 6,
                    FechaAsignacion = new DateTime(2024, 2, 1)
                },
                new PrestadorServicio
                {
                    Id = 7,
                    PrestadorId = 7,
                    ServicioId = 7,
                    FechaAsignacion = new DateTime(2024, 2, 5)
                },
                new PrestadorServicio
                {
                    Id = 8,
                    PrestadorId = 8,
                    ServicioId = 8,
                    FechaAsignacion = new DateTime(2024, 2, 10)
                },
                new PrestadorServicio
                {
                    Id = 9,
                    PrestadorId = 9,
                    ServicioId = 9,
                    FechaAsignacion = new DateTime(2024, 2, 15)
                },
                new PrestadorServicio
                {
                    Id = 10,
                    PrestadorId = 10,
                    ServicioId = 10,
                    FechaAsignacion = new DateTime(2024, 2, 20)
                }
            );
        }
    }
}