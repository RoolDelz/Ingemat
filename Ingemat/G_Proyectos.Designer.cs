namespace Ingemat
{
    partial class G_Proyectos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_Dni = new System.Windows.Forms.TextBox();
            this.Estado = new System.Windows.Forms.ComboBox();
            this.DNI = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_proyectos = new System.Windows.Forms.Button();
            this.btn_empleados = new System.Windows.Forms.Button();
            this.btn_os = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_formatos = new System.Windows.Forms.Button();
            this.btn_ot = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_aplicar = new System.Windows.Forms.Button();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ver = new System.Windows.Forms.Button();
            this.btn_facturas = new System.Windows.Forms.Button();
            this.BTinicio = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Dni
            // 
            this.Txt_Dni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Txt_Dni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Dni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Dni.Location = new System.Drawing.Point(396, 76);
            this.Txt_Dni.Margin = new System.Windows.Forms.Padding(2);
            this.Txt_Dni.Name = "Txt_Dni";
            this.Txt_Dni.Size = new System.Drawing.Size(479, 20);
            this.Txt_Dni.TabIndex = 40;
            // 
            // Estado
            // 
            this.Estado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Estado.FormattingEnabled = true;
            this.Estado.ItemHeight = 16;
            this.Estado.Items.AddRange(new object[] {
            "No Confirmado",
            "En Proceso",
            "Completado"});
            this.Estado.Location = new System.Drawing.Point(369, 117);
            this.Estado.Margin = new System.Windows.Forms.Padding(2);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(112, 24);
            this.Estado.TabIndex = 70;
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.BackColor = System.Drawing.Color.Transparent;
            this.DNI.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNI.ForeColor = System.Drawing.Color.Black;
            this.DNI.Location = new System.Drawing.Point(287, 75);
            this.DNI.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(72, 21);
            this.DNI.TabIndex = 71;
            this.DNI.Text = "Codigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(287, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 21);
            this.label1.TabIndex = 72;
            this.label1.Text = "Estado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(594, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 21);
            this.label2.TabIndex = 73;
            this.label2.Text = "Año:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(645, 120);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(92, 20);
            this.textBox1.TabIndex = 76;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(715, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 41);
            this.label3.TabIndex = 117;
            this.label3.Text = "Proyectos";
            // 
            // btn_proyectos
            // 
            this.btn_proyectos.BackColor = System.Drawing.Color.Magenta;
            this.btn_proyectos.FlatAppearance.BorderSize = 0;
            this.btn_proyectos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_proyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_proyectos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proyectos.ForeColor = System.Drawing.Color.White;
            this.btn_proyectos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_proyectos.Location = new System.Drawing.Point(9, 204);
            this.btn_proyectos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_proyectos.Name = "btn_proyectos";
            this.btn_proyectos.Size = new System.Drawing.Size(199, 48);
            this.btn_proyectos.TabIndex = 2;
            this.btn_proyectos.Text = "Proyectos";
            this.btn_proyectos.UseVisualStyleBackColor = false;
            this.btn_proyectos.Click += new System.EventHandler(this.btn_proyectos_Click);
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
            this.btn_empleados.Location = new System.Drawing.Point(9, 256);
            this.btn_empleados.Margin = new System.Windows.Forms.Padding(2);
            this.btn_empleados.Name = "btn_empleados";
            this.btn_empleados.Size = new System.Drawing.Size(199, 54);
            this.btn_empleados.TabIndex = 6;
            this.btn_empleados.Text = "Empleados";
            this.btn_empleados.UseVisualStyleBackColor = false;
            this.btn_empleados.Click += new System.EventHandler(this.btn_empleados_Click);
            // 
            // btn_os
            // 
            this.btn_os.BackColor = System.Drawing.Color.Transparent;
            this.btn_os.FlatAppearance.BorderSize = 0;
            this.btn_os.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_os.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_os.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_os.ForeColor = System.Drawing.Color.White;
            this.btn_os.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_os.Location = new System.Drawing.Point(9, 366);
            this.btn_os.Margin = new System.Windows.Forms.Padding(2);
            this.btn_os.Name = "btn_os";
            this.btn_os.Size = new System.Drawing.Size(195, 48);
            this.btn_os.TabIndex = 3;
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
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(9, 583);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(199, 48);
            this.btn_cerrar.TabIndex = 4;
            this.btn_cerrar.Text = "Cerrar Sesion";
            this.btn_cerrar.UseVisualStyleBackColor = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
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
            this.btn_formatos.Location = new System.Drawing.Point(9, 314);
            this.btn_formatos.Margin = new System.Windows.Forms.Padding(2);
            this.btn_formatos.Name = "btn_formatos";
            this.btn_formatos.Size = new System.Drawing.Size(199, 48);
            this.btn_formatos.TabIndex = 163;
            this.btn_formatos.Text = "Formatos";
            this.btn_formatos.UseVisualStyleBackColor = false;
            this.btn_formatos.Click += new System.EventHandler(this.btn_formatos_Click);
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
            this.btn_ot.Location = new System.Drawing.Point(9, 418);
            this.btn_ot.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ot.Name = "btn_ot";
            this.btn_ot.Size = new System.Drawing.Size(199, 48);
            this.btn_ot.TabIndex = 164;
            this.btn_ot.Text = "Ordenes De Trabajo";
            this.btn_ot.UseVisualStyleBackColor = false;
            this.btn_ot.Click += new System.EventHandler(this.btn_ot_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_facturas);
            this.panel1.Controls.Add(this.btn_ot);
            this.panel1.Controls.Add(this.BTinicio);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.btn_empleados);
            this.panel1.Controls.Add(this.btn_proyectos);
            this.panel1.Controls.Add(this.btn_formatos);
            this.panel1.Controls.Add(this.btn_os);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 662);
            this.panel1.TabIndex = 174;
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.Location = new System.Drawing.Point(783, 118);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(75, 23);
            this.btn_aplicar.TabIndex = 175;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.UseVisualStyleBackColor = true;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(864, 118);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.TabIndex = 176;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(291, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1064, 422);
            this.dataGridView1.TabIndex = 177;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IdProyecto";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre Proyecto";
            this.Column2.Name = "Column2";
            this.Column2.Width = 400;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fecha";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Estudio";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Precio";
            this.Column6.Name = "Column6";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Estado";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // btn_ver
            // 
            this.btn_ver.Location = new System.Drawing.Point(1257, 121);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(75, 23);
            this.btn_ver.TabIndex = 180;
            this.btn_ver.Text = "Ver";
            this.btn_ver.UseVisualStyleBackColor = true;
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
            this.btn_facturas.Location = new System.Drawing.Point(9, 470);
            this.btn_facturas.Margin = new System.Windows.Forms.Padding(2);
            this.btn_facturas.Name = "btn_facturas";
            this.btn_facturas.Size = new System.Drawing.Size(199, 48);
            this.btn_facturas.TabIndex = 199;
            this.btn_facturas.Text = "Facturas";
            this.btn_facturas.UseVisualStyleBackColor = false;
            this.btn_facturas.Click += new System.EventHandler(this.btn_facturas_Click);
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
            this.BTinicio.Location = new System.Drawing.Point(9, 12);
            this.BTinicio.Name = "BTinicio";
            this.BTinicio.Size = new System.Drawing.Size(195, 150);
            this.BTinicio.TabIndex = 9;
            this.BTinicio.UseVisualStyleBackColor = false;
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.Transparent;
            this.btn_buscar.BackgroundImage = global::Ingemat.Properties.Resources.Lupa;
            this.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar.ForeColor = System.Drawing.Color.Gray;
            this.btn_buscar.Location = new System.Drawing.Point(922, 67);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(45, 29);
            this.btn_buscar.TabIndex = 59;
            this.btn_buscar.UseVisualStyleBackColor = false;
            // 
            // G_Proyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1424, 661);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_aplicar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.Txt_Dni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "G_Proyectos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Txt_Dni;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.ComboBox Estado;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_proyectos;
        private System.Windows.Forms.Button btn_empleados;
        private System.Windows.Forms.Button btn_os;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button BTinicio;
        private System.Windows.Forms.Button btn_formatos;
        private System.Windows.Forms.Button btn_ot;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_aplicar;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btn_facturas;
    }
}

