using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datOrdenTrabajo
    {
        private readonly Conexion conexion = Conexion.Instancia;

        public bool InsertarOrdenTrabajo(entOrdenTrabajo ot)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO dbo.OrdenTrabajo (N_OT, NomOT, FechaCreacion, IdProyecto) 
                        VALUES (@NOT, @NomOT, @Fecha, @IdProy)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NOT", ot.N_OT);
                    cmd.Parameters.AddWithValue("@NomOT", ot.NomOT);
                    cmd.Parameters.AddWithValue("@Fecha", ot.FechaCreacion);
                    cmd.Parameters.AddWithValue("@IdProy", ot.IdProyecto);

                    int filas = cmd.ExecuteNonQuery();
                    exito = filas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error insertando OT: " + ex.Message);
                throw ex;
            }
            return exito;
        }
        public List<entOrdenTrabajoVista> ListarOrdenesTrabajoVista()
        {
            List<entOrdenTrabajoVista> lista = new List<entOrdenTrabajoVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ot.IdOT, ot.N_OT, ot.NomOT, ot.Estado, ot.FechaFinalizacion,
                            p.NomProyecto,
                            e.NombreEmpleado, ote.FechaAsignacion
                        FROM 
                            dbo.OrdenTrabajo ot
                        INNER JOIN 
                            dbo.Proyecto p ON ot.IdProyecto = p.IdProyecto
                        LEFT JOIN 
                            dbo.OrdenTrabajoEncargado ote ON ot.IdOT = ote.IdOT
                        LEFT JOIN 
                            dbo.Empleado e ON ote.IdEmpleado = e.IdEmpleado
                        ORDER BY 
                            ot.IdOT DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new entOrdenTrabajoVista
                        {
                            IdOT = Convert.ToInt32(reader["IdOT"]),
                            N_OT = reader["N_OT"].ToString(),
                            NomOT = reader["NomOT"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            NomProyecto = reader["NomProyecto"].ToString(),

                            FechaFinalizacion = reader["FechaFinalizacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaFinalizacion"]),
                            NombreEmpleado = reader["NombreEmpleado"] == DBNull.Value ? "--- Sin Asignar ---" : reader["NombreEmpleado"].ToString(),
                            FechaAsignacion = reader["FechaAsignacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaAsignacion"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar órdenes de trabajo: " + ex.Message);
            }
            return lista;
        }
        public bool AsignarEmpleado(int idOT, int idEmpleado)
        {
            bool exito = false;
            using (SqlConnection conn = conexion.Conectar())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string queryInsert = "INSERT INTO dbo.OrdenTrabajoEncargado (IdOT, IdEmpleado, FechaAsignacion) VALUES (@IdOT, @IdEmp, @Fecha)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn, transaction);
                    cmdInsert.Parameters.AddWithValue("@IdOT", idOT);
                    cmdInsert.Parameters.AddWithValue("@IdEmp", idEmpleado);
                    cmdInsert.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    cmdInsert.ExecuteNonQuery();

                    string queryUpdate = "UPDATE dbo.OrdenTrabajo SET Estado = 'Asignado' WHERE IdOT = @IdOT";
                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn, transaction);
                    cmdUpdate.Parameters.AddWithValue("@IdOT", idOT);
                    cmdUpdate.ExecuteNonQuery();

                    transaction.Commit();
                    exito = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Error al asignar empleado: " + ex.Message);
                }
            }
            return exito;
        }
        public List<entOrdenTrabajoVista> ListarOrdenesPorEmpleado(int idEmpleado)
        {
            List<entOrdenTrabajoVista> lista = new List<entOrdenTrabajoVista>();
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ot.IdOT, 
                            ot.N_OT, 
                            ot.NomOT, 
                            ot.Estado, 
                            p.NomProyecto,
                            ote.FechaAsignacion
                        FROM 
                            dbo.OrdenTrabajoEncargado ote
                        INNER JOIN 
                            dbo.OrdenTrabajo ot ON ote.IdOT = ot.IdOT
                        INNER JOIN 
                            dbo.Proyecto p ON ot.IdProyecto = p.IdProyecto
                        WHERE 
                            ote.IdEmpleado = @IdEmpleado
                        ORDER BY 
                            ote.FechaAsignacion DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        lista.Add(new entOrdenTrabajoVista
                        {
                            IdOT = Convert.ToInt32(reader["IdOT"]),
                            N_OT = reader["N_OT"].ToString(),
                            NomOT = reader["NomOT"].ToString(),
                            Estado = reader["Estado"].ToString(),
                            NomProyecto = reader["NomProyecto"].ToString(),
                            FechaAsignacion = Convert.ToDateTime(reader["FechaAsignacion"]),
                            NombreEmpleado = "TÚ"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar tus actividades: " + ex.Message);
            }
            return lista;
        }
        public entDetalleOT ObtenerDetalleCompleto(int idOT)
        {
            entDetalleOT detalle = null;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            ot.IdOT, ot.NomOT,
                            p.NomProyecto,
                            prof.DireccionProforma,
                            cat.NomCategoria,
                            f.NomFormato
                        FROM dbo.OrdenTrabajo ot
                        INNER JOIN dbo.Proyecto p ON ot.IdProyecto = p.IdProyecto
                        INNER JOIN dbo.OrdenServicio os ON p.IdOS = os.IdOS
                        INNER JOIN dbo.Proforma prof ON os.IdProforma = prof.IdProforma
                        INNER JOIN dbo.Categoria cat ON prof.IdCategoria = cat.IdCategoria
                        INNER JOIN dbo.Formato f ON prof.IdFormato = f.IdFormato
                        WHERE ot.IdOT = @IdOT";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdOT", idOT);
                    SqlDataReader r = cmd.ExecuteReader();
                    if (r.Read())
                    {
                        detalle = new entDetalleOT
                        {
                            IdOT = Convert.ToInt32(r["IdOT"]),
                            NomOT = r["NomOT"].ToString(),
                            NomProyecto = r["NomProyecto"].ToString(),
                            Direccion = r["DireccionProforma"].ToString(),
                            Categoria = r["NomCategoria"].ToString(),
                            Formato = r["NomFormato"].ToString()
                        };
                    }
                }
            }
            catch (Exception) { }
            return detalle;
        }
        public bool FinalizarOrdenTrabajo(int idOT)
        {
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "UPDATE dbo.OrdenTrabajo SET Estado = 'Finalizada', FechaFinalizacion = GETDATE() WHERE IdOT = @IdOT";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdOT", idOT);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception) { return false; }
        }
    }
}
