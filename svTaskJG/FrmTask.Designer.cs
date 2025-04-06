namespace svTaskJG
{
    partial class FrmTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTask));
            this.pnlServicios = new System.Windows.Forms.Panel();
            this.lblValor = new System.Windows.Forms.Label();
            this.btnAgregarServicos = new System.Windows.Forms.Button();
            this.lvServicos = new System.Windows.Forms.ListBox();
            this.txtServicios = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnActualizarCambios = new System.Windows.Forms.Button();
            this.btnAgregarEmpresas = new System.Windows.Forms.Button();
            this.txtEmpresas = new System.Windows.Forms.TextBox();
            this.lvEmpresas = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chVolverActualizar = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tmHora = new System.Windows.Forms.DateTimePicker();
            this.btnAgregarEndpoint = new System.Windows.Forms.Button();
            this.txtEndPonint = new System.Windows.Forms.TextBox();
            this.lvEnspoints = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlServicios.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlServicios
            // 
            this.pnlServicios.Controls.Add(this.lblValor);
            this.pnlServicios.Controls.Add(this.btnAgregarServicos);
            this.pnlServicios.Controls.Add(this.lvServicos);
            this.pnlServicios.Controls.Add(this.txtServicios);
            this.pnlServicios.Controls.Add(this.label1);
            this.pnlServicios.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlServicios.Location = new System.Drawing.Point(0, 0);
            this.pnlServicios.Name = "pnlServicios";
            this.pnlServicios.Size = new System.Drawing.Size(200, 355);
            this.pnlServicios.TabIndex = 0;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(12, 315);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(150, 23);
            this.lblValor.TabIndex = 8;
            this.lblValor.Text = "ID Actualizar: 268";
            // 
            // btnAgregarServicos
            // 
            this.btnAgregarServicos.Location = new System.Drawing.Point(140, 30);
            this.btnAgregarServicos.Name = "btnAgregarServicos";
            this.btnAgregarServicos.Size = new System.Drawing.Size(51, 23);
            this.btnAgregarServicos.TabIndex = 7;
            this.btnAgregarServicos.Text = "Add";
            this.btnAgregarServicos.UseVisualStyleBackColor = true;
            this.btnAgregarServicos.Click += new System.EventHandler(this.btnAgregarServicos_Click);
            // 
            // lvServicos
            // 
            this.lvServicos.FormattingEnabled = true;
            this.lvServicos.Location = new System.Drawing.Point(9, 58);
            this.lvServicos.Name = "lvServicos";
            this.lvServicos.Size = new System.Drawing.Size(182, 238);
            this.lvServicos.TabIndex = 1;
            // 
            // txtServicios
            // 
            this.txtServicios.Location = new System.Drawing.Point(9, 31);
            this.txtServicios.Name = "txtServicios";
            this.txtServicios.Size = new System.Drawing.Size(128, 20);
            this.txtServicios.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnActualizarCambios);
            this.panel2.Controls.Add(this.btnAgregarEmpresas);
            this.panel2.Controls.Add(this.txtEmpresas);
            this.panel2.Controls.Add(this.lvEmpresas);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(582, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 355);
            this.panel2.TabIndex = 2;
            // 
            // btnActualizarCambios
            // 
            this.btnActualizarCambios.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarCambios.Location = new System.Drawing.Point(10, 311);
            this.btnActualizarCambios.Name = "btnActualizarCambios";
            this.btnActualizarCambios.Size = new System.Drawing.Size(178, 32);
            this.btnActualizarCambios.TabIndex = 10;
            this.btnActualizarCambios.Text = "Actualizar Cambios";
            this.btnActualizarCambios.UseVisualStyleBackColor = true;
            this.btnActualizarCambios.Click += new System.EventHandler(this.btnActualizarCambios_Click);
            // 
            // btnAgregarEmpresas
            // 
            this.btnAgregarEmpresas.Location = new System.Drawing.Point(141, 31);
            this.btnAgregarEmpresas.Name = "btnAgregarEmpresas";
            this.btnAgregarEmpresas.Size = new System.Drawing.Size(51, 23);
            this.btnAgregarEmpresas.TabIndex = 5;
            this.btnAgregarEmpresas.Text = "Add";
            this.btnAgregarEmpresas.UseVisualStyleBackColor = true;
            this.btnAgregarEmpresas.Click += new System.EventHandler(this.btnAgregarEmpresas_Click);
            // 
            // txtEmpresas
            // 
            this.txtEmpresas.Location = new System.Drawing.Point(10, 32);
            this.txtEmpresas.Name = "txtEmpresas";
            this.txtEmpresas.Size = new System.Drawing.Size(128, 20);
            this.txtEmpresas.TabIndex = 4;
            // 
            // lvEmpresas
            // 
            this.lvEmpresas.FormattingEnabled = true;
            this.lvEmpresas.Location = new System.Drawing.Point(10, 56);
            this.lvEmpresas.Name = "lvEmpresas";
            this.lvEmpresas.Size = new System.Drawing.Size(182, 238);
            this.lvEmpresas.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(84, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Empresas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chVolverActualizar);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tmHora);
            this.panel1.Controls.Add(this.btnAgregarEndpoint);
            this.panel1.Controls.Add(this.txtEndPonint);
            this.panel1.Controls.Add(this.lvEnspoints);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 355);
            this.panel1.TabIndex = 3;
            // 
            // chVolverActualizar
            // 
            this.chVolverActualizar.AutoSize = true;
            this.chVolverActualizar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chVolverActualizar.Location = new System.Drawing.Point(233, 322);
            this.chVolverActualizar.Name = "chVolverActualizar";
            this.chVolverActualizar.Size = new System.Drawing.Size(143, 23);
            this.chVolverActualizar.TabIndex = 9;
            this.chVolverActualizar.Text = "Volver Actualizar";
            this.chVolverActualizar.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "ID Actualizar";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(89, 323);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(87, 20);
            this.txtID.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hora";
            // 
            // tmHora
            // 
            this.tmHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tmHora.Location = new System.Drawing.Point(12, 323);
            this.tmHora.Name = "tmHora";
            this.tmHora.Size = new System.Drawing.Size(71, 20);
            this.tmHora.TabIndex = 5;
            // 
            // btnAgregarEndpoint
            // 
            this.btnAgregarEndpoint.Location = new System.Drawing.Point(325, 31);
            this.btnAgregarEndpoint.Name = "btnAgregarEndpoint";
            this.btnAgregarEndpoint.Size = new System.Drawing.Size(51, 23);
            this.btnAgregarEndpoint.TabIndex = 4;
            this.btnAgregarEndpoint.Text = "Add";
            this.btnAgregarEndpoint.UseVisualStyleBackColor = true;
            this.btnAgregarEndpoint.Click += new System.EventHandler(this.btnAgregarEndpoint_Click);
            // 
            // txtEndPonint
            // 
            this.txtEndPonint.Location = new System.Drawing.Point(6, 32);
            this.txtEndPonint.Name = "txtEndPonint";
            this.txtEndPonint.Size = new System.Drawing.Size(313, 20);
            this.txtEndPonint.TabIndex = 3;
            // 
            // lvEnspoints
            // 
            this.lvEnspoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEnspoints.FormattingEnabled = true;
            this.lvEnspoints.Location = new System.Drawing.Point(6, 58);
            this.lvEnspoints.Name = "lvEnspoints";
            this.lvEnspoints.Size = new System.Drawing.Size(370, 238);
            this.lvEnspoints.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "EndPonts";
            // 
            // FrmTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 355);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlServicios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tareas";
            this.pnlServicios.ResumeLayout(false);
            this.pnlServicios.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlServicios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lvServicos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAgregarEmpresas;
        private System.Windows.Forms.TextBox txtEmpresas;
        private System.Windows.Forms.ListBox lvEmpresas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregarEndpoint;
        private System.Windows.Forms.TextBox txtEndPonint;
        private System.Windows.Forms.ListBox lvEnspoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAgregarServicos;
        private System.Windows.Forms.TextBox txtServicios;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker tmHora;
        private System.Windows.Forms.Button btnActualizarCambios;
        private System.Windows.Forms.CheckBox chVolverActualizar;
    }
}

