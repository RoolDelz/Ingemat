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
    public partial class G_Costos : Form
    {
        public G_Costos()
        {
            InitializeComponent();
        }

        private void btn_proyectos_Click(object sender, EventArgs e)
        {
            G_Proyectos pantalla = new G_Proyectos();
            this.Hide();
            pantalla.Show();
        }

        private void btnCostos_Click(object sender, EventArgs e)
        {
            G_Costos pantalla = new G_Costos();
            this.Hide();
            pantalla.Show();
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            G_Empresa pantalla = new G_Empresa();
            this.Hide();
            pantalla.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            G_Clientes pantalla = new G_Clientes();
            this.Hide();
            pantalla.Show();
        }
    }
}
