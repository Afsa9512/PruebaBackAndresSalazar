using PruebaDobleV.DAL.Connection;
using PruebaDobleV.DAL.Interfaces;
using PruebaDobleV.Entities.DevLabEntity;
using System.Data;
using System.Data.SqlClient;

namespace PruebaDobleV.DAL.DevLab
{
    public class FacturaDAL : IFacturaDAL
    {
        public async Task<List<EntityFactura>> GetAllFacturasAsync()
        {
            try
            {
                List<EntityFactura> listFacturas = new List<EntityFactura>();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetAllFacturas", ref mensajeDeError);

                foreach (DataRow item in data.Rows)
                {
                    EntityFactura factura = new EntityFactura
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        FechaFactura = Convert.ToDateTime(item["FechaEmisionFactura"]),
                        IdCliente = Convert.ToInt32(item["IdCliente"]),
                        NumeroFactura = Convert.ToInt32(item["NumeroFactura"]),
                        NumeroTotalArticulos = Convert.ToInt32(item["NumeroTotalArticulos"]),
                        SubTotalFactura = Convert.ToDecimal(item["SubTotalFactura"]),
                        TotalImpuesto = Convert.ToDecimal(item["TotalImpuesto"]),
                        TotalFactura = Convert.ToDecimal(item["TotalFactura"]),
                    };
                    listFacturas.Add(factura);
                }

                return listFacturas;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<EntityFactura>> GetFacturaByFilterAsync(int filter)
        {
            try
            {
                List<EntityFactura> listFacturas = new List<EntityFactura>();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "filter",Value = filter }
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetFacturaByFilter", ref mensajeDeError, parameters);

                foreach (DataRow item in data.Rows)
                {
                    EntityFactura factura = new EntityFactura()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        FechaFactura = Convert.ToDateTime(item["FechaEmisionFactura"]),
                        IdCliente = Convert.ToInt32(item["IdCliente"]),
                        NumeroFactura = Convert.ToInt32(item["NumeroFactura"]),
                        NumeroTotalArticulos = Convert.ToInt32(item["NumeroTotalArticulos"]),
                        SubTotalFactura = Convert.ToDecimal(item["SubTotalFactura"]),
                        TotalImpuesto = Convert.ToDecimal(item["TotalImpuesto"]),
                        TotalFactura = Convert.ToDecimal(item["TotalFactura"])
                    };
                    listFacturas.Add(factura);
                }

                return listFacturas;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CreateFactura(EntityFactura entity)
        {
            try
            {
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;
                string mensaje = string.Empty;
                int idFactura = 0;

                SqlParameter[] parameters = {
                    new SqlParameter {ParameterName = "FechaFactura", Value = DateTime.UtcNow},
                    new SqlParameter {ParameterName = "IdCliente", Value = entity.IdCliente},
                    new SqlParameter {ParameterName = "NumeroFactura", Value = entity.NumeroFactura},
                    new SqlParameter {ParameterName = "NumeroTotalArticulos", Value = entity.NumeroTotalArticulos},
                    new SqlParameter {ParameterName = "SubTotalFactura", Value = entity.SubTotalFactura},
                    new SqlParameter {ParameterName = "TotalImpuesto", Value = entity.TotalImpuesto},
                    new SqlParameter {ParameterName = "TotalFactura", Value = entity.TotalFactura},
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.CreateFactura", ref mensajeDeError, parameters);

                foreach (DataRow item in data.Rows)
                {
                    idFactura = Convert.ToInt32(item["IdFactura"]);
                }

                return idFactura;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EntityFactura> GetFacturaByNumeroAsync(int numeroFactura)
        {
            try
            {
                EntityFactura factura = new EntityFactura();
                AdminConection adminConection = new AdminConection();
                string mensajeDeError = string.Empty;

                SqlParameter[] parameters = {
                    new SqlParameter { ParameterName = "numeroFactura",Value = numeroFactura }
                };

                DataTable data = adminConection.ObtenerDataTable("DevLab.dbo.GetFacturaByNumero", ref mensajeDeError, parameters);

                foreach (DataRow item in data.Rows)
                {
                    factura = new EntityFactura()
                    {
                        Id = Convert.ToInt32(item["Id"]),
                        FechaFactura = Convert.ToDateTime(item["FechaEmisionFactura"]),
                        IdCliente = Convert.ToInt32(item["IdCliente"]),
                        NumeroFactura = Convert.ToInt32(item["NumeroFactura"]),
                        NumeroTotalArticulos = Convert.ToInt32(item["NumeroTotalArticulos"]),
                        SubTotalFactura = Convert.ToDecimal(item["SubTotalFactura"]),
                        TotalImpuesto = Convert.ToDecimal(item["TotalImpuesto"]),
                        TotalFactura = Convert.ToDecimal(item["TotalFactura"])
                    };
                }

                return factura;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
