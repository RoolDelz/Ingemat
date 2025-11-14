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

            // 1. Creamos el formulario de login
            Login loginForm = new Login();

            // 2. Mostramos el login como un diálogo modal.
            // La aplicación se detiene aquí hasta que loginForm se cierre.
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 3. Si el login fue exitoso (DialogResult.OK),
                //    leemos el cargo que se guardó en la Sesión.
                string cargo = entSession.Cargo;
                Form formularioPrincipal = null;

                // 4. Determinamos qué formulario principal abrir
                switch (cargo)
                {
                    case "Gerente":
                        formularioPrincipal = new G_Proyectos(); // Se abre G_Proyectos
                        break;
                    case "Area de ventas":
                        formularioPrincipal = new V_Proformas(); // Se abre V_Proformas
                        break;
                    case "Ayudante Tecnico":
                        formularioPrincipal = new T_Actividades(); // Se abre T_Actividades
                        break;
                    default:
                        // Seguridad por si algo falla
                        MessageBox.Show("Error: Cargo no reconocido. Saliendo.");
                        Application.Exit();
                        return;
                }

                // 5. Iniciamos la aplicación con el formulario principal correcto.
                Application.Run(formularioPrincipal);
            }
            else
            {
                // 6. Si el login se cancela o falla, la app no inicia.
                Application.Exit();
            }
        }
    }
}
