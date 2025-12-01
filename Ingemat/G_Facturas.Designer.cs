namespace Ingemat
{
    partial class G_Facturas
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DNI = new System.Windows.Forms.Label();
            this.cmbEstadoFactura = new System.Windows.Forms.ComboBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_facturas = new System.Windows.Forms.Button();
            this.btn_os = new System.Windows.Forms.Button();
            this.btn_ot = new System.Windows.Forms.Button();
            this.BTinicio = new System.Windows.Forms.Button();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.btn_empleados = new System.Windows.Forms.Button();
            this.btn_formatos = new System.Windows.Forms.Button();
            this.btn_proyectos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(1569, 171);
            this.btnVer.Margin = new System.Windows.Forms.Padding(4);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(100, 28);
            this.btnVer.TabIndex = 344;
            this.btnVer.Text = "Ver";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(379, 220);
            this.dgvFacturas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.Size = new System.Drawing.Size(1290, 513);
            this.dgvFacturas.TabIndex = 343;
            this.dgvFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Purple;
            this.label3.Location = new System.Drawing.Point(1001, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 51);
            this.label3.TabIndex = 340;
            this.label3.Text = "Facturas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(373, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 23);
            this.label1.TabIndex = 337;
            this.label1.Text = "Estado:";
            // 
            // DNI
            // 
            this.DNI.AutoSize = true;
            this.DNI.BackColor = System.Drawing.Color.Transparent;
            this.DNI.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DNI.ForeColor = System.Drawing.Color.Black;
            this.DNI.Location = new System.Drawing.Point(373, 108);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(87, 23);
            this.DNI.TabIndex = 336;
            this.DNI.Text = "Codigo:";
            // 
            // cmbEstadoFactura
            // 
            this.cmbEstadoFactura.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoFactura.FormattingEnabled = true;
            this.cmbEstadoFactura.ItemHeight = 19;
            this.cmbEstadoFactura.Location = new System.Drawing.Point(483, 160);
            this.cmbEstadoFactura.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEstadoFactura.Name = "cmbEstadoFactura";
            this.cmbEstadoFactura.Size = new System.Drawing.Size(148, 27);
            this.cmbEstadoFactura.TabIndex = 335;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodigo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(519, 110);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(639, 25);
            this.txtCodigo.TabIndex = 333;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::Ingemat.Properties.Resources.Lupa;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.ForeColor = System.Drawing.Color.Gray;
            this.btnBuscar.Location = new System.Drawing.Point(1220, 98);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(60, 36);
            this.btnBuscar.TabIndex = 334;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_facturas);
            this.panel1.Controls.Add(this.btn_os);
            this.panel1.Controls.Add(this.btn_ot);
            this.panel1.Controls.Add(this.BTinicio);
            this.panel1.Controls.Add(this.btn_cerrar);
            this.panel1.Controls.Add(this.btn_empleados);
            this.panel1.Controls.Add(this.btn_formatos);
            this.panel1.Controls.Add(this.btn_proyectos);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 815);
            this.panel1.TabIndex = 439;
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
            this.btn_facturas.Location = new System.Drawing.Point(12, 578);
            this.btn_facturas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_facturas.Name = "btn_facturas";
            this.btn_facturas.Size = new System.Drawing.Size(265, 59);
            this.btn_facturas.TabIndex = 441;
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
            this.btn_os.Location = new System.Drawing.Point(12, 450);
            this.btn_os.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_os.Name = "btn_os";
            this.btn_os.Size = new System.Drawing.Size(265, 59);
            this.btn_os.TabIndex = 439;
            this.btn_os.Text = "Ordenes De Servicio";
            this.btn_os.UseVisualStyleBackColor = false;
            this.btn_os.Click += new System.EventHandler(this.btn_os_Click);
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
            // G_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1899, 814);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.cmbEstadoFactura);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "G_Facturas";
            this.Load += new System.EventHandler(this.G_Facturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DNI;
        private System.Windows.Forms.ComboBox cmbEstadoFactura;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_facturas;
        private System.Windows.Forms.Button btn_os;
        private System.Windows.Forms.Button btn_ot;
        private System.Windows.Forms.Button BTinicio;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Button btn_empleados;
        private System.Windows.Forms.Button btn_formatos;
        private System.Windows.Forms.Button btn_proyectos;
    }
}