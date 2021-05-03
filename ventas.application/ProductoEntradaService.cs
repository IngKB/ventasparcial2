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
        public UnitOfWork UnitOfWork { get; }
        public ProductoRepository ProductoRepository { get; }
        public ProductoEntradaService(UnitOfWork unitOfWork, ProductoRepository prodRepository)
        {
            UnitOfWork = unitOfWork;
            ProductoRepository = prodRepository;
        }



    }
}
