namespace SCAPEN_2021.Presentacion
{
    partial class PrePlanilla
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBarra = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblnumerosemana = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtdesde = new System.Windows.Forms.DateTimePicker();
            this.txthasta = new System.Windows.Forms.DateTimePicker();
            this.pbxBusqueda = new System.Windows.Forms.PictureBox();
            this.panelBuscador = new System.Windows.Forms.Panel();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBusqueda)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarra
            // 
            this.panelBarra.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarra.Location = new System.Drawing.Point(0, 0);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(1083, 30);
            this.panelBarra.TabIndex = 3;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(249, 19);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(44, 25);
            this.Label5.TabIndex = 603;
            this.Label5.Text = "Del";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(430, 17);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(29, 25);
            this.Label6.TabIndex = 604;
            this.Label6.Text = "al";
            // 
            // lblnumerosemana
            // 
            this.lblnumerosemana.AutoSize = true;
            this.lblnumerosemana.BackColor = System.Drawing.Color.Transparent;
            this.lblnumerosemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblnumerosemana.ForeColor = System.Drawing.Color.White;
            this.lblnumerosemana.Location = new System.Drawing.Point(771, 24);
            this.lblnumerosemana.Name = "lblnumerosemana";
            this.lblnumerosemana.Size = new System.Drawing.Size(24, 25);
            this.lblnumerosemana.TabIndex = 605;
            this.lblnumerosemana.Text = "#";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Transparent;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.Label7.ForeColor = System.Drawing.Color.White;
            this.Label7.Location = new System.Drawing.Point(637, 21);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(128, 25);
            this.Label7.TabIndex = 606;
            this.Label7.Text = "Semana Nº:";
            // 
            // txtdesde
            // 
            this.txtdesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtdesde.Location = new System.Drawing.Point(299, 21);
            this.txtdesde.Name = "txtdesde";
            this.txtdesde.Size = new System.Drawing.Size(109, 20);
            this.txtdesde.TabIndex = 607;
            this.txtdesde.Value = new System.DateTime(2020, 11, 3, 0, 0, 0, 0);
            this.txtdesde.ValueChanged += new System.EventHandler(this.Txtdesde_ValueChanged);
            // 
            // txthasta
            // 
            this.txthasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txthasta.Location = new System.Drawing.Point(490, 19);
            this.txthasta.Name = "txthasta";
            this.txthasta.Size = new System.Drawing.Size(109, 20);
            this.txthasta.TabIndex = 608;
            this.txthasta.Value = new System.DateTime(2021, 11, 5, 0, 0, 0, 0);
            this.txthasta.ValueChanged += new System.EventHandler(this.Txthasta_ValueChanged);
            // 
            // pbxBusqueda
            // 
            this.pbxBusqueda.Image = global::SCAPEN_2021.Properties.Resources.buscar__1_;
            this.pbxBusqueda.Location = new System.Drawing.Point(672, 49);
            this.pbxBusqueda.Name = "pbxBusqueda";
            this.pbxBusqueda.Size = new System.Drawing.Size(34, 38);
            this.pbxBusqueda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxBusqueda.TabIndex = 611;
            this.pbxBusqueda.TabStop = false;
            // 
            // panelBuscador
            // 
            this.panelBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(55)))));
            this.panelBuscador.Location = new System.Drawing.Point(338, 80);
            this.panelBuscador.Name = "panelBuscador";
            this.panelBuscador.Size = new System.Drawing.Size(315, 2);
            this.panelBuscador.TabIndex = 610;
            // 
            // txtBuscador
            // 
            this.txtBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.ForeColor = System.Drawing.Color.White;
            this.txtBuscador.Location = new System.Drawing.Point(338, 57);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(311, 22);
            this.txtBuscador.TabIndex = 609;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.BackColor = System.Drawing.Color.Transparent;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.reportViewer1.Location = new System.Drawing.Point(31, 127);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1020, 510);
            this.reportViewer1.TabIndex = 612;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtdesde);
            this.panel1.Controls.Add(this.Label5);
            this.panel1.Controls.Add(this.pbxBusqueda);
            this.panel1.Controls.Add(this.panelBuscador);
            this.panel1.Controls.Add(this.txthasta);
            this.panel1.Controls.Add(this.txtBuscador);
            this.panel1.Controls.Add(this.Label6);
            this.panel1.Controls.Add(this.Label7);
            this.panel1.Controls.Add(this.lblnumerosemana);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 97);
            this.panel1.TabIndex = 613;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 127);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 510);
            this.panel2.TabIndex = 614;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1051, 127);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(32, 572);
            this.flowLayoutPanel1.TabIndex = 615;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 637);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1051, 62);
            this.panel3.TabIndex = 616;
            // 
            // PrePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBarra);
            this.Name = "PrePlanilla";
            this.Size = new System.Drawing.Size(1083, 699);
            this.Load += new System.EventHandler(this.PrePlanilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxBusqueda)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarra;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label lblnumerosemana;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.DateTimePicker txtdesde;
        internal System.Windows.Forms.DateTimePicker txthasta;
        private System.Windows.Forms.PictureBox pbxBusqueda;
        private System.Windows.Forms.Panel panelBuscador;
        private System.Windows.Forms.TextBox txtBuscador;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
    }
}
