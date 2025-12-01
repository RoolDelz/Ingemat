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
    public partial class T_Actividades : Form
    {
        private logOrdenTrabajo _logOT = new logOrdenTrabajo();
        public T_Actividades()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarMisActividades();
        }
        private void T_Actividades_Load(object sender, EventArgs e)
        {
        }
        private void ConfigurarGrid()
        {
            dgvActividades.AutoGenerateColumns = false;
            dgvActividades.Columns.Clear();

            dgvActividades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdOT",
                HeaderText = "ID",
                DataPropertyName = "IdOT",
                Visible = false
            });

            dgvActividades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNOT",
                HeaderText = "Cód. OT",
                DataPropertyName = "N_OT",
                Width = 120
            });

            dgvActividades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNomOT",
                HeaderText = "Actividad",
                DataPropertyName = "NomOT",
                Width = 200
            });

            dgvActividades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProyecto",
                HeaderText = "Proyecto",
                DataPropertyName = "NomProyecto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvActividades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha Asignación",
                DataPropertyName = "FechaAsignacion",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dgvActividades.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100
            });
        }
        private void CargarMisActividades()
        {
            try
            {
                int miId = entSession.IdEmpleado;

                if (miId == 0)
                {
                    MessageBox.Show("Error de sesión: No se identificó al empleado.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<entOrdenTrabajoVista> misOrdenes = _logOT.ListarMisActividades(miId);

                dgvActividades.DataSource = misOrdenes;

                if (misOrdenes.Count == 0)
                {      
                    MessageBox.Show($"El empleado ID {miId} no tiene actividades asignadas.", "Información");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tus actividades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRealizar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una actividad para trabajar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entOrdenTrabajoVista actividadSeleccionada = (entOrdenTrabajoVista)dgvActividades.SelectedRows[0].DataBoundItem;

            if (actividadSeleccionada.Estado == "Finalizada") 
            {
                if (MessageBox.Show("Esta actividad ya está finalizada. ¿Desea ver los detalles?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            T_RealizarActividad formRealizar = new T_RealizarActividad(actividadSeleccionada.IdOT);
            formRealizar.ShowDialog(); 

            CargarMisActividades();
        }
        private void btn_actividades_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
