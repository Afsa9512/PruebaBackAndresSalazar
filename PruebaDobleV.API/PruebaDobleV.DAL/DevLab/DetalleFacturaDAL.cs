using PruebaDobleV.DAL.Connection;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using System.Data;
using System.Data.SqlClient;

namespace PruebaDobleV.DAL.DevLab
{
    public class DetalleFacturaDAL : IDetalleFacturaDAL
    {
        public Task CreateDetalleFactura(EntityDetallesFactura entity)
        {
            try
            {
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter {ParameterName = "idFactura", Value = entity.IdFactura},
                    new SqlParameter {ParameterName = "idProducto", Value = entity.IdProducto},
                    new SqlParameter {ParameterName = "cantidadDeProducto", Value = entity.CantidadDeProducto},
                    new SqlParameter {ParameterName = "subTotal", Value = entity.SubtotalProducto},
                    new SqlParameter {ParameterName = "precioUnitario", Value = entity.PrecioUnitarioProducto},
                    new SqlParameter {ParameterName = "notas", Value = entity.Notas}
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.CreateDetalleFactura", ref mensajeDeError, parameters);

                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
