using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ventas.domain;
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
                    return new EntradaProductoResponse(1, "No se encontro el producto");
                }
                if(prod is ProductoSimple)
                {
                    var prodSimple = (ProductoSimple)prod;
                    var respuesta = prodSimple.RegistrarEntrada(request.Cantidad);
                    UnitOfWork.Commit();
                    return new EntradaProductoResponse(0, respuesta);
                }
                return new EntradaProductoResponse(1, "No se puede registrar entrada de productos compuestos");

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

