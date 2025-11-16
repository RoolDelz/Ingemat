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

        public G_Formatos()
        {
            InitializeComponent();
            LoadCategories();
            cmbCategoria.SelectedIndexChanged += new EventHandler(cmbCategoria_SelectedIndexChanged);
        }
        private void LoadCategories()
        {
            cmbCategoria.DataSource = GetCategories();
            cmbCategoria.DisplayMember = "NomCategoria";
            cmbCategoria.ValueMember = "IdCategoria";
        }

        private void LoadFormats(int idCategoria)
        {
            var formatos = logicaFormato.ListarFormatos(idCategoria); 

            if (formatos == null || formatos.Count == 0)
            {
                MessageBox.Show("No hay formatos disponibles para esta categoría.");
                cmbFormato.DataSource = null; 
                txtCosto.Enabled = true;
                return;
            }

            cmbFormato.DataSource = formatos;
            cmbFormato.DisplayMember = "NomFormato"; 
            cmbFormato.ValueMember = "IdFormato";  

            cmbFormato.Enabled = true;  
            txtCosto.Enabled = true;  
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbCategoria.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para la categoría.");
                return;
            }

            string categoriaNombre = cmbCategoria.Text;
            logicaCategoria.InsertarCategoria(new Categoria { NomCategoria = categoriaNombre });

            MessageBox.Show("Categoría agregada correctamente.");
            cmbCategoria.SelectedIndex = -1; 


            LoadCategories();
        }

        private void btnAgregarFormato_Click(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue == null || !(cmbCategoria.SelectedValue is int idCategoria) || idCategoria == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbFormato.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el formato.");
                return;
            }

            decimal precio;
            if (!decimal.TryParse(txtCosto.Text, out precio) || precio <= 0)
            {
                MessageBox.Show("Por favor, ingrese un precio válido para el formato.");
                return;
            }

            logicaFormato.InsertarFormato(new Formato { NomFormato = cmbFormato.Text, PrecioFormato = precio, IdCategoria = idCategoria });

            MessageBox.Show("Formato agregado correctamente.");

            LoadFormats(idCategoria);

            txtCosto.Clear(); 
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoria.SelectedValue != null && cmbCategoria.SelectedValue is int idCategoria && idCategoria != 0)
            {
                LoadFormats(idCategoria);
            }
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbFormato.SelectedValue != null && cmbFormato.SelectedValue is int idFormato && idFormato != 0)
            {
                txtSubformato.Enabled = true;  
            }
            else
            {
                txtSubformato.Enabled = false; 
            }
        }

        private void btnAgregarSubFormato_Click(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedValue == null || (int)cmbFormato.SelectedValue == 0)
            {
                MessageBox.Show("Por favor, seleccione un formato.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubformato.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el subformato.");
                return;
            }

            int idFormato = Convert.ToInt32(cmbFormato.SelectedValue);
            logicaSubFormato.InsertarSubFormato(new SubFormato { NomSubFormato = txtSubformato.Text, IdFormato = idFormato });

            MessageBox.Show("Subformato agregado correctamente.");
            txtSubformato.Clear();
        }

        private List<Categoria> GetCategories()
        {
            return logicaCategoria.ListarCategorias();
        }

        private List<Formato> GetFormatsByCategory(int idCategoria)
        {
            return logicaFormato.ListarFormatos(idCategoria);
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
