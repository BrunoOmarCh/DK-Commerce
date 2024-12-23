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
    public class ContactoProveedorDA: ConfigDataAccess
    {
        public const string UpContactoProveedorInsert = "UpContactoProveedorInsert";
        public const string UpContactoProveedorUpdate = "UpContactoProveedorUpdate";
        public const string UpContactoProveedorDelete = "UpContactoProveedorDelete";
        public const string UpContactoProveedorSelById = "UpContactoProveedorSelById";

        public  ContactoProveedorBE SelectById(int ContactoProveedorId)
        {
            ContactoProveedorBE beContactoProveedor= null;
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

                            beContactoProveedor.ContactoProveedorId= ContactoProveedorId ; 
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

        public void Insert(ContactoProveedorBE beContactoProveedor)
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
                            sqlCmd.CommandText = UpContactoProveedorInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@NombreContacto", SqlDbType.NVarChar).Value = beContactoProveedor.NombreContacto ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@CargoContacto", SqlDbType.NVarChar).Value= beContactoProveedor.CargoContacto ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Dni", SqlDbType.NVarChar).Value = beContactoProveedor.Dni ?? (object)DBNull.Value;

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

        public void Update(int idContactoProveedor, ContactoProveedorBE beContactoProveedor)
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
                            sqlCmd.CommandText = "UpContactoProveedorUpdate";
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ContactoProveedorId", SqlDbType.Int).Value = idContactoProveedor;
                            sqlCmd.Parameters.Add("@NombreContacto", SqlDbType.NVarChar).Value =
                                beContactoProveedor.NombreContacto != null ? (object)beContactoProveedor.NombreContacto :DBNull.Value;
                            sqlCmd.Parameters.Add("@CargoContacto", SqlDbType.NVarChar).Value =
                                beContactoProveedor.CargoContacto != null ? (object)beContactoProveedor.CargoContacto : DBNull.Value;
                            sqlCmd.Parameters.Add("@Dni", SqlDbType.NVarChar).Value = 
                                beContactoProveedor.Dni != null ? (object)beContactoProveedor.Dni : DBNull.Value;

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

        public void Delete(int idContactoProveedor)
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
                            sqlCmd.CommandText = UpContactoProveedorDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ContactoProveedorId", SqlDbType.Int).Value = idContactoProveedor;

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

