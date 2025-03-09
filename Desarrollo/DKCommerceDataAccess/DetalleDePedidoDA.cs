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
    public class DetalleDePedidoDA: ConfigDataAccess
    {
        public const string UpDetalleDePedidoInsert = "UpDetalleDePedidoInsert";
        public const string UpDetalleDePedidoUpdate = "UpDetalleDePedidoUpdate";
        public const string UpDetalleDePedidoDelete = "UpDetalleDePedidoDelete";
        public const string UpDetalleDePedidoSelById = "UpDetalleDePedidoSelById";


        public DetalleDePedidoBE SelectById(int pedidoId, int productoId)
        {
            DetalleDePedidoBE detallebe = null;
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
                        sqlCmd.CommandText = "UpDetalleDePedidoSelectById"; // Nombre del procedimiento almacenado
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@PedidoId", SqlDbType.Int).Value = pedidoId;
                        sqlCmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = productoId;

                        dr = sqlCmd.ExecuteReader();
                        if (dr.Read())
                        {
                            detallebe = new DetalleDePedidoBE
                            {
                                PedidoId = pedidoId,
                                ProductoId = (int)dr["productoId"],
                                PrecioNeto = (decimal)dr["PrecioNeto"],
                                Cantidad = (int)dr["Cantidad"],
                                Descuento = (decimal)dr["Descuento"],
                                Igv = dr["Igv"] == DBNull.Value ? null : (decimal?)dr["Igv"],
                                Isc = dr["Isc"] == DBNull.Value ? null : (decimal?)dr["Isc"],
                                MontoSubTotal = dr["MontoSubTotal"] == DBNull.Value ? null : (decimal?)dr["MontoSubTotal"]
                            };
                        }
                        return detallebe;
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
        public void Insert(DetalleDePedidoBE detallebe)
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
                            sqlCmd.CommandText = "UpDetalleDePedidoInsert"; 
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@PedidoId", SqlDbType.Int).Value = detallebe.PedidoId;
                            sqlCmd.Parameters.Add("@ProductoId", SqlDbType.Int).Value = detallebe.ProductoId;
                            sqlCmd.Parameters.Add("@PrecioNeto", SqlDbType.Decimal).Value = detallebe.PrecioNeto;
                            sqlCmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = detallebe.Cantidad;
                            sqlCmd.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = detallebe.Descuento;
                            sqlCmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = detallebe.Igv ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Isc", SqlDbType.Decimal).Value = detallebe.Isc ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@MontoSubTotal", SqlDbType.Decimal).Value = detallebe.MontoSubTotal ?? (object)DBNull.Value;

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



    }
}
