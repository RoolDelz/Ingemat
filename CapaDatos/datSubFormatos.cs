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

        // Obtener subformatos por formato
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

        // Agregar nuevo subformato
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
    }
}
