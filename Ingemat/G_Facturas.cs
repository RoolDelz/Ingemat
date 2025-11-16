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
        private logFactura logica = new logFactura();
        private bool esNuevo = false;
        private int idFacturaSeleccionada = 0;
        private DateTime fechaFacturaSeleccionada;
        public G_Facturas()
        {
            InitializeComponent();
        }

        private void G_Facturas_Load(object sender, EventArgs e)
        {
            CargarGrid();
            EstadoInicial();

            cmbEstadoFactura.Items.Add("Pendiente");
            cmbEstadoFactura.Items.Add("Pagada");
            cmbEstadoFactura.Items.Add("Anulada");
        }

        private void EstadoInicial()
        {
            HabilitarControles(false);
            LimpiarControles();
            btnAgregar.Enabled = true;
            btnAplicar.Enabled = false;
            btnLimpiar.Enabled = false;
            btnBuscar.Enabled = true;
            dgvFacturas.Enabled = true;
            cmbProyecto.Visible = false;
            esNuevo = false;
            idFacturaSeleccionada = 0;
        }

        private void HabilitarControles(bool habilitar)
        {
            txtCodigo.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            cmbEstadoFactura.Enabled = habilitar;
            txtObservaciones.Enabled = habilitar;
        }

        private void LimpiarControles()
        {
            txtCodigo.Text = "";
            txtPrecio.Text = "0.00";
            cmbEstadoFactura.SelectedIndex = -1;
            txtObservaciones.Text = "";
            cmbProyecto.DataSource = null;
            idFacturaSeleccionada = 0;
            fechaFacturaSeleccionada = DateTime.MinValue;
        }

        private void CargarGrid()
        {
            dgvFacturas.DataSource = logica.ListarFacturas();
            if (dgvFacturas.Columns.Contains("IdFactura"))
            {
                dgvFacturas.Columns["IdFactura"].Visible = false;
            }
            if (dgvFacturas.Columns.Contains("Observaciones"))
            {
                dgvFacturas.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void CargarComboProyectos()
        {
            cmbProyecto.DataSource = logica.ListarProyectosSinFactura();
            cmbProyecto.DisplayMember = "NomProyecto";
            cmbProyecto.ValueMember = "IdProyecto";
            cmbProyecto.SelectedIndex = -1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            EstadoInicial();

            esNuevo = true;

            HabilitarControles(true);

            btnAgregar.Enabled = false;
            btnAplicar.Enabled = true;
            btnLimpiar.Enabled = true;
            btnBuscar.Enabled = false;
            dgvFacturas.Enabled = false;

            cmbProyecto.Visible = true;
            CargarComboProyectos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                entFactura fac = new entFactura();
                fac.NumFactura = txtCodigo.Text.Trim();
                fac.PrecioFactura = decimal.Parse(txtPrecio.Text.Trim(), CultureInfo.InvariantCulture);
                fac.Estado = cmbEstadoFactura.Text;
                fac.Observaciones = txtObservaciones.Text.Trim();

                bool resultado = false;

                if (esNuevo)
                {
                    if (cmbProyecto.SelectedValue == null)
                    {
                        MessageBox.Show("Debe seleccionar un proyecto válido de la lista.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Aseguramos la conversión
                    fac.IdProyecto = Convert.ToInt32(cmbProyecto.SelectedValue);
                    fac.FechaFactura = DateTime.Now;

                    resultado = logica.InsertarFactura(fac); 
                }
                else
                {
                    fac.IdFactura = idFacturaSeleccionada;
                    fac.FechaFactura = fechaFacturaSeleccionada;
                    resultado = logica.EditarFactura(fac); 
                }

                if (resultado)
                {
                    MessageBox.Show("Datos guardados correctamente.", "Éxito");
                    CargarGrid();
                    EstadoInicial();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("El precio debe ser un número válido (ej: 2000.00).", "Error de Formato");
                txtPrecio.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error detectado: " + ex.Message, "Error Crítico");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoBuscado = txtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigoBuscado))
            {
                MessageBox.Show("Ingrese un código para buscar.", "Aviso");
                return;
            }

            foreach (DataGridViewRow row in dgvFacturas.Rows)
            {
                if (row.Cells["Codigo"].Value != null && row.Cells["Codigo"].Value.ToString().Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    dgvFacturas.ClearSelection();
                    row.Selected = true;
                    dgvFacturas.CurrentCell = row.Cells["Codigo"];
                    CargarDatosDesdeGrid(row);
                    return;
                }
            }
            MessageBox.Show("No se encontró ninguna factura con ese código.", "Búsqueda fallida");
        }

        private void CargarDatosDesdeGrid(DataGridViewRow row)
        {
            EstadoInicial();
            HabilitarControles(true);
            btnAgregar.Enabled = false;
            btnAplicar.Enabled = true;
            btnLimpiar.Enabled = true;
            btnBuscar.Enabled = false;

            idFacturaSeleccionada = (int)row.Cells["IdFactura"].Value;
            txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
            txtPrecio.Text = string.Format(CultureInfo.InvariantCulture, "{0:F2}", row.Cells["Precio"].Value);
            cmbEstadoFactura.Text = row.Cells["Estado"].Value.ToString();
            txtObservaciones.Text = row.Cells["Observaciones"].Value.ToString();
            fechaFacturaSeleccionada = (DateTime)row.Cells["Fecha"].Value;
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !esNuevo)
            {
                CargarDatosDesdeGrid(dgvFacturas.Rows[e.RowIndex]);
            }
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

        private void btn_ver_Click(object sender, EventArgs e)
        {
            G_VerFactura pantalla = new G_VerFactura();
            this.Hide();
            pantalla.Show();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
