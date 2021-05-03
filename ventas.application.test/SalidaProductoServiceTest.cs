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
    public class SalidaProductoServiceTest
    {
        public ventasContext _dbContext;
        public SalidaProductoService _salidaService;//SUT - Objeto bajo prueba

        //se ejecuta una vez por cada prueba //hace parte del Arrange
        [SetUp]
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

            ProductoSimple pan = (ProductoSimple)ProductoMother.ProductoPan("001");
            pan.RegistrarEntrada(10);

            ProductoSimple salchicha = (ProductoSimple)ProductoMother.ProductoSalchicha("002");
            salchicha.RegistrarEntrada(10);

            _dbContext.Productos.Add(pan);
            _dbContext.Productos.Add(salchicha);
            _dbContext.SaveChanges();

        }

        [Test]
        public void SalidaProductoSimpleTest()
        {
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("001", 3));
            Assert.AreEqual("Nueva salida: Pan, cantidad:3, costo:500, precio:0", response.Mensaje);
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            _dbContext.Database.EnsureDeleted();
        }

    }
}
