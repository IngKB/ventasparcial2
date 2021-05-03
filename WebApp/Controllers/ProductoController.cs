using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ventas.application;
using ventas.domain.Contracts;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductoRepository _productoRepository;
        public ProductoController
            (IUnitOfWork unitOfWork,
            IProductoRepository productoRepository)
        {

            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;

            //if (!_productoRepository.GetAll().Any())
            //{
            //    var cuenta = new CuentaAhorro("10001", "Cuenta ejemplo", "VALLEDUPAR", "cliente@bancoacme.com");
            //    cuentaBancariaRepository.Add(cuenta);
            //    unitOfWork.Commit();
            //}
        }

        [HttpPost("entrada")]
        public EntradaProductoResponse PostEntradaProducto(EntradaProductoRequest request)
        {
            var service = new ProductoEntradaService(_unitOfWork, _productoRepository);
            var response = service.Ejecutar(request);
            return response;
        }

        [HttpPost("salida")]
        public SalidaProductoResponse PostSalidaProducto(SalidaProductoRequest request)
        {
            var service = new SalidaProductoService(_unitOfWork, _productoRepository);
            var response = service.Ejecutar(request);
            return response;
        }

    }
}
