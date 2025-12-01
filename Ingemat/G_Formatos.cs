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
    public partial class G_Formatos : Form
    {
        private logCategoria logicaCategoria = new logCategoria();
        private logFormatos logicaFormato = new logFormatos();
        private logSubformatos logicaSubFormato = new logSubformatos();

        private enum TipoEdicion { Ninguno, Categoria, Formato, Subformato }
        private TipoEdicion edicionActual = TipoEdicion.Ninguno;

        private int idCategoriaSel = 0;
        private int idFormatoSel = 0;
        private int idSubFormatoSel = 0;

        public G_Formatos()
        {
            InitializeComponent();
        }

        private void G_Formatos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarTodo();
            ControlesEstadoInicial();
        }

        private void ConfigurarGrid()
        {
            dgvFormatos.AutoGenerateColumns = false;
            dgvFormatos.Columns.Clear();
            dgvFormatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormatos.MultiSelect = false;
            dgvFormatos.ReadOnly = true;

            // Columnas solicitadas
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre Categoría", DataPropertyName = "NomCategoria", Width = 150 });
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nombre Formato", DataPropertyName = "NomFormato", Width = 200 });
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Precio Formato", DataPropertyName = "PrecioFormato", Width = 80 });
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Subformato", DataPropertyName = "NomSubFormato", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });

            // Columnas Ocultas para IDs
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdCategoria", Visible = false });
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdFormato", Visible = false });
            dgvFormatos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "IdSubFormato", Visible = false });
        }

        private void ControlesEstadoInicial()
        {
            edicionActual = TipoEdicion.Ninguno;

            cmbCategoria.Enabled = true;
            cmbFormato.Enabled = true;
            txtCosto.Enabled = true;
            txtSubformato.Enabled = true;

            btnGuardar.Enabled = false;

            btnAgregarCategoria.Enabled = true;
            btnAgregarFormato.Enabled = true;
            btnAgregarSubFormato.Enabled = true;

            idCategoriaSel = 0;
            idFormatoSel = 0;
            idSubFormatoSel = 0;
        }

        private void CargarTodo()
        {
            LoadCategories();
            CargarGridDatos();
        }

        private void LoadCategories()
        {
            var sel = cmbCategoria.SelectedValue;

            cmbCategoria.DataSource = logicaCategoria.ListarCategorias();
            cmbCategoria.DisplayMember = "NomCategoria";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.SelectedIndex = -1;

            if (sel != null) cmbCategoria.SelectedValue = sel;
        }

        private void CargarGridDatos()
        {
            dgvFormatos.DataSource = logicaSubFormato.ListarTodo();
        }

        private void dgvFormatos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormatos.SelectedRows.Count > 0)
            {
                if (edicionActual != TipoEdicion.Ninguno) return;

                var row = dgvFormatos.SelectedRows[0];
                var item = row.DataBoundItem as entFormatoVista;

                if (item != null)
                {
                    idCategoriaSel = item.IdCategoria;
                    idFormatoSel = item.IdFormato;
                    idSubFormatoSel = item.IdSubFormato;


                    cmbCategoria.SelectedValue = idCategoriaSel;
                    if (cmbCategoria.SelectedIndex == -1) cmbCategoria.Text = item.NomCategoria;

                    LoadFormats(idCategoriaSel);

                    cmbFormato.SelectedValue = idFormatoSel;
                    if (cmbFormato.SelectedIndex == -1) cmbFormato.Text = item.NomFormato;

                    txtCosto.Text = item.PrecioFormato.ToString("0.00");
                    txtSubformato.Text = item.NomSubFormato;
                }
            }
        }

        private void LoadFormats(int idCategoria)
        {
            cmbFormato.DataSource = logicaFormato.ListarFormatos(idCategoria);
            cmbFormato.DisplayMember = "NomFormato";
            cmbFormato.ValueMember = "IdFormato";
            cmbFormato.SelectedIndex = -1;
        }


        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue is int id && id > 0)
            {
                LoadFormats(id);
                if (edicionActual == TipoEdicion.Ninguno) txtCosto.Clear();
            }
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is Formato fmt)
            {

                if (edicionActual == TipoEdicion.Ninguno)
                {
                    txtCosto.Text = fmt.PrecioFormato.ToString("0.00");
                }
            }
            else
            {
                if (edicionActual == TipoEdicion.Ninguno) txtCosto.Clear();
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCategoria.Text)) return;
            logicaCategoria.InsertarCategoria(new Categoria { NomCategoria = cmbCategoria.Text });
            MessageBox.Show("Categoría agregada.");
            LoadCategories();
            ControlesEstadoInicial();
        }

        private void btnAgregarFormato_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue == null) return;
            decimal precio;
            if (!decimal.TryParse(txtCosto.Text, out precio)) return;

            logicaFormato.InsertarFormato(new Formato { NomFormato = cmbFormato.Text, PrecioFormato = precio, IdCategoria = (int)cmbCategoria.SelectedValue });
            MessageBox.Show("Formato agregado.");
            LoadFormats((int)cmbCategoria.SelectedValue);
            ControlesEstadoInicial();
        }

        private void btnAgregarSubFormato_Click(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedValue == null) return;
            logicaSubFormato.InsertarSubFormato(new SubFormato { NomSubFormato = txtSubformato.Text, IdFormato = (int)cmbFormato.SelectedValue });
            MessageBox.Show("Subformato agregado.");
            CargarGridDatos();
            ControlesEstadoInicial();
        }


        private void btnEditarCategoria_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion()) return;

            PrepararEdicion(TipoEdicion.Categoria);

            cmbCategoria.Enabled = true;
            cmbFormato.Enabled = false;
            txtCosto.Enabled = false;
            txtSubformato.Enabled = false;

            MessageBox.Show("Modifique el nombre de la CATEGORÍA y pulse Guardar.");
            cmbCategoria.Focus();
        }

        private void btnEditarFormato_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion()) return;

            PrepararEdicion(TipoEdicion.Formato);

            cmbCategoria.Enabled = false;
            cmbFormato.Enabled = true;
            txtCosto.Enabled = true;
            txtSubformato.Enabled = false;

            MessageBox.Show("Modifique el FORMATO o PRECIO y pulse Guardar.");
        }

        private void btnEditarSubFormato_Click(object sender, EventArgs e)
        {
            if (!ValidarSeleccion()) return;

            PrepararEdicion(TipoEdicion.Subformato);

            cmbCategoria.Enabled = false;
            cmbFormato.Enabled = false;
            txtCosto.Enabled = false;
            txtSubformato.Enabled = true;

            MessageBox.Show("Modifique el nombre del SUBFORMATO y pulse Guardar.");
        }

        private bool ValidarSeleccion()
        {
            if (idCategoriaSel == 0 && dgvFormatos.SelectedRows.Count > 0)
            {
                var item = dgvFormatos.SelectedRows[0].DataBoundItem as entFormatoVista;
                if (item != null)
                {
                    idCategoriaSel = item.IdCategoria;
                    idFormatoSel = item.IdFormato;
                    idSubFormatoSel = item.IdSubFormato;
                }
            }

            if (idCategoriaSel == 0)
            {
                MessageBox.Show("Seleccione una fila válida para editar.", "Aviso");
                return false;
            }
            return true;
        }

        private void PrepararEdicion(TipoEdicion tipo)
        {
            edicionActual = tipo;
            btnGuardar.Enabled = true;

            btnAgregarCategoria.Enabled = false;
            btnAgregarFormato.Enabled = false;
            btnAgregarSubFormato.Enabled = false;

            dgvFormatos.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool exito = false;

            try
            {
                switch (edicionActual)
                {
                    case TipoEdicion.Categoria:
                        exito = logicaCategoria.Editar(new Categoria
                        {
                            IdCategoria = idCategoriaSel,
                            NomCategoria = cmbCategoria.Text
                        });
                        break;

                    case TipoEdicion.Formato:
                        decimal precio = 0;
                        decimal.TryParse(txtCosto.Text, out precio);
                        exito = logicaFormato.Editar(new Formato
                        {
                            IdFormato = idFormatoSel,
                            NomFormato = cmbFormato.Text,
                            PrecioFormato = precio,
                            IdCategoria = idCategoriaSel
                        });
                        break;

                    case TipoEdicion.Subformato:
                        exito = logicaSubFormato.Editar(new SubFormato
                        {
                            IdSubFormato = idSubFormatoSel,
                            NomSubFormato = txtSubformato.Text,
                            IdFormato = idFormatoSel
                        });
                        break;
                }

                if (exito)
                {
                    MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvFormatos.Enabled = true;
                    ControlesEstadoInicial();

                    CargarGridDatos();
                    LoadCategories();
                }
                else
                {
                    MessageBox.Show("No se pudieron guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvFormatos.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                dgvFormatos.Enabled = true;
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
