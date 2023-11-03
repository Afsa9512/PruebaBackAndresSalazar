using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.DAL.Interfaces
{
    public interface IDetalleFacturaDAL
    {
        public Task CreateDetalleFactura(EntityDetallesFactura entity);
    }
}
