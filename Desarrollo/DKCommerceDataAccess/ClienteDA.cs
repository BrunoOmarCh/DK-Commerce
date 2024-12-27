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

        public void Insert(ClienteBE becliente)
        {
            if (string.IsNullOrEmpty(becliente.NombreRazonSocial))
            {
                throw new ArgumentException("El campo 'NombreRazonSocial' no puede ser nulo ni vacío.");
            }
            var conn = Configuration.GetConnectionString("DK Commerce");

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpClienteInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@NombreRazonSocial", SqlDbType.NVarChar).Value = becliente.NombreRazonSocial;
                            sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.NVarChar).Value = becliente.TipoDocumento ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@NroDocumento", SqlDbType.NVarChar).Value = becliente.NroDocumento ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = becliente.ContactoId ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = becliente.Direccion ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = becliente.Ciudad ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value = becliente.Region ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = becliente.CodPostal ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = becliente.Pais ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = becliente.Telefono ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = becliente.Fax ?? (object)DBNull.Value;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            sqlTran?.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        public void Update(string clienteId, ClienteBE becliente)
        {
            if (string.IsNullOrEmpty(becliente.NombreRazonSocial))
            {
                throw new ArgumentException("El campo 'NombreRazonSocial' no puede ser nulo ni vacío.");
            }

            var conn = Configuration.GetConnectionString("DK Commerce");

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpClienteUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = clienteId;
                            sqlCmd.Parameters.Add("@NombreRazonSocial", SqlDbType.NVarChar).Value =
                                becliente.NombreRazonSocial;
                            sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.NVarChar).Value =
                                becliente.TipoDocumento != null ? (object)becliente.TipoDocumento : DBNull.Value;
                            sqlCmd.Parameters.Add("@NroDocumento", SqlDbType.NVarChar).Value =
                                becliente.NroDocumento != null ? (object)becliente.NroDocumento : DBNull.Value;
                            sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value =
                                becliente.ContactoId != null ? (object)becliente.ContactoId : DBNull.Value;
                            sqlCmd.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value =
                                becliente.Direccion != null ? (object)becliente.Direccion : DBNull.Value;
                            sqlCmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value =
                                becliente.Ciudad != null ? (object)becliente.Ciudad : DBNull.Value;
                            sqlCmd.Parameters.Add("@Region", SqlDbType.NVarChar).Value =
                                becliente.Region != null ? (object)becliente.Region : DBNull.Value;
                            sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value =
                                becliente.CodPostal != null ? (object)becliente.CodPostal : DBNull.Value;
                            sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value =
                                becliente.Pais != null ? (object)becliente.Pais : DBNull.Value;
                            sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value =
                                becliente.Telefono != null ? (object)becliente.Telefono : DBNull.Value;
                            sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value =
                                becliente.Fax != null ? (object)becliente.Fax : DBNull.Value;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            sqlTran?.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }


        public void Delete(string clienteId)
        {
            var conn = Configuration.GetConnectionString("DK Commerce");

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpClienteDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ClienteId", SqlDbType.NVarChar).Value = clienteId;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            sqlTran?.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }
    }
}
