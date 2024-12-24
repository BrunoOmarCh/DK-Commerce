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
            ContactoProveedorBE beContactoProveedor = null;
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
                        sqlCmd.CommandText = UpContactoProveedorSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@ContactoProveedorId", SqlDbType.Int).Value = ContactoProveedorId;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beContactoProveedor = new ContactoProveedorBE();

                            beContactoProveedor.ContactoProveedorId = ContactoProveedorId;
                            beContactoProveedor.NombreContacto = dr["NombreContacto"] == DBNull.Value ? null : Convert.ToString(dr["NombreContacto"])!;
                            beContactoProveedor.CargoContacto = dr["CargoContacto"] == DBNull.Value ? null : Convert.ToString(dr["CargoContacto"])!;
                            beContactoProveedor.Dni = dr["Dni"] == DBNull.Value ? null : Convert.ToString(dr["Dni"])!;

                        }

                        return beContactoProveedor;
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
