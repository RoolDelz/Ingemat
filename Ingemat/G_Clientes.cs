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
    public partial class G_Clientes : Form
    {
        private logCliente _logCliente = new logCliente();

        private int idClienteSel = 0;
        private bool editando = false;
        public G_Clientes()
        {
            InitializeComponent();
        }
        private void G_Clientes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarComboTipoDoc();
            CargarClientes();
            EstadoInicial();
        }

        private void ConfigurarGrid()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "IdCliente", Width = 40 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cliente", DataPropertyName = "NomCliente", Width = 200 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo", DataPropertyName = "Documento", Width = 60 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "N° Documento", DataPropertyName = "NDocumento", Width = 100 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "TelefonoCliente", Width = 90 });
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Correo", DataPropertyName = "CorreoCliente", Width = 150 });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Proyecto Relacionado", DataPropertyName = "NomProyecto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void CargarComboTipoDoc()
        {
            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add("DNI");
            cmbTipoDocumento.Items.Add("RUC");
            cmbTipoDocumento.SelectedIndex = 0;
        }

        private void CargarClientes()
        {
            try
            {
                dgvClientes.DataSource = _logCliente.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void EstadoInicial()
        {
            txtNombreCliente.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtNumeroDocumento.Enabled = false;
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditarCliente.Enabled = true;

            dgvClientes.Enabled = true;

            editando = false;
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (editando) return;

            if (dgvClientes.SelectedRows.Count > 0)
            {
                var item = (entClienteVista)dgvClientes.SelectedRows[0].DataBoundItem;

                idClienteSel = item.IdCliente;
                txtNombreCliente.Text = item.NomCliente;
                txtNumeroDocumento.Text = item.NDocumento;
                txtTelefono.Text = item.TelefonoCliente;
                txtCorreo.Text = item.CorreoCliente;

                if (!string.IsNullOrEmpty(item.Documento))
                {
                    if (cmbTipoDocumento.Items.Contains(item.Documento))
                        cmbTipoDocumento.SelectedItem = item.Documento;
                }
            }
        }

        private void btnEditarCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSel == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista.", "Aviso");
                return;
            }

            EstadoEdicion();
        }

        private void EstadoEdicion()
        {
            editando = true;

            txtNombreCliente.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtNumeroDocumento.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditarCliente.Enabled = false;

            dgvClientes.Enabled = false;

            txtNombreCliente.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            if (dgvClientes.SelectedRows.Count > 0)
                dgvClientes_SelectionChanged(null, null);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entCliente clienteEditado = new entCliente
                {
                    IdCliente = idClienteSel,
                    NomCliente = txtNombreCliente.Text.Trim(),
                    Documento = cmbTipoDocumento.Text,
                    NDocumento = txtNumeroDocumento.Text.Trim(),
                    TelefonoCliente = txtTelefono.Text.Trim(),
                    CorreoCliente = txtCorreo.Text.Trim()
                };

                if (_logCliente.Editar(clienteEditado))
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientes();
                    EstadoInicial();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_proyectos_Click(object sender, EventArgs e)
        {
            G_Proyectos pantalla = new G_Proyectos();
            this.Hide();
            pantalla.Show();
        }

        private void btnCostos_Click(object sender, EventArgs e)
        {
            G_Costos pantalla = new G_Costos();
            this.Hide();
            pantalla.Show();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            G_Empresa pantalla = new G_Empresa();
            this.Hide();
            pantalla.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            G_Clientes pantalla = new G_Clientes();
            this.Hide();
            pantalla.Show();
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
