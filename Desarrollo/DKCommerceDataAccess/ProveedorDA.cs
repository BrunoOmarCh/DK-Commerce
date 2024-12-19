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


        public void Insert(ProveedorBE beProveedor)
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
                            sqlCmd.CommandText = UpProveedorInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = beProveedor.Nombre;

                            if (beProveedor.Ruc != null)
                                sqlCmd.Parameters.Add("@Ruc", SqlDbType.Char).Value = beProveedor.Ruc;
                            else
                                sqlCmd.Parameters.Add("@Ruc", SqlDbType.Char).Value = DBNull.Value;

                            if (beProveedor.ContactoId != 0)
                                sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = beProveedor.ContactoId;
                            else
                                sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = DBNull.Value;

                            if (beProveedor.Direccion != null)
                                sqlCmd.Parameters.Add("@Dirección", SqlDbType.NVarChar).Value = beProveedor.Direccion;
                            else
                                sqlCmd.Parameters.Add("@Dirección", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Ciudad != null)
                                sqlCmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = beProveedor.Ciudad;
                            else
                                sqlCmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Region != null)
                                sqlCmd.Parameters.Add("@Región", SqlDbType.NVarChar).Value = beProveedor.Region;
                            else
                                sqlCmd.Parameters.Add("@Región", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.CodPostal != null)
                                sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = beProveedor.CodPostal;
                            else
                                sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Pais != null)
                                sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = beProveedor.Pais;
                            else
                                sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Telefono != null)
                                sqlCmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = beProveedor.Telefono;
                            else
                                sqlCmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = DBNull.Value;

                            if (beProveedor.Fax != null)
                                sqlCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = beProveedor.Fax;
                            else
                                sqlCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = DBNull.Value;

                            if (beProveedor.PaginaPrincipal != null)
                                sqlCmd.Parameters.Add("@PaginaPrincipal", SqlDbType.VarChar).Value = beProveedor.PaginaPrincipal;
                            else
                                sqlCmd.Parameters.Add("@PaginaPrincipal", SqlDbType.VarChar).Value = DBNull.Value;
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

        public void Update(int idProveedor, ProveedorBE beProveedor)
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
                            sqlCmd.CommandText = UpProveedorUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = idProveedor;

                            sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = beProveedor.Nombre;

                            if (beProveedor.Ruc != null)
                                sqlCmd.Parameters.Add("@Ruc", SqlDbType.Char).Value = beProveedor.Ruc;
                            else
                                sqlCmd.Parameters.Add("@Ruc", SqlDbType.Char).Value = DBNull.Value;

                            if (beProveedor.ContactoId != 0)
                                sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = beProveedor.ContactoId;
                            else
                                sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = DBNull.Value;

                            if (beProveedor.Direccion != null)
                                sqlCmd.Parameters.Add("@Dirección", SqlDbType.NVarChar).Value = beProveedor.Direccion;
                            else
                                sqlCmd.Parameters.Add("@Dirección", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Ciudad != null)
                                sqlCmd.Parameters.Add("@Ciudad", SqlDbType.Char).Value = beProveedor.Ciudad;
                            else
                                sqlCmd.Parameters.Add("@Ciudad", SqlDbType.Char).Value = DBNull.Value;

                            if (beProveedor.Region != null)
                                sqlCmd.Parameters.Add("@Región", SqlDbType.NVarChar).Value = beProveedor.Region;
                            else
                                sqlCmd.Parameters.Add("@Región", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.CodPostal != null)
                                sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = beProveedor.CodPostal;
                            else
                                sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Pais != null)
                                sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = beProveedor.Pais;
                            else
                                sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = DBNull.Value;

                            if (beProveedor.Telefono != null)
                                sqlCmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = beProveedor.Telefono;
                            else
                                sqlCmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = DBNull.Value;

                            if (beProveedor.Fax != null)
                                sqlCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = beProveedor.Fax;
                            else
                                sqlCmd.Parameters.Add("@Fax", SqlDbType.VarChar).Value = DBNull.Value;

                            if (beProveedor.PaginaPrincipal != null)
                                sqlCmd.Parameters.Add("@PaginaPrincipal", SqlDbType.VarChar).Value = beProveedor.PaginaPrincipal;
                            else
                                sqlCmd.Parameters.Add("@PaginaPrincipal", SqlDbType.VarChar).Value = DBNull.Value;

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

        public void Delete(int idProveedor)
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
                            sqlCmd.CommandText = UpProveedorDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = idProveedor;

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

