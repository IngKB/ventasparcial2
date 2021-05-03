using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain.Contracts;

namespace ventas.application
{
    public class ProductoEntradaService
    {
        public IUnitOfWork UnitOfWork { get; }
        public IProductoRepository ProductoRepository { get; }
        public ProductoEntradaService(IUnitOfWork unitOfWork, IProductoRepository prodRepository)
        {
            UnitOfWork = unitOfWork;
            ProductoRepository = prodRepository;
        }

        public EntradaProductoResponse Ejecutar(EntradaProductoRequest request)
        {
            try
            {
                var prod = ProductoRepository.FindFirstOrDefault(prd => prd.Codigo == request.Codigo);
                if (prod == null)
                {
                    return new EntradaProductoResponse(1, "Se puede registrar un producto nuevo");
                }
                var respuesta = prod.RegistrarSalida(request.Cantidad);
                UnitOfWork.Commit();
                return new EntradaProductoResponse(0, respuesta);
            }
            catch (Exception e)
            {

                return new EntradaProductoResponse(1, "Error no se encontro el producto" );
            }
        }
    }

    public record EntradaProductoRequest(string Codigo , int Cantidad );

    public record EntradaProductoResponse(int Estado, string Mensaje);


}

