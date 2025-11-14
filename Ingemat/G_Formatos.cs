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
            cmbCategoria.DataSource = GetCategories(); // Método que trae las categorías
            cmbCategoria.DisplayMember = "NomCategoria"; // El campo de la categoría que se muestra
            cmbCategoria.ValueMember = "IdCategoria"; // El valor de la categoría
        }

        // Método para cargar los formatos según la categoría seleccionada
        private void LoadFormats(int idCategoria)
        {
            var formatos = logicaFormato.ListarFormatos(idCategoria);  // Obtener los formatos de la categoría seleccionada

            // Verificar si hay formatos disponibles para la categoría seleccionada
            if (formatos == null || formatos.Count == 0)
            {
                MessageBox.Show("No hay formatos disponibles para esta categoría.");
                cmbFormato.DataSource = null; // Limpiar los datos del ComboBox
                txtCosto.Enabled = true;    // Habilitar el TextBox de precio para agregar uno nuevo
                return;
            }

            cmbFormato.DataSource = formatos;
            cmbFormato.DisplayMember = "NomFormato";  // Mostrar el nombre del formato
            cmbFormato.ValueMember = "IdFormato";    // El valor del formato será su ID

            cmbFormato.Enabled = true;  // Habilitar el ComboBox si hay formatos disponibles
            txtCosto.Enabled = true;    // Habilitar el TextBox de precio si hay formatos disponibles
        }

        // Agregar Categoría
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            // Validar si el ComboBox de categoría está vacío
            if (string.IsNullOrWhiteSpace(cmbCategoria.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para la categoría.");
                return;
            }

            // Agregar la categoría a la base de datos
            string categoriaNombre = cmbCategoria.Text;
            logicaCategoria.InsertarCategoria(new Categoria { NomCategoria = categoriaNombre });

            MessageBox.Show("Categoría agregada correctamente.");
            cmbCategoria.SelectedIndex = -1; // Limpiar la selección de categoría

            // Volver a cargar las categorías para asegurarse de que se actualice la lista
            LoadCategories();
        }

        // Agregar Formato
        private void btnAgregarFormato_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una categoría
            if (cmbCategoria.SelectedValue == null || !(cmbCategoria.SelectedValue is int idCategoria) || idCategoria == 0)
            {
                MessageBox.Show("Por favor, seleccione una categoría.");
                return;
            }

            // Validar si el TextBox de formato y precio no están vacíos
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

            // Agregar el formato a la base de datos con la categoría seleccionada
            logicaFormato.InsertarFormato(new Formato { NomFormato = cmbFormato.Text, PrecioFormato = precio, IdCategoria = idCategoria });

            MessageBox.Show("Formato agregado correctamente.");

            // Volver a cargar los formatos para asegurarse de que se actualice la lista
            LoadFormats(idCategoria); // Recargar los formatos asociados a la categoría seleccionada

            txtCosto.Clear(); // Limpiar el TextBox de precio
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado una categoría válida
            if (cmbCategoria.SelectedValue != null && cmbCategoria.SelectedValue is int idCategoria && idCategoria != 0)
            {
                // Recargar los formatos según la categoría seleccionada
                LoadFormats(idCategoria);  // Llamar a la función de carga de formatos para la categoría seleccionada
            }
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si el SelectedValue no es null y que sea un entero válido
            if (cmbFormato.SelectedValue != null && cmbFormato.SelectedValue is int idFormato && idFormato != 0)
            {
                txtSubformato.Enabled = true;  // Habilitar el TextBox de subformato
            }
            else
            {
                txtSubformato.Enabled = false; // Deshabilitar el TextBox si no se ha seleccionado un formato
            }
        }

        // Agregar Subformato
        private void btnAgregarSubFormato_Click(object sender, EventArgs e)
        {
            // Validar si se ha seleccionado un formato
            if (cmbFormato.SelectedValue == null || (int)cmbFormato.SelectedValue == 0)
            {
                MessageBox.Show("Por favor, seleccione un formato.");
                return;
            }

            // Validar si el TextBox de subformato no está vacío
            if (string.IsNullOrWhiteSpace(txtSubformato.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre para el subformato.");
                return;
            }

            // Agregar el subformato a la base de datos con el formato seleccionado
            int idFormato = Convert.ToInt32(cmbFormato.SelectedValue);
            logicaSubFormato.InsertarSubFormato(new SubFormato { NomSubFormato = txtSubformato.Text, IdFormato = idFormato });

            MessageBox.Show("Subformato agregado correctamente.");
            txtSubformato.Clear(); // Limpiar el TextBox de subformato
        }

        // Métodos para obtener datos de la base de datos (simulados)
        private List<Categoria> GetCategories()
        {
            return logicaCategoria.ListarCategorias(); // Llamada a la capa lógica para obtener las categorías desde la base de datos
        }

        private List<Formato> GetFormatsByCategory(int idCategoria)
        {
            return logicaFormato.ListarFormatos(idCategoria); // Llamada a la capa lógica para obtener los formatos de la categoría seleccionada
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
