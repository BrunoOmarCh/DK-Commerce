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
    public class ContactoClienteDA: ConfigDataAccess
    {
        public const string UpContactoClienteInsert = "UpContactoClienteInsert";
        public const string UpContactoClienteUpdate = "UpContactoClienteUpdate";
        public const string UpContactoClienteDelete = "UpContactoClienteDelete";
        public const string UpContactoClienteSelById = "UpContactoClienteSelById";

        public ContactoClienteBE SelectById(int ContactoClienteId)
        {
            ContactoClienteBE beContactoCliente = null;
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
                        sqlCmd.CommandText = UpContactoClienteInsert;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = ContactoClienteId;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beContactoCliente = new ContactoClienteBE();

                            beContactoCliente.ContactoId = ContactoClienteId;
                            beContactoCliente.NombreContacto = dr["NombreContacto"] == DBNull.Value ? null : Convert.ToString(dr["NombreContacto"])!;
                            beContactoCliente.CargoContacto = dr["CargoContacto"] == DBNull.Value ? null : Convert.ToString(dr["CargoContacto"])!;
                            beContactoCliente.TipoDocumento= dr["TipoDocumento"] == DBNull.Value ? null : Convert.ToString(dr["TipoDocumento"])!;
                            beContactoCliente.NroDocumento= dr["NroDocumento"] == DBNull.Value ? null : Convert.ToString(dr["NroDocumento"])!;

                        }

                        return beContactoCliente;
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


        public void Insert(ContactoClienteBE beContactoCliente)
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
                            sqlCmd.CommandText = UpContactoClienteInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@NombreContacto", SqlDbType.NVarChar).Value = beContactoCliente.NombreContacto ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@CargoContacto", SqlDbType.NVarChar).Value = beContactoCliente.CargoContacto ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.NVarChar).Value = beContactoCliente.TipoDocumento ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@NroDocumento", SqlDbType.NVarChar).Value = beContactoCliente.NroDocumento ?? (object)DBNull.Value;

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


        public void Update(int idContactoCliente, ContactoClienteBE beContactoCliente)
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
                            sqlCmd.CommandText = UpContactoClienteUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = idContactoCliente;
                            sqlCmd.Parameters.Add("@NombreContacto", SqlDbType.NVarChar).Value =
                                beContactoCliente.NombreContacto != null ? (object)beContactoCliente.NombreContacto : DBNull.Value;
                            sqlCmd.Parameters.Add("@CargoContacto", SqlDbType.NVarChar).Value =
                                beContactoCliente.CargoContacto != null ? (object)beContactoCliente.CargoContacto : DBNull.Value;
                            sqlCmd.Parameters.Add("@TipoDocumento", SqlDbType.NVarChar).Value =
                                beContactoCliente.TipoDocumento != null ? (object)beContactoCliente.TipoDocumento : DBNull.Value;
                            sqlCmd.Parameters.Add("@NroDocumento", SqlDbType.NVarChar).Value =
                                beContactoCliente.NroDocumento != null ? (object)beContactoCliente.NroDocumento : DBNull.Value;

                            // Ejecutar la consulta
                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit(); // Confirmar la transacción
                        }
                        catch (Exception)
                        {
                            sqlTran?.Rollback(); // Rollback en caso de error
                            throw;
                        }
                    }
                }
            }
        }

        public void Delete(int idContactoCliente)
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
                            sqlCmd.CommandText = UpContactoClienteDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = idContactoCliente;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception)
                        {
                            sqlTran?.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
