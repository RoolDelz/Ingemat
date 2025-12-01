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
    public partial class G_Proyectos : Form
    {
        private logProyecto _logProyecto = new logProyecto();
        public G_Proyectos()
        {
            InitializeComponent();
        }
        private void V_Proyectos_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarProyectos();
        }
        private void ConfigurarDataGridView()
        {
            dgvProyectos.AutoGenerateColumns = false;
            dgvProyectos.Columns.Clear();

            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Cód.",
                DataPropertyName = "IdProyecto",
                Width = 50
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre del Proyecto",
                DataPropertyName = "NomProyecto", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmpresa",
                HeaderText = "Nombre Empresa",
                DataPropertyName = "NomEmpresa",
                Width = 200
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDireccion",
                HeaderText = "Dirección Proforma",
                DataPropertyName = "DireccionProforma",
                Width = 200
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha Creación",
                DataPropertyName = "FechaCreacion",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" },
                Width = 80
            });
            dgvProyectos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 100
            });
        }

        private void CargarProyectos()
        {
            try
            {
                List<entProyectoVista> lista = _logProyecto.Listar();
                dgvProyectos.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proyectos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un proyecto para iniciar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            entProyectoVista proyectoSeleccionado = (entProyectoVista)dgvProyectos.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Desea iniciar el proyecto '{proyectoSeleccionado.NomProyecto}'?\nEsto generará las Órdenes de Trabajo automáticamente.", "Confirmar Inicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string resultado = _logProyecto.IniciarProyecto(proyectoSeleccionado.IdProyecto, proyectoSeleccionado.Estado);

                    if (resultado == "OK")
                    {
                        MessageBox.Show("El proyecto fue iniciado, ordenes de trabajo creadas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarProyectos();
                    }
                    else
                    {
                        MessageBox.Show(resultado, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al iniciar el proyecto: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_facturas_Click(object sender, EventArgs e)
        {
            G_Facturas pantalla = new G_Facturas();
            this.Hide();
            pantalla.Show();
        }
    }
}
