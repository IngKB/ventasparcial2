using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Contracts;

namespace ventas.application.test.Dobles
{
    class UnitOfWorkFake : IUnitOfWork
    {
        public void Commit()
        {
        }

    }
}
