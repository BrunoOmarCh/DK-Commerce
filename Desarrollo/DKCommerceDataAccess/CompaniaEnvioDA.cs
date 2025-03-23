using DKCommerceBussinesEntity;
using Libreria;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DKCommerceDataAccess
{
    public class CompaniaEnvioDA : ConfigDataAccess
    {
        public const string UpCompaniaEnvioInsert = "UpCompaniaEnvioInsert";
        public const string UpCompaniaEnvioUpdate = "UpCompaniaEnvioUpdate";
        public const string UpCompaniaEnvioDelete = "UpCompaniaEnvioDelete";
        public const string UpCompaniaEnvioSelById = "UpCompaniaEnvioSelById";

        public CompaniaEnvioBE SelectById(int idCompaniaEnvio)
        {
            CompaniaEnvioBE beCompaniaEnvio = null;
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
                        sqlCmd.CommandText = UpCompaniaEnvioSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@CompañiaDeEnvioId", SqlDbType.Int).Value = idCompaniaEnvio;
                        dr = sqlCmd.ExecuteReader();

                        while (dr.Read())
                        {
                            beCompaniaEnvio = new CompaniaEnvioBE
                            {
                                CompañiaDeEnvioId = idCompaniaEnvio,
                                NombreCompañia = dr["NombreCompañia"]?.ToString(),
                                Ruc = dr["Ruc"] == DBNull.Value ? null : Convert.ToString(dr["Ruc"])!,
                                Telefono = dr["Telefono"] == DBNull.Value ? null : Convert.ToString(dr["Telefono"])!
                            };
                        }

                        return beCompaniaEnvio;
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
        public void Insert(CompaniaEnvioBE beCompaniaEnvio)
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
                            sqlCmd.CommandText = UpCompaniaEnvioInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@NombreCompañia", SqlDbType.NVarChar).Value = beCompaniaEnvio.NombreCompañia ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Ruc", SqlDbType.NVarChar).Value = beCompaniaEnvio.Ruc ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = beCompaniaEnvio.Telefono ?? (object)DBNull.Value;


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

        public void Update(int idCompaniaEnvio, CompaniaEnvioBE beCompaniaEnvio)
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
                            sqlCmd.CommandText = UpCompaniaEnvioUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@CompañiaDeEnvioId", SqlDbType.Int).Value = idCompaniaEnvio;
                            sqlCmd.Parameters.Add("@NombreCompañia", SqlDbType.NVarChar).Value =
                                beCompaniaEnvio.NombreCompañia != null ? (object)beCompaniaEnvio.NombreCompañia : DBNull.Value;
                            sqlCmd.Parameters.Add("@Ruc", SqlDbType.NVarChar).Value =
                                beCompaniaEnvio.Ruc != null ? (object)beCompaniaEnvio.Ruc: DBNull.Value;
                            sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value =
                                beCompaniaEnvio.Telefono != null ? (object)beCompaniaEnvio.Telefono: DBNull.Value;

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
        
    }
}
