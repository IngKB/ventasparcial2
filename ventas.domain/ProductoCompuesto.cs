using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Base;

namespace ventas.domain
{
    public class ProductoCompuesto : Producto
    {

        public List<Producto> Productos { get; private set; }

        public ProductoCompuesto(string id, string nombre, decimal precio, List<Producto> productos) : base(id, nombre, 0, precio)
        {
            Productos = productos;
            getCosto();
        }

        private ProductoCompuesto()
        {
        }

        public override string RegistrarSalida(int cantidad)
        {
            if (cantidad >0)
            {
                var precioTotal = cantidad * Precio;
                foreach (var item in Productos)
                {
                    item.RegistrarSalida(cantidad);
                }

                return $"Nueva salida: {Nombre}, cantidad:{cantidad}, costo_total:{Costo.ToString("C2", new CultureInfo("es-CO"))}, " +
                    $"precio_total:{precioTotal.ToString("C2", new CultureInfo("es-CO"))}";
            }
            return $"Cantidad debe ser mayor a 0";

        }

        public override decimal getCosto()
        {
            decimal total = 0;
            foreach (var item in Productos)
            {
                total += item.getCosto();
            }
            this.Costo = total;
            return total;
        }
    }
}
