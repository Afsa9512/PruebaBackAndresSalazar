using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.BL.Interfaces
{
    public interface IClienteBL
    {
        public Task<EntityResult<List<EntityCliente>>> GetAllClientesAsync();
        public Task<EntityResult<EntityCliente>> GetClienteByIdAsync(int idCliente);
        public string CreateCliente(EntityCliente dto);
        public string UpdateCliente(EntityCliente dto);
    }
}
