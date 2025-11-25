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
    public partial class G_AprobarOS : Form
    {
        private logOrdenServicio _logOrdenServicio = new logOrdenServicio();
        private logProyecto _logProyecto = new logProyecto();
        public G_AprobarOS()
        {
            InitializeComponent();
        }

        private void G_aprobarOS_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarTodasLasOrdenes();
        }

        private void ConfigurarGrid()
        {
            dgvOrdenes.AutoGenerateColumns = false;
            dgvOrdenes.Columns.Clear();

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdOS",
                HeaderText = "Cód. OS",
                DataPropertyName = "IdOS",
                Width = 60
            });
            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "FechaOS",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 80
            });
            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmpresa",
                HeaderText = "Empresa Solicitante",
                DataPropertyName = "NomEmpresa",
                Width = 200
            });
            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRuc",
                HeaderText = "RUC",
                DataPropertyName = "RucEmpresa",
                Width = 100
            });
            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProforma",
                HeaderText = "Proforma Ref.",
                DataPropertyName = "MotivoProforma",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "EstadoOS",
                Width = 80
            });
        }

        private void CargarTodasLasOrdenes()
        {
            try
            {
                dgvOrdenes.DataSource = _logOrdenServicio.Listar(null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            ProcesarEstado("Aprobar");
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            ProcesarEstado("Rechazar");
        }

        private void ProcesarEstado(string accion)
        {
            if (dgvOrdenes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una orden.", "Aviso");
                return;
            }

            var orden = (entOrdenServicioVista)dgvOrdenes.SelectedRows[0].DataBoundItem;

            if (accion == "Rechazar")
            {
                bool tieneProyecto = _logProyecto.ExisteProyecto(orden.IdOS);
                if (tieneProyecto)
                {
                    MessageBox.Show("No se puede rechazar esta Orden de Servicio porque ya tiene un Proyecto creado e iniciado.", "Acción Bloqueada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return; 
                }
            }

            if (orden.EstadoOS != "Pendiente")
            {
                if (MessageBox.Show($"Esta orden ya está {orden.EstadoOS}. ¿Desea cambiarla a {accion}?", "Confirmar Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            try
            {
                bool exito = false;
                if (accion == "Aprobar") exito = _logOrdenServicio.AprobarOS(orden.IdOS);
                else exito = _logOrdenServicio.RechazarOS(orden.IdOS);

                if (exito)
                {
                    MessageBox.Show($"Orden {accion}da correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarTodasLasOrdenes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCrearPro_Click(object sender, EventArgs e)
        {
            if (dgvOrdenes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una Orden de Servicio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var orden = (entOrdenServicioVista)dgvOrdenes.SelectedRows[0].DataBoundItem;

            if (orden.EstadoOS != "Aprobado")
            {
                MessageBox.Show("Solo se pueden crear proyectos para Órdenes de Servicio con estado 'Aprobado'.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Desea crear el proyecto para la OS #{orden.IdOS}?\nSe usará '{orden.MotivoProforma}' como nombre.", "Confirmar Creación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool creado = _logProyecto.CrearProyectoDesdeOS(orden.IdOS, orden.MotivoProforma);

                    if (creado)
                    {
                        MessageBox.Show("Proyecto creado e iniciado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
