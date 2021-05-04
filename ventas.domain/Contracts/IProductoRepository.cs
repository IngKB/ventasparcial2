using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Base;

namespace ventas.domain.Contracts
{
    public interface IProductoRepository : IGenericRepository<Producto>
    {
        public Producto FindFirstOrDefaultIncluded(Expression<Func<Producto, bool>> predicate);
    }
}
