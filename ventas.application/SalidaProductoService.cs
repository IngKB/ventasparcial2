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

        public SalidaProductoResponse Ejecutar(SalidaProductoRequest request)
        {
            try
            {
                var prod = ProductoRepository.FindFirstOrDefault(prd => prd.Codigo == request.Codigo);
                if (prod == null)
                {
                    return new SalidaProductoResponse(1, "No se encuentra el producto");
                }
            Console.WriteLine(prod);
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
