using SCAPEN_2021.AsistenteDeInstalacion;
using SCAPEN_2021.Datos;
using SCAPEN_2021.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SCAPEN_2021.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        bool maximizar = false;
        public int idUsuario;
        public string usuario;
        public Image imagen;
        string servidor = @".\SQLEXPRESS";
        string ruta;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
        public MenuPrincipal()
        {

            InitializeComponent();
            this.AutoScroll = true;
        }


        private void MunuPrincipal_Load(object sender, EventArgs e)
        {
            panelGeneral.Dock = DockStyle.Fill;
            validarPermisos();
            lblUsuario.Text = usuario;
            Icono.Image = imagen;
        }

        private void validarPermisos()
        {
            DataTable dt = new DataTable();
            ProcesosPermisos procesosPermisos = new ProcesosPermisos();
            Permisos permisos = new Permisos();
            permisos.setIdUsuario(idUsuario);
            procesosPermisos.mostrarPermisos(ref dt, permisos);
            foreach (DataRow row in dt.Rows)
            {
                String modulo = Convert.ToString(row["Modulo"]);
                if (modulo == "Pre planilla".ToUpper())
                {
                    btnConsultas.Visible = true;
                }
                if (modulo == "Personal".ToUpper())
                {
                    btnPersonal.Visible = true;
                }
                if (modulo == "Registro".ToUpper())
                {
                    btnRegistro.Visible = true;
                }
                if (modulo == "Usuarios".ToUpper())
                {
                    btnUsuarios.Visible = true;
                }
                if (modulo == "Restaurar BD".ToUpper())
                {
                    btnRestaurar.Visible = true;
                }
                if (modulo == "Crear Backup".ToUpper())
                {
                    btnRespaldos.Visible = true;
                }
                if (modulo == "Estanciones".ToUpper())
                {
                    btnEstaciones.Visible = true;
                }
            }
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Panel27_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void BtnPersonal_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            ControlDePersonal personal = new ControlDePersonal();
            personal.Dock = DockStyle.Fill;
            panelGeneral.Controls.Add(panelBarra);
            panelGeneral.Controls.Add(personal);
            personal.imagen = Icono.Image;
            personal.idUser = idUsuario;
            personal.usuario = usuario;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {

            Boolean max = maximizar;

            if (max == true)
            {
                this.Size = new System.Drawing.Size(1113, 661);
                this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
                this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
                btnMaximizar.BackgroundImage = Properties.Resources.maximizar_50;
                maximizar = false;
            }
            if (max == false) {

                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                btnMaximizar.BackgroundImage = Properties.Resources.restaurar_ventana_50;
                maximizar = true;
            }

        }

        private void BtnMinimizar_Click_1(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void PanelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            this.Size = new System.Drawing.Size(1113, 661);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            maximizar = false;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            ControlDeAsistencias panelAsistencias = new ControlDeAsistencias();
            panelAsistencias.Dock = DockStyle.Fill;
            panelGeneral.Controls.Add(panelBarra);
            panelGeneral.Controls.Add(panelAsistencias);
            panelAsistencias.icono = Icono.Image;
            panelAsistencias.idUsuario = idUsuario;
            panelAsistencias.usuario = usuario;
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            ControlDeUsuarios panelUsuarios = new ControlDeUsuarios();

            panelUsuarios.imagen = Icono.Image;
            panelUsuarios.idUser = idUsuario;
            panelUsuarios.usuario = usuario;
            panelUsuarios.Dock = DockStyle.Fill;
            panelGeneral.Controls.Add(panelBarra);
            panelGeneral.Controls.Add(panelUsuarios);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Dispose();
            Login login = new Login();
            login.ShowDialog();
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            PrePlanilla prePlanilla = new PrePlanilla();
            prePlanilla.Dock = DockStyle.Fill;
            panelGeneral.Controls.Add(panelBarra);
            panelGeneral.Controls.Add(prePlanilla);
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            restaurarBD();
        }

        private void restaurarBD()
        {
            SqlConnection connection = null;
            try
            {
                dlg.InitialDirectory = "";
                dlg.Filter = "Backup " + ControlDeCopiasBD.bd + "|*.bak";
                dlg.FilterIndex = 2;
                dlg.Title = "Seleccionador de Copías De seguridad";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ruta = Path.GetFullPath(dlg.FileName);
                    DialogResult result = MessageBox.Show("Usted esta a punto de restaurar la Base de datos, asegurese de que el archivo.bak sea reciente " +
                                                          "de lo contrario podria perder información y no podr recuperarla, al menos que antes realize una " +
                                                          "copia de seguridad de los datos actuales.\n\n\t ¿Desea continuar?", "Restauración de base de datos?",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        connection = new SqlConnection("Server=" + servidor + ";database=master; integrated security=yes");
                        connection.Open();
                        string proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + ControlDeCopiasBD.bd + "' USE [master] ALTER DATABASE [" + ControlDeCopiasBD.bd + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + ControlDeCopiasBD.bd + "] RESTORE DATABASE " + ControlDeCopiasBD.bd + " FROM DISK = N'" + ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";
                        SqlCommand command = new SqlCommand(proceso, connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("La base de datos ha sido restaurada satisfactoriamente!", "Restauración de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        Application.Restart();
                    }
                }
            }
            catch (Exception)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                recuperarDatosAntePerdida();
            }
        }

        private void recuperarDatosAntePerdida()
        {
            servidor = "-";

            SqlConnection connection = new SqlConnection("Server=" + servidor + ";database=master; integrated security=yes");
            try
            {
                connection.Open();
                string proceso = "EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'" + ControlDeCopiasBD.bd + "' USE [master] ALTER DATABASE [" + ControlDeCopiasBD.bd + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE DROP DATABASE [" + ControlDeCopiasBD.bd + "] RESTORE DATABASE " + ControlDeCopiasBD.bd + " FROM DISK = N'" + ruta + "' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";
                SqlCommand command = new SqlCommand(proceso, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("La base de datos no se ha podido restablecer a un punto anterior", "Restauración de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                Application.Restart();
            }
            catch (Exception)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void BtnRespaldos_Click(object sender, EventArgs e)
        {
            panelGeneral.Controls.Clear();
            ControlDeCopiasBD controlDeCopiasBD = new ControlDeCopiasBD();
            controlDeCopiasBD.Dock = DockStyle.Fill;
            panelGeneral.Controls.Add(controlDeCopiasBD);
        }

        private void BtnEstaciones_Click(object sender, EventArgs e)
        {
            Dispose();
            SeleccionarServidor frm = new SeleccionarServidor();
            frm.ShowDialog();
        }
    }
}
