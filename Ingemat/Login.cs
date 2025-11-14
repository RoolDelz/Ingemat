using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaEntidad;

namespace Ingemat
{
    public partial class Login : Form
    {
        private logLogin logicaLogin = new logLogin();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_iniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            // Llamamos a la capa lógica para validar
            bool exito = logicaLogin.ValidarLogin(usuario, password);

            if (exito)
            {
                // Si el login es exitoso, cerramos este formulario
                // con un resultado "OK".
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Si falla, mostramos un error
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
