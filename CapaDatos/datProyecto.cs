using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datProyecto
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public int InsertarProyecto(entProyecto pro)
        {
            int idProyecto = 0;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO dbo.Proyecto (NomProyecto, FechaCreacion, IdOS) 
                        VALUES (@Nom, @Fecha, @IdOS); 
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", pro.NomProyecto);
                    cmd.Parameters.AddWithValue("@Fecha", pro.FechaCreacion);
                    cmd.Parameters.AddWithValue("@IdOS", pro.IdOS);

                    idProyecto = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BD al crear Proyecto: " + ex.Message);
            }
            return idProyecto;
        }
        public bool ExisteProyectoPorOS(int idOS)
        {
            bool existe = false;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.Proyecto WHERE IdOS = @IdOS", conn);
                    cmd.Parameters.AddWithValue("@IdOS", idOS);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    existe = count > 0;
                }
            }
            catch (Exception) { }
            return existe;
        }
        public List<entProyectoVista> ListarProyectosVista()
        {
            List<entProyectoVista> lista = new List<entProyectoVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.IdProyecto, p.NomProyecto, p.Estado, p.FechaCreacion,
                            e.NomEmpresa,
                            prof.DireccionProforma
                        FROM 
                            dbo.Proyecto p
                        INNER JOIN 
                            dbo.OrdenServicio os ON p.IdOS = os.IdOS
                        INNER JOIN 
                            dbo.Empresa e ON os.IdEmpresa = e.IdEmpresa
                        INNER JOIN 
                            dbo.Proforma prof ON os.IdProforma = prof.IdProforma
                        ORDER BY 
                            p.IdProyecto DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new entProyectoVista
                        {
                            IdProyecto = Convert.ToInt32(reader["IdProyecto"]),
                            NomProyecto = reader["NomProyecto"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"]),
                            NomEmpresa = reader["NomEmpresa"].ToString(),
                            DireccionProforma = reader["DireccionProforma"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar proyectos: " + ex.Message);
            }
            return lista;
        }
        public bool ActualizarEstado(int idProyecto, string nuevoEstado)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE dbo.Proyecto SET Estado = @Estado WHERE IdProyecto = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@Id", idProyecto);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex) { throw new Exception("Error al actualizar estado: " + ex.Message); }
        }
        public int ObtenerIdFormatoDeProyecto(int idProyecto)
        {
            int idFormato = 0;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT pf.IdFormato 
                        FROM dbo.Proyecto p
                        INNER JOIN dbo.OrdenServicio os ON p.IdOS = os.IdOS
                        INNER JOIN dbo.Proforma pf ON os.IdProforma = pf.IdProforma
                        WHERE p.IdProyecto = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", idProyecto);

                    object result = cmd.ExecuteScalar();
                    if (result != null) idFormato = Convert.ToInt32(result);
                }
            }
            catch (Exception ex) { throw new Exception("Error al obtener formato: " + ex.Message); }
            return idFormato;
        }
    }
}
