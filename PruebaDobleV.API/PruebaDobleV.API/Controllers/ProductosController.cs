using Microsoft.AspNetCore.Mvc;
using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Entities.ViewModels;

namespace PruebaDobleV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IProductoBL _actionBL_Producto;
        private IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public ProductosController(IProductoBL actionBL_Producto, IConfiguration configuration, IWebHostEnvironment env)
        {
            _actionBL_Producto = actionBL_Producto;
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public async Task<List<EntityCatProducto>> GetAllProductos()
        {
            var productos = await _actionBL_Producto.GetAllProductosAsync();

            return productos.Data;
        }

        [HttpGet("GetProductoById")]
        public async Task<EntityCatProducto> GetProductoById(int idProducto)
        {
            var producto = await _actionBL_Producto.GetProductoByIdAsync(idProducto);
            EntityCatProducto entity = new EntityCatProducto();
            entity.Id = producto.Data.Id;
            entity.NombreProducto = producto.Data.NombreProducto;
            entity.ImagenProducto = producto.Data.ImagenProducto == null ? string.Empty : "data:image/png;base64," + Convert.ToBase64String(producto.Data.ImagenProducto);
            entity.PrecioUnitario = producto.Data.PrecioUnitario;
            entity.Ext = producto.Data.Ext;
            return entity;
        }

        [HttpPost]
        public async Task<JsonResult> CreateProducto(EntityCatProducto dto)
        {
            string rutaRaiz = _env.ContentRootPath;

            string rutaCompleta = $"{rutaRaiz}Imagenes\\{dto.ImagenProducto}";

            byte[] imagen = System.IO.File.ReadAllBytes(rutaCompleta);

            if (System.IO.File.Exists(rutaCompleta))
            {
                try
                {
                    // Eliminar el archivo
                    System.IO.File.Delete(rutaCompleta);
                }
                catch (IOException e)
                {
                    Console.WriteLine("Ocurrió un error al intentar eliminar el archivo: " + e.Message);
                }
            }

            var result = _actionBL_Producto.CreateProducto(dto, imagen);

            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateProductoAsync(EntityCatProducto dto)
        {
            var result = _actionBL_Producto.UpdateProducto(dto);

            return new JsonResult(result);
        }

        [HttpPost, Route("cargar-imagen")]
        public Task<ImagenViewModel> UploadOneFile(IFormFile file)
        {
            ImagenViewModel respuesta = new();
            try
            {
                var uploadDate = DateTime.Now;
                var uploadGuid = Guid.NewGuid();

                string NombreCarpeta = $"\\Imagenes";

                string RutaRaiz = _env.ContentRootPath;

                string RutaCompleta = RutaRaiz + NombreCarpeta;

                if (!Directory.Exists(RutaCompleta))
                {
                    Directory.CreateDirectory(RutaCompleta);
                }

                if (file.Length > 0)
                {
                    string NombreArchivo = file.FileName;

                    string RutaFullCompleta = Path.Combine(RutaCompleta, NombreArchivo);

                    using (var stream = new FileStream(RutaFullCompleta, FileMode.Create))
                    {
                        file.CopyTo(stream);

                        respuesta.RutaImagen = file.FileName;
                    }
                }
            }
            catch (Exception e)
            {
                respuesta.RutaImagen = string.Empty;
            }

            return Task.FromResult(respuesta);
        }
    }
}
