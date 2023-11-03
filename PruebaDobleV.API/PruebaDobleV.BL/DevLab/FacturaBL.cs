using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.DAL.DevLab;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Entities.ViewModels;
using PruebaDobleV.Utility;

namespace PruebaDobleV.BL.DevLab
{
    public class FacturaBL : IFacturaBL
    {
        private readonly IFacturaDAL facturaDAL;
        private readonly IDetalleFacturaDAL detalleFacturaDAL;
        public FacturaBL(IFacturaDAL facturaDAL, IDetalleFacturaDAL detalleFacturaDAL)
        {
            this.facturaDAL = facturaDAL;
            this.detalleFacturaDAL = detalleFacturaDAL;
        }

        public async Task<EntityResult<List<EntityFactura>>> GetAllFacturasAsync()
        {
            try
            {
                List<EntityFactura> result = await facturaDAL.GetAllFacturasAsync();

                if (result != null)
                    return EntityResult<List<EntityFactura>>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<List<EntityFactura>>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityResult<List<EntityFactura>>> GetFacturaByFilterAsync(int filter)
        {
            try
            {
                List<EntityFactura> result = await facturaDAL.GetFacturaByFilterAsync(filter);

                if (result != null)
                    return EntityResult<List<EntityFactura>>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<List<EntityFactura>>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CreateFactura(ViewModelFactura model)
        {
            try
            {
                var result = facturaDAL.CreateFactura(model.EntityFactura);
                if (result != null && model.DetallesFactura.Count > 0)
                {
                    foreach (var detalle in model.DetallesFactura)
                    {
                        detalle.IdFactura = Convert.ToInt32(result.Result);
                        detalleFacturaDAL.CreateDetalleFactura(detalle);
                    }
                }

                return "Factura creada con exito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityResult<EntityFactura>> GetFacturaByNumeroAsync(int numeroFactura)
        {
            try
            {
                EntityFactura result = await facturaDAL.GetFacturaByNumeroAsync(numeroFactura);

                if (result != null)
                    return EntityResult<EntityFactura>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<EntityFactura>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
