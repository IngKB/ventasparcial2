using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain;
using ventas.infrastructure;

namespace ventas.application.test
{
    [SetUpFixture]
    public class SalidaProductoServiceTest
    {
        private ventasContext _dbContext;
        private SalidaProductoService _salidaService;//SUT - Objeto bajo prueba

        //se ejecuta una vez por cada prueba //hace parte del Arrange
        [OneTimeSetUp]
        public void Setup()
        {
            //Arrange
            var optionsSqlite = new DbContextOptionsBuilder<ventasContext>()
           .UseSqlite(@"Data Source=ventasDataBaseTest.db")
           .Options;

            _dbContext = new ventasContext(optionsSqlite);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            _salidaService = new SalidaProductoService(
                new UnitOfWork(_dbContext),
                new ProductoRepository(_dbContext));
        }

        [Test]
        public void SalidaProductoTest()
        {

        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _dbContext.Database.EnsureDeleted();
        }


    }
}
