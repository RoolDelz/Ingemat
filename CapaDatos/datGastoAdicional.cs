using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class datGastoAdicional
    {
        private readonly Conexion conexion = Conexion.Instancia;
        public List<entGastoAdicional> ObtenerGastosPorTipo(int idTipoGasto)
        {
            List<entGastoAdicional> lista = new List<entGastoAdicional>();
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdGastoA, NomGastoA, Precio, IdGastoTipo FROM dbo.GastoAdicional WHERE IdGastoTipo = @IdTipo", conn);
                cmd.Parameters.AddWithValue("@IdTipo", idTipoGasto);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new entGastoAdicional
                    {
                        IdGastoA = Convert.ToInt32(reader["IdGastoA"]),
                        NomGastoA = reader["NomGastoA"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        IdGastoTipo = Convert.ToInt32(reader["IdGastoTipo"])
                    });
                }
            }
            return lista;
        }
        public List<entGastoAdicional> ListarGastosPorProforma(int idProforma)
        {
            List<entGastoAdicional> lista = new List<entGastoAdicional>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ga.IdGastoA, ga.NomGastoA, ga.Precio, ga.IdGastoTipo
                        FROM 
                            dbo.GastoAdicional ga
                        JOIN 
                            dbo.GastosProf gp ON ga.IdGastoA = gp.IdGastoA
                        WHERE 
                            gp.IdProforma = @IdProforma";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdProforma", idProforma);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new entGastoAdicional
                        {
                            IdGastoA = Convert.ToInt32(reader["IdGastoA"]),
                            NomGastoA = reader["NomGastoA"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            IdGastoTipo = Convert.ToInt32(reader["IdGastoTipo"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en datGastoAdicional.ListarGastosPorProforma: " + ex.Message);
            }
            return lista;
        }
    }
}
