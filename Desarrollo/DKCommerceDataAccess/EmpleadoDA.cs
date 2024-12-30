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
    public class EmpleadoDA: ConfigDataAccess
    {
        public const string UpEmpleadoInsert = "UpEmpleadoInsert";
        public const string UpEmpleadoUpdate = "UpEmpleadoUpdate";
        public const string UpEmpleadoDelete = "UpEmpleadoDelete";
        public const string UpEmpleadoSelById = "UpEmpleadoSelById";

        public EmpleadoBE SelectById(int empleadoId)
        {
            EmpleadoBE beEmpleado = null;
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
                        sqlCmd.CommandText = UpEmpleadoSelById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.Add("@EmpleadoId", SqlDbType.Int).Value = empleadoId;
                        dr = sqlCmd.ExecuteReader();
                        if (dr.Read())
                        {
                            beEmpleado = new EmpleadoBE
                            {
                                EmpleadoId = empleadoId,
                                Nombres = Convert.ToString(dr["Nombres"]),
                                ApellidoPaterno = dr["ApellidoPaterno"] as string,
                                ApellidoMaterno = dr["ApellidoMaterno"] as string,
                                TipoDocIdentidad = dr["TipoDocIdentidad"] as string,
                                NroDocIdentidad = dr["NroDocIdentidad"] as string,
                                Cargo = dr["Cargo"] as string,
                                Tratamiento = dr["Tratamiento"] as string,
                                FechaNacimiento = dr["FechaNacimiento"] as DateTime?,
                                FechaContratación = dr["FechaContratación"] as DateTime?,
                                Dirección = dr["Dirección"] as string,
                                Ciudad = dr["Ciudad"] as string,
                                Región = dr["Región"] as string,
                                CodPostal = dr["CodPostal"] as string,
                                Pais = dr["Pais"] as string,
                                TelefonoFijo = dr["TelefonoFijo"] as string,
                                Anexo = dr["Anexo"] as string,
                                Notas = dr["Notas"] as string,
                                JefeId = dr["JefeId"] as int?,
                                Email = dr["Email"] as string,
                                EstadoCivil = dr["EstadoCivil"] as string
                            };
                        }

                        return beEmpleado;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al seleccionar empleado por ID.", ex);
                    }
                    finally
                    {
                        dr?.Close();
                        dr?.Dispose();
                    }
                }
            }
        }

        public void Insert(EmpleadoBE beEmpleado)
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
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.CommandText = UpEmpleadoInsert;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.AddWithValue("@Nombres", beEmpleado.Nombres);
                            sqlCmd.Parameters.AddWithValue("@ApellidoPaterno", (object?)beEmpleado.ApellidoPaterno ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@ApellidoMaterno", (object?)beEmpleado.ApellidoMaterno ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@TipoDocIdentidad", (object?)beEmpleado.TipoDocIdentidad ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@NroDocIdentidad", (object?)beEmpleado.NroDocIdentidad ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Cargo", (object?)beEmpleado.Cargo ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Tratamiento", (object?)beEmpleado.Tratamiento ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@FechaNacimiento", (object?)beEmpleado.FechaNacimiento ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@FechaContratación", (object?)beEmpleado.FechaContratación ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Dirección", (object?)beEmpleado.Dirección ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Ciudad", (object?)beEmpleado.Ciudad ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Región", (object?)beEmpleado.Región ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@CodPostal", (object?)beEmpleado.CodPostal ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Pais", (object?)beEmpleado.Pais ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@TelefonoFijo", (object?)beEmpleado.TelefonoFijo ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Anexo", (object?)beEmpleado.Anexo ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Notas", (object?)beEmpleado.Notas ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@JefeId", (object?)beEmpleado.JefeId ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@Email", (object?)beEmpleado.Email ?? DBNull.Value);
                            sqlCmd.Parameters.AddWithValue("@EstadoCivil", (object?)beEmpleado.EstadoCivil ?? DBNull.Value);

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception ex)
                        {
                            sqlTran.Rollback();
                            throw new Exception("Error al insertar empleado.", ex);
                        }
                    }
                }
            }
        }
    }
}
