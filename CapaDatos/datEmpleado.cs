using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class datEmpleado
    {
        public DataTable ListarEmpleados()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = "SELECT IdEmpleado, NombreEmpleado, Dni, TelefonoEmpleado, CorreoEmpleado, Cargo, Estado FROM dbo.Empleado";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    // Manejar el error (por ejemplo, registrar en un log)
                    Console.WriteLine("Error en datEmpleado.ListarEmpleados: " + ex.Message);
                }
            }
            return dt;
        }

        public bool InsertarEmpleado(entEmpleado emp)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @"INSERT INTO dbo.Empleado 
                                 (NombreEmpleado, Dni, TelefonoEmpleado, CorreoEmpleado, Cargo, Estado) 
                                 VALUES 
                                 (@Nombre, @Dni, @Telefono, @Correo, @Cargo, @Estado)";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", emp.NombreEmpleado);
                        cmd.Parameters.AddWithValue("@Dni", emp.Dni);
                        cmd.Parameters.AddWithValue("@Telefono", emp.TelefonoEmpleado);
                        cmd.Parameters.AddWithValue("@Correo", emp.CorreoEmpleado);
                        cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                        cmd.Parameters.AddWithValue("@Estado", emp.Estado);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return (filasAfectadas > 0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en datEmpleado.InsertarEmpleado: " + ex.Message);
                    return false;
                }
            }
        }

        public bool EditarEmpleado(entEmpleado emp)
        {
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = @"UPDATE dbo.Empleado SET
                                 NombreEmpleado = @Nombre,
                                 Dni = @Dni,
                                 TelefonoEmpleado = @Telefono,
                                 CorreoEmpleado = @Correo,
                                 Cargo = @Cargo,
                                 Estado = @Estado
                                 WHERE IdEmpleado = @IdEmpleado";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", emp.NombreEmpleado);
                        cmd.Parameters.AddWithValue("@Dni", emp.Dni);
                        cmd.Parameters.AddWithValue("@Telefono", emp.TelefonoEmpleado);
                        cmd.Parameters.AddWithValue("@Correo", emp.CorreoEmpleado);
                        cmd.Parameters.AddWithValue("@Cargo", emp.Cargo);
                        cmd.Parameters.AddWithValue("@Estado", emp.Estado);
                        cmd.Parameters.AddWithValue("@IdEmpleado", emp.IdEmpleado);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return (filasAfectadas > 0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en datEmpleado.EditarEmpleado: " + ex.Message);
                    return false;
                }
            }
        }
        public entEmpleado BuscarEmpleadoPorDni(string dni)
        {
            entEmpleado emp = null; 
            using (SqlConnection cn = Conexion.Instancia.Conectar())
            {
                try
                {
                    cn.Open();
                    string query = "SELECT * FROM dbo.Empleado WHERE Dni = @Dni";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Dni", dni);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read()) 
                            {
                                emp = new entEmpleado(); 
                                emp.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                                emp.NombreEmpleado = dr["NombreEmpleado"].ToString();
                                emp.Dni = dr["Dni"].ToString();
                                emp.TelefonoEmpleado = dr["TelefonoEmpleado"].ToString();
                                emp.CorreoEmpleado = dr["CorreoEmpleado"].ToString();
                                emp.Cargo = dr["Cargo"].ToString();
                                emp.Estado = Convert.ToBoolean(dr["Estado"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en datEmpleado.BuscarEmpleadoPorDni: " + ex.Message);
                }
            }
            return emp;
        }
    }
}
