using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.Formatos;

namespace CapaDatos
{
    public class datFormatos
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public List<Formato> ObtenerFormatos(int idCategoria)
        {
            List<Formato> formatos = new List<Formato>();
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Formato WHERE IdCategoria = @IdCategoria", conn);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    formatos.Add(new Formato
                    {
                        IdFormato = Convert.ToInt32(reader["IdFormato"]),
                        NomFormato = reader["NomFormato"].ToString(),
                        PrecioFormato = Convert.ToDecimal(reader["PrecioFormato"]),
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"])
                    });
                }
            }
            return formatos;
        }

        public void AgregarFormato(Formato formato)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Formato (NomFormato, PrecioFormato, IdCategoria) VALUES (@NomFormato, @PrecioFormato, @IdCategoria)", conn);
                cmd.Parameters.AddWithValue("@NomFormato", formato.NomFormato);
                cmd.Parameters.AddWithValue("@PrecioFormato", formato.PrecioFormato);
                cmd.Parameters.AddWithValue("@IdCategoria", formato.IdCategoria);
                cmd.ExecuteNonQuery();
            }
        }
        public bool EditarFormato(Formato formato)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE Formato SET NomFormato = @Nom, PrecioFormato = @Precio WHERE IdFormato = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", formato.NomFormato);
                    cmd.Parameters.AddWithValue("@Precio", formato.PrecioFormato);
                    cmd.Parameters.AddWithValue("@Id", formato.IdFormato);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
