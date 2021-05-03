using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Base;

namespace ventas.domain.Contracts
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
    }
}
