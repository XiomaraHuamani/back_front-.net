using System;
using Microsoft.EntityFrameworkCore;
using LocalizaME.Entity;
using System.Reflection;

namespace LocalizaME.DataAccess
{
    public class LocalizameDbContext : DbContext
    {
        public LocalizameDbContext(DbContextOptions<LocalizameDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Repartidor> Repartidors { get; set; }
        public DbSet<Ubicacion> Ubicacions { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalles { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=LocalizaME;User Id=sa;Password=Pa$$w0rd;Encrypt=false");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Descripcion = "BALON GLP-E 5 KG NORMAL",
                    Marca = "CHASKIGAS",
                    UnidadMedida = "UND",
                    Precio = 21.5m,
                    Status = true
                },
                new Producto
                {
                    Id = 2,
                    Descripcion = "BALON GLP-E 10 KG NORMAL",
                    Marca = "CHASKIGAS",
                    UnidadMedida = "UND",
                    Precio = 43m,
                    Status = true
                },
                new Producto
                {
                    Id = 3,
                    Descripcion = "BALON GLP-E 10 KG PREMIUM",
                    Marca = "CHASKIGAS",
                    UnidadMedida = "UND",
                    Precio = 43m,
                    Status = true
                },
                new Producto
                {
                    Id = 4,
                    Descripcion = "BALON GLP-E 15 KG NORMAL",
                    Marca = "CHASKIGAS",
                    UnidadMedida = "UND",
                    Precio = 64m,
                    Status = true
                },
                new Producto
                {
                    Id = 5,
                    Descripcion = "BALON GLP-E 45 KG NORMAL",
                    Marca = "CHASKIGAS",
                    UnidadMedida = "UND",
                    Precio = 191m,
                    Status = true
                });

            modelBuilder.Entity<Repartidor>().HasData(
                new Repartidor
                {
                    Id = 1,
                    Apellidos = "CALCINA QUISPE",
                    Nombres = "HECTOR",
                    Telefono = "987654321",
                    PlacaVehiculo = "ABC-111",
                    Status = true
                },
                new Repartidor
                {
                    Id = 2,
                    Apellidos = "COAQUIRA PATINO",
                    Nombres = "MIGUEL ANGEL",
                    Telefono = "987654322",
                    PlacaVehiculo = "ABC-222",
                    Status = true
                },
                new Repartidor
                {
                    Id = 3,
                    Apellidos = "QUISPE COA",
                    Nombres = "ARTURO",
                    Telefono = "987654323",
                    PlacaVehiculo = "ABC-333",
                    Status = true
                },
                new Repartidor
                {
                    Id = 4,
                    Apellidos = "CHECA SALAS",
                    Nombres = "DIEGO",
                    Telefono = "987654324",
                    PlacaVehiculo = "ABC-444",
                    Status = true
                });
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { Id = 1, RazonSocial = "ELVA PERFECTA CACYALLA HUAMANI-PUNTO LIMON", Telefono = "998080383", Direccion = "URB. CAMPIÑA DORADA Mz-A Lt-11-A", Distrito = "AREQUIPA", Latitud = "-16.4198485", Longitud = "-71.5401245" },
                new Cliente { Id = 2, RazonSocial = "HIDALGO DELGADO", Telefono = "934315600", Direccion = "URB. BELLO AMANECER-QUINTA LAS FLORES Lt-15 PISO-4", Distrito = "CAYMA", Latitud = "-16.3758922", Longitud = "-71.5535819" },
                new Cliente { Id = 3, RazonSocial = "APAZA CISNEROS JUANA SOFIA", Telefono = "959932933", Direccion = "CALLE MICAELA BASTIDAS 129-FERROVIARIOS", Distrito = "AREQUIPA", Latitud = "-16.4090474", Longitud = "-71.537451" }
                );
        }
    }
}

