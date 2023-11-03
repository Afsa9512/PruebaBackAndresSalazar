using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Entities.ViewModels;

namespace PruebaDobleV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private IFacturaBL _actionBL_Factura;
        private IConfiguration _configuration;

        public FacturasController(IFacturaBL actionBL_Factura, IConfiguration configuration)
        {
            _actionBL_Factura = actionBL_Factura;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<EntityFactura>> GetAllFacturas()
        {
            var facturas = await _actionBL_Factura.GetAllFacturasAsync();

            return facturas.Data;
        }

        [HttpGet("GetFacturaByFilter")]
        public async Task<List<EntityFactura>> GetFacturaByFilter(int filter)
        {
            var facturas = await _actionBL_Factura.GetFacturaByFilterAsync(filter);

            return facturas.Data;
        }

        [HttpGet("GetFacturaByNumero")]
        public async Task<EntityFactura> GetFacturaByNumero(int numeroFactura)
        {
            var facturas = await _actionBL_Factura.GetFacturaByNumeroAsync(numeroFactura);

            return facturas.Data;
        }

        [HttpPost]
        public async Task<JsonResult> CreateFactura(ViewModelFactura facturaVM)
        {
            var result = _actionBL_Factura.CreateFactura(facturaVM);

            return new JsonResult(result);
        }

    }
}
