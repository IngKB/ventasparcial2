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
    [TestFixture]
    public class SalidaProductoServiceTestBaseDatos
    {
        public ventasContext _dbContext;
        public SalidaProductoService _salidaService;//SUT - Objeto bajo prueba

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
        public void SalidaProductoSimpleTest()
        {
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("001", 3));
            Assert.AreEqual("Nueva salida: Pan, cantidad:3, costo_total:$ 500,00, precio_total:$ 0,00", response.Mensaje);
        }

        [Test]
        public void SalidaProductoCompuestoTest()
        {
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("004", 4));
            Assert.AreEqual("Nueva salida: Perro, cantidad:4, costo_total:$ 1.500,00, precio_total:$ 20.000,00", response.Mensaje);
        }

        [Test]
        public void NoSePuedeHacerSalidaNegativa()
        {
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("003", -4));
            Assert.AreEqual("Salida menor o igual a 0", response.Mensaje);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _dbContext.Database.EnsureDeleted();
        }

    }
}
