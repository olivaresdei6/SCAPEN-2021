using SCAPEN_2021.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SCAPEN_2021.Presentacion.AsistenteDeInstalacion
{
    public partial class ConexionRemota : Form
    {
        public ConexionRemota()
        {
            InitializeComponent();
        }
        bool maximizar = false;
        String cadena_de_conexion;
        String indicador_de_conexion;
        private Encriptacion aes = new Encriptacion();
        int id;

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

        private void BtnSalir_Click(object sender, EventArgs e)
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

        private void PanelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            this.Size = new System.Drawing.Size(1113, 661);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            maximizar = false;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Btnconectar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIp.Text))
            {
                conectarConLaPCprincipal();
            }
            else
            {
                MessageBox.Show("Error aL establecer la conexión con la PC principal porque na ha digitado la direccion IP", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }


        private void conectarConLaPCprincipal()
        {
            String ip = txtIp.Text;
            cadena_de_conexion = "Data Source =" + ip + ";Initial Catalog=SCAPEN;Integrated Security=False;User Id=scapen;Password=_@2001scapen2021_@9614";
            comprobar_conexion();
            if (indicador_de_conexion == "HAY CONEXION")
            {
                SavetoXML(aes.Encrypt(cadena_de_conexion, Decencriptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexion Correcta. Vuelve a Abrir el Sistema", "Conexion Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
        }
        public void SavetoXML(object dbcnString)
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
        private void comprobar_conexion()
        {
            try
            {
                SqlConnection conexionManual = new SqlConnection(cadena_de_conexion);
                conexionManual.Open();
                SqlCommand da = new SqlCommand("Select * from TblUsuarios", conexionManual);
                id = Convert.ToInt32(da.ExecuteScalar());
                indicador_de_conexion = "HAY CONEXION";
            }
            catch (Exception)
            {
                indicador_de_conexion = "NO HAY CONEXION";

            }
        }

    }
}
