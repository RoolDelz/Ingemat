using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datEmpresa
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public List<entEmpresa> ListarEmpresas()
        {
            List<entEmpresa> lista = new List<entEmpresa>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdEmpresa, NomEmpresa, Ruc, TelefonoEmpresa, CorreoEmpresa, DireccionEmpresa FROM dbo.Empresa", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        lista.Add(new entEmpresa
                        {
                            IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                            NomEmpresa = reader["NomEmpresa"].ToString(),
                            Ruc = reader["Ruc"].ToString(),
                            TelefonoEmpresa = reader["TelefonoEmpresa"].ToString(),
                            CorreoEmpresa = reader["CorreoEmpresa"].ToString(),
                            DireccionEmpresa = reader["DireccionEmpresa"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en datEmpresa.ListarEmpresas: " + ex.Message);
            }
            return lista;
        }
        public int InsertarEmpresa(entEmpresa empresa)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                string query = @"
                    INSERT INTO dbo.Empresa (NomEmpresa, Ruc, TelefonoEmpresa, CorreoEmpresa, DireccionEmpresa) 
                    VALUES (@Nom, @Ruc, @Tel, @Correo, @Dir);
                    SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nom", empresa.NomEmpresa);
                cmd.Parameters.AddWithValue("@Ruc", empresa.Ruc);
                cmd.Parameters.AddWithValue("@Tel", empresa.TelefonoEmpresa);
                cmd.Parameters.AddWithValue("@Correo", empresa.CorreoEmpresa);
                cmd.Parameters.AddWithValue("@Dir", empresa.DireccionEmpresa);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public entEmpresa ObtenerEmpresaPorId(int idEmpresa)
        {
            entEmpresa emp = null;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT * FROM dbo.Empresa WHERE IdEmpresa = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", idEmpresa);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        emp = new entEmpresa
                        {
                            IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                            NomEmpresa = reader["NomEmpresa"].ToString(),
                            Ruc = reader["Ruc"].ToString(),
                            TelefonoEmpresa = reader["TelefonoEmpresa"].ToString(),
                            CorreoEmpresa = reader["CorreoEmpresa"].ToString(),
                            DireccionEmpresa = reader["DireccionEmpresa"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error: " + ex.Message); }
            return emp;
        }
        public List<entEmpresaVista> ListarEmpresasVista()
        {
            List<entEmpresaVista> lista = new List<entEmpresaVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT
                            e.IdEmpresa, e.NomEmpresa, e.Ruc, e.TelefonoEmpresa, e.CorreoEmpresa, e.DireccionEmpresa,
                            ISNULL((SELECT TOP 1 p.NomProyecto 
                                    FROM dbo.OrdenServicio os 
                                    JOIN dbo.Proyecto p ON os.IdOS = p.IdOS 
                                    WHERE os.IdEmpresa = e.IdEmpresa 
                                    ORDER BY p.IdProyecto DESC), '--- Sin Proyecto ---') as NomProyecto
                        FROM 
                            dbo.Empresa e
                        ORDER BY 
                            e.IdEmpresa DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new entEmpresaVista
                        {
                            IdEmpresa = Convert.ToInt32(reader["IdEmpresa"]),
                            NomEmpresa = reader["NomEmpresa"].ToString(),
                            Ruc = reader["Ruc"].ToString(),
                            TelefonoEmpresa = reader["TelefonoEmpresa"].ToString(),
                            CorreoEmpresa = reader["CorreoEmpresa"].ToString(),
                            DireccionEmpresa = reader["DireccionEmpresa"].ToString(),
                            NomProyecto = reader["NomProyecto"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error listar empresas: " + ex.Message);
            }
            return lista;
        }

        public bool EditarEmpresa(entEmpresa empresa)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        UPDATE dbo.Empresa SET 
                            NomEmpresa = @Nom, 
                            Ruc = @Ruc, 
                            TelefonoEmpresa = @Tel, 
                            CorreoEmpresa = @Correo,
                            DireccionEmpresa = @Dir
                        WHERE IdEmpresa = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Nom", empresa.NomEmpresa);
                    cmd.Parameters.AddWithValue("@Ruc", empresa.Ruc);
                    cmd.Parameters.AddWithValue("@Tel", empresa.TelefonoEmpresa);
                    cmd.Parameters.AddWithValue("@Correo", empresa.CorreoEmpresa);
                    cmd.Parameters.AddWithValue("@Dir", empresa.DireccionEmpresa);
                    cmd.Parameters.AddWithValue("@Id", empresa.IdEmpresa);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
