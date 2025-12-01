using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.Formatos;

namespace CapaDatos
{
    public class datSubFormatos
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public List<SubFormato> ObtenerSubFormatos(int idFormato)
        {
            List<SubFormato> subFormatos = new List<SubFormato>();

            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SubFormato WHERE IdFormato = @IdFormato", conn);
                cmd.Parameters.AddWithValue("@IdFormato", idFormato);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subFormatos.Add(new SubFormato
                    {
                        IdSubFormato = Convert.ToInt32(reader["IdSubFormato"]),
                        NomSubFormato = reader["NomSubFormato"].ToString(),
                        IdFormato = Convert.ToInt32(reader["IdFormato"])
                    });
                }
            }
            return subFormatos;
        }

        public void AgregarSubFormato(SubFormato subFormato)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO SubFormato (NomSubFormato, IdFormato) VALUES (@NomSubFormato, @IdFormato)", conn);
                cmd.Parameters.AddWithValue("@NomSubFormato", subFormato.NomSubFormato);
                cmd.Parameters.AddWithValue("@IdFormato", subFormato.IdFormato);
                cmd.ExecuteNonQuery();
            }
        }
        public bool EditarSubFormato(SubFormato subFormato)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE SubFormato SET NomSubFormato = @Nom WHERE IdSubFormato = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", subFormato.NomSubFormato);
                    cmd.Parameters.AddWithValue("@Id", subFormato.IdSubFormato);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
        public List<entFormatoVista> ListarVistaCompleta()
        {
            List<entFormatoVista> lista = new List<entFormatoVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            c.IdCategoria, c.NomCategoria,
                            f.IdFormato, f.NomFormato, f.PrecioFormato,
                            s.IdSubFormato, s.NomSubFormato
                        FROM dbo.SubFormato s
                        INNER JOIN dbo.Formato f ON s.IdFormato = f.IdFormato
                        INNER JOIN dbo.Categoria c ON f.IdCategoria = c.IdCategoria
                        ORDER BY c.NomCategoria, f.NomFormato";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new entFormatoVista
                        {
                            IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                            NomCategoria = reader["NomCategoria"].ToString(),
                            IdFormato = Convert.ToInt32(reader["IdFormato"]),
                            NomFormato = reader["NomFormato"].ToString(),
                            PrecioFormato = Convert.ToDecimal(reader["PrecioFormato"]),
                            IdSubFormato = Convert.ToInt32(reader["IdSubFormato"]),
                            NomSubFormato = reader["NomSubFormato"].ToString()
                        });
                    }
                }
            }
            catch (Exception) { }
            return lista;
        }
    }
}
