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
    public partial class G_Empresa : Form
    {
        private logEmpresa _logEmpresa = new logEmpresa();

        private int idEmpresaSel = 0;
        private bool editando = false;
        public G_Empresa()
        {
            InitializeComponent();
        }
        private void G_Empresa_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarEmpresas();
            EstadoInicial();

            dgvEmpresas.SelectionChanged += dgvEmpresas_SelectionChanged;
        }
        private void ConfigurarGrid()
        {
            dgvEmpresas.AutoGenerateColumns = false;
            dgvEmpresas.Columns.Clear();
            dgvEmpresas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpresas.MultiSelect = false;
            dgvEmpresas.ReadOnly = true;

            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "IdEmpresa", Width = 40 });
            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Empresa", DataPropertyName = "NomEmpresa", Width = 200 });
            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "RUC", DataPropertyName = "Ruc", Width = 90 });
            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Teléfono", DataPropertyName = "TelefonoEmpresa", Width = 90 });
            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Correo", DataPropertyName = "CorreoEmpresa", Width = 150 });
            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Dirección", DataPropertyName = "DireccionEmpresa", Width = 200 });

            dgvEmpresas.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Proyecto Reciente", DataPropertyName = "NomProyecto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void CargarEmpresas()
        {
            try
            {
                dgvEmpresas.DataSource = _logEmpresa.ListarVista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empresas: " + ex.Message);
            }
        }

        private void EstadoInicial()
        {
            txtNombreEmpresa.Enabled = false;
            txtRuc.Enabled = false;
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;
            txtDireccion.Enabled = false;

            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnEditarEmpresa.Enabled = true;

            dgvEmpresas.Enabled = true;

            editando = false;
        }

        private void dgvEmpresas_SelectionChanged(object sender, EventArgs e)
        {
            if (editando) return;

            if (dgvEmpresas.SelectedRows.Count > 0)
            {
                var item = (entEmpresaVista)dgvEmpresas.SelectedRows[0].DataBoundItem;

                idEmpresaSel = item.IdEmpresa;
                txtNombreEmpresa.Text = item.NomEmpresa;
                txtRuc.Text = item.Ruc;
                txtTelefono.Text = item.TelefonoEmpresa;
                txtCorreo.Text = item.CorreoEmpresa;
                txtDireccion.Text = item.DireccionEmpresa;
            }
        }

        private void btnEditarEmpresa_Click(object sender, EventArgs e)
        {
            if (idEmpresaSel == 0)
            {
                MessageBox.Show("Seleccione una empresa de la lista.", "Aviso");
                return;
            }

            EstadoEdicion();
        }

        private void EstadoEdicion()
        {
            editando = true;

            txtNombreEmpresa.Enabled = true;
            txtRuc.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtDireccion.Enabled = true;

            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            btnEditarEmpresa.Enabled = false;

            dgvEmpresas.Enabled = false;

            txtNombreEmpresa.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial();
            if (dgvEmpresas.SelectedRows.Count > 0)
                dgvEmpresas_SelectionChanged(null, null);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entEmpresa empresaEditada = new entEmpresa
                {
                    IdEmpresa = idEmpresaSel,
                    NomEmpresa = txtNombreEmpresa.Text.Trim(),
                    Ruc = txtRuc.Text.Trim(),
                    TelefonoEmpresa = txtTelefono.Text.Trim(),
                    CorreoEmpresa = txtCorreo.Text.Trim(),
                    DireccionEmpresa = txtDireccion.Text.Trim()
                };
                if (_logEmpresa.Editar(empresaEditada))
                {
                    MessageBox.Show("Empresa actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarEmpresas();
                    EstadoInicial();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar la empresa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
