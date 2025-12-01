using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ingemat
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login loginForm = new Login();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                string cargo = entSession.Cargo;
                Form formularioPrincipal = null;

                switch (cargo)
                {
                    case "Gerente":
                        formularioPrincipal = new G_Proyectos();
                        break;
                    case "Area de ventas":
                        formularioPrincipal = new V_Proformas();
                        break;
                    case "Ayudante Tecnico":
                        formularioPrincipal = new T_Actividades();
                        break;
                    default:
                        MessageBox.Show($"El cargo '{cargo}' no tiene un formulario asignado.", "Error");
                        Application.Exit();
                        return;
                }
                Application.Run(formularioPrincipal);
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
