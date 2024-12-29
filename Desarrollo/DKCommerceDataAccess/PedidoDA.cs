using Libreria;
using System;
using System.Collections.Generic;
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
    }
}
