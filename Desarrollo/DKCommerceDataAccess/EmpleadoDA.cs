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

    }
}
