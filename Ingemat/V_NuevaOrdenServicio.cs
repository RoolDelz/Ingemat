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
using static CapaEntidad.Formatos;


namespace Ingemat
{
    public partial class V_NuevaOrdenServicio : Form
    {
        private logEmpresa _logEmpresa = new logEmpresa();
        private logGastoAdicional _logGastoAdicional = new logGastoAdicional();
        private logOrdenServicio _logOrdenServicio = new logOrdenServicio();

        private entProformaVista proformaActual;
        public V_NuevaOrdenServicio()
        {
            InitializeComponent();
        }

        public V_NuevaOrdenServicio(entProformaVista proformaSeleccionada)
        {
            InitializeComponent();
            this.proformaActual = proformaSeleccionada;
        }
        private void V_NuevaOrdenServicio_Load(object sender, EventArgs e)
        {
            if (proformaActual == null)
            {
                MessageBox.Show("Error: No se ha cargado ninguna proforma. Este formulario debe abrirse desde la ventana de Proformas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ConfigurarFormulario();
            PreCargarDatosProforma();
            CargarGastosAdicionales();
        }
        private void ConfigurarFormulario()
        {
            txtProyecto.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            cmbCategoria.Enabled = false;
            cmbFormato.Enabled = false;
            dgvGastosAdicionales.ReadOnly = true;
            dgvGastosAdicionales.AllowUserToAddRows = false;

            ConfigurarDataGridViewGastos();
        }

        private void ConfigurarDataGridViewGastos()
        {
            dgvGastosAdicionales.AutoGenerateColumns = false;
            dgvGastosAdicionales.Columns.Clear();
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "NomGastoA", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        private void PreCargarDatosProforma()
        {
            txtProyecto.Text = proformaActual.Motivo;

            txtDireccion.Text = proformaActual.DireccionProforma;

            txtRepresentante.Text = proformaActual.NomCliente;

            cmbCategoria.Items.Add(new Categoria { IdCategoria = proformaActual.IdCategoria, NomCategoria = proformaActual.NomCategoria });
            cmbCategoria.SelectedIndex = 0;

            cmbFormato.Items.Add(new Formato { IdFormato = proformaActual.IdFormato, NomFormato = proformaActual.NomFormato });
            cmbFormato.SelectedIndex = 0;

            lblPrecioFormato.Text = proformaActual.PrecioFormato.ToString("N2");

            decimal gastos = proformaActual.Total - proformaActual.PrecioFormato;
            lblGastosAdicionalesTotal.Text = gastos.ToString("N2");
            lblCosto.Text = proformaActual.Total.ToString("N2");
            lblTotalFinal.Text = proformaActual.PrecioFinal.ToString("N2");
        }

        private void CargarGastosAdicionales()
        {
            try
            {
                List<entGastoAdicional> gastos = _logGastoAdicional.ListarGastosPorProforma(proformaActual.IdProforma);
                dgvGastosAdicionales.DataSource = gastos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar gastos adicionales: " + ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                entEmpresa nuevaEmpresa = new entEmpresa
                {
                    NomEmpresa = txtEmpresaSolicitante.Text,
                    Ruc = txtRuc.Text,
                    TelefonoEmpresa = txtTelefono.Text,
                    DireccionEmpresa = txtDireccionEmpresa.Text,
                    CorreoEmpresa = txtCorreo.Text
                };

                int idEmpresa = _logEmpresa.InsertarEmpresa(nuevaEmpresa);

                entOrdenServicio nuevaOS = new entOrdenServicio
                {
                    FechaOS = dtpFecha.Value,
                    IdProforma = proformaActual.IdProforma,
                    IdEmpresa = idEmpresa,
                };

                bool exito = _logOrdenServicio.Guardar(nuevaOS);

                if (exito)
                {
                    MessageBox.Show("¡Orden de Servicio creada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RegresarAProformas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void RegresarAProformas()
        {
            V_Proformas formProformas = new V_Proformas();
            formProformas.Show();
            this.Close();
        }

        private void btn_regresar_Click(object sender, EventArgs e)
        {
            RegresarAProformas();
        }
    }
}
