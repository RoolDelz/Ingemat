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
        public List<entClienteVista> ListarClientesVista()
        {
            List<entClienteVista> lista = new List<entClienteVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT
                            c.IdCliente, c.NomCliente, c.Documento, c.NDocumento, c.TelefonoCliente, c.CorreoCliente,
                            ISNULL(p.NomProyecto, '--- Sin Proyecto ---') as NomProyecto
                        FROM 
                            dbo.Cliente c
                        LEFT JOIN 
                            dbo.Proforma pf ON c.IdCliente = pf.IdCliente
                        LEFT JOIN 
                            dbo.OrdenServicio os ON pf.IdProforma = os.IdProforma
                        LEFT JOIN 
                            dbo.Proyecto p ON os.IdOS = p.IdOS
                        ORDER BY 
                            c.IdCliente DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new entClienteVista
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            NomCliente = reader["NomCliente"].ToString(),
                            Documento = reader["Documento"].ToString(),
                            NDocumento = reader["NDocumento"].ToString(),
                            TelefonoCliente = reader["TelefonoCliente"].ToString(),
                            CorreoCliente = reader["CorreoCliente"].ToString(),
                            NomProyecto = reader["NomProyecto"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error listar clientes: " + ex.Message);
            }
            return lista;
        }
        public bool EditarCliente(entCliente cliente)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        UPDATE dbo.Cliente SET 
                            NomCliente = @Nom, 
                            Documento = @Doc, 
                            NDocumento = @Num, 
                            TelefonoCliente = @Tel, 
                            CorreoCliente = @Correo 
                        WHERE IdCliente = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", cliente.NomCliente);
                    cmd.Parameters.AddWithValue("@Doc", cliente.Documento);
                    cmd.Parameters.AddWithValue("@Num", cliente.NDocumento);
                    cmd.Parameters.AddWithValue("@Tel", cliente.TelefonoCliente);
                    cmd.Parameters.AddWithValue("@Correo", cliente.CorreoCliente);
                    cmd.Parameters.AddWithValue("@Id", cliente.IdCliente);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
