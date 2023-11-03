using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Entities.ViewModels;

namespace PruebaDobleV.BL.Interfaces
{
    public interface IFacturaBL
    {
        public Task<EntityResult<List<EntityFactura>>> GetAllFacturasAsync();
        public Task<EntityResult<List<EntityFactura>>> GetFacturaByFilterAsync(int filter);
        public Task<EntityResult<EntityFactura>> GetFacturaByNumeroAsync(int numeroFactura);
        public string CreateFactura(ViewModelFactura model);
    }
}
