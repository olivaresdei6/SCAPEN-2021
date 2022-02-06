using SCAPEN_2021.AsistenteDeInstalacion;
using SCAPEN_2021.Datos;
using SCAPEN_2021.Presentacion;
using SCAPEN_2021.Presentacion.AsistenteDeInstalacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SCAPEN_2021.Presentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            // Set to no text.
            txtPassword.Text = "";
            // The password character is an asterisk.
            txtPassword.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            txtPassword.MaxLength = 6;
        }
        bool maximizar = false;
        String usuario;
        int IdUsuario;
        int contador;
        String indicador;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
        private void PanelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            this.Size = new System.Drawing.Size(1113, 661);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            maximizar = false;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

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

        private void Log_Load(object sender, EventArgs e)
        {
            validarConexion();
        }

        private void mostrarUsuarios()
        {
            DataTable dt = new DataTable();
            new ProcesosUsuarios().mostrarTodosLosUsuarios(ref dt);
            contador = dt.Rows.Count;
        }

        private void validarConexion()
        {
            new ProcesosUsuarios().verificarUsuarios(ref indicador);
            if (indicador == "Correcto")
            {                
                mostrarUsuarios();
                if (contador==0)
                {
                    Dispose();
                    new UsuarioPrincipal().ShowDialog();
                }
                else
                {
                    dibujarUsuarios();
                }
            }
            else
            {
                Dispose();
                SeleccionarServidor frm = new SeleccionarServidor();
                frm.ShowDialog();
            }
        }

        private void dibujarUsuarios()
        {
            try
            {
                panelUsuarios.Visible = true;
                panelUsuarios.Dock = DockStyle.Fill;
                panelUsuarios.BringToFront();
                DataTable dt = new DataTable();
                new ProcesosUsuarios().mostrarTodosLosUsuarios(ref dt);
                foreach (DataRow rdr in dt.Rows)
                {
                    Label lblUser = new Label();
                    Panel panelIcon = new Panel();
                    PictureBox icon = new PictureBox();

                    lblUser.Text = rdr["Usuario"].ToString();
                    lblUser.Name = rdr["Usuario"].ToString();
                    lblUser.Size = new Size(123, 38);
                    lblUser.Font = new Font("Consolas", 13, FontStyle.Bold);
                    lblUser.BackColor = Color.Transparent;
                    lblUser.ForeColor = Color.White;
                    lblUser.Dock = DockStyle.Bottom;
                    lblUser.TextAlign = ContentAlignment.MiddleCenter;
                    lblUser.Cursor = Cursors.Hand;

                    panelIcon.Size = new Size(123, 125);
                    panelIcon.BorderStyle = BorderStyle.None;
                    panelIcon.BackColor = Color.FromArgb(29, 29, 29);

                    icon.Size = new Size(123, 87);
                    icon.Dock = DockStyle.Top;
                    icon.BackgroundImage = null;
                    byte[] bi = (Byte[])rdr["Icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    icon.Image = Image.FromStream(ms);
                    icon.SizeMode = PictureBoxSizeMode.Zoom;
                    icon.Tag = rdr["Usuario"].ToString();
                    icon.Cursor = Cursors.Hand;

                    panelIcon.Controls.Add(lblUser);
                    panelIcon.Controls.Add(icon);
                    lblUser.BringToFront();

                    flpImagenes.Controls.Add(panelIcon);
                    icon.Click += eventoIcon; ;
                }
            }
            catch (Exception)
            {


            }
        }

        private void eventoIcon(object sender, EventArgs e)
        {
            usuario = Convert.ToString((((PictureBox)sender).Tag));
            Icono.Image = ((PictureBox)sender).Image;
            mostrarPanelPass();

        }
        private void mostrarPanelPass()
        {
            panelIngresoDeContraseña.Visible = true;
            panelIngresoDeContraseña.Location = new Point((Width - panelIngresoDeContraseña.Width) / 2, (Height - panelIngresoDeContraseña.Height) / 2);
            panelUsuarios.Visible = false;
        }

        private void validarUsuarios()
        {
            new ProcesosUsuarios().validarUsuarios(txtPassword.Text, usuario, ref IdUsuario);
            if (IdUsuario > 0)
            {
                Dispose();
                MenuPrincipal frm = new MenuPrincipal();
                frm.idUsuario = IdUsuario;
                frm.usuario = usuario;
                frm.imagen = Icono.Image;
                frm.ShowDialog();

            }
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            validarUsuarios();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Contraseña erronea ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "1";
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "2";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "3";
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "4";
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "5";
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "6";
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "7";
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "8";
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "9";
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 6)
            {
                txtPassword.Text += "0";
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            int contador = 0;
            contador = txtPassword.Text.Count();
            if (contador>0)
            {
                txtPassword.Text = txtPassword.Text.Substring(0, txtPassword.Text.Count() - 1);
            }
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            Dispose();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
