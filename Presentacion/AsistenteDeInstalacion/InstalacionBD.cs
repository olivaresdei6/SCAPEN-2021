using SCAPEN_2021.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SCAPEN_2021.Presentacion.AsistenteDeInstalacion
{
    public partial class InstalacionBD : Form
    {
        String nombre_del_equipo_usuario;
        private Encriptacion aes = new Encriptacion();
        string rutaCompleta;
        string nombreDelEquipo;
        public static int milisegundos;
        public static int segundos;
        public static int milisegundo1;
        public static int segundos1;
        public InstalacionBD()
        {
            InitializeComponent();
        }
        private Encriptacion encriptacion = new Encriptacion();

        String ruta;
        bool maximizar = false;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
            if (max == false)
            {

                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                btnMaximizar.BackgroundImage = Properties.Resources.restaurar_ventana_50;
                maximizar = true;
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void InstalacionBD_Load(object sender, EventArgs e)
        {
            centrarPaneles();
            remplazar();
            comprobarSiHayServidorInstaladoEnSQLServer();
            conectar();
        }

        private void conectar()
        {
            if (btnInstalarServidor.Visible==true)
            {
                comprobarSiHayServidorInstaladoEnSQLNormal();
            }
        }

        private void comprobarSiHayServidorInstaladoEnSQLNormal()
        {
            txtservidor.Text = ".";
            ejecutarScriptEliminarBaseComprobacionDeInicio();
            ejecutarScriptCrearBaseComprobacionDeInicio();
        }

        private void centrarPaneles()
        {
            PanelServ.Location = new Point((Width - panelInformacion.Width) / 2, (Height - panelInformacion.Height) / 2);
            nombre_del_equipo_usuario = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Cursor = Cursors.WaitCursor;
            PanelServ.Visible = false;
            PanelServ.Dock = DockStyle.None;
        }

        private void remplazar()
        {
            txtCrear_procedimientos.Text = txtCrear_procedimientos.Text.Replace("ORUS369", TXTbasededatos.Text);

            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("BASEADACURSO", TXTbasededatos.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("ada369", txtusuario.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("BASEADA", TXTbasededatos.Text);
            txtCrearUsuarioDb.Text = txtCrearUsuarioDb.Text.Replace("softwarereal", txtContraseña.Text);

            txtCrear_procedimientos.Text = txtCrear_procedimientos.Text + Environment.NewLine + txtCrearUsuarioDb.Text;

        }

        private void comprobarSiHayServidorInstaladoEnSQLServer()
        {
            txtservidor.Text = @".\" + lblnombredeservicio.Text;
            ejecutarScriptEliminarBaseComprobacionDeInicio();
            ejecutarScriptCrearBaseComprobacionDeInicio();
        }

        private void ejecutarScriptEliminarBaseComprobacionDeInicio()
        {
            String str;
            SqlConnection myConn = new SqlConnection("Data source="+txtservidor.Text+";Initial Catalog=master; Integrated Security=true");
            str = txtEliminarBase.Text;
            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
        }

        private void ejecutarScriptCrearBaseComprobacionDeInicio()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=" + txtservidor.Text + "; database=master; integrated security=yes");
            String s = "CREATE DATABASE " + TXTbasededatos.Text;
            SqlCommand cmd = new SqlCommand(s, sqlConnection);
            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                guardarEnXML(encriptacion.Encrypt("Data Source="+txtservidor.Text+";Initial Catalog="+TXTbasededatos.Text+";Integrated security = true;", Decencriptacion.appPwdUnique, 256));
                ejecutarScript();
                PanelServ.Visible = true;
                PanelServ.Dock = DockStyle.Fill;
                Label1.Text = "Instancia Encontrada...\nNo cierre esta ventana, se cerrara automaticamente cuando este todo listo";
                panelTiempo.Visible = false;
                timer4.Start();
            }
            catch (Exception)
            {

                PanelServ.Visible = false;

                PanelServ.Dock = DockStyle.None;
                btnInstalarServidor.Visible = true;
                panelTiempo.Visible = true;
                lblbuscador_de_servidores.Text = "De click a Instalar Servidor, luego de clic en SI cuando se le pida, luego precione aceptar y espere por favor";
                
            }
        }

        private void guardarEnXML(Object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        private void ejecutarScript()
        {
            ruta = Path.Combine(Directory.GetCurrentDirectory(), txtnombre_scrypt.Text + ".txt");
            StreamWriter sw = null;
            try
            {
                if (File.Exists(ruta) == false)
                {
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrear_procedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }
                else if (File.Exists(ruta)==true)
                {
                    File.Delete(ruta);
                    sw = File.CreateText(ruta);
                    sw.WriteLine(txtCrear_procedimientos.Text);
                    sw.Flush();
                    sw.Close();
                }


                

                Process process = new Process();
                process.StartInfo.FileName="sqlcmd";
                process.StartInfo.Arguments = " -S " + txtservidor.Text + " -i " + txtnombre_scrypt.Text + ".txt";
                process.Start();

            }
            catch (Exception)
            {
            }
        }


        private void Timer4_Tick_1(object sender, EventArgs e)
        {
            timer2.Stop();
            timer3.Stop();
            milisegundos += 1;
            mil3.Text = milisegundos.ToString();
            if (milisegundos == 60)
            {
                segundos += 1;
                seg3.Text = segundos.ToString();
                milisegundos = 0;
            }
            if (segundos == 15)
            {
                timer4.Stop();
                try
                {
                    File.Delete(ruta);
                }
                catch (Exception)
                {

                }
                Dispose();
                Application.Restart();
            }
        }

        private void BtnInstalarServidor_Click(object sender, EventArgs e)
        {
            try
            {
                txtArgumentosini.Text = txtArgumentosini.Text.Replace("PRUEBAFINAL22", lblnombredeservicio.Text);
                timerCRARINI.Start();
                instalarSQL();
                timer2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void instalarSQL()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "SQLEXPR_x64_ENU.exe";
                process.StartInfo.Arguments = "/ConfigurationFile=ConfigurationFile.ini /ACTION=Install /IACCEPTSQLSERVERLICENSETERMS /SECURITYMODE=SQL /SAPWD=" + txtContraseña.Text + " /SQLSYSADMINACCOUNTS=" + nombre_del_equipo_usuario;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
                PanelServ.Visible = true;
                PanelServ.Dock = DockStyle.Fill;

            }
            catch (Exception)
            {
            }
        }

        private void TimerCRARINI_Tick(object sender, EventArgs e)
        {
            string ruta;
            StreamWriter writer;
            ruta = Path.Combine(Directory.GetCurrentDirectory(), "ConfigurationFile.ini");
            ruta = ruta.Replace("ConfigurationFile.ini", @"SQLEXPR_x64_ENU\ConfigurationFile.ini");
            if (File.Exists(ruta)==true)
            {
                timerCRARINI.Stop();
            }
            else
            {
                try
                {
                    writer = File.CreateText(ruta);
                    writer.WriteLine(txtArgumentosini.Text);
                    writer.Flush();
                    writer.Close();
                    timerCRARINI.Stop();
                }
                catch (Exception)
                {

                }
            }
        }
        public static int minutos1;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            milisegundo1 += 1;
            milise.Text = Convert.ToString(milisegundo1);
            if (milisegundos == 60)
            {
                segundos1 += 1;
                seg.Text = Convert.ToString(segundos1);
                milisegundo1 = 0;
            }
            if (segundos1==60)
            {
                minutos1 += 1;
                min.Text = Convert.ToString(minutos1);
                segundos1 = 0;
            }
            if (minutos1 == 6)
            {
                timer2.Stop();
                ejecutarScriptEliminarBaseComprobacionDeInicio();
                ejecutarScriptCrearBaseComprobacionDeInicio();
                timer3.Start();
            }
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            milisegundo1 += 1;
            milise.Text = Convert.ToString(milisegundo1);
            if (milisegundos == 60)
            {
                segundos1 += 1;
                seg.Text = Convert.ToString(segundos1);
                milisegundo1 = 0;
            }
            if (segundos1 == 60)
            {
                minutos1 += 1;
                min.Text = Convert.ToString(minutos1);
                segundos1 = 0;
            }
            if (minutos1 == 1)
            {
                ejecutarScriptEliminarBaseComprobacionDeInicio();
                ejecutarScriptCrearBaseComprobacionDeInicio();
            }
        }
    }
}
