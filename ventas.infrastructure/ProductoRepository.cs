using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ventas.domain;
using ventas.domain.Contracts;
using Microsoft.EntityFrameworkCore;


namespace ventas.infrastructure
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        protected readonly DbSet<ProductoCompuesto> _dbsetCompuesto;
        public ProductoRepository(IDbContext context) : base(context)
        {
            _dbsetCompuesto = context.Set<ProductoCompuesto>();
        }
        public Producto FindFirstOrDefaultIncluded(Expression<Func<Producto, bool>> predicate)
        {
            return _dbsetCompuesto.Include(a=>a.Productos).FirstOrDefault(predicate);
        }
    }
}
