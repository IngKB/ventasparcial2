using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ventas.domain
{
    public abstract class Producto
    {
        private string Id { get; set; }
        public string Nombre { get; protected set; }
        protected decimal Costo { get; set; }
        public decimal Precio { get; protected set; }


        public Producto(string id, string nombre, decimal costo, decimal precio)
        {
            Id = id;
            Nombre = nombre;
            Costo = costo;
            Precio = precio;
        }

        public abstract string RegistrarSalida(int cantidad);


        public abstract decimal getCosto();

    }
}
