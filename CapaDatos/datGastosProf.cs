using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class datGastosProf
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public void InsertarGastoProf(entGastoProf gasto)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.GastosProf (IdProforma, IdGastoA) VALUES (@IdProforma, @IdGastoA)", conn);

                cmd.Parameters.AddWithValue("@IdProforma", gasto.IdProforma);
                cmd.Parameters.AddWithValue("@IdGastoA", gasto.IdGastoA);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
