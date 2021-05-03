using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Base;

namespace ventas.domain
{
    public abstract class Producto: Entity<int>
    {
        public string Codigo { get; private set; }
        public string Nombre { get; protected set; }
        protected decimal Costo { get; set; }
        public decimal Precio { get; protected set; }


        public Producto(string codigo, string nombre, decimal costo, decimal precio)
        {
            Codigo = codigo;
            Nombre = nombre;
            Costo = costo;
            Precio = precio;
        }

        public abstract string RegistrarSalida(int cantidad);


        public abstract decimal getCosto();

    }
}
