using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.application.test.Dobles;

namespace ventas.application.test
{
    public class SalidaProductoServiceDobles
    {
        public SalidaProductoService _salidaService;//SUT - Objeto bajo prueba

        //se ejecuta una vez por cada prueba //hace parte del Arrange
        [SetUp]
        public void Setup()
        {
            //Arrange
        }

        [Test]
        public void SalidaProductoSimpleTest()
        {
            _salidaService = new SalidaProductoService(new UnitOfWorkFake(), new ProductoRepositoryStub());
            var response = _salidaService.Ejecutar(new SalidaProductoRequest("001", 3));
            Assert.AreEqual("Nueva salida: Pan, cantidad:3, costo_total:$ 500,00, precio_total:$ 0,00", response.Mensaje);
        }

    }
}
