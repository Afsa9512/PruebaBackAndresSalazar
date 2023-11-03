using PruebaDobleV.DAL.Connection;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using System.Data;
using System.Data.SqlClient;

namespace PruebaDobleV.DAL.DevLab
{
    public class ClienteDAL : IClienteDAL
    {
        public async Task<List<EntityCliente>> GetAllClientesAsync()
        {
            try
            {
                List<EntityCliente> listClientes = new List<EntityCliente>();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetAllClientes", ref mensajeDeError);

                foreach (DataRow item in data.Rows)
                {
                    EntityCliente cliente = new EntityCliente
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        RazonSocial = item["RazonSocial"].ToString(),
                        IdTipoCliente = Convert.ToInt32(item["IdTipoCliente"]),
                        TipoCliente = item["TipoCliente"].ToString(),
                        FechaCreacion = Convert.ToDateTime(item["FechaCreacion"]),
                        RFC = item["RFC"].ToString(),
                    };
                    listClientes.Add(cliente);
                }

                return listClientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityCliente> GetClienteByIdAsync(int idCliente)
        {
            try
            {
                EntityCliente cliente = new EntityCliente();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "IdCliente",Value = idCliente }
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetClienteById", ref mensajeDeError, parameters);

                foreach (DataRow item in data.Rows)
                {
                    cliente = new EntityCliente()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        RazonSocial = item["RazonSocial"].ToString(),
                        IdTipoCliente = Convert.ToInt32(item["IdTipoCliente"]),
                        TipoCliente = item["TipoCliente"].ToString(),
                        FechaCreacion = Convert.ToDateTime(item["FechaCreacion"]),
                        RFC = item["RFC"].ToString(),
                    };
                }

                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task CreateCliente(EntityCliente entity)
        {
            try
            {
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter {ParameterName = "RazonSocial", Value = entity.RazonSocial},
                    new SqlParameter {ParameterName = "IdTipoCliente", Value = entity.IdTipoCliente},
                    new SqlParameter {ParameterName = "FechaCreacion", Value = DateTime.UtcNow.Date},
                    new SqlParameter {ParameterName = "RFC", Value = entity.RFC},
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.CreateCliente", ref mensajeDeError, parameters);

                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task UpdateCliente(EntityCliente dto)
        {
            try
            {
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "IdCliente", Value = dto.Id},
                    new SqlParameter { ParameterName = "IdTipoCliente", Value = dto.IdTipoCliente},
                    new SqlParameter {ParameterName = "RazonSocial", Value = dto.RazonSocial},
                    new SqlParameter {ParameterName = "RFC", Value = dto.RFC}
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.UpdateCliente", ref mensajeDeError, parameters);

                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
