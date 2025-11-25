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
    public partial class V_OrdenServicio : Form
    {
        private logOrdenServicio _logOrdenServicio = new logOrdenServicio();
        public V_OrdenServicio()
        {
            InitializeComponent();
        }
        private void V_OrdenServicio_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarOrdenes();
        }
        private void ConfigurarDataGridView()
        {
            dgvOrdenesServicio.AutoGenerateColumns = false;
            dgvOrdenesServicio.Columns.Clear();

            dgvOrdenesServicio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdOS",
                HeaderText = "Cód. OS",
                DataPropertyName = "IdOS",
                Width = 60
            });
            dgvOrdenesServicio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "FechaOS",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 80
            });
            dgvOrdenesServicio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmpresa",
                HeaderText = "Empresa Solicitante",
                DataPropertyName = "NomEmpresa",
                Width = 200
            });
            dgvOrdenesServicio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRuc",
                HeaderText = "RUC",
                DataPropertyName = "RucEmpresa",
                Width = 100
            });
            dgvOrdenesServicio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProforma",
                HeaderText = "Proforma Ref.",
                DataPropertyName = "MotivoProforma", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvOrdenesServicio.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "EstadoOS",
                Width = 80
            });
        }
        private void CargarOrdenes()
        {
            try
            {
                List<entOrdenServicioVista> lista = _logOrdenServicio.Listar();
                dgvOrdenesServicio.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar órdenes de servicio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRealizarFactura_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesServicio.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una Orden Aprobada para facturar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entOrdenServicioVista ordenSeleccionada = (entOrdenServicioVista)dgvOrdenesServicio.SelectedRows[0].DataBoundItem;

            if (ordenSeleccionada.EstadoOS != "Aprobado")
            {
                MessageBox.Show("Solo se pueden facturar órdenes Aprobadas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            V_NuevaFactura formFactura = new V_NuevaFactura(ordenSeleccionada);
            formFactura.Show();
            this.Hide();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_proformas_Click(object sender, EventArgs e)
        {
            V_Proformas pantalla = new V_Proformas();
            this.Hide();
            pantalla.Show();
        }

        private void btn_nuevaProforma_Click(object sender, EventArgs e)
        {
            V_NuevaProforma pantalla = new V_NuevaProforma();
            this.Hide();
            pantalla.Show();
        }

        private void btn_os_Click(object sender, EventArgs e)
        {
            V_OrdenServicio pantalla = new V_OrdenServicio();
            this.Hide();
            pantalla.Show();
        }

        private void btn_facturas_Click(object sender, EventArgs e)
        {
            V_Facturas pantalla = new V_Facturas();
            this.Hide();
            pantalla.Show();
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            V_VistaOS pantalla = new V_VistaOS();
            this.Hide();
            pantalla.Show();
        }
    }
}
