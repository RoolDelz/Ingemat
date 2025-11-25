using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datOrdenServicio
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public bool InsertarOrdenServicio(entOrdenServicio os)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.OrdenServicio (FechaOS, IdProforma, IdEmpresa, EstadoOS) VALUES (@FechaOS, @IdProforma, @IdEmpresa, @EstadoOS)", conn);

                    cmd.Parameters.AddWithValue("@FechaOS", os.FechaOS);
                    cmd.Parameters.AddWithValue("@IdProforma", os.IdProforma);
                    cmd.Parameters.AddWithValue("@IdEmpresa", os.IdEmpresa);
                    cmd.Parameters.AddWithValue("@EstadoOS", os.EstadoOS);

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    exito = filasAfectadas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en datOrdenServicio.InsertarOrdenServicio: " + ex.Message);
            }
            return exito;
        }
        public List<entOrdenServicioVista> ListarOrdenesServicioVista(string estado = null)
        {
            List<entOrdenServicioVista> lista = new List<entOrdenServicioVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            os.IdOS, os.FechaOS, os.EstadoOS,
                            os.IdProforma, p.Motivo,
                            e.NomEmpresa, e.Ruc
                        FROM 
                            dbo.OrdenServicio os
                        JOIN 
                            dbo.Empresa e ON os.IdEmpresa = e.IdEmpresa
                        JOIN 
                            dbo.Proforma p ON os.IdProforma = p.IdProforma
                        WHERE 
                            (@Estado IS NULL OR os.EstadoOS = @Estado)
                        ORDER BY 
                            os.IdOS DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (string.IsNullOrEmpty(estado))
                        cmd.Parameters.AddWithValue("@Estado", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@Estado", estado);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new entOrdenServicioVista
                        {
                            IdOS = Convert.ToInt32(reader["IdOS"]),
                            FechaOS = Convert.ToDateTime(reader["FechaOS"]),
                            EstadoOS = reader["EstadoOS"].ToString(),
                            IdProforma = Convert.ToInt32(reader["IdProforma"]),
                            MotivoProforma = reader["Motivo"].ToString(),
                            NomEmpresa = reader["NomEmpresa"].ToString(),
                            RucEmpresa = reader["Ruc"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar órdenes de servicio: " + ex.Message);
            }
            return lista;
        }
        public bool ActualizarEstadoOS(int idOS, string nuevoEstado)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE dbo.OrdenServicio SET EstadoOS = @Estado WHERE IdOS = @IdOS";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@IdOS", idOS);

                    exito = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar estado: " + ex.Message);
            }
            return exito;
        }
    }
}
