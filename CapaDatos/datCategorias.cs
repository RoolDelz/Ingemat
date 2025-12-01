using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaEntidad.Formatos;

namespace CapaDatos
{
    public class datCategorias
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public List<Categoria> ObtenerCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Categoria", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categorias.Add(new Categoria
                    {
                        IdCategoria = Convert.ToInt32(reader["IdCategoria"]),
                        NomCategoria = reader["NomCategoria"].ToString()
                    });
                }
            }
            return categorias;
        }

        public void AgregarCategoria(Categoria categoria)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Categoria (NomCategoria) VALUES (@NomCategoria)", conn);
                cmd.Parameters.AddWithValue("@NomCategoria", categoria.NomCategoria);
                cmd.ExecuteNonQuery();
            }
        }
        public bool EditarCategoria(Categoria categoria)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE Categoria SET NomCategoria = @Nom WHERE IdCategoria = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", categoria.NomCategoria);
                    cmd.Parameters.AddWithValue("@Id", categoria.IdCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
