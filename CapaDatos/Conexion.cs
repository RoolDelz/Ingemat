using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get { return Conexion._instancia; }
        }

        private Conexion() { }

        // Método para obtener la conexión
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();

            cn.ConnectionString =
                "Data Source=Rool;" +
                "Initial Catalog=INGEMAT_M1;" +
                "Integrated Security=true";

            return cn;
        }
    }
}
