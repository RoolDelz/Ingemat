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
        public T_RealizarActividad()
        {
            InitializeComponent();
        }

        private void btn_actividades_Click(object sender, EventArgs e)
        {
            T_Actividades pantalla = new T_Actividades();
            this.Hide();
            pantalla.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
