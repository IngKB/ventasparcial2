using NUnit.Framework;
using System.Collections.Generic;
using ventas.domain;

namespace ventas.domian.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*
         DADO que se ha registrado un producto simple
         CUANDO se intente registrar una entrada de ese producto menor o igual a 0
         ENTONCES el sistema debe rechazar la entrada 
         Y mostrar el mensaje "Entrada menor o igual a 0"
         */
        [Test]
        public void EntradaProductoMenorACero()
        {
            //Arrange
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");

            //Act
            var respuesta = salchicha.RegistrarEntrada(-1);

            //Assert
            Assert.AreEqual("Entrada menor o igual a 0", respuesta);
        }

        /*
         DADO que se ha registrado un producto simple
         CUANDO se ingrese una entrada de este producto
         ENTONCES el sistema debe aumentar la cantidad existente 
         */
        [Test]
        public void EntradaDebeAumentarCantidad()
        {
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");

            //Act
            var respuesta = salchicha.RegistrarEntrada(10);

            //Assert
            Assert.AreEqual("Salchicha Nueva cantidad: 10", respuesta);
        }

        /*
        DADO que se ha registrado un producto simple
        CUANDO se intente registrar una salida menor o igual a 0
        ENTONCES el sistema debe rechazar la salida 
         Y mostrar el mensaje "Salida menor o igual a 0"
        */
        [Test]
        public void SalidaSimpleMenorACero()
        {
            //Arrange
            ProductoSimple cocacola = new ProductoSimple("002", "CocaCola", 1000, 3000, "Venta");

            //Act
            var respuesta = cocacola.RegistrarSalida(-1);

            //Assert
            Assert.AreEqual("Salida menor o igual a 0", respuesta);
        }

        /*
       DADO que se ha registrado un producto simple
       CUANDO se registre una salida
       ENTONCES el sistema debe disminuir la cantidad existente 
       */
        [Test]
        public void SalidaSencillaDebeDisminuirCantidad()
        {
            //Arrange
            ProductoSimple cocacola = new ProductoSimple("002", "CocaCola", 1000, 3000, "Venta");
            //Act
            cocacola.RegistrarEntrada(10);
            var respuesta = cocacola.RegistrarSalida(6);
            //Assert
            Assert.AreEqual("Nueva salida: CocaCola, cantidad:6, costo:$ 1.000,00, precio:$ 3.000,00", respuesta);
        }

        /*
        DADO que se ha registrado un producto compuesto
        CUANDO se registre una salida
        ENTONCES el sistema debe disminuir la cantidad existente de los productos que lo componen
        */
        [Test]
        public void SalidaCompuestaDebeDisminuirCantidad()
        {
            ProductoSimple salchicha = new ProductoSimple("001", "Salchicha", 1000, 0, "Preparacion");
            ProductoSimple pan = new ProductoSimple("002", "Pan", 500, 0, "Preparacion");

            salchicha.RegistrarEntrada(10);
            pan.RegistrarEntrada(10);
            List<Producto> ingredientes = new List<Producto>() { salchicha, pan };

            Producto perroCaliente = new ProductoCompuesto("003", "PerroCaliente", 5000, ingredientes);

            //Act
            var respuesta = perroCaliente.RegistrarSalida(1);


            //Assert
            Assert.AreEqual("Nueva salida: PerroCaliente, cantidad:1, costo:$ 1.500,00, precio:$ 5.000,00", respuesta);

        }
    }
}