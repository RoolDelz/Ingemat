using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Ingemat
{
    public partial class G_Facturas : Form
    {
        private logFactura _logFactura = new logFactura();
        public G_Facturas()
        {
            InitializeComponent();
        }
        private void G_Facturas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarFacturas();
        }
        private void ConfigurarGrid()
        {
            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.Clear();

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "IdFactura", Width = 50 });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "N° Factura", DataPropertyName = "NumFactura", Width = 100 });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha", DataPropertyName = "FechaFactura", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Proyecto", DataPropertyName = "NomProyecto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "NomCliente", Width = 150 });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Total", DataPropertyName = "PrecioFactura", Width = 90, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "Estado", Width = 80 });
        }
        private void CargarFacturas()
        {
            try
            {
                dgvFacturas.DataSource = _logFactura.Listar();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una factura.", "Aviso");
                return;
            }
            var item = (entFacturaVista)dgvFacturas.SelectedRows[0].DataBoundItem;

            G_VerFactura visor = new G_VerFactura(item.IdFactura);
            visor.Show();
            this.Hide();
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btn_proyectos_Click(object sender, EventArgs e)
        {
            G_Proyectos pantalla = new G_Proyectos();
            this.Hide();
            pantalla.Show();
        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            G_Empleados pantalla = new G_Empleados();
            this.Hide();
            pantalla.Show();
        }

        private void btn_formatos_Click(object sender, EventArgs e)
        {
            G_Formatos pantalla = new G_Formatos();
            this.Hide();
            pantalla.Show();
        }

        private void btn_os_Click(object sender, EventArgs e)
        {
            G_AprobarOS pantalla = new G_AprobarOS();
            this.Hide();
            pantalla.Show();
        }

        private void btn_ot_Click(object sender, EventArgs e)
        {
            G_OrdenTrabajo pantalla = new G_OrdenTrabajo();
            this.Hide();
            pantalla.Show();
        }

        private void btn_facturas_Click(object sender, EventArgs e)
        {
            G_Facturas pantalla = new G_Facturas();
            this.Hide();
            pantalla.Show();
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
