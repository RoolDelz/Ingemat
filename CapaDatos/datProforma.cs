using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

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
                cmd.Parameters.AddWithValue("@Total", proforma.Total); // Costo
                cmd.Parameters.AddWithValue("@Final", proforma.PrecioFinal); // Total

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
