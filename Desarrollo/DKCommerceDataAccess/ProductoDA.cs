using DKCommerceBussinesEntity;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Libreria;


namespace DKCommerceDataAccess
{
    public class ProductoDA : ConfigDataAccess
    {
        public const string UpProductoInsert = "UpProductoInsert";
        public const string UpProductoUpdate = "UpProductoUpdate";
        public const string UpProductoDelete = "UpProductoDelete";
        public const string UpProductoSelById = "UpProductoSelById";
        public const string UpProductoStatus = "UpProductoStatus";
        public const string UpProductoExists = "UpProductoExists";
        public const string UpProductoPagination = "UpProductoPagination";


        public ProductoBE SelectById(int idProducto)
        {
            ProductoBE beProducto = null;
            var conn = Configuration.GetConnectionString("Dk_Commerce");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn)) // Conecta a la base de datos
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())// Conectará al procedure
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon;// Cadena de conexión con los datos:servidor, base de datos, usuario, contraseña
                        sqlCmd.CommandText = UpProductoSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;// Indicarle que es un stored procedure

                        sqlCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beProducto = new ProductoBE();

                            beProducto.IdProducto = idProducto;
                            beProducto.NombreProducto = Convert.ToString(dr["NombreProducto"]);// Convertir de objeto a string
                            beProducto.ProveedorId = int.Parse(dr["ProveedorId"].ToString()!);// Ignorar cualquier posible null
                            beProducto.CategoriaId = int.Parse(dr["CategoriaId"].ToString()!);
                            beProducto.CantidadPorUnidad = Convert.ToString(dr["CantidadPorUnidad"]);
                            beProducto.PrecioLista = decimal.Parse(dr["PrecioLista"].ToString()!);
                            if (dr["Descuento"] != DBNull.Value)
                            {
                                beProducto.Descuento = decimal.Parse(dr["Descuento"].ToString()!);
                            }
                            if (dr["Igv"] != DBNull.Value)
                            {
                                beProducto.Igv = decimal.Parse(dr["Igv"].ToString()!);
                            }
                            if (dr["Isc"] != DBNull.Value)
                            {
                                beProducto.Isc = decimal.Parse(dr["Isc"].ToString()!);
                            }
                            beProducto.PrecioVenta = decimal.Parse(dr["PrecioVenta"].ToString()!);
                            beProducto.UnidadesEnExistencia = short.Parse(dr["UnidadesEnExistencia"].ToString()!);
                            beProducto.UnidadesEnPedido = short.Parse(dr["UnidadesEnPedido"].ToString()!);
                            beProducto.NivelNuevoPedido = short.Parse(dr["NivelNuevoPedido"].ToString()!);
                            beProducto.Suspendido = bool.Parse(dr["Suspendido"].ToString()!);
                        }
                        
                        return beProducto;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        dr?.Close();// ?: Si no es null el objeto, cerrarlo
                        dr?.Dispose(); // ?: Si no es null, descargarlo de memoria
                    }
                }
            }
        }

        public void Insert(ProductoBE beProducto)
        {
            var conn = Configuration.GetConnectionString("Dk_Commerce");

            using (var sqlCon = new SqlConnection(conn)) // Conecta a la base de datos
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())// Conectará al procedure
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpProductoInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar).Value = beProducto.NombreProducto;
                            sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = beProducto.ProveedorId;
                            sqlCmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = beProducto.CategoriaId;
                            sqlCmd.Parameters.Add("@PrecioLista", SqlDbType.Decimal).Value = beProducto.PrecioLista;
                            if (beProducto.Igv.HasValue)// Manejo de tipo nullable (tipo que soporta null)
                            {
                                sqlCmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = beProducto.Igv.Value;
                            }
                            else
                            {
                                sqlCmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = DBNull.Value;//DBNull.Value: Un valor NULL de la base de datos
                            }
                            if (beProducto.Isc.HasValue)
                            {
                                sqlCmd.Parameters.Add("@Isc", SqlDbType.Decimal).Value = beProducto.Isc.Value;
                            }
                            else
                            {
                                sqlCmd.Parameters.Add("@Isc", SqlDbType.Decimal).Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = beProducto.PrecioVenta;
                            // Bit en SQL Server equivalente a Booleano en C#  
                            sqlCmd.Parameters.Add("@Suspendido", SqlDbType.Bit).Value = beProducto.Suspendido;

                            sqlCmd.ExecuteNonQuery();//<----- Ejecuta el comando (procedure)
                            sqlTran.Commit();//<----- Confirma la operación (transacción)
                        }
                        catch (Exception ex)
                        {
                            sqlTran?.Rollback();
                            throw ex;
                        }
                    }
                }
            } //using: Al cerrar las llaves, se libera el objeto, luego ya no existe
        }

        public bool Exists(int idProducto)
        {
            bool existe = false;// bool equivale a bit en SQL Server
            var conn = Configuration.GetConnectionString("Dk_Commerce");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = UpProductoExists;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            existe = Convert.ToBoolean(dr["Exists"]);// Convierte bit a boolean
                        }

                        return existe;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        dr?.Close();
                        dr?.Dispose();
                    }
                }
            }
        }

        public List<ProductoBE> Paginacion(string texto, int tamañoPagina,
            int nroPagina, string nombreColumna, bool? orderBy)
        {
            var ProductoList = new List<ProductoBE>();
            var conn = Configuration.GetConnectionString("DK_Commerce");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon;
                        sqlCmd.CommandText = UpProductoPagination;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@Texto", SqlDbType.NVarChar).Value = texto;
                        sqlCmd.Parameters.Add("@TamañoPagina", SqlDbType.Int).Value = tamañoPagina;
                        sqlCmd.Parameters.Add("@NroPagina", SqlDbType.Int).Value = nroPagina;
                        if (string.IsNullOrWhiteSpace(nombreColumna))
                        {
                            sqlCmd.Parameters.Add("@NombreColumna", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlCmd.Parameters.Add("@NombreColumna", SqlDbType.VarChar).Value = nombreColumna;
                        }
                        if (orderBy.HasValue)
                        {
                            sqlCmd.Parameters.Add("@OrderBy", SqlDbType.Bit).Value = orderBy.Value;
                        }
                        else
                        {
                            sqlCmd.Parameters.Add("@OrderBy", SqlDbType.Bit).Value = DBNull.Value;
                        }

                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            var beProducto = new ProductoBE();

                            beProducto.IdProducto = int.Parse(dr["IdProducto"].ToString()!);
                            beProducto.NombreProducto = Convert.ToString(dr["NombreProducto"]);
                            beProducto.ProveedorId = int.Parse(dr["ProveedorId"].ToString()!);
                            beProducto.CategoriaId = int.Parse(dr["CategoriaId"].ToString()!);
                            beProducto.CantidadPorUnidad = Convert.ToString(dr["CantidadPorUnidad"]);
                            beProducto.PrecioLista = decimal.Parse(dr["PrecioLista"].ToString()!);
                            if (dr["Descuento"] != DBNull.Value)
                            {
                                beProducto.Descuento = decimal.Parse(dr["Descuento"].ToString()!);
                            }
                            if (dr["Igv"] != DBNull.Value)
                            {
                                beProducto.Igv = decimal.Parse(dr["Igv"].ToString()!);
                            }
                            if (dr["Isc"] != DBNull.Value)
                            {
                                beProducto.Isc = decimal.Parse(dr["Isc"].ToString()!);
                            }
                            beProducto.PrecioVenta = decimal.Parse(dr["PrecioVenta"].ToString()!);
                            beProducto.UnidadesEnExistencia = short.Parse(dr["UnidadesEnExistencia"].ToString()!);
                            beProducto.UnidadesEnPedido = short.Parse(dr["UnidadesEnPedido"].ToString()!);
                            beProducto.NivelNuevoPedido = short.Parse(dr["NivelNuevoPedido"].ToString()!);
                            beProducto.Suspendido = bool.Parse(dr["Suspendido"].ToString()!);

                            ProductoList.Add(beProducto);
                        }

                        return ProductoList;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        dr?.Close();// ?: Si no es null el objeto, cerrarlo
                        dr?.Dispose(); // ?: Si no es null, descargarlo de memoria
                    }
                }
            }
        }

        public void Update(int idProducto, ProductoBE beProducto)
        {
            var conn = Configuration.GetConnectionString("DK_Commerce");

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
                            sqlCmd.CommandText = UpProductoUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

                            sqlCmd.Parameters.Add("@NombreProducto", SqlDbType.NVarChar).Value = beProducto.NombreProducto;
                            sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = beProducto.ProveedorId;
                            sqlCmd.Parameters.Add("@CategoriaId", SqlDbType.Int).Value = beProducto.CategoriaId;
                            sqlCmd.Parameters.Add("@PrecioLista", SqlDbType.Decimal).Value = beProducto.PrecioLista;
                            if (beProducto.Igv.HasValue)
                            {
                                sqlCmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = beProducto.Igv.Value;
                            }
                            else
                            {
                                sqlCmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = DBNull.Value;
                            }
                            if (beProducto.Isc.HasValue)
                            {
                                sqlCmd.Parameters.Add("@Isc", SqlDbType.Decimal).Value = beProducto.Isc.Value;
                            }
                            else
                            {
                                sqlCmd.Parameters.Add("@Isc", SqlDbType.Decimal).Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.Add("@PrecioVenta", SqlDbType.Decimal).Value = beProducto.PrecioVenta;
                            sqlCmd.Parameters.Add("@Suspendido", SqlDbType.Bit).Value = beProducto.Suspendido;

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

        public void Status(int idProducto, ProductoBE beProducto)
        {
            var conn = Configuration.GetConnectionString("DK_Commerce");

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
                            sqlCmd.CommandText = UpProductoStatus;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
                            sqlCmd.Parameters.Add("@Suspendido", SqlDbType.Bit).Value = beProducto.Suspendido;

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

        public void Delete(int idProducto)
        {
            var conn = Configuration.GetConnectionString("Mercurio");

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
                            sqlCmd.CommandText = UpProductoDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;

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
