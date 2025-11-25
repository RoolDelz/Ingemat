namespace Ingemat
{
    partial class G_AprobarOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_facturas = new System.Windows.Forms.Button();
            this.btn_ot = new System.Windows.Forms.Button();
            this.BTinicio = new System.Windows.Forms.Button();
            this.btn_os = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_empleados = new System.Windows.Forms.Button();
            this.btn_formatos = new System.Windows.Forms.Button();
            this.btn_proyectos = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnCrearPro = new System.Windows.Forms.Button();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.dgvOrdenes = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.Label();
            this.Estado = new System.Windows.Forms.ComboBox();
            this.Txt_Dni = new System.Windows.Forms.TextBox();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(720, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(541, 44);
            this.label3.TabIndex = 143;
            this.label3.Text = "Aprobar Ordenes De Servicio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_facturas);
            this.panel1.Controls.Add(this.btn_ot);
            this.panel1.Controls.Add(this.BTinicio);
            this.panel1.Controls.Add(this.btn_os);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.btn_empleados);
            this.panel1.Controls.Add(this.btn_formatos);
            this.panel1.Controls.Add(this.btn_proyectos);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 815);
            this.panel1.TabIndex = 175;
            // 
            // btn_facturas
            // 
            this.btn_facturas.BackColor = System.Drawing.Color.Transparent;
            this.btn_facturas.FlatAppearance.BorderSize = 0;
            this.btn_facturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_facturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_facturas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_facturas.ForeColor = System.Drawing.Color.White;
            this.btn_facturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_facturas.Location = new System.Drawing.Point(12, 578);
            this.btn_facturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_facturas.Name = "btn_facturas";
            this.btn_facturas.Size = new System.Drawing.Size(265, 59);
            this.btn_facturas.TabIndex = 198;
            this.btn_facturas.Text = "Facturas";
            this.btn_facturas.UseVisualStyleBackColor = false;
            this.btn_facturas.Click += new System.EventHandler(this.btn_facturas_Click);
            // 
            // btn_ot
            // 
            this.btn_ot.BackColor = System.Drawing.Color.Transparent;
            this.btn_ot.FlatAppearance.BorderSize = 0;
            this.btn_ot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_ot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ot.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ot.ForeColor = System.Drawing.Color.White;
            this.btn_ot.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ot.Location = new System.Drawing.Point(12, 514);
            this.btn_ot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ot.Name = "btn_ot";
            this.btn_ot.Size = new System.Drawing.Size(265, 59);
            this.btn_ot.TabIndex = 164;
            this.btn_ot.Text = "Ordenes De Trabajo";
            this.btn_ot.UseVisualStyleBackColor = false;
            this.btn_ot.Click += new System.EventHandler(this.btn_ot_Click);
            // 
            // BTinicio
            // 
            this.BTinicio.BackColor = System.Drawing.Color.Transparent;
            this.BTinicio.BackgroundImage = global::Ingemat.Properties.Resources.Usuario;
            this.BTinicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTinicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTinicio.FlatAppearance.BorderSize = 0;
            this.BTinicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BTinicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTinicio.ForeColor = System.Drawing.Color.White;
            this.BTinicio.Location = new System.Drawing.Point(12, 15);
            this.BTinicio.Margin = new System.Windows.Forms.Padding(4);
            this.BTinicio.Name = "BTinicio";
            this.BTinicio.Size = new System.Drawing.Size(260, 185);
            this.BTinicio.TabIndex = 9;
            this.BTinicio.UseVisualStyleBackColor = false;
            // 
            // btn_os
            // 
            this.btn_os.BackColor = System.Drawing.Color.Magenta;
            this.btn_os.FlatAppearance.BorderSize = 0;
            this.btn_os.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_os.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_os.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_os.ForeColor = System.Drawing.Color.White;
            this.btn_os.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_os.Location = new System.Drawing.Point(12, 450);
            this.btn_os.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_os.Name = "btn_os";
            this.btn_os.Size = new System.Drawing.Size(265, 59);
            this.btn_os.TabIndex = 2;
            this.btn_os.Text = "Ordenes De Servicio";
            this.btn_os.UseVisualStyleBackColor = false;
            this.btn_os.Click += new System.EventHandler(this.btn_os_Click);
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Location = new System.Drawing.Point(12, 718);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(265, 59);
            this.btn_cerrar.TabIndex = 4;
            this.btn_cerrar.Text = "Cerrar Sesion";
            this.btn_cerrar.UseVisualStyleBackColor = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_empleados
            // 
            this.btn_empleados.BackColor = System.Drawing.Color.Transparent;
            this.btn_empleados.FlatAppearance.BorderSize = 0;
            this.btn_empleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_empleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_empleados.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_empleados.ForeColor = System.Drawing.Color.White;
            this.btn_empleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_empleados.Location = new System.Drawing.Point(12, 315);
            this.btn_empleados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_empleados.Name = "btn_empleados";
            this.btn_empleados.Size = new System.Drawing.Size(265, 66);
            this.btn_empleados.TabIndex = 6;
            this.btn_empleados.Text = "Empleados";
            this.btn_empleados.UseVisualStyleBackColor = false;
            this.btn_empleados.Click += new System.EventHandler(this.btn_empleados_Click);
            // 
            // btn_formatos
            // 
            this.btn_formatos.BackColor = System.Drawing.Color.Transparent;
            this.btn_formatos.FlatAppearance.BorderSize = 0;
            this.btn_formatos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_formatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_formatos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_formatos.ForeColor = System.Drawing.Color.White;
            this.btn_formatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_formatos.Location = new System.Drawing.Point(12, 386);
            this.btn_formatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_formatos.Name = "btn_formatos";
            this.btn_formatos.Size = new System.Drawing.Size(265, 59);
            this.btn_formatos.TabIndex = 163;
            this.btn_formatos.Text = "Formatos";
            this.btn_formatos.UseVisualStyleBackColor = false;
            this.btn_formatos.Click += new System.EventHandler(this.btn_formatos_Click);
            // 
            // btn_proyectos
            // 
            this.btn_proyectos.BackColor = System.Drawing.Color.Transparent;
            this.btn_proyectos.FlatAppearance.BorderSize = 0;
            this.btn_proyectos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_proyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_proyectos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proyectos.ForeColor = System.Drawing.Color.White;
            this.btn_proyectos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_proyectos.Location = new System.Drawing.Point(12, 251);
            this.btn_proyectos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_proyectos.Name = "btn_proyectos";
            this.btn_proyectos.Size = new System.Drawing.Size(260, 59);
            this.btn_proyectos.TabIndex = 3;
            this.btn_proyectos.Text = "Proyectos";
            this.btn_proyectos.UseVisualStyleBackColor = false;
            this.btn_proyectos.Click += new System.EventHandler(this.btn_proyectos_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.Location = new System.Drawing.Point(1759, 495);
            this.btnRechazar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(100, 28);
            this.btnRechazar.TabIndex = 197;
            this.btnRechazar.Text = "Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = true;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnCrearPro
            // 
            this.btnCrearPro.Location = new System.Drawing.Point(1745, 386);
            this.btnCrearPro.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrearPro.Name = "btnCrearPro";
            this.btnCrearPro.Size = new System.Drawing.Size(127, 28);
            this.btnCrearPro.TabIndex = 196;
            this.btnCrearPro.Text = "Crear Proyecto";
            this.btnCrearPro.UseVisualStyleBackColor = true;
            this.btnCrearPro.Click += new System.EventHandler(this.btnCrearPro_Click);
            // 
            // btnAprobar
            // 
            this.btnAprobar.Location = new System.Drawing.Point(1759, 439);
            this.btnAprobar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(100, 28);
            this.btnAprobar.TabIndex = 194;
            this.btnAprobar.Text = "Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = true;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // dgvOrdenes
            // 
            this.dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenes.Location = new System.Drawing.Point(318, 211);
            this.dgvOrdenes.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOrdenes.Name = "dgvOrdenes";
            this.dgvOrdenes.RowHeadersWidth = 51;
            this.dgvOrdenes.Size = new System.Drawing.Size(1419, 519);
            this.dgvOrdenes.TabIndex = 193;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(861, 150);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 25);
            this.textBox1.TabIndex = 189;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(793, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 188;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(384, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 187;
            this.label1.Text = "Estado:";
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.BackColor = System.Drawing.Color.Transparent;
            this.DNI.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNI.ForeColor = System.Drawing.Color.Black;
            this.DNI.Location = new System.Drawing.Point(384, 95);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(87, 23);
            this.DNI.TabIndex = 186;
            this.DNI.Text = "Codigo:";
            // 
            // Estado
            // 
            this.Estado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estado.FormattingEnabled = true;
            this.Estado.ItemHeight = 19;
            this.Estado.Items.AddRange(new object[] {
            "No Confirmado",
            "En Proceso",
            "Completado"});
            this.Estado.Location = new System.Drawing.Point(493, 146);
            this.Estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(148, 27);
            this.Estado.TabIndex = 185;
            // 
            // Txt_Dni
            // 
            this.Txt_Dni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Txt_Dni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Dni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Dni.Location = new System.Drawing.Point(529, 96);
            this.Txt_Dni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Dni.Name = "Txt_Dni";
            this.Txt_Dni.Size = new System.Drawing.Size(639, 25);
            this.Txt_Dni.TabIndex = 183;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.Transparent;
            this.btn_buscar.BackgroundImage = global::Ingemat.Properties.Resources.Lupa;
            this.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar.ForeColor = System.Drawing.Color.Gray;
            this.btn_buscar.Location = new System.Drawing.Point(1231, 85);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(60, 36);
            this.btn_buscar.TabIndex = 184;
            this.btn_buscar.UseVisualStyleBackColor = false;
            // 
            // G_AprobarOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1899, 814);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnCrearPro);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.dgvOrdenes);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.Txt_Dni);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "G_AprobarOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "9";
            this.Load += new System.EventHandler(this.G_aprobarOS_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_ot;
        private System.Windows.Forms.Button BTinicio;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_empleados;
        private System.Windows.Forms.Button btn_os;
        private System.Windows.Forms.Button btn_formatos;
        private System.Windows.Forms.Button btn_proyectos;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnCrearPro;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.DataGridView dgvOrdenes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.ComboBox Estado;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox Txt_Dni;
        private System.Windows.Forms.Button btn_facturas;
    }
}