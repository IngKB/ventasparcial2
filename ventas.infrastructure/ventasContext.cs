using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ventas.domain;

namespace ventas.infrastructure
{
    public class ventasContext : DbContextBase
    {

        public ventasContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Producto> Productos { get; set; }//equivale a Repositorios
        public DbSet<ProductoSimple> ProductosSimples { get; set; }
        public DbSet<ProductoCompuesto> ProductoCompuesto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasKey(c => c.Id);

            modelBuilder.Entity<ProductoSimple>().HasData(new { Id = 1, Codigo = "001", Nombre = "Pan", Precio = 0m, Costo = 500m, Tipo = "Preparacion", Cantidad = 10 });

        }
    }
}
