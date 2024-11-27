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

        public Categoria SelectById(int categoriaId)
        {
            Categoria beCategoria = null;
            var conn = Configuration.GetConnectionString("Mercurio");
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
                            beCategoria = new Categoria();
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


    }
}
