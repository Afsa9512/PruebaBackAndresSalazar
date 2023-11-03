using PruebaDobleV.DAL.Connection;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDobleV.DAL.DevLab
{
    public class TipoClienteDAL : ITipoClienteDAL
    {        
        public async Task<List<EntityCatTipoCliente>> GetAllTipoClientesAsync()
        {
            try
            {
                List<EntityCatTipoCliente> listTipoClientes = new List<EntityCatTipoCliente>();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetAllTipoClientes", ref mensajeDeError);

                foreach (DataRow item in data.Rows)
                {
                    EntityCatTipoCliente tipoCliente = new EntityCatTipoCliente
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        TipoCliente = item["TipoCliente"].ToString()
                    };
                    listTipoClientes.Add(tipoCliente);
                }

                return listTipoClientes;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityCatTipoCliente> GetTipoClienteByIdAsync(int idTipoCliente)
        {
            try
            {
                EntityCatTipoCliente tipoCliente = new EntityCatTipoCliente();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "IdCliente",Value = idTipoCliente }
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetClienteById", ref mensajeDeError, parameters);

                foreach (DataRow item in data.Rows)
                {
                    tipoCliente = new EntityCatTipoCliente()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        TipoCliente = item["TipoCliente"].ToString()
                    };
                }

                return tipoCliente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task CreateTipoCliente(EntityCatTipoCliente entity)
        {
            try
            {
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter {ParameterName = "TipoCliente", Value = entity.TipoCliente}
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.CreateTipoCliente", ref mensajeDeError, parameters);

                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Task UpdateTipoCliente(EntityCatTipoCliente entity)
        {
            try
            {
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter {ParameterName = "Id", Value = entity.Id},
                    new SqlParameter {ParameterName = "TipoCliente", Value = entity.TipoCliente}
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.UpdateTipoCliente", ref mensajeDeError, parameters);

                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
