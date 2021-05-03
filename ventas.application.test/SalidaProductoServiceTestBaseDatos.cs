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

            ProductoSimple pan = (ProductoSimple)ProductoMother.ProductoPan("001");
            pan.RegistrarEntrada(10);

            ProductoSimple salchicha = (ProductoSimple)ProductoMother.ProductoSalchicha("002");
            salchicha.RegistrarEntrada(10);

            ProductoCompuesto perro = new("003", "Perro", 5000, new List<Producto> { pan, salchicha });
          
            //_dbContext.Productos.Add(pan);
            _dbContext.Productos.Add(salchicha);
            _dbContext.Productos.Add(perro);
            _dbContext.SaveChanges();

        }

        [Test]
        public void SalidaProductoSimpleTest()
        {
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("001", 3));
            Assert.AreEqual("Nueva salida: Pan, cantidad:3, costo:$500,00, precio:$0,00", response.Mensaje);
        }

        [Test]
        public void SalidaProductoCompuestoTest()
        {
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("003", 4));
            Assert.AreEqual("Nueva salida: Perro, cantidad:4, costo:$1.500,00, precio:$20.000,00", response.Mensaje);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            _dbContext.Database.EnsureDeleted();
        }

    }
}
