using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ventas.domain;

namespace ventas.infrastructure
{
    class ventasContext : DbContextBase
    {

        public ventasContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<ProductoCompuesto> ProductosCompuestos { get; set; }//equivale a Repositorios
        public DbSet<ProductoSimple> ProductoSimples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoCompuesto>().HasKey(c => c.Id);
            modelBuilder.Entity<ProductoSimple>().HasKey(c => c.Id);

            //inicailizacion de datos 
            //modelBuilder.Entity<CuentaBancaria>().HasData(new  { Id=1, Numero="1010", Ciudad="Valleduar", Email="Email"} );
            //modelBuilder.Entity<CuentaBancaria>().HasData(new { Id = 1, Numero = "1010", Ciudad = "Valleduar", Email = "Email" });
        }
    }
}
