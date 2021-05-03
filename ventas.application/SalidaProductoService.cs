using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Contracts;

namespace ventas.application
{
    public class SalidaProductoService
    {
        public IUnitOfWork UnitOfWork { get; }
        public IProductoRepository ProductoRepository { get; }
        public SalidaProductoService(IUnitOfWork unitOfWork, IProductoRepository prodRepository)
        {
            UnitOfWork = unitOfWork;
            ProductoRepository = prodRepository;
        }

        public SalidaProductoResponse Ejecutar(SalidaProductoRequest request)
        {
            try
            {
                var prod = ProductoRepository.FindFirstOrDefault(prd => prd.Codigo == request.Codigo);
                if (prod == null)
                {
                    return new SalidaProductoResponse(1, "No se encuentra el producto");
                }
                var respuesta = prod.RegistrarSalida(request.Cantidad);
                UnitOfWork.Commit();
                return new SalidaProductoResponse(0, respuesta);
            }
            catch (Exception e)
            {
                return new SalidaProductoResponse(1, "Error " + e);
            }
        }
    }

    public record SalidaProductoRequest(string Codigo, int Cantidad);
    public record SalidaProductoResponse(int Estado, string Mensaje);
}
