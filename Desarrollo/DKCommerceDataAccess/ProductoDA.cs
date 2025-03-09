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
            var conn = Configuration.GetConnectionString("Dk Commerce");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn)) // Conecta a la base de datos
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand()) // Conectará al procedure
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon; // Cadena de conexión con los datos: servidor, base de datos, usuario, contraseña
                        sqlCmd.CommandText = UpProductoSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure; // Indicarle que es un stored procedure

                        sqlCmd.Parameters.Add("@IdProducto", SqlDbType.Int).Value = idProducto;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beProducto = new ProductoBE();

                            // Asignación de valores desde el DataReader
                            beProducto.IdProducto = idProducto;
                            beProducto.NombreProducto = Convert.ToString(dr["NombreProducto"]); // Convertir de objeto a string
                            beProducto.ProveedorId = dr["ProveedorId"] != DBNull.Value ? (int?)dr["ProveedorId"] : null;
                            beProducto.CategoriaId = dr["CategoriaId"] != DBNull.Value ? (int?)dr["CategoriaId"] : null;
                            beProducto.CantidadPorUnidad = Convert.ToString(dr["CantidadPorUnidad"]);
                            beProducto.PrecioLista = dr["PrecioLista"] != DBNull.Value ? (decimal?)dr["PrecioLista"] : null;
                            beProducto.Descuento = dr["Descuento"] != DBNull.Value ? (decimal?)dr["Descuento"] : null;
                            beProducto.Igv = dr["Igv"] != DBNull.Value ? (decimal?)dr["Igv"] : null;
                            beProducto.Isc = dr["Isc"] != DBNull.Value ? (decimal?)dr["Isc"] : null;
                            beProducto.PrecioVenta = dr["PrecioVenta"] != DBNull.Value ? (decimal?)dr["PrecioVenta"] : null;
                            beProducto.UnidadesEnExistencia = dr["UnidadesEnExistencia"] != DBNull.Value ? (short?)dr["UnidadesEnExistencia"] : null;
                            beProducto.UnidadesEnPedido = dr["UnidadesEnPedido"] != DBNull.Value ? (short?)dr["UnidadesEnPedido"] : null;
                            beProducto.NivelNuevoPedido = dr["NivelNuevoPedido"] != DBNull.Value ? (int?)dr["NivelNuevoPedido"] : null;
                            beProducto.Suspendido = dr["Suspendido"] != DBNull.Value && Convert.ToBoolean(dr["Suspendido"]);
                            beProducto.UsuarioId = dr["UsuarioId"] != DBNull.Value ? (int?)dr["UsuarioId"] : null;
                        }
                        return beProducto;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error al obtener el producto con ID {idProducto}: {ex.Message}", ex); // Lanza la excepción sin alterar el contexto original
                    }
                    finally
                    {
                        dr?.Close(); // Si no es null el objeto, cerrarlo
                        dr?.Dispose(); // Descargarlo de memoria
                    }
                }
            }
        }



    }
}
