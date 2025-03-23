using DKCommerceBussinesEntity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria;

namespace DKCommerceDataAccess
{
    public class ClienteDA : ConfigDataAccess
    {
        public const string UpClienteInsert = "UpClienteInsert";
        public const string UpClienteUpdate = "UpClienteUpdate";
        public const string UpClienteDelete = "UpClienteDelete";
        public const string UpClienteSelById = "UpClienteSelById";


        public ClienteBE SelectById(string clienteId)
        {
            ClienteBE becliente = null;
            var conn = Configuration.GetConnectionString("DK Commerce");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = UpClienteSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = clienteId;
                        dr = sqlCmd.ExecuteReader();

                        while (dr.Read())
                        {
                            becliente = new ClienteBE
                            {
                                ClienteId = clienteId,
                                NombreRazonSocial = dr["NombreRazonSocial"]?.ToString(),
                                TipoDocumento = dr["TipoDocumento"] == DBNull.Value ? null : dr["TipoDocumento"].ToString(),
                                NroDocumento = dr["NroDocumento"] == DBNull.Value ? null : dr["NroDocumento"].ToString(),
                                ContactoId = dr["ContactoId"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["ContactoId"]),
                                Direccion = dr["Direccion"] == DBNull.Value ? null : dr["Direccion"].ToString(),
                                Ciudad = dr["Ciudad"] == DBNull.Value ? null : dr["Ciudad"].ToString(),
                                Region = dr["Region"] == DBNull.Value ? null : dr["Region"].ToString(),
                                CodPostal = dr["CodPostal"] == DBNull.Value ? null : dr["CodPostal"].ToString(),
                                Pais = dr["Pais"] == DBNull.Value ? null : dr["Pais"].ToString(),
                                Telefono = dr["Telefono"] == DBNull.Value ? null : dr["Telefono"].ToString(),
                                Fax = dr["Fax"] == DBNull.Value ? null : dr["Fax"].ToString()
                            };
                        }

                        return becliente;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        dr?.Close();
                        dr?.Dispose();
                    }
                }
            }
        }

    }
}
