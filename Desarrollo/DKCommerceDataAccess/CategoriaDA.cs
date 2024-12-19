using DKCommerceBussinesEntity;
using Libreria;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKCommerceDataAccess 
{
    public class CategoriaDA : ConfigDataAccess
    {
        public const string UpCategoriaInsert = "UpCategoriaInsert";
        public const string UpCategoriaUpdate = "UpCategoriaUpdate";
        public const string UpCategoriaDelete = "UpCategoriaDelete";
        public const string UpCategoriaSelById = "UpCategoriaSelById";

        public CategoriaBE SelectById(int categoriaId)
        {
            CategoriaBE beCategoria = null;
            var conn = Configuration.GetConnectionString("DK Commerce");
            SqlDataReader dr = null;

            using (var SqlCon = new SqlConnection(conn))
            {
                SqlCon.Open();
                using (var SqlCmd = new SqlCommand())
                {
                    try
                    {
                        SqlCmd.Connection = SqlCon;
                        SqlCmd.CommandText = UpCategoriaSelById;
                        SqlCmd.CommandType = CommandType.StoredProcedure;

                        SqlCmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = categoriaId;
                        dr = SqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beCategoria = new CategoriaBE();
                            // Se lee el objeto, se lo convierte a String y luego a Int
                            beCategoria.CategoriaId = int.Parse(dr["CategoriaId"].ToString());
                            beCategoria.Nombre = dr["Nombre"].ToString();
                            beCategoria.Descripcion = dr["Descripcion"].ToString();
                            beCategoria.Suspendido = bool.Parse(dr["Suspendido"].ToString());
                        }

                        return beCategoria;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        dr.Close();
                        dr.Dispose();
                    }
                }
            }
        }

        public void Insert(CategoriaBE beCategoria)
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
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.CommandText = UpCategoriaInsert;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = beCategoria.Nombre;
                            sqlCmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = beCategoria.Descripcion;
                            sqlCmd.Parameters.Add("@Suspendido", SqlDbType.Bit).Value = beCategoria.Suspendido;

                            sqlCmd.ExecuteNonQuery();// Ejecuta el procedimiento almacenado, Ej Elegir a enviar Yape
                            sqlTran.Commit();// Confirma la operacion en la base de datos, ej: Transferir un Yape
                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();// Deshacer todo lo avanzado
                            throw ex;
                        }
                    }
                }
            }
        }


        public void Update(int idCategoria, CategoriaBE beCategoria)
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
                            sqlCmd.CommandText = UpCategoriaUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = idCategoria;
                            sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = beCategoria.Nombre;
                            sqlCmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar).Value = beCategoria.Descripcion;
                            sqlCmd.Parameters.Add("@Suspendido", SqlDbType.Bit).Value = beCategoria.Suspendido;

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

        public void Delete(int idCategoria)
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
                            sqlCmd.CommandText = UpCategoriaDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = idCategoria;

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
