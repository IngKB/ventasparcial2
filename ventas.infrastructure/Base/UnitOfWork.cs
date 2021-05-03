using System;
using System.Collections.Generic;
using System.Text;
using ventas.domain.Contracts;

namespace ventas.infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        public UnitOfWork(IDbContext context) => _context = context;

        public void Commit()
        {
            _context.SaveChanges();
        }

        
    }
}
