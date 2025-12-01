namespace Ingemat
{
    partial class V_Facturas
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
            this.btnVer = new System.Windows.Forms.Button();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.btn_limpiar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.Label();
            this.Estado = new System.Windows.Forms.ComboBox();
            this.Txt_Dni = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTinicio = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_nuevaProforma = new System.Windows.Forms.Button();
            this.btn_facturas = new System.Windows.Forms.Button();
            this.btn_os = new System.Windows.Forms.Button();
            this.btn_proformas = new System.Windows.Forms.Button();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.btn_aplicar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(1671, 175);
            this.btnVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(100, 28);
            this.btnVer.TabIndex = 331;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(377, 214);
            this.dgvFacturas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.Size = new System.Drawing.Size(1419, 519);
            this.dgvFacturas.TabIndex = 330;
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.Location = new System.Drawing.Point(1141, 161);
            this.btn_limpiar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(100, 28);
            this.btn_limpiar.TabIndex = 329;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(1000, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 51);
            this.label3.TabIndex = 327;
            this.label3.Text = "Facturas";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(849, 164);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 25);
            this.textBox1.TabIndex = 326;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(781, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 325;
            this.label2.Text = "Año:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(372, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 324;
            this.label1.Text = "Estado:";
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.BackColor = System.Drawing.Color.Transparent;
            this.DNI.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNI.ForeColor = System.Drawing.Color.Black;
            this.DNI.Location = new System.Drawing.Point(372, 108);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(87, 23);
            this.DNI.TabIndex = 323;
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
            this.Estado.Location = new System.Drawing.Point(481, 160);
            this.Estado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(148, 27);
            this.Estado.TabIndex = 322;
            // 
            // Txt_Dni
            // 
            this.Txt_Dni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Txt_Dni.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Dni.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Dni.Location = new System.Drawing.Point(517, 110);
            this.Txt_Dni.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Dni.Name = "Txt_Dni";
            this.Txt_Dni.Size = new System.Drawing.Size(639, 25);
            this.Txt_Dni.TabIndex = 320;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.BTinicio);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.btn_nuevaProforma);
            this.panel1.Controls.Add(this.btn_facturas);
            this.panel1.Controls.Add(this.btn_os);
            this.panel1.Controls.Add(this.btn_proformas);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 815);
            this.panel1.TabIndex = 319;
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
            // btn_cerrar
            // 
            this.btn_cerrar.BackColor = System.Drawing.Color.Transparent;
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cerrar.Location = new System.Drawing.Point(12, 718);
            this.btn_cerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(265, 59);
            this.btn_cerrar.TabIndex = 4;
            this.btn_cerrar.Text = "Cerrar Sesion";
            this.btn_cerrar.UseVisualStyleBackColor = false;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // btn_nuevaProforma
            // 
            this.btn_nuevaProforma.BackColor = System.Drawing.Color.Transparent;
            this.btn_nuevaProforma.FlatAppearance.BorderSize = 0;
            this.btn_nuevaProforma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_nuevaProforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nuevaProforma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevaProforma.ForeColor = System.Drawing.Color.White;
            this.btn_nuevaProforma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_nuevaProforma.Location = new System.Drawing.Point(12, 315);
            this.btn_nuevaProforma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_nuevaProforma.Name = "btn_nuevaProforma";
            this.btn_nuevaProforma.Size = new System.Drawing.Size(265, 66);
            this.btn_nuevaProforma.TabIndex = 6;
            this.btn_nuevaProforma.Text = "Nueva Proforma";
            this.btn_nuevaProforma.UseVisualStyleBackColor = false;
            this.btn_nuevaProforma.Click += new System.EventHandler(this.btn_nuevaProforma_Click);
            // 
            // btn_facturas
            // 
            this.btn_facturas.BackColor = System.Drawing.Color.Magenta;
            this.btn_facturas.FlatAppearance.BorderSize = 0;
            this.btn_facturas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_facturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_facturas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_facturas.ForeColor = System.Drawing.Color.White;
            this.btn_facturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_facturas.Location = new System.Drawing.Point(12, 450);
            this.btn_facturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_facturas.Name = "btn_facturas";
            this.btn_facturas.Size = new System.Drawing.Size(265, 59);
            this.btn_facturas.TabIndex = 2;
            this.btn_facturas.Text = "Facturas";
            this.btn_facturas.UseVisualStyleBackColor = false;
            this.btn_facturas.Click += new System.EventHandler(this.btn_facturas_Click);
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
            this.btn_os.Location = new System.Drawing.Point(12, 386);
            this.btn_os.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_os.Name = "btn_os";
            this.btn_os.Size = new System.Drawing.Size(265, 59);
            this.btn_os.TabIndex = 163;
            this.btn_os.Text = "Ordenes De Servicio";
            this.btn_os.UseVisualStyleBackColor = false;
            this.btn_os.Click += new System.EventHandler(this.btn_os_Click);
            // 
            // btn_proformas
            // 
            this.btn_proformas.BackColor = System.Drawing.Color.Transparent;
            this.btn_proformas.FlatAppearance.BorderSize = 0;
            this.btn_proformas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_proformas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_proformas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_proformas.ForeColor = System.Drawing.Color.White;
            this.btn_proformas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_proformas.Location = new System.Drawing.Point(17, 251);
            this.btn_proformas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_proformas.Name = "btn_proformas";
            this.btn_proformas.Size = new System.Drawing.Size(260, 59);
            this.btn_proformas.TabIndex = 3;
            this.btn_proformas.Text = "Proformas";
            this.btn_proformas.UseVisualStyleBackColor = false;
            this.btn_proformas.Click += new System.EventHandler(this.btn_proformas_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.Transparent;
            this.btn_buscar.BackgroundImage = global::Ingemat.Properties.Resources.Lupa;
            this.btn_buscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_buscar.ForeColor = System.Drawing.Color.Gray;
            this.btn_buscar.Location = new System.Drawing.Point(1219, 98);
            this.btn_buscar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(60, 36);
            this.btn_buscar.TabIndex = 321;
            this.btn_buscar.UseVisualStyleBackColor = false;
            // 
            // btn_aplicar
            // 
            this.btn_aplicar.Location = new System.Drawing.Point(1033, 161);
            this.btn_aplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_aplicar.Name = "btn_aplicar";
            this.btn_aplicar.Size = new System.Drawing.Size(100, 28);
            this.btn_aplicar.TabIndex = 328;
            this.btn_aplicar.Text = "Aplicar";
            this.btn_aplicar.UseVisualStyleBackColor = true;
            // 
            // V_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1899, 814);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.btn_limpiar);
            this.Controls.Add(this.btn_aplicar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.Estado);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.Txt_Dni);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "V_Facturas";
            this.Load += new System.EventHandler(this.V_Facturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btn_limpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.ComboBox Estado;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox Txt_Dni;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTinicio;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_nuevaProforma;
        private System.Windows.Forms.Button btn_facturas;
        private System.Windows.Forms.Button btn_os;
        private System.Windows.Forms.Button btn_proformas;
        private System.Windows.Forms.Button btn_aplicar;
    }
}