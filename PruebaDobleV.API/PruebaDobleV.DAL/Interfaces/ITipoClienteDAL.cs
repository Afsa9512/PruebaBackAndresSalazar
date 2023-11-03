using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.DAL.Interfaces
{
    public interface ITipoClienteDAL
    {
        public Task<List<EntityCatTipoCliente>> GetAllTipoClientesAsync();
        public Task<EntityCatTipoCliente> GetTipoClienteByIdAsync(int idTipoCliente);
        public Task CreateTipoCliente(EntityCatTipoCliente entity);
        public Task UpdateTipoCliente(EntityCatTipoCliente entity);
    }
}
