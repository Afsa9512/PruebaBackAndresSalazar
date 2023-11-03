using PruebaDobleV.BL.DevLab;
using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.DAL.DevLab;
using PruebaDobleV.DAL.Interfaces;

namespace PruebaDobleV.API.Extensions
{
    public static class DevLabExtensions
    {
        public static void configureExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IClienteBL, ClienteBL>();
            builder.Services.AddTransient<IClienteDAL, ClienteDAL>();
            builder.Services.AddTransient<ITipoClienteBL, TipoClienteBL>();
            builder.Services.AddTransient<ITipoClienteDAL, TipoClienteDAL>();
            builder.Services.AddTransient<IProductoBL, ProductoBL>();
            builder.Services.AddTransient<IProductoDAL, ProductoDAL>();
            builder.Services.AddTransient<IFacturaBL, FacturaBL>();
            builder.Services.AddTransient<IFacturaDAL, FacturaDAL>();
            builder.Services.AddTransient<IDetalleFacturaDAL, DetalleFacturaDAL>();
        }
    }
}
