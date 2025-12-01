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
    public partial class T_RealizarActividad : Form
    {
        private int _idOT;
        private logOrdenTrabajo _logOT = new logOrdenTrabajo();
        private logReporte _logReporte = new logReporte();

        private bool modoEdicion = false;

        public T_RealizarActividad(int idOT)
        {
            InitializeComponent();
            _idOT = idOT;
        }
        private void T_RealizarActividad_Load(object sender, EventArgs e)
        {
            ConfigurarFormularioInicial();
            CargarDatosCabecera();
            CargarReportes();
        }
        private void ConfigurarFormularioInicial()
        {
            dtpFecha.Enabled = false;
            dtpFecha.Value = DateTime.Now;

            txtProyecto.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtFormato.ReadOnly = true;
            txtActividad.ReadOnly = true;

            btnGuardar.Enabled = false;
            btnFinalizar.Enabled = false;
            btnSubirArchivo.Enabled = false;
            btnEditar.Enabled = true;

            dgvReportes.Columns.Clear();
            dgvReportes.Columns.Add("Nombre", "Nombre Archivo");
            dgvReportes.Columns.Add("Extension", "Tipo");
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.ReadOnly = true;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDatosCabecera()
        {
            try
            {
                entDetalleOT detalle = _logOT.ObtenerDetalle(_idOT);
                if (detalle != null)
                {
                    txtProyecto.Text = detalle.NomProyecto;
                    txtDireccion.Text = detalle.Direccion;
                    txtCategoria.Text = detalle.Categoria;
                    txtFormato.Text = detalle.Formato;
                    txtActividad.Text = detalle.NomOT;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error cargando datos: " + ex.Message); }
        }

        private void CargarReportes()
        {
            try
            {
                List<entReporte> lista = _logReporte.Listar(_idOT);
                dgvReportes.Rows.Clear();
                foreach (var item in lista)
                {
                    dgvReportes.Rows.Add(item.NombreArchivo, item.Extension);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error cargando reportes: " + ex.Message); }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            modoEdicion = true;
            btnGuardar.Enabled = true;
            btnSubirArchivo.Enabled = true;
            btnEditar.Enabled = false;

            MessageBox.Show("Modo edición activado. Puede subir archivos ahora.");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion) return;

            btnFinalizar.Enabled = true;
            btnEditar.Enabled = true;
            btnGuardar.Enabled = false;
            btnSubirArchivo.Enabled = false;
            modoEdicion = false;

            MessageBox.Show("Cambios guardados. Ahora puede finalizar la actividad.");
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (dgvReportes.Rows.Count == 0)
            {
                if (MessageBox.Show("No ha subido ningún reporte. ¿Desea finalizar sin evidencias?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            if (MessageBox.Show("¿Seguro que desea finalizar esta actividad?\nSe marcará como completada y se registrará la fecha de fin.", "Finalizar Actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (_logOT.Finalizar(_idOT))
                    {
                        MessageBox.Show("¡Actividad Finalizada Correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al finalizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos permitidos|*.pdf;*.png;*.jpg;*.jpeg";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logReporte.SubirArchivo(_idOT, ofd.FileName);

                    CargarReportes();

                    MessageBox.Show("Archivo subido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al subir", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            if (modoEdicion)
            {
                DialogResult r = MessageBox.Show("Está en modo edición. ¿Desea salir? Los archivos ya subidos se mantendrán guardados.", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
