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
    }
}
