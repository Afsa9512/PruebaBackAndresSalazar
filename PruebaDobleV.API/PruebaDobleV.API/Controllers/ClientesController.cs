using Microsoft.AspNetCore.Mvc;
using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private IClienteBL _actionBL_Cliente;
        private IConfiguration _configuration;

        public ClientesController(IClienteBL actionBL_Cliente, IConfiguration configuration)
        {
            _actionBL_Cliente = actionBL_Cliente;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<EntityCliente>> GetAllClientes()
        {
            var clientes = await _actionBL_Cliente.GetAllClientesAsync();

            return clientes.Data;
        }

        [HttpGet("GetClienteById")]
        public async Task<EntityCliente> GetClienteById(int idCliente)
        {
            var cliente = await _actionBL_Cliente.GetClienteByIdAsync(idCliente);

            return cliente.Data;
        }

        [HttpPost]
        public async Task<JsonResult> CreateCliente(EntityCliente dto)
        {
            var result = _actionBL_Cliente.CreateCliente(dto);

            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateCliente(EntityCliente dto)
        {
            var result = _actionBL_Cliente.UpdateCliente(dto);

            return new JsonResult(result);
        }

    }
}
