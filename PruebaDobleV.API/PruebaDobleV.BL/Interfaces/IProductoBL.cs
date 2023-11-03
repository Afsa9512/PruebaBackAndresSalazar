using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Entities.ViewModels;

namespace PruebaDobleV.BL.Interfaces
{
    public interface IProductoBL
    {
        public Task<EntityResult<List<EntityCatProducto>>> GetAllProductosAsync();
        public Task<EntityResult<ProductoViewModel>> GetProductoByIdAsync(int idProducto);
        public string CreateProducto(EntityCatProducto dto, byte[] imagen);
        public string UpdateProducto(EntityCatProducto dto);
    }
}
