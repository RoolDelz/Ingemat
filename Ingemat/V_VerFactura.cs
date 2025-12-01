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
    public partial class V_VerFactura : Form
    {
        private logFactura _logFactura = new logFactura();
        private logEmpresa _logEmpresa = new logEmpresa();
        private logProforma _logProforma = new logProforma();
        private logGastoAdicional _logGastoAdicional = new logGastoAdicional();

        private int _idFactura;
        public V_VerFactura(int idFactura)
        {
            InitializeComponent();
            _idFactura = idFactura;
        }
        private void V_VerFactura_Load(object sender, EventArgs e)
        {
            ConfigurarFormularioSoloLectura();
            ConfigurarGrid();
            CargarDatosCompletos();
        }
        private void ConfigurarFormularioSoloLectura()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox) ((TextBox)c).ReadOnly = true;
                if (c is ComboBox) ((ComboBox)c).Enabled = false;
                if (c is DateTimePicker) ((DateTimePicker)c).Enabled = false;
            }

            btnRegresar.Enabled = true;
            if (Controls.ContainsKey("btnGuardar")) Controls["btnGuardar"].Visible = false;

            dgvGastosAdicionales.ReadOnly = true;
            dgvGastosAdicionales.AllowUserToAddRows = false;
        }
        private void ConfigurarGrid()
        {
            dgvGastosAdicionales.AutoGenerateColumns = false;
            dgvGastosAdicionales.Columns.Clear();
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "NomGastoA", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }
        private void CargarDatosCompletos()
        {
            try
            {
                DataTable dt = _logFactura.ObtenerDetalle(_idFactura);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                int idEmpresa = Convert.ToInt32(row["IdEmpresa"]);
                int idProforma = Convert.ToInt32(row["IdProforma"]);

                dtpFecha.Value = Convert.ToDateTime(row["FechaFactura"]);
                cmbMetodoPago.Text = row["MetodoPago"].ToString();

                entEmpresa empresa = _logEmpresa.ObtenerPorId(idEmpresa);
                if (empresa != null)
                {
                    txtEmpresaSolicitante.Text = empresa.NomEmpresa;
                    txtRuc.Text = empresa.Ruc;
                    txtTelefono.Text = empresa.TelefonoEmpresa;
                    txtCorreo.Text = empresa.CorreoEmpresa;
                    txtDireccionEmpresa.Text = empresa.DireccionEmpresa;
                }

                entProformaVista proforma = _logProforma.ObtenerVistaPorId(idProforma);
                if (proforma != null)
                {
                    txtRepresentante.Text = proforma.NomCliente;
                    txtProyecto.Text = proforma.Motivo;
                    txtDireccion.Text = proforma.DireccionProforma;

                    cmbCategoria.Items.Add(proforma.NomCategoria);
                    cmbCategoria.SelectedIndex = 0;
                    cmbFormato.Items.Add(proforma.NomFormato);
                    cmbFormato.SelectedIndex = 0;

                    lblPrecioFormato.Text = proforma.PrecioFormato.ToString("N2");
                }
                List<entGastoAdicional> gastos = _logGastoAdicional.ListarGastosPorProforma(idProforma);
                dgvGastosAdicionales.DataSource = gastos;

                decimal totalGastos = 0;
                foreach (var g in gastos) totalGastos += g.Precio;

                decimal costo = (proforma != null ? proforma.PrecioFormato : 0) + totalGastos;
                decimal total = Convert.ToDecimal(row["PrecioFactura"]);

                lblGastosAdicionalesTotal.Text = totalGastos.ToString("N2");
                lblCosto.Text = costo.ToString("N2");
                lblTotalFinal.Text = total.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalles: " + ex.Message);
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            V_Facturas lista = new V_Facturas();
            lista.Show();
            this.Close();
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
    }
}
