using SCAPEN_2021.Presentacion;
using SCAPEN_2021.Presentacion.AsistenteDeInstalacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SCAPEN_2021.AsistenteDeInstalacion
{
    public partial class SeleccionarServidor : Form
    {
        public SeleccionarServidor()
        {
            InitializeComponent();
        }
        public Image imagen;
        public String usuario;
        public int idUser;
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

        private void BtnPrincipal_Click(object sender, EventArgs e)
        {
            Dispose();
            InstalacionBD frm = new InstalacionBD();
            frm.ShowDialog();
        }

        private void BtnRemoto_Click(object sender, EventArgs e)
        {
            Dispose();
            ConexionRemota frm = new ConexionRemota();
            frm.ShowDialog();
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            MenuPrincipal frm = new MenuPrincipal();
            frm.imagen = imagen;
            frm.idUsuario = idUser;
            frm.usuario = usuario;
            this.ParentForm.Visible = false;
            frm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
