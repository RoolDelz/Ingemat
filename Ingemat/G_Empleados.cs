using CapaLogica;
using CapaEntidad;
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
    public partial class G_Empleados : Form
    {
        private logEmpleado logica = new logEmpleado();
        private bool esNuevo = false; 
        private int idEmpleadoSeleccionado = 0;
        public G_Empleados()
        {
            InitializeComponent();
        }
        private void G_Empleados_Load(object sender, EventArgs e)
        {
            ListarEmpleadosGrid();
            EstadoInicial();
        }
        private void EstadoInicial()
        {
            HabilitarControles(false); // Deshabilita campos de edición
            LimpiarControles();

            txtEDni.Enabled = true; // Solo el DNI para buscar
            btnEBuscar.Enabled = true;
            btnEAgregar.Enabled = true;
            dgvEmpleados.Enabled = true;

            btnEEditar.Enabled = false; // Deshabilitados hasta seleccionar
            btnEGuardar.Enabled = false;
            btnECancelar.Enabled = false;

            esNuevo = false;
            idEmpleadoSeleccionado = 0;
        }

        // Habilita o deshabilita los campos de datos
        private void HabilitarControles(bool habilitar)
        {
            txtENombres.Enabled = habilitar;
            txtETelefono.Enabled = habilitar;
            txtECorreo.Enabled = habilitar;
            cmbECargo.Enabled = habilitar; // Asumiendo que es cmbCargo
            chkEstado.Enabled = habilitar;

            // Si habilitamos controles, el DNI se bloquea (no se edita)
            if (habilitar && !esNuevo)
            {
                txtEDni.Enabled = false;
            }
            else
            {
                txtEDni.Enabled = habilitar; // Habilitado para MODO NUEVO
            }
        }

        // Limpia todos los campos
        private void LimpiarControles()
        {
            txtEDni.Text = "";
            txtENombres.Text = "";
            txtETelefono.Text = "";
            txtECorreo.Text = "";
            cmbECargo.SelectedIndex = -1;
            chkEstado.Checked = true; // Por defecto
        }

        // Carga el DataGridView
        private void ListarEmpleadosGrid()
        {
            dgvEmpleados.DataSource = logica.ListarEmpleados();
            if (dgvEmpleados.Columns.Contains("IdEmpleado"))
            {
                dgvEmpleados.Columns["IdEmpleado"].Visible = false;
            }
        }

        // Carga los datos de un objeto Empleado en el formulario
        private void CargarDatosFormulario(entEmpleado emp)
        {
            if (emp == null) return;

            idEmpleadoSeleccionado = emp.IdEmpleado;
            txtEDni.Text = emp.Dni;
            txtETelefono.Text = emp.TelefonoEmpleado;
            txtECorreo.Text = emp.CorreoEmpleado;
            cmbECargo.Text = emp.Cargo;
            chkEstado.Checked = emp.Estado;

            // --- Lógica para separar Nombres y Apellidos ---
            string nombreCompleto = emp.NombreEmpleado;
            int primerEspacio = nombreCompleto.IndexOf(' ');

            if (primerEspacio != -1)
            {
                txtENombres.Text = nombreCompleto.Substring(0, primerEspacio);
            }
            else
            {
                txtENombres.Text = nombreCompleto;
            }

            // Habilitamos el botón Editar
            btnEEditar.Enabled = true;
        }

        // Seleccionar desde el Grid
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que no sea el header
            {
                // Obtenemos el DNI de la fila seleccionada
                string dni = dgvEmpleados.Rows[e.RowIndex].Cells["Dni"].Value.ToString();

                // Usamos la lógica de búsqueda para cargar los datos
                entEmpleado emp = logica.BuscarEmpleadoPorDni(dni);
                if (emp != null)
                {
                    CargarDatosFormulario(emp);
                }
            }
        }

        // MODO NUEVO
        private void btnEAgregar_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            HabilitarControles(true);
            LimpiarControles();

            // Deshabilitamos los botones de navegación/selección
            btnEBuscar.Enabled = false;
            btnEAgregar.Enabled = false;
            btnEEditar.Enabled = false;
            dgvEmpleados.Enabled = false;

            // Habilitamos los botones de acción
            btnEGuardar.Enabled = true;
            btnECancelar.Enabled = true;

            txtENombres.Focus(); // Mover el cursor al primer campo
        }

        // MODO EDICIÓN
        private void btnEEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            HabilitarControles(true); // Habilita campos

            // Deshabilitamos los botones de navegación/selección
            btnEBuscar.Enabled = false;
            btnEAgregar.Enabled = false;
            btnEEditar.Enabled = false;
            dgvEmpleados.Enabled = false;

            // Habilitamos los botones de acción
            btnEGuardar.Enabled = true;
            btnECancelar.Enabled = true;

            txtENombres.Focus();
        }

        // CANCELAR (Modo Nuevo o Edición)
        private void btnECancelar_Click(object sender, EventArgs e)
        {
            EstadoInicial(); // Simplemente resetea el formulario
        }

        // GUARDAR (para Nuevo o Edición)
        private void btnEGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entEmpleado emp = new entEmpleado();

                // --- Lógica para unir Nombres y Apellidos ---
                emp.NombreEmpleado = $"{txtENombres.Text.Trim()}".Trim();

                emp.Dni = txtEDni.Text.Trim();
                emp.TelefonoEmpleado = txtETelefono.Text.Trim();
                emp.CorreoEmpleado = txtECorreo.Text.Trim();
                emp.Cargo = cmbECargo.Text;
                emp.Estado = chkEstado.Checked;

                bool resultado;

                if (esNuevo)
                {
                    // INSERTAR
                    resultado = logica.InsertarEmpleado(emp);
                    if (resultado)
                    {
                        MessageBox.Show("Empleado creado exitosamente.", "Éxito");
                    }
                }
                else
                {
                    // EDITAR
                    emp.IdEmpleado = idEmpleadoSeleccionado; // Usamos el ID guardado
                    resultado = logica.EditarEmpleado(emp);
                    if (resultado)
                    {
                        MessageBox.Show("Empleado modificado exitosamente.", "Éxito");
                    }
                }

                if (resultado)
                {
                    ListarEmpleadosGrid();
                    EstadoInicial(); // Volver al estado inicial
                }
                else
                {
                    MessageBox.Show("Error al guardar el empleado. Verifique los datos.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message, "Error");
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

        private void btnEGuardar_Click_1(object sender, EventArgs e)
        {
            string dni = txtEDni.Text.Trim();
            entEmpleado emp = logica.BuscarEmpleadoPorDni(dni);

            if (emp != null)
            {
                CargarDatosFormulario(emp);
            }
            else
            {
                MessageBox.Show("No se encontró ningún empleado con ese DNI.", "Búsqueda fallida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
                btnEEditar.Enabled = false;
            }
        }

    }
}
