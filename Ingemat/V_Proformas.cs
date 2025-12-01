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
    public partial class V_Proformas : Form
    {
        private logProformaVista _logProformaVista = new logProformaVista();

        public V_Proformas()
        {
            InitializeComponent();
        }

        private void V_proformas_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarProformas();
        }

        private void ConfigurarDataGridView()
        {
            dgvProformas.AutoGenerateColumns = false;
            dgvProformas.Columns.Clear();

            dgvProformas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdProforma",
                HeaderText = "Código",
                DataPropertyName = "IdProforma",
                Width = 60
            });
            dgvProformas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaP",
                HeaderText = "Fecha",
                DataPropertyName = "FechaP",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 80
            });
            dgvProformas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNomCliente",
                HeaderText = "Cliente",
                DataPropertyName = "NomCliente",
                Width = 200
            });
            dgvProformas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMotivo",
                HeaderText = "Motivo",
                DataPropertyName = "Motivo",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvProformas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNomFormato",
                HeaderText = "Servicio",
                DataPropertyName = "NomFormato",
                Width = 150
            });
            dgvProformas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecioFinal",
                HeaderText = "Monto Total",
                DataPropertyName = "PrecioFinal",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 90
            });
        }
        private void CargarProformas()
        {
            try
            {
                List<entProformaVista> lista = _logProformaVista.Listar();
                dgvProformas.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proformas: " + ex.Message, "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRealizarOS_Click(object sender, EventArgs e)
        {
            if (dgvProformas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una proforma de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entProformaVista proformaSeleccionada = (entProformaVista)dgvProformas.SelectedRows[0].DataBoundItem;

            if (proformaSeleccionada == null)
            {
                MessageBox.Show("Error al obtener los datos de la proforma seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            V_NuevaOrdenServicio formNuevaOS = new V_NuevaOrdenServicio(proformaSeleccionada);
            formNuevaOS.Show();

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

        private void btn_facturas_Click(object sender, EventArgs e)
        {
            V_Facturas pantalla = new V_Facturas();
            this.Hide();
            pantalla.Show();
        }

        private void btn_realizarOS_Click(object sender, EventArgs e)
        {
            V_NuevaOrdenServicio pantalla = new V_NuevaOrdenServicio();
            this.Hide();
            pantalla.Show();
        }

        private void btn_os_Click(object sender, EventArgs e)
        {
            V_OrdenServicio pantalla = new V_OrdenServicio();
            this.Hide();
            pantalla.Show();
        }

        private void btn_facturas_Click_1(object sender, EventArgs e)
        {
            V_Facturas pantalla = new V_Facturas();
            this.Hide();
            pantalla.Show();
        }
    }
}
