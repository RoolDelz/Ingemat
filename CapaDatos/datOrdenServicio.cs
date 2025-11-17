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
    }
}
