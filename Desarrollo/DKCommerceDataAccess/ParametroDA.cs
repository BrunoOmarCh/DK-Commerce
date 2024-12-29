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
    public class ParametroDA: ConfigDataAccess
    {
        public const string UpParametroInsert = "UpParametroInsert";
        public const string UpParametroUpdate = "UpParametroUpdate";
        public const string UpParametroDelete = "UpParametroDelete";
        public const string UpParametroSelById = "UpParametroSelById";

        public ParametroBE SelectById(string Claveid)
        {
            ParametroBE beParametro= null;
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
                        sqlCmd.CommandText = UpParametroInsert;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Claveid;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beParametro = new ParametroBE();

                            beParametro.Clave= Claveid;
                            beParametro.Grupo= dr["Grupo"] == DBNull.Value ? null : Convert.ToString(dr["Grupo"])!;
                            beParametro.Valor= dr["Valor"] == DBNull.Value ? null : Convert.ToString(dr["Valor"])!;

                        }

                        return beParametro;
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
