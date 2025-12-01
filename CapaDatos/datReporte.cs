using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datReporte
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public bool InsertarReporte(entReporte reporte)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "INSERT INTO dbo.OrdenTrabajoReporte (IdOT, NombreArchivo, Extension, Contenido) VALUES (@IdOT, @Nombre, @Ext, @Contenido)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdOT", reporte.IdOT);
                    cmd.Parameters.AddWithValue("@Nombre", reporte.NombreArchivo);
                    cmd.Parameters.AddWithValue("@Ext", reporte.Extension);
                    cmd.Parameters.AddWithValue("@Contenido", reporte.Contenido);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }

        public List<entReporte> ListarPorOT(int idOT)
        {
            List<entReporte> lista = new List<entReporte>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT IdReporte, NombreArchivo, Extension FROM dbo.OrdenTrabajoReporte WHERE IdOT = @IdOT";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdOT", idOT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new entReporte
                        {
                            IdReporte = Convert.ToInt32(reader["IdReporte"]),
                            NombreArchivo = reader["NombreArchivo"].ToString(),
                            Extension = reader["Extension"].ToString()
                        });
                    }
                }
            }
            catch (Exception) { }
            return lista;
        }
    }
}
