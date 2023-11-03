using PruebaDobleV.BL.Interfaces;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Utility;
using PruebaDobleV.Entities.DevLabEntity;

namespace PruebaDobleV.BL.DevLab
{
    public class ClienteBL : IClienteBL
    {
        private readonly IClienteDAL clienteDAL;
        public ClienteBL(IClienteDAL clienteDAL)
        {
            this.clienteDAL = clienteDAL;
        }

        public async Task<EntityResult<List<EntityCliente>>> GetAllClientesAsync()
        {
            try
            {
                List<EntityCliente> result = await clienteDAL.GetAllClientesAsync();

                if (result != null)
                    return EntityResult<List<EntityCliente>>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<List<EntityCliente>>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityResult<EntityCliente>> GetClienteByIdAsync(int idCliente)
        {
            try
            {
                EntityCliente result = await clienteDAL.GetClienteByIdAsync(idCliente);

                if (result != null)
                    return EntityResult<EntityCliente>.SuccessResult(true, System.Net.HttpStatusCode.OK, result, string.Empty);
                else
                    return EntityResult<EntityCliente>.WrongResult(System.Net.HttpStatusCode.NotFound, Utilidades.GetNotFoundListError());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string CreateCliente(EntityCliente dto)
        {
            try
            {
                var result = clienteDAL.CreateCliente(dto);

                return "Cliente creado con exito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string UpdateCliente(EntityCliente dto)
        {
            try
            {
                var result = clienteDAL.UpdateCliente(dto);

                return "Cliente actualizado con exito.!";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
