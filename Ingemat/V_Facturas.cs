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

namespace Ingemat
{
    public partial class V_Facturas : Form
    {
        private logFactura _logFactura = new logFactura();
        public V_Facturas()
        {
            InitializeComponent();
        }
        private void V_Facturas_Load(object sender, EventArgs e)
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

            V_VerFactura visor = new V_VerFactura(item.IdFactura);
            visor.Show();
            this.Hide();
        }
        private void btn_proformas_Click(object sender, EventArgs e)
        {
            V_Proformas pantalla = new V_Proformas();
            this.Hide();
            pantalla.Show();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_nuevaProforma_Click(object sender, EventArgs e)
        {
            V_NuevaProforma pantalla = new V_NuevaProforma();
            this.Hide();
            pantalla.Show();
        }

        private void btn_facturas_Click(object sender, EventArgs e)
        {
            V_Facturas pantalla = new V_Facturas();
            this.Hide();
            pantalla.Show();
        }

        private void btn_os_Click(object sender, EventArgs e)
        {
            V_OrdenServicio pantalla = new V_OrdenServicio();
            this.Hide();
            pantalla.Show();
        }
    }
}
