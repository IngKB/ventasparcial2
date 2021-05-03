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

        public EntradaProductoResponse Ejecutar(SalidaProductoRequest request)
        {
            try
            {
                var prod = ProductoRepository.FindFirstOrDefault(prd => prd.Codigo == request.Codigo);
                if (prod == null)
                {
                    return new EntradaProductoResponse(1, "Se puede registrar un producto nuevo");
                }
                Console.WriteLine(prod);
                var respuesta = prod.RegistrarSalida(request.Cantidad);
                UnitOfWork.Commit();
                return new EntradaProductoResponse(0, respuesta);
            }
            catch (Exception e)
            {
                return new EntradaProductoResponse(1, "Error " + e);
            }
        }
    }


    public record EntradaProductoResponse(int Estado, string Mensaje);


}

