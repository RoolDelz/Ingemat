using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class datTipoGasto
    {
        private readonly Conexion conexion = Conexion.Instancia;
        public List<entTipoGasto> ObtenerTiposGasto()
        {
            List<entTipoGasto> lista = new List<entTipoGasto>();
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdGastoTipo, NomGastoTipo FROM dbo.TipoGasto", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new entTipoGasto
                    {
                        IdGastoTipo = Convert.ToInt32(reader["IdGastoTipo"]),
                        NomGastoTipo = reader["NomGastoTipo"].ToString()
                    });
                }
            }
            return lista;
        }
        public List<entTipoGasto> ListarTiposGasto()
        {
            List<entTipoGasto> lista = new List<entTipoGasto>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdGastoTipo, NomGastoTipo FROM dbo.TipoGasto", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new entTipoGasto
                        {
                            IdGastoTipo = Convert.ToInt32(reader["IdGastoTipo"]),
                            NomGastoTipo = reader["NomGastoTipo"].ToString()
                        });
                    }
                }
            }
            catch (Exception) { }
            return lista;
        }
        public bool AgregarTipoGasto(entTipoGasto tipo)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "INSERT INTO TipoGasto (NomGastoTipo) VALUES (@Nom)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", tipo.NomGastoTipo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
        public bool EditarTipoGasto(entTipoGasto tipo)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE TipoGasto SET NomGastoTipo = @Nom WHERE IdGastoTipo = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", tipo.NomGastoTipo);
                    cmd.Parameters.AddWithValue("@Id", tipo.IdGastoTipo);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
