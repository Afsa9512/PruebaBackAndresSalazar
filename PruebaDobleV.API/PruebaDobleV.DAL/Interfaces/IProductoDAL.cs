using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Entities.ViewModels;

namespace PruebaDobleV.DAL.Interfaces
{
    public interface IProductoDAL
    {
        public Task<List<EntityCatProducto>> GetAllProductosAsync();
        public Task<ProductoViewModel> GetProductoByIdAsync(int idProducto);
        public Task CreateProducto(EntityCatProducto entity, byte[] imagen);
        public Task UpdateProducto(EntityCatProducto entity);
    }
}
