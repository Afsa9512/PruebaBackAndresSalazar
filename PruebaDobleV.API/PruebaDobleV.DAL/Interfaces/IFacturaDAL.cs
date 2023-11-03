using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.DAL.Interfaces
{
    public interface IFacturaDAL
    {
        public Task<List<EntityFactura>> GetAllFacturasAsync();
        public Task<List<EntityFactura>> GetFacturaByFilterAsync(int filter);
        public Task<EntityFactura> GetFacturaByNumeroAsync(int numeroFactura);
        public Task<int> CreateFactura(EntityFactura entity);
    }
}
