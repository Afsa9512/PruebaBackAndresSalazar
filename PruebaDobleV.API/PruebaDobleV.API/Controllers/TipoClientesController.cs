using Microsoft.AspNetCore.Mvc;
using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoClientesController : ControllerBase
    {
        private ITipoClienteBL _actionBL_TipoCliente;

        public TipoClientesController(ITipoClienteBL actionBL_TipoCliente)
        {
            _actionBL_TipoCliente = actionBL_TipoCliente;
        }

        [HttpGet]
        public async Task<List<EntityCatTipoCliente>> GetAllTipoClientes()
        {
            var tipoClientes = await _actionBL_TipoCliente.GetAllTipoClientesAsync();

            return tipoClientes.Data;
        }

        [HttpGet("GetTipoClienteById")]
        public async Task<EntityCatTipoCliente> GetTipoClienteById(int idCliente)
        {
            var cliente = await _actionBL_TipoCliente.GetTipoClienteByIdAsync(idCliente);

            return cliente.Data;
        }

        [HttpPost]
        public async Task<JsonResult> CreateTipoCliente(EntityCatTipoCliente dto)
        {
            var result = _actionBL_TipoCliente.CreateTipoCliente(dto);

            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateTipoCliente(EntityCatTipoCliente dto)
        {
            var result = _actionBL_TipoCliente.UpdateTipoCliente(dto);

            return new JsonResult(result);
        }
    }
}
