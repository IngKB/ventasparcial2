using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure;

namespace ventas.application.test
{
  public  class EntradaProductoSevriceTest
    {
        private ventasContext dbContext;
        private  ProductoEntradaService _entradaService;//SUT - Objeto bajo prueba

        //se ejecuta una vez por cada prueba //hace parte del Arrange
        [SetUp]
        public void Setup()
        {
            //Arrange
            var optionsSqlite = new DbContextOptionsBuilder<ventasContext>()
           .UseSqlite(@"Data Source=ventasDataBaseTest.db")
           .Options;

            dbContext = new ventasContext(optionsSqlite);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            _entradaService = new ProductoEntradaService(
                new UnitOfWork(dbContext),
                new CuentaBancariaRepository(_dbContext),
                new MailServerSpy());
        }
    }
}
