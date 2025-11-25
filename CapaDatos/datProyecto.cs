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
    }
}
