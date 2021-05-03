using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain;
using ventas.domain.Contracts;

namespace ventas.infrastructure
{
    public class ProductoSimpleRepository : GenericRepository<ProductoSimple>, IProductoSimpleRepository
    {
        public ProductoSimpleRepository(IDbContext context) : base(context)
        {
        }
    }

   
}
