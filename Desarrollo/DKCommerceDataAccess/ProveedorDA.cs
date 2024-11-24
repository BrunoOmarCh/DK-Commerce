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
    public class ProveedorDA : ConfigDataAccess
    {
        public const string UpProveedorInsert = "UpProveedorInsert";
        public const string UpProveedorUpdate = "UpProveedorUpdate";
        public const string UpProveedorDelete = "UpProveedorDelete";
        public const string UpProveedorSelById = "UpProveedorSelById";

        public ProveedorBE SelectById(int idProveedor)
        {
            ProveedorBE beProveedor = null;
            var conn = Configuration.GetConnectionString("Pluton");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = UpProveedorSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = idProveedor;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beProveedor = new ProveedorBE();

                            beProveedor.ProveedorId = idProveedor;
                            beProveedor.Nombre = Convert.ToString(dr["Nombre"])!;
                            beProveedor.Ruc = Convert.ToString(dr["Ruc"])!;
                            beProveedor.ContactoId = int.Parse(dr["ContactoId"].ToString()!);
                            beProveedor.Direccion = Convert.ToString(dr["Dirección"])!;
                            beProveedor.Ciudad = Convert.ToString(dr["Ciudad"])!;
                            beProveedor.Region = Convert.ToString(dr["Región"])!;
                            beProveedor.CodPostal = Convert.ToString(dr["CodPostal"])!;
                            beProveedor.Pais = Convert.ToString(dr["Pais"])!;
                            beProveedor.Telefono = Convert.ToString(dr["Telefono"])!;
                            beProveedor.Fax = Convert.ToString(dr["Fax"])!;
                            beProveedor.PaginaPrincipal = Convert.ToString(dr["PaginaPrincipal"])!;
                        }

                        return beProveedor;
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
