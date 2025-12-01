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
    public partial class G_Costos : Form
    {
        private logTipoGasto _logTipo = new logTipoGasto();
        private logGastoAdicional _logGasto = new logGastoAdicional();

        private int idTipoSel = 0;
        private int idGastoSel = 0;
        private bool editandoTipo = false;
        private bool editandoGasto = false;

        public G_Costos()
        {
            InitializeComponent();
        }

        private void G_Costos_Load(object sender, EventArgs e)
        {
            dgvTipos.SelectionChanged += dgvTipos_SelectionChanged;
            dgvGastos.SelectionChanged += dgvGastos_SelectionChanged;

            ConfigurarGridTipos();
            ConfigurarGridGastos();

            CargarTipos();
            CargarGastos();

            EstadoInicialTipo();
            EstadoInicialGasto();
        }
        private void ConfigurarGridTipos()
        {
            dgvTipos.AutoGenerateColumns = false;
            dgvTipos.Columns.Clear();
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.MultiSelect = false;
            dgvTipos.ReadOnly = true;

            dgvTipos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "IdGastoTipo", Width = 40, Visible = false });
            dgvTipos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo de Gasto", DataPropertyName = "NomGastoTipo", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void CargarTipos()
        {
            int idSelPrevio = idTipoSel;

            var lista = _logTipo.ListarTiposGasto();
            dgvTipos.DataSource = lista;

            cmbTipoGastoSel.DataSource = lista;
            cmbTipoGastoSel.DisplayMember = "NomGastoTipo";
            cmbTipoGastoSel.ValueMember = "IdGastoTipo";
            cmbTipoGastoSel.SelectedIndex = -1;
        }

        private void EstadoInicialTipo()
        {
            txtTipoGasto.Enabled = false;
            txtTipoGasto.Clear();

            btnGuardarTipo.Enabled = false;
            btnCancelarTipo.Enabled = false;

            btnAgregarTipo.Enabled = true;
            btnEditarTipo.Enabled = true;

            dgvTipos.Enabled = true;
            editandoTipo = false;
            idTipoSel = 0;
        }

        private void dgvTipos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTipos.SelectedRows.Count > 0)
            {
                if (editandoTipo) return;

                try
                {
                    var item = (entTipoGasto)dgvTipos.SelectedRows[0].DataBoundItem;
                    if (item != null)
                    {
                        idTipoSel = item.IdGastoTipo;
                        txtTipoGasto.Text = item.NomGastoTipo;
                    }
                }
                catch { }
            }
        }

        private void btnAgregarTipo_Click(object sender, EventArgs e)
        {
            EstadoEdicionTipo();
            txtTipoGasto.Clear();
            idTipoSel = 0;
            txtTipoGasto.Focus();
        }

        private void btnEditarTipo_Click(object sender, EventArgs e)
        {
            if (idTipoSel == 0 && dgvTipos.SelectedRows.Count > 0)
            {
                var item = (entTipoGasto)dgvTipos.SelectedRows[0].DataBoundItem;
                idTipoSel = item.IdGastoTipo;
                txtTipoGasto.Text = item.NomGastoTipo;
            }

            if (idTipoSel == 0) { MessageBox.Show("Seleccione un tipo de la lista."); return; }

            EstadoEdicionTipo();
            txtTipoGasto.Focus();
        }

        private void EstadoEdicionTipo()
        {
            editandoTipo = true;
            txtTipoGasto.Enabled = true;

            btnGuardarTipo.Enabled = true;
            btnCancelarTipo.Enabled = true;

            btnAgregarTipo.Enabled = false;
            btnEditarTipo.Enabled = false;

            dgvTipos.Enabled = false;
        }

        private void btnCancelarTipo_Click(object sender, EventArgs e)
        {
            EstadoInicialTipo();
            if (dgvTipos.Rows.Count > 0)
            {
                dgvTipos_SelectionChanged(null, null);
            }
        }

        private void btnGuardarTipo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipoGasto.Text))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return;
            }

            entTipoGasto obj = new entTipoGasto { IdGastoTipo = idTipoSel, NomGastoTipo = txtTipoGasto.Text };

            if (_logTipo.Guardar(obj))
            {
                MessageBox.Show("Tipo guardado correctamente.");
                CargarTipos();
                EstadoInicialTipo();
            }
            else
            {
                MessageBox.Show("Error al guardar en la base de datos.");
            }
        }

        private void ConfigurarGridGastos()
        {
            dgvGastos.AutoGenerateColumns = false;
            dgvGastos.Columns.Clear();
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.MultiSelect = false;
            dgvGastos.ReadOnly = true;

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo", DataPropertyName = "NomGastoTipo", Width = 120 });
            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre Gasto", DataPropertyName = "NomGastoA", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio", DataPropertyName = "Precio", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" } });

            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdGastoA", Visible = false });
            dgvGastos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdGastoTipo", Visible = false });
        }

        private void CargarGastos()
        {
            dgvGastos.DataSource = _logGasto.ListarTodo();
        }

        private void EstadoInicialGasto()
        {
            cmbTipoGastoSel.Enabled = false;
            txtNombreGasto.Enabled = false;
            txtPrecio.Enabled = false;

            cmbTipoGastoSel.SelectedIndex = -1;
            txtNombreGasto.Clear();
            txtPrecio.Clear();

            btnGuardarGasto.Enabled = false;
            btnCancelarGasto.Enabled = false;

            btnAgregarGasto.Enabled = true;
            btnEditarGasto.Enabled = true;

            dgvGastos.Enabled = true;
            editandoGasto = false;
            idGastoSel = 0;
        }

        private void dgvGastos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGastos.SelectedRows.Count > 0)
            {
                if (editandoGasto) return;

                try
                {
                    DataRowView row = (DataRowView)dgvGastos.SelectedRows[0].DataBoundItem;

                    if (row != null)
                    {
                        idGastoSel = Convert.ToInt32(row["IdGastoA"]);
                        txtNombreGasto.Text = row["NomGastoA"].ToString();
                        txtPrecio.Text = Convert.ToDecimal(row["Precio"]).ToString("N2");

                        if (row["IdGastoTipo"] != DBNull.Value)
                        {
                            cmbTipoGastoSel.SelectedValue = Convert.ToInt32(row["IdGastoTipo"]);
                        }
                    }
                }
                catch { }
            }
        }

        private void btnAgregarGasto_Click(object sender, EventArgs e)
        {
            EstadoEdicionGasto();
            idGastoSel = 0;
            cmbTipoGastoSel.SelectedIndex = -1;
            txtNombreGasto.Clear();
            txtPrecio.Clear();
            cmbTipoGastoSel.Focus();
        }

        private void btnEditarGasto_Click(object sender, EventArgs e)
        {
            if (idGastoSel == 0 && dgvGastos.SelectedRows.Count > 0)
            {
                dgvGastos_SelectionChanged(null, null);
            }

            if (idGastoSel == 0) { MessageBox.Show("Seleccione un gasto de la lista."); return; }

            EstadoEdicionGasto();
        }

        private void EstadoEdicionGasto()
        {
            editandoGasto = true;
            cmbTipoGastoSel.Enabled = true;
            txtNombreGasto.Enabled = true;
            txtPrecio.Enabled = true;

            btnGuardarGasto.Enabled = true;
            btnCancelarGasto.Enabled = true;

            btnAgregarGasto.Enabled = false;
            btnEditarGasto.Enabled = false;

            dgvGastos.Enabled = false;
        }

        private void btnCancelarGasto_Click(object sender, EventArgs e)
        {
            EstadoInicialGasto();
            if (dgvGastos.Rows.Count > 0) dgvGastos_SelectionChanged(null, null);
        }

        private void btnGuardarGasto_Click(object sender, EventArgs e)
        {
            if (cmbTipoGastoSel.SelectedValue == null) { MessageBox.Show("Seleccione un Tipo de Gasto."); return; }
            if (string.IsNullOrWhiteSpace(txtNombreGasto.Text)) { MessageBox.Show("Ingrese el Nombre del Gasto."); return; }

            decimal precio = 0;
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0) { MessageBox.Show("El precio debe ser un número mayor a 0."); return; }

            entGastoAdicional obj = new entGastoAdicional
            {
                IdGastoA = idGastoSel,
                NomGastoA = txtNombreGasto.Text,
                Precio = precio,
                IdGastoTipo = (int)cmbTipoGastoSel.SelectedValue
            };

            if (_logGasto.Guardar(obj))
            {
                MessageBox.Show("Gasto guardado correctamente.");
                CargarGastos();
                EstadoInicialGasto();
            }
            else
            {
                MessageBox.Show("Error al guardar en la base de datos.");
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
