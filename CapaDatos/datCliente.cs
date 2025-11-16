using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class datCliente
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public int InsertarCliente(entCliente cliente)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Cliente (NomCliente, Documento, NDocumento, TelefonoCliente, CorreoCliente) VALUES (@Nom, @Doc, @NDoc, @Tel, @Corr); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@Nom", cliente.NomCliente);
                cmd.Parameters.AddWithValue("@Doc", cliente.Documento);
                cmd.Parameters.AddWithValue("@NDoc", cliente.NDocumento);
                cmd.Parameters.AddWithValue("@Tel", cliente.TelefonoCliente);
                cmd.Parameters.AddWithValue("@Corr", cliente.CorreoCliente);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
