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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasKey(c => c.Id);
        }
    }
}
