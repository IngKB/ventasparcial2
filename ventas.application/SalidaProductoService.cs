using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.infrastructure;

namespace ventas.application
{
    public class SalidaProductoService
    {
        public UnitOfWork UnitOfWork { get; }
        public ProductoRepository ProductoRepository { get; }
        public SalidaProductoService(UnitOfWork unitOfWork, ProductoRepository prodRepository)
        {
            UnitOfWork = unitOfWork;
            ProductoRepository = prodRepository;
        }

    }
}
