using System;
using System.Collections.Generic;
using System.Text;
using ventas.domain.Base;

namespace ventas.domain
{
    public class ProductoSimple: Producto
    {
        
        public int Cantidad { get; private set; }
        private string Tipo { get; set; }

        public ProductoSimple(string id, string nombre, decimal costo, decimal precio, string tipo) : base(id, nombre, costo, precio)
        {
            Cantidad = 0;
            Tipo = tipo;
        }

        public ProductoSimple()
        {
        }

        public string RegistrarEntrada(int cantidad)
        {
            if (cantidad >= 0)
            {
                this.Cantidad += cantidad;
                return $"{Nombre} Nueva cantidad: {Cantidad}";
            }
            return "Entrada menor o igual a 0";
        }

        public override string RegistrarSalida(int cantidad)
        {
            if (cantidad >= 0)
            {
                this.Cantidad -= cantidad;
                return $"Nueva salida: {Nombre}, cantidad:{cantidad}, costo:{Costo.ToString("C2")}, precio:{Precio.ToString("C2")}";
            }
            return "Salida menor o igual a 0";
        }

        public override decimal getCosto()
        {
            return Costo;
        }
    }
}
