using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using PruebaDobleV.Utility;

namespace PruebaDobleV.BL.DevLab
{
    public class TipoClienteBL : ITipoClienteBL
    {
        private readonly ITipoClienteDAL tipoClienteDAL;
        public TipoClienteBL(ITipoClienteDAL tipoClienteDAL)
        {
            this.tipoClienteDAL = tipoClienteDAL;
        }

        public async Task<EntityResult<List<EntityCatTipoCliente>>> GetAllTipoClientesAsync()
        {
            try
            {
                List<EntityCatTipoCliente> result = await tipoClienteDAL.GetAllTipoClientesAsync();

                if (result != null)
                    return EntityResult<List<EntityCatTipoCliente>>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<List<EntityCatTipoCliente>>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityResult<EntityCatTipoCliente>> GetTipoClienteByIdAsync(int idTipoCliente)
        {
            try
            {
                EntityCatTipoCliente result = await tipoClienteDAL.GetTipoClienteByIdAsync(idTipoCliente);

                if (result != null)
                    return EntityResult<EntityCatTipoCliente>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<EntityCatTipoCliente>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CreateTipoCliente(EntityCatTipoCliente dto)
        {
            try
            {
                var result = tipoClienteDAL.CreateTipoCliente(dto);

                return "Tipo Cliente creado con exito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string UpdateTipoCliente(EntityCatTipoCliente dto)
        {
            try
            {
                var result = tipoClienteDAL.UpdateTipoCliente(dto);

                return "Tipo Cliente actualizado con exito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
