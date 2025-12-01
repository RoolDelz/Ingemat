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
    public partial class G_OrdenTrabajo : Form
    {
        private logOrdenTrabajo _logOT = new logOrdenTrabajo();
        private logEmpleado _logEmpleado = new logEmpleado();
        public G_OrdenTrabajo()
        {
            InitializeComponent();
        }
        private void G_OrdenTrabajo_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarGrid();
            CargarComboTrabajadores();
        }

        private void ConfigurarGrid()
        {
            dgvOrdenesTrabajo.AutoGenerateColumns = false;
            dgvOrdenesTrabajo.Columns.Clear();

            // Configuración exacta según tu pedido
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cód. OT", DataPropertyName = "N_OT", Width = 120 });
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Orden de Trabajo", DataPropertyName = "NomOT", Width = 150 });
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Proyecto", DataPropertyName = "NomProyecto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Estado", DataPropertyName = "Estado", Width = 80 });
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Empleado Asignado", DataPropertyName = "NombreEmpleado", Width = 150 });
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "F. Asignación", DataPropertyName = "FechaAsignacion", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
            dgvOrdenesTrabajo.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "F. Fin", DataPropertyName = "FechaFinalizacion", Width = 80, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        }
        private void CargarGrid()
        {
            try
            {
                dgvOrdenesTrabajo.DataSource = _logOT.Listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista: " + ex.Message);
            }
        }

        private void CargarComboTrabajadores()
        {
            try
            {
                cmbTrabajador.DataSource = _logEmpleado.ListarAyudantesActivos();
                cmbTrabajador.DisplayMember = "NombreEmpleado";
                cmbTrabajador.ValueMember = "IdEmpleado";
                cmbTrabajador.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar trabajadores: " + ex.Message);
            }
        }
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvOrdenesTrabajo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una Orden de Trabajo de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbTrabajador.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un Trabajador del desplegable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            entOrdenTrabajoVista otSeleccionada = (entOrdenTrabajoVista)dgvOrdenesTrabajo.SelectedRows[0].DataBoundItem;
            int idEmpleado = (int)cmbTrabajador.SelectedValue;
            string nombreEmpleado = cmbTrabajador.Text;

            if (otSeleccionada.Estado == "Asignado" || otSeleccionada.Estado == "Finalizado")
            {
                if (MessageBox.Show($"Esta orden ya está asignada a '{otSeleccionada.NombreEmpleado}'. ¿Desea reasignarla?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            try
            {
                bool exito = _logOT.AsignarTrabajador(otSeleccionada.IdOT, idEmpleado);

                if (exito)
                {
                    MessageBox.Show($"Se asignó correctamente a {nombreEmpleado}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrid();
                    cmbTrabajador.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asignar (posiblemente ya está asignado): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cmbTrabajador.SelectedIndex = -1;
            dgvOrdenesTrabajo.ClearSelection();
        }
        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
