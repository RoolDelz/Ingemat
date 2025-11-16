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
    public partial class V_NuevaProforma : Form
    {
        private logCategoria _logCategoria = new logCategoria();
        private logFormatos _logFormatos = new logFormatos();
        private logTipoGasto _logTipoGasto = new logTipoGasto();
        private logGastoAdicional _logGastoAdicional = new logGastoAdicional();
        private logProforma _logProforma = new logProforma();

        private decimal precioFormatoActual = 0;
        public V_NuevaProforma()
        {
            InitializeComponent();
        }

        private void V_NuevaProforma_Load(object sender, EventArgs e)
        {
            // 1. Cargar ComboBox de Documento
            cmbDocumento.Items.Add("DNI");
            cmbDocumento.Items.Add("RUC10");
            cmbDocumento.SelectedIndex = 0;

            CargarCategorias();
            CargarTiposGasto();

            ConfigurarDataGridView();
            ActualizarTotales();
        }

        private void ConfigurarDataGridView()
        {
            dgvGastosAdicionales.AutoGenerateColumns = false;
            dgvGastosAdicionales.Columns.Clear();

            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdGastoA",
                HeaderText = "ID",
                DataPropertyName = "IdGastoA",
                Visible = false
            });

            // Columna Tipo
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTipoGasto",
                HeaderText = "Tipo Gasto",
                Width = 120,
                ReadOnly = true
            });

            // Columna Descripción
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDescripcion",
                HeaderText = "Descripción",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = true
            });

            // Columna Precio
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecioGasto",
                HeaderText = "Precio",
                Width = 80,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        // --- CARGA DE DATOS ---
        private void CargarCategorias()
        {
            try
            {
                cmbCategoria.DataSource = _logCategoria.ListarCategorias();
                cmbCategoria.DisplayMember = "NomCategoria";
                cmbCategoria.ValueMember = "IdCategoria";
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando categorías: " + ex.Message); }
        }

        private void CargarTiposGasto()
        {
            try
            {
                cmbTipoGasto.DataSource = _logTipoGasto.ListarTiposGasto();
                cmbTipoGasto.DisplayMember = "NomGastoTipo";
                cmbTipoGasto.ValueMember = "IdGastoTipo";
                cmbTipoGasto.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando tipos de gasto: " + ex.Message); }
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue != null && cmbCategoria.SelectedValue is int idCategoria)
            {
                try
                {
                    cmbFormato.DataSource = _logFormatos.ListarFormatos(idCategoria);
                    cmbFormato.DisplayMember = "NomFormato";
                    cmbFormato.ValueMember = "IdFormato";
                    cmbFormato.SelectedIndex = -1;
                    precioFormatoActual = 0;
                    ActualizarTotales();
                }
                catch (Exception ex) { MessageBox.Show("Error cargando formatos: " + ex.Message); }
            }
            else
            {
                cmbFormato.DataSource = null;
                precioFormatoActual = 0;
                ActualizarTotales();
            }
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is Formato formatoSeleccionado)
            {
                precioFormatoActual = formatoSeleccionado.PrecioFormato;
            }
            else
            {
                precioFormatoActual = 0;
            }
            ActualizarTotales();
        }

        private void cmbTipoGasto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoGasto.SelectedValue != null && cmbTipoGasto.SelectedValue is int idTipoGasto)
            {
                try
                {
                    cmbGastoAdicional.DataSource = _logGastoAdicional.ListarGastosPorTipo(idTipoGasto);
                    cmbGastoAdicional.DisplayMember = "NomGastoA";
                    cmbGastoAdicional.ValueMember = "IdGastoA";
                    cmbGastoAdicional.SelectedIndex = -1;
                }
                catch (Exception ex) { MessageBox.Show("Error cargando gastos: " + ex.Message); }
            }
            else
            {
                cmbGastoAdicional.DataSource = null;
            }
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            if (cmbTipoGasto.SelectedItem == null || cmbGastoAdicional.SelectedItem == null)
            {
                MessageBox.Show("Seleccione Tipo y Gasto.");
                return;
            }

            entTipoGasto tipo = (entTipoGasto)cmbTipoGasto.SelectedItem;
            entGastoAdicional gasto = (entGastoAdicional)cmbGastoAdicional.SelectedItem;

            dgvGastosAdicionales.Rows.Add(
                gasto.IdGastoA,
                tipo.NomGastoTipo,
                gasto.NomGastoA,
                gasto.Precio
            );

            cmbGastoAdicional.SelectedIndex = -1;
            ActualizarTotales();
        }

        private void btnEliminarGasto_Click(object sender, EventArgs e)
        {
            if (dgvGastosAdicionales.SelectedRows.Count > 0)
            {
                dgvGastosAdicionales.Rows.Remove(dgvGastosAdicionales.SelectedRows[0]);
                ActualizarTotales();
            }
        }

        // --- CÁLCULOS ---
        private void ActualizarTotales()
        {
            decimal totalGastos = 0;
            foreach (DataGridViewRow row in dgvGastosAdicionales.Rows)
            {
                if (row.Cells["colPrecioGasto"].Value != null)
                    totalGastos += Convert.ToDecimal(row.Cells["colPrecioGasto"].Value);
            }

            decimal costo = precioFormatoActual + totalGastos;
            decimal totalFinal = costo * 1.18m;

            lblPrecioFormato.Text = precioFormatoActual.ToString("N2");
            lblGastosAdicionalesTotal.Text = totalGastos.ToString("N2");
            lblCosto.Text = costo.ToString("N2");
            lblTotalFinal.Text = totalFinal.ToString("N2");
        }
        private void LimpiarFormulario()
        {
            // Limpiar TextBoxes
            txtSolicitante.Clear();
            txtNumeroDocumento.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtMotivo.Clear();
            txtDireccion.Clear();

            cmbDocumento.SelectedIndex = 0;
            cmbCategoria.SelectedIndex = -1;
            cmbTipoGasto.SelectedIndex = -1; 

            dtpFecha.Value = DateTime.Now;

            dgvGastosAdicionales.Rows.Clear();

            precioFormatoActual = 0;

            ActualizarTotales();

            txtSolicitante.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSolicitante.Text))
            {
                MessageBox.Show("El campo 'Solicitante' es obligatorio.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSolicitante.Focus();
                return;
            }
            if (cmbFormato.SelectedItem == null || !(cmbFormato.SelectedValue is int))
            {
                MessageBox.Show("Debe seleccionar un 'Formato' de servicio.", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return;
            }

            entCliente cliente = new entCliente
            {
                NomCliente = txtSolicitante.Text,
                Documento = cmbDocumento.Text,
                NDocumento = txtNumeroDocumento.Text,
                TelefonoCliente = txtTelefono.Text,
                CorreoCliente = txtCorreo.Text
            };

            entProforma proforma = new entProforma
            {
                Motivo = txtMotivo.Text,
                FechaP = dtpFecha.Value,
                DireccionProforma = txtDireccion.Text,
                IdCategoria = (int)cmbCategoria.SelectedValue,
                IdFormato = (int)cmbFormato.SelectedValue,

                Total = 0.00m,
                PrecioFinal = 0.00m
            };

            List<entGastoAdicional> gastos = new List<entGastoAdicional>();
            foreach (DataGridViewRow row in dgvGastosAdicionales.Rows)
            {
                gastos.Add(new entGastoAdicional
                {
                    IdGastoA = Convert.ToInt32(row.Cells["colIdGastoA"].Value)
                });
            }

            try
            {
                bool exito = _logProforma.GuardarProformaCompleta(cliente, proforma, gastos);

                if (exito)
                {
                    MessageBox.Show("¡Proforma guardada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fatal al intentar guardar: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
