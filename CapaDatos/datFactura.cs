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
        private readonly Conexion conexion = Conexion.Instancia;

        public bool InsertarFactura(entFactura factura)
        {
            bool exito = false;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO dbo.Factura (NumFactura, FechaFactura, PrecioFactura, IdProyecto, MetodoPago) 
                        VALUES (@Num, @Fecha, @Precio, @IdProy, @Metodo)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Num", factura.NumFactura ?? "S/N");
                    cmd.Parameters.AddWithValue("@Fecha", factura.FechaFactura);
                    cmd.Parameters.AddWithValue("@Precio", factura.PrecioFactura);
                    cmd.Parameters.AddWithValue("@IdProy", factura.IdProyecto);
                    cmd.Parameters.AddWithValue("@Metodo", factura.MetodoPago);

                    int filas = cmd.ExecuteNonQuery();
                    exito = filas > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en datFactura.InsertarFactura: " + ex.Message);
                throw ex;
            }
            return exito;
        }

        public int ObtenerIdProyectoPorOS(int idOS)
        {
            int idProyecto = 0;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    string query = "SELECT IdProyecto FROM dbo.Proyecto WHERE IdOS = @IdOS";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdOS", idOS);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        idProyecto = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception) { }
            return idProyecto;
        }
        public int ObtenerIdEmpresaPorOS(int idOS)
        {
            int idEmpresa = 0;
            try
            {
                using (SqlConnection conn = conexion.Conectar())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT IdEmpresa FROM dbo.OrdenServicio WHERE IdOS = @IdOS", conn);
                    cmd.Parameters.AddWithValue("@IdOS", idOS);
                    object result = cmd.ExecuteScalar();
                    if (result != null) idEmpresa = Convert.ToInt32(result);
                }
            }
            catch { }
            return idEmpresa;
        }
    }
}