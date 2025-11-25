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
    public partial class V_NuevaFactura : Form
    {
        private logFactura _logFactura = new logFactura();
        private logEmpresa _logEmpresa = new logEmpresa();
        private logProforma _logProforma = new logProforma();
        private logGastoAdicional _logGastoAdicional = new logGastoAdicional();

        private entOrdenServicioVista ordenActual;
        private decimal precioFormatoActual = 0;

        public V_NuevaFactura(entOrdenServicioVista ordenSeleccionada)
        {
            InitializeComponent();
            this.ordenActual = ordenSeleccionada;
        }
        private void V_NuevaFactura_Load(object sender, EventArgs e)
        {
            if (ordenActual == null)
            {
                MessageBox.Show("Error: No hay orden seleccionada.");
                this.Close();
                return;
            }

            ConfigurarFormulario();
            CargarDatosCompletos();

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Transferencia", "Cheque", "Crédito" });
            cmbMetodoPago.SelectedIndex = 0;

            dtpFecha.Value = DateTime.Now;
        }
        private void ConfigurarFormulario()
        {
            txtEmpresaSolicitante.ReadOnly = true;
            txtRuc.ReadOnly = true;
            txtTelefono.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            txtDireccionEmpresa.ReadOnly = true;
            txtRepresentante.ReadOnly = true; 
            txtProyecto.ReadOnly = true;      

            cmbCategoria.Enabled = false;
            cmbFormato.Enabled = false;

            dgvGastosAdicionales.ReadOnly = true;
            dgvGastosAdicionales.AllowUserToAddRows = false;

            dgvGastosAdicionales.AutoGenerateColumns = false;
            dgvGastosAdicionales.Columns.Clear();
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Descripción", DataPropertyName = "NomGastoA", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvGastosAdicionales.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }
        private void CargarDatosCompletos()
        {
            try
            {
                int idEmpresa = _logFactura.ObtenerIdEmpresaPorOS(ordenActual.IdOS);
                entEmpresa empresa = _logEmpresa.ObtenerPorId(idEmpresa);

                if (empresa != null)
                {
                    txtEmpresaSolicitante.Text = empresa.NomEmpresa;
                    txtRuc.Text = empresa.Ruc;
                    txtTelefono.Text = empresa.TelefonoEmpresa;
                    txtCorreo.Text = empresa.CorreoEmpresa;
                    txtDireccionEmpresa.Text = empresa.DireccionEmpresa; 
                }

                entProformaVista proforma = _logProforma.ObtenerVistaPorId(ordenActual.IdProforma);

                if (proforma != null)
                {
                    txtRepresentante.Text = proforma.NomCliente; 
                    txtProyecto.Text = proforma.Motivo;   

                    cmbCategoria.Items.Add(new Categoria { IdCategoria = proforma.IdCategoria, NomCategoria = proforma.NomCategoria });
                    cmbCategoria.SelectedIndex = 0;
                    cmbFormato.Items.Add(new Formato { IdFormato = proforma.IdFormato, NomFormato = proforma.NomFormato });
                    cmbFormato.SelectedIndex = 0;

                    precioFormatoActual = proforma.PrecioFormato;
                }

                List<entGastoAdicional> gastos = _logGastoAdicional.ListarGastosPorProforma(ordenActual.IdProforma);
                dgvGastosAdicionales.DataSource = gastos;

                CalcularTotales(gastos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }
        private void CalcularTotales(List<entGastoAdicional> gastos)
        {
            decimal totalGastos = 0;
            foreach (var g in gastos)
            {
                totalGastos += g.Precio;
            }

            decimal costo = precioFormatoActual + totalGastos;
            decimal totalFinal = costo * 1.18m;

            lblPrecioFormato.Text = precioFormatoActual.ToString("N2");
            lblGastosAdicionalesTotal.Text = totalGastos.ToString("N2");
            lblCosto.Text = costo.ToString("N2");
            lblTotalFinal.Text = totalFinal.ToString("N2");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProyecto = _logFactura.ObtenerIdProyecto(ordenActual.IdOS);

                if (idProyecto == 0)
                {
                    MessageBox.Show("No se encontró un Proyecto iniciado para esta Orden de Servicio.\nEl Gerente debe crear el proyecto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                entFactura nuevaFactura = new entFactura
                {
                    FechaFactura = dtpFecha.Value,
                    PrecioFactura = Convert.ToDecimal(lblTotalFinal.Text),
                    IdProyecto = idProyecto,
                    MetodoPago = cmbMetodoPago.Text
                };

                if (_logFactura.Guardar(nuevaFactura))
                {
                    MessageBox.Show("Factura generada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Regresar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Regresar();
        }

        private void Regresar()
        {
            V_OrdenServicio vOrden = new V_OrdenServicio();
            vOrden.Show();
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
