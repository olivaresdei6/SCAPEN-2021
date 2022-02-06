namespace SCAPEN_2021.Presentacion
{
    partial class ControlDeAsistencias
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
            this.components = new System.ComponentModel.Container();
            this.panelBarra = new System.Windows.Forms.Panel();
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.panelAsistencias = new System.Windows.Forms.Panel();
            this.panelRegistro = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblAviso = new System.Windows.Forms.Label();
            this.lblHora2 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha2 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.panelIdentificacion = new System.Windows.Forms.Panel();
            this.lblIdentificacion = new System.Windows.Forms.Label();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.panelObservacion = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.lblConfirmar = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.panelConfirmarIzquierda = new System.Windows.Forms.Panel();
            this.panelConfirmarDrecha = new System.Windows.Forms.Panel();
            this.panelConfirmarArriba = new System.Windows.Forms.Panel();
            this.panelConfirmarAbajo = new System.Windows.Forms.Panel();
            this.rchTxtObserbacion = new System.Windows.Forms.RichTextBox();
            this.lblObservfacion = new System.Windows.Forms.Label();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelAsistencias.SuspendLayout();
            this.panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.panelObservacion.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panelEncabezado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBarra
            // 
            this.panelBarra.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarra.Location = new System.Drawing.Point(0, 0);
            this.panelBarra.Name = "panelBarra";
            this.panelBarra.Size = new System.Drawing.Size(1184, 44);
            this.panelBarra.TabIndex = 4;
            // 
            // timerHora
            // 
            this.timerHora.Enabled = true;
            this.timerHora.Tick += new System.EventHandler(this.TimerHora_Tick_1);
            // 
            // panelAsistencias
            // 
            this.panelAsistencias.Controls.Add(this.panelRegistro);
            this.panelAsistencias.Controls.Add(this.panelObservacion);
            this.panelAsistencias.Controls.Add(this.panelEncabezado);
            this.panelAsistencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAsistencias.Location = new System.Drawing.Point(0, 44);
            this.panelAsistencias.Name = "panelAsistencias";
            this.panelAsistencias.Size = new System.Drawing.Size(1184, 655);
            this.panelAsistencias.TabIndex = 8;
            // 
            // panelRegistro
            // 
            this.panelRegistro.Controls.Add(this.button1);
            this.panelRegistro.Controls.Add(this.txtIdentificacion);
            this.panelRegistro.Controls.Add(this.pbxLogo);
            this.panelRegistro.Controls.Add(this.lblNombre);
            this.panelRegistro.Controls.Add(this.lblAviso);
            this.panelRegistro.Controls.Add(this.lblHora2);
            this.panelRegistro.Controls.Add(this.lblHora);
            this.panelRegistro.Controls.Add(this.lblFecha2);
            this.panelRegistro.Controls.Add(this.lblFecha);
            this.panelRegistro.Controls.Add(this.panelIdentificacion);
            this.panelRegistro.Controls.Add(this.lblIdentificacion);
            this.panelRegistro.Controls.Add(this.lblMensaje);
            this.panelRegistro.Location = new System.Drawing.Point(121, 109);
            this.panelRegistro.Name = "panelRegistro";
            this.panelRegistro.Size = new System.Drawing.Size(586, 523);
            this.panelRegistro.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.button1.BackgroundImage = global::SCAPEN_2021.Properties.Resources.agregar_cargo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(486, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 44);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIdentificacion.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.ForeColor = System.Drawing.Color.White;
            this.txtIdentificacion.Location = new System.Drawing.Point(228, 185);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(242, 25);
            this.txtIdentificacion.TabIndex = 12;
            this.txtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIdentificacion_KeyPress);
            this.txtIdentificacion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtIdentificacion_KeyUp);
            // 
            // pbxLogo
            // 
            this.pbxLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxLogo.Image = global::SCAPEN_2021.Properties.Resources.icono_SCAPEN;
            this.pbxLogo.Location = new System.Drawing.Point(0, 0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(586, 124);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 11;
            this.pbxLogo.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNombre.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(55)))));
            this.lblNombre.Location = new System.Drawing.Point(33, 428);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(510, 31);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "*****";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAviso
            // 
            this.lblAviso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAviso.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(55)))));
            this.lblAviso.Location = new System.Drawing.Point(33, 379);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(510, 31);
            this.lblAviso.TabIndex = 9;
            this.lblAviso.Text = "********************";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHora2
            // 
            this.lblHora2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHora2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora2.ForeColor = System.Drawing.Color.DarkGray;
            this.lblHora2.Location = new System.Drawing.Point(230, 320);
            this.lblHora2.Name = "lblHora2";
            this.lblHora2.Size = new System.Drawing.Size(139, 31);
            this.lblHora2.TabIndex = 8;
            this.lblHora2.Text = "Hora";
            this.lblHora2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHora
            // 
            this.lblHora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHora.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(134, 320);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(88, 31);
            this.lblHora.TabIndex = 7;
            this.lblHora.Text = "Hora:";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha2
            // 
            this.lblFecha2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFecha2.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha2.ForeColor = System.Drawing.Color.DarkGray;
            this.lblFecha2.Location = new System.Drawing.Point(230, 260);
            this.lblFecha2.Name = "lblFecha2";
            this.lblFecha2.Size = new System.Drawing.Size(139, 31);
            this.lblFecha2.TabIndex = 6;
            this.lblFecha2.Text = "Fecha";
            this.lblFecha2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFecha
            // 
            this.lblFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblFecha.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(134, 260);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(88, 31);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha:";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelIdentificacion
            // 
            this.panelIdentificacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(156)))), ((int)(((byte)(55)))));
            this.panelIdentificacion.Location = new System.Drawing.Point(228, 211);
            this.panelIdentificacion.Name = "panelIdentificacion";
            this.panelIdentificacion.Size = new System.Drawing.Size(242, 2);
            this.panelIdentificacion.TabIndex = 3;
            // 
            // lblIdentificacion
            // 
            this.lblIdentificacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblIdentificacion.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdentificacion.ForeColor = System.Drawing.Color.White;
            this.lblIdentificacion.Location = new System.Drawing.Point(28, 188);
            this.lblIdentificacion.Name = "lblIdentificacion";
            this.lblIdentificacion.Size = new System.Drawing.Size(194, 31);
            this.lblIdentificacion.TabIndex = 2;
            this.lblIdentificacion.Text = "Identificación:";
            this.lblIdentificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(13, 131);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(561, 35);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "Registro de asistencias";
            this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelObservacion
            // 
            this.panelObservacion.Controls.Add(this.panel13);
            this.panelObservacion.Controls.Add(this.rchTxtObserbacion);
            this.panelObservacion.Controls.Add(this.lblObservfacion);
            this.panelObservacion.Location = new System.Drawing.Point(759, 192);
            this.panelObservacion.Name = "panelObservacion";
            this.panelObservacion.Size = new System.Drawing.Size(303, 401);
            this.panelObservacion.TabIndex = 13;
            this.panelObservacion.Visible = false;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label1);
            this.panel13.Controls.Add(this.btnRegresar);
            this.panel13.Controls.Add(this.lblConfirmar);
            this.panel13.Controls.Add(this.btnConfirmar);
            this.panel13.Controls.Add(this.panelConfirmarIzquierda);
            this.panel13.Controls.Add(this.panelConfirmarDrecha);
            this.panel13.Controls.Add(this.panelConfirmarArriba);
            this.panel13.Controls.Add(this.panelConfirmarAbajo);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 175);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(303, 209);
            this.panel13.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Consolas", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 28);
            this.label1.TabIndex = 11;
            this.label1.Text = "Regresar sin guardar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnRegresar.BackgroundImage = global::SCAPEN_2021.Properties.Resources.volver;
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Location = new System.Drawing.Point(9, 98);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(284, 60);
            this.btnRegresar.TabIndex = 12;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click_1);
            // 
            // lblConfirmar
            // 
            this.lblConfirmar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblConfirmar.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmar.ForeColor = System.Drawing.Color.White;
            this.lblConfirmar.Location = new System.Drawing.Point(9, 70);
            this.lblConfirmar.Name = "lblConfirmar";
            this.lblConfirmar.Size = new System.Drawing.Size(284, 28);
            this.lblConfirmar.TabIndex = 5;
            this.lblConfirmar.Text = "Confirmar";
            this.lblConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnConfirmar.BackgroundImage = global::SCAPEN_2021.Properties.Resources.comprobar;
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Location = new System.Drawing.Point(9, 10);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(284, 60);
            this.btnConfirmar.TabIndex = 10;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click_1);
            // 
            // panelConfirmarIzquierda
            // 
            this.panelConfirmarIzquierda.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelConfirmarIzquierda.Location = new System.Drawing.Point(0, 10);
            this.panelConfirmarIzquierda.Name = "panelConfirmarIzquierda";
            this.panelConfirmarIzquierda.Size = new System.Drawing.Size(9, 189);
            this.panelConfirmarIzquierda.TabIndex = 6;
            // 
            // panelConfirmarDrecha
            // 
            this.panelConfirmarDrecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelConfirmarDrecha.Location = new System.Drawing.Point(293, 10);
            this.panelConfirmarDrecha.Name = "panelConfirmarDrecha";
            this.panelConfirmarDrecha.Size = new System.Drawing.Size(10, 189);
            this.panelConfirmarDrecha.TabIndex = 8;
            // 
            // panelConfirmarArriba
            // 
            this.panelConfirmarArriba.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfirmarArriba.Location = new System.Drawing.Point(0, 0);
            this.panelConfirmarArriba.Name = "panelConfirmarArriba";
            this.panelConfirmarArriba.Size = new System.Drawing.Size(303, 10);
            this.panelConfirmarArriba.TabIndex = 9;
            // 
            // panelConfirmarAbajo
            // 
            this.panelConfirmarAbajo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelConfirmarAbajo.Location = new System.Drawing.Point(0, 199);
            this.panelConfirmarAbajo.Name = "panelConfirmarAbajo";
            this.panelConfirmarAbajo.Size = new System.Drawing.Size(303, 10);
            this.panelConfirmarAbajo.TabIndex = 7;
            // 
            // rchTxtObserbacion
            // 
            this.rchTxtObserbacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.rchTxtObserbacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.rchTxtObserbacion.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rchTxtObserbacion.ForeColor = System.Drawing.Color.White;
            this.rchTxtObserbacion.Location = new System.Drawing.Point(0, 31);
            this.rchTxtObserbacion.Name = "rchTxtObserbacion";
            this.rchTxtObserbacion.Size = new System.Drawing.Size(303, 144);
            this.rchTxtObserbacion.TabIndex = 4;
            this.rchTxtObserbacion.Text = "";
            // 
            // lblObservfacion
            // 
            this.lblObservfacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblObservfacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblObservfacion.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservfacion.ForeColor = System.Drawing.Color.White;
            this.lblObservfacion.Location = new System.Drawing.Point(0, 0);
            this.lblObservfacion.Name = "lblObservfacion";
            this.lblObservfacion.Size = new System.Drawing.Size(303, 31);
            this.lblObservfacion.TabIndex = 3;
            this.lblObservfacion.Text = "Observación";
            this.lblObservfacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.Controls.Add(this.panel1);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Size = new System.Drawing.Size(1184, 66);
            this.panelEncabezado.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(974, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 66);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(9, 56);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(200, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 56);
            this.panel3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(210, 10);
            this.panel4.TabIndex = 9;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnInicio.BackgroundImage = global::SCAPEN_2021.Properties.Resources.pagina_de_inicio;
            this.btnInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Location = new System.Drawing.Point(9, 10);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(191, 56);
            this.btnInicio.TabIndex = 10;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.BtnInicio_Click);
            // 
            // ControlDeAsistencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Controls.Add(this.panelAsistencias);
            this.Controls.Add(this.panelBarra);
            this.Name = "ControlDeAsistencias";
            this.Size = new System.Drawing.Size(1184, 699);
            this.panelAsistencias.ResumeLayout(false);
            this.panelRegistro.ResumeLayout(false);
            this.panelRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.panelObservacion.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panelEncabezado.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarra;
        private System.Windows.Forms.Timer timerHora;
        private System.Windows.Forms.Panel panelAsistencias;
        private System.Windows.Forms.Panel panelRegistro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label lblHora2;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha2;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel panelIdentificacion;
        private System.Windows.Forms.Label lblIdentificacion;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Panel panelObservacion;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label lblConfirmar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panelConfirmarIzquierda;
        private System.Windows.Forms.Panel panelConfirmarDrecha;
        private System.Windows.Forms.Panel panelConfirmarArriba;
        private System.Windows.Forms.Panel panelConfirmarAbajo;
        private System.Windows.Forms.RichTextBox rchTxtObserbacion;
        private System.Windows.Forms.Label lblObservfacion;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnInicio;
    }
}
