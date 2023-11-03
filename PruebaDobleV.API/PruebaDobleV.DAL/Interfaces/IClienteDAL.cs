using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.DAL.Interfaces
{
    public interface IClienteDAL
    {
        public Task<List<EntityCliente>> GetAllClientesAsync();
        public Task<EntityCliente> GetClienteByIdAsync(int idCliente);
        public Task CreateCliente(EntityCliente entity);
        public Task UpdateCliente(EntityCliente entity);
    }
}
