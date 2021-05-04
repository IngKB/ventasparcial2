using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Base;

namespace ventas.domain
{
    public abstract class Producto: Entity<int>, IAggregateRoot
    {
        public string Codigo { get; private set; }
        public string Nombre { get; protected set; }
        public decimal Costo { get; protected set; }
        public decimal Precio { get; protected set; }
        public ProductoCompuesto ProductoPadre { get; private set; }


        protected Producto(string codigo, string nombre, decimal costo, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Costo = costo;
            Precio = precio;
        }

        protected Producto()
        {
        }

        public abstract string RegistrarSalida(int cantidad);


        public abstract decimal getCosto();

    }
}
