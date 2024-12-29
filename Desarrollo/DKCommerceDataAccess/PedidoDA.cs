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
    public class PedidoDA: ConfigDataAccess
    {
        public const string UpPedidoInsert = "UpPedidoInsert";
        public const string UpPedidoUpdate = "UpPedidoUpdate";
        public const string UpPedidoDelete = "UpPedidoDelete";
        public const string UpPedidoSelById = "UpPedidoSelById";

        public PedidoBE SelectById(int pedidoId)
        {
            PedidoBE bePedido = null;
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
                        sqlCmd.CommandText = UpPedidoSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@PedidoId", SqlDbType.Int).Value = pedidoId;

                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            bePedido = new PedidoBE
                            {
                                PedidoId = pedidoId,
                                ClienteId = dr["ClienteId"]?.ToString(),
                                IdEmpleado = dr["IdEmpleado"] == DBNull.Value ? null : (int?)dr["IdEmpleado"],
                                FechaPedido = dr["FechaPedido"] == DBNull.Value ? null : (DateTime?)dr["FechaPedido"],
                                FechaEntrega = dr["FechaEntrega"] == DBNull.Value ? null : (DateTime?)dr["FechaEntrega"],
                                FechaEnvío = dr["FechaEnvío"] == DBNull.Value ? null : (DateTime?)dr["FechaEnvío"],
                                FormaEnvío = dr["FormaEnvío"] == DBNull.Value ? null : (int?)dr["FormaEnvío"],
                                Igv = dr["Igv"] == DBNull.Value ? null : (decimal?)dr["Igv"],
                                Isc = dr["Isc"] == DBNull.Value ? null : (decimal?)dr["Isc"],
                                MontoTotal = dr["MontoTotal"] == DBNull.Value ? null : (decimal?)dr["MontoTotal"],
                                Destinatario = dr["Destinatario"]?.ToString(),
                                DirecciónDestinatario = dr["DirecciónDestinatario"]?.ToString(),
                                CiudadDestinatario = dr["CiudadDestinatario"]?.ToString(),
                                RegiónDestinatario = dr["RegiónDestinatario"]?.ToString(),
                                CódPostalDestinatario = dr["CódPostalDestinatario"]?.ToString(),
                                PaísDestinatario = dr["PaísDestinatario"]?.ToString()
                            };
                        }
                        return bePedido;
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
        public void Insert(PedidoBE bePedido)
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
                            sqlCmd.CommandText = UpPedidoInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ClienteId", SqlDbType.VarChar).Value = bePedido.ClienteId ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@IdEmpleado", SqlDbType.Int).Value = bePedido.IdEmpleado ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@FechaPedido", SqlDbType.DateTime2).Value = bePedido.FechaPedido ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@FechaEntrega", SqlDbType.DateTime2).Value = bePedido.FechaEntrega ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@FechaEnvío", SqlDbType.DateTime2).Value = bePedido.FechaEnvío ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@FormaEnvío", SqlDbType.Int).Value = bePedido.FormaEnvío ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Igv", SqlDbType.Decimal).Value = bePedido.Igv ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Isc", SqlDbType.Decimal).Value = bePedido.Isc ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@MontoTotal", SqlDbType.Decimal).Value = bePedido.MontoTotal ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@Destinatario", SqlDbType.NVarChar).Value = bePedido.Destinatario ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@DirecciónDestinatario", SqlDbType.NVarChar).Value = bePedido.DirecciónDestinatario ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@CiudadDestinatario", SqlDbType.NVarChar).Value = bePedido.CiudadDestinatario ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@RegiónDestinatario", SqlDbType.NVarChar).Value = bePedido.RegiónDestinatario ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@CódPostalDestinatario", SqlDbType.NVarChar).Value = bePedido.CódPostalDestinatario ?? (object)DBNull.Value;
                            sqlCmd.Parameters.Add("@PaísDestinatario", SqlDbType.NVarChar).Value = bePedido.PaísDestinatario ?? (object)DBNull.Value;

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
