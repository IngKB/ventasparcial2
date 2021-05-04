using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ventas.domain;
using ventas.domain.Contracts;

namespace ventas.application.test.Dobles
{
    public class ProductoRepositoryStub : IProductoRepository
    {
        public void Add(Producto entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<Producto> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(Producto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<Producto> entities)
        {
            throw new NotImplementedException();
        }

        public Producto Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> FindBy(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> FindBy(Expression<Func<Producto, bool>> filter = null, Func<IQueryable<Producto>, IOrderedQueryable<Producto>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Producto FindFirstOrDefault(Expression<Func<Producto, bool>> predicate)
        {
            return new ProductoSimple("001", "Pan", 500m, 0m, "Preparacion");
        }

        public Producto FindFirstOrDefaultIncluded(Expression<Func<Producto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
