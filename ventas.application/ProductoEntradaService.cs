using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure;

namespace ventas.application
{
    public class ProductoEntradaService
    {
        public ProductoEntradaService(UnitOfWork unitOfWork, CuentaBancariaRepository cuentaBancariaRepository, MailServerSpy mailServerSpy)
        {
            UnitOfWork = unitOfWork;
            CuentaBancariaRepository = cuentaBancariaRepository;
            MailServerSpy = mailServerSpy;
        }

        public UnitOfWork UnitOfWork { get; }
        public CuentaBancariaRepository CuentaBancariaRepository { get; }
        public MailServerSpy MailServerSpy { get; }
    }
}
