using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain;

namespace ventas.infrastructure
{
    public static class ProductoMother
    {
        public static Producto ProductoSalchicha(string codigo)
        {
            return new ProductoSimple(codigo, "Salchicha", 1000, 0, "Preparacion");
        }

        public static Producto ProductoCocacola(string codigo)
        {
            return new ProductoSimple(codigo, "Cocacola", 1000, 3000, "Venta");
        }

        public static Producto ProductoPan(string codigo)
        {
            return new ProductoSimple(codigo, "Pan", 500, 0, "Preparacion");
        }

    }
}
