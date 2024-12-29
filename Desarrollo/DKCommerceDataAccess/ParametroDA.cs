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


        public void Insert(ParametroBE beParametro)
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
                            sqlCmd.CommandText = UpParametroInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@Grupo", SqlDbType.NVarChar).Value = beParametro.Grupo ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Valor", SqlDbType.NVarChar).Value = beParametro.Valor ?? (object)DBNull.Value;
                           
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

        public void Update(string idClave, ParametroBE beParametro)
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
                            sqlCmd.CommandText = UpParametroUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@clave", SqlDbType.NVarChar).Value = idClave;
                            sqlCmd.Parameters.Add("@Grupo", SqlDbType.NVarChar).Value =
                                beParametro.Grupo != null ? (object)beParametro.Grupo: DBNull.Value;
                            sqlCmd.Parameters.Add("@Valor", SqlDbType.NVarChar).Value =
                                beParametro.Valor != null ? (object)beParametro.Valor: DBNull.Value;
                            
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

        public void Delete(string idClave)
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
                            sqlCmd.CommandText = UpParametroDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@Clave", SqlDbType.NVarChar).Value = idClave;

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
