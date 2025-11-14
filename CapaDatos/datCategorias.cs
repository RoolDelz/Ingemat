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
        // Usamos la instancia de Conexion para obtener la conexión
        private readonly Conexion conexion = Conexion.Instancia;

        // Obtener todas las categorías
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

        // Agregar nueva categoría
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
    }
}
