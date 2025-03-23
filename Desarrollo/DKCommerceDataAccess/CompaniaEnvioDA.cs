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
    }
}
