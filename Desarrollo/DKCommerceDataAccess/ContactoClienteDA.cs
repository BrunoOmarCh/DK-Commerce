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

    }
}
