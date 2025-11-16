using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class datFactura
    {
        public DataTable ListarFacturas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT 
                            F.IdFactura, F.NumFactura AS Codigo,
                            P.NomProyecto, F.FechaFactura AS Fecha, 
                            FO.NomFormato AS Estudio, F.PrecioFactura AS Precio, 
                            F.Estado, F.Observaciones
                        FROM dbo.Factura F
                        JOIN dbo.Proyecto P ON F.IdProyecto = P.IdProyecto
                        JOIN dbo.OrdenServicio OS ON P.IdOS = OS.IdOS
                        JOIN dbo.Proforma PR ON OS.IdProforma = PR.IdProforma
                        JOIN dbo.Formato FO ON PR.IdFormato = FO.IdFormato";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en datFactura.ListarFacturas: " + ex.Message);
                }
            }
            return dt;
        }

        public DataTable ListarProyectosSinFactura()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @"
                        SELECT P.IdProyecto, P.NomProyecto 
                        FROM dbo.Proyecto P
                        LEFT JOIN dbo.Factura F ON P.IdProyecto = F.IdProyecto
                        WHERE F.IdFactura IS NULL";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return dt;
        }

        public bool InsertarFactura(entFactura fac)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @"
                SET NOCOUNT OFF; 
                INSERT INTO dbo.Factura 
                             (NumFactura, FechaFactura, PrecioFactura, Observaciones, IdProyecto, Estado)
                             VALUES 
                             (@Num, @Fecha, @Precio, @Obs, @IdProyecto, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Num", fac.NumFactura);
                        cmd.Parameters.AddWithValue("@Fecha", fac.FechaFactura);
                        cmd.Parameters.AddWithValue("@Precio", fac.PrecioFactura);
                        cmd.Parameters.AddWithValue("@Obs", fac.Observaciones);
                        cmd.Parameters.AddWithValue("@IdProyecto", fac.IdProyecto);
                        cmd.Parameters.AddWithValue("@Estado", fac.Estado);

                        int filas = cmd.ExecuteNonQuery();

                        if (filas == 0)
                        {
                            throw new Exception("ERROR DE BASE DE DATOS: La operación SQL no insertó ninguna fila.");
                        }

                        return true; 
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("ERROR SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR INESPERADO: " + ex.Message);
                }
            }
        }

        public bool EditarFactura(entFactura fac)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @"UPDATE dbo.Factura SET
                                     NumFactura = @Num,
                                     FechaFactura = @Fecha,
                                     PrecioFactura = @Precio,
                                     Observaciones = @Obs,
                                     Estado = @Estado
                                     WHERE IdFactura = @IdFactura";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Num", fac.NumFactura);
                        cmd.Parameters.AddWithValue("@Fecha", fac.FechaFactura);
                        cmd.Parameters.AddWithValue("@Precio", fac.PrecioFactura);
                        cmd.Parameters.AddWithValue("@Obs", fac.Observaciones);
                        cmd.Parameters.AddWithValue("@Estado", fac.Estado);
                        cmd.Parameters.AddWithValue("@IdFactura", fac.IdFactura);

                        int filas = cmd.ExecuteNonQuery();
                        return (filas > 0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("--- ERROR SQL AL EDITAR FACTURA ---");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("-----------------------------------");
                    return false;
                }
            }
        }
    }
}