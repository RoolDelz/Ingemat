using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using static CapaEntidad.Formatos;

namespace CapaDatos
{
    public class datProforma
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public int InsertarProforma(entProforma proforma)
        {
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Proforma (Motivo, FechaP, DireccionProforma, IdCliente, IdCategoria, IdFormato, Total, PrecioFinal) VALUES (@Motivo, @FechaP, @Dir, @IdCli, @IdCat, @IdFmt, @Total, @Final); SELECT SCOPE_IDENTITY();", conn);

                cmd.Parameters.AddWithValue("@Motivo", proforma.Motivo);
                cmd.Parameters.AddWithValue("@FechaP", proforma.FechaP);
                cmd.Parameters.AddWithValue("@Dir", proforma.DireccionProforma);
                cmd.Parameters.AddWithValue("@IdCli", proforma.IdCliente);
                cmd.Parameters.AddWithValue("@IdCat", proforma.IdCategoria);
                cmd.Parameters.AddWithValue("@IdFmt", proforma.IdFormato);
                cmd.Parameters.AddWithValue("@Total", proforma.Total);
                cmd.Parameters.AddWithValue("@Final", proforma.PrecioFinal);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
       public List<entProformaVista> ListarProformasVista()
        {
            List<entProformaVista> lista = new List<entProformaVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.IdProforma, p.Motivo, p.FechaP, p.DireccionProforma, 
                            p.IdCliente, c.NomCliente, 
                            p.IdCategoria, cat.NomCategoria, 
                            p.IdFormato, f.NomFormato, f.PrecioFormato,
                            p.Total, p.PrecioFinal
                        FROM 
                            dbo.Proforma p
                        LEFT JOIN 
                            dbo.Cliente c ON p.IdCliente = c.IdCliente
                        LEFT JOIN 
                            dbo.Categoria cat ON p.IdCategoria = cat.IdCategoria
                        LEFT JOIN 
                            dbo.Formato f ON p.IdFormato = f.IdFormato
                        ORDER BY
                            p.IdProforma DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        lista.Add(new entProformaVista
                        {
                            IdProforma = Convert.ToInt32(reader["IdProforma"]),
                            Motivo = reader["Motivo"].ToString(),
                            FechaP = Convert.ToDateTime(reader["FechaP"]),
                            DireccionProforma = reader["DireccionProforma"].ToString(),

                            Total = reader["Total"] == DBNull.Value ? 0.00m : Convert.ToDecimal(reader["Total"]),
                            PrecioFinal = reader["PrecioFinal"] == DBNull.Value ? 0.00m : Convert.ToDecimal(reader["PrecioFinal"]),

                            IdCliente = reader["IdCliente"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCliente"]),
                            NomCliente = reader["NomCliente"] == DBNull.Value ? "---" : reader["NomCliente"].ToString(),

                            IdCategoria = reader["IdCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCategoria"]),
                            NomCategoria = reader["NomCategoria"] == DBNull.Value ? "---" : reader["NomCategoria"].ToString(),

                            IdFormato = reader["IdFormato"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdFormato"]),
                            NomFormato = reader["NomFormato"] == DBNull.Value ? "---" : reader["NomFormato"].ToString(),
                            
                            PrecioFormato = reader["PrecioFormato"] == DBNull.Value ? 0.00m : Convert.ToDecimal(reader["PrecioFormato"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error leyendo datos: " + ex.Message);
            }
            return lista;
        }
        public entProformaVista ObtenerProformaVistaPorId(int idProforma)
        {
            entProformaVista p = null;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"SELECT p.IdProforma, p.Motivo, p.FechaP, p.DireccionProforma, 
                                    p.IdCliente, c.NomCliente, 
                                    p.IdCategoria, cat.NomCategoria, 
                                    p.IdFormato, f.NomFormato, f.PrecioFormato, p.Total, p.PrecioFinal
                             FROM dbo.Proforma p
                             LEFT JOIN dbo.Cliente c ON p.IdCliente = c.IdCliente
                             LEFT JOIN dbo.Categoria cat ON p.IdCategoria = cat.IdCategoria
                             LEFT JOIN dbo.Formato f ON p.IdFormato = f.IdFormato
                             WHERE p.IdProforma = @Id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", idProforma);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        p = new entProformaVista
                        {
                            IdProforma = Convert.ToInt32(reader["IdProforma"]),
                            Motivo = reader["Motivo"].ToString(),
                            DireccionProforma = reader["DireccionProforma"].ToString(),
                            NomCliente = reader["NomCliente"].ToString(),
                            IdCategoria = reader["IdCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdCategoria"]),
                            NomCategoria = reader["NomCategoria"].ToString(),
                            IdFormato = reader["IdFormato"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdFormato"]),
                            NomFormato = reader["NomFormato"].ToString(),
                            PrecioFormato = reader["PrecioFormato"] == DBNull.Value ? 0m : Convert.ToDecimal(reader["PrecioFormato"])
                        };
                    }
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Error: " + ex.Message); }
            return p;
        }
    }
}
