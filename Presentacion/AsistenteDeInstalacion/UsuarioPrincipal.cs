using SCAPEN_2021.Datos;
using SCAPEN_2021.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SCAPEN_2021.Presentacion.AsistenteDeInstalacion
{
    public partial class UsuarioPrincipal : Form
    {
        int idUsuario;
        public UsuarioPrincipal()
        {
            InitializeComponent();
        }
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Length ==6 && txtConfirmarPass.Text.Length==6)
            {
                if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtApellidos.Text) &&
               !string.IsNullOrEmpty(txtIdentificacion.Text) && !string.IsNullOrEmpty(txtUsuario.Text) &&
               !string.IsNullOrEmpty(txtContraseña.Text) && !String.IsNullOrEmpty(txtConfirmarPass.Text))
                {
                    if (txtContraseña.Text == txtConfirmarPass.Text)
                    {
                        insertarUsuarioPorDefecto();
                    }
                    else
                    {
                        labelPass.Text = "Las contraseñas no coinciden";
                    }
                }
                else
                {
                    MessageBox.Show("Todos los campos deben ser diligenciados para completar el registro", "Llenar campos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                labelPass.Text = "La contraseña debe tener 6 numeros";
            }
        }

        private void TxtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtContraseña.Text.Length <= 5)
            {
                if (Char.IsDigit(e.KeyChar) == true || Char.IsControl(e.KeyChar) == true)
                {

                    e.Handled = false;
                }else
                {
                    e.Handled = true;
                }
            }            
            else
            {
                if (char.IsControl(e.KeyChar) == true)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtConfirmarPass_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtConfirmarPass.Text.Length <= 5)
            {
                if (Char.IsDigit(e.KeyChar) == true || Char.IsControl(e.KeyChar) == true)
                {

                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (char.IsControl(e.KeyChar) == true)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            
        }

        private void TxtConfirmarPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContraseña.Text) && !String.IsNullOrEmpty(txtConfirmarPass.Text))
            {
                {
                    if (txtContraseña.Text != txtConfirmarPass.Text)
                    {
                        labelPass.Text = "Las contraseñas no coinciden";
                    }
                    else
                    {
                        labelPass.Text = "";
                    }
                }
            }
    }

    private void insertarUsuarioPorDefecto()
        {
            MemoryStream ms = new MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            Usuario admin = new Usuario(txtNombres.Text.ToUpper(), txtApellidos.Text.ToUpper(), txtIdentificacion.Text.ToUpper(), txtUsuario.Text, txtConfirmarPass.Text, ms.GetBuffer());
            if (new ProcesosUsuarios().insertarUsuarios(admin)==true)
            {
                InsertarCopiasBD();
                insertarModulos();
                new ProcesosUsuarios().obtenerIdUsuario(ref idUsuario, txtUsuario.Text);
                insertarPermisos();
            }

        }

        private void InsertarCopiasBD()
        {
            ProcesosCopiasBD copiasBD = new ProcesosCopiasBD();
            copiasBD.InsertarCopiasBD();
        }

        private void insertarPermisos()
        {
            DataTable dt = new DataTable();
            ProcesosModulos procesosModulos = new ProcesosModulos();
            procesosModulos.mostrarModulos(ref dt);
            foreach (DataRow row in dt.Rows)
            {
                int idModulo = Convert.ToInt32(row["idModulo"]);
                Permisos permisos = new Permisos();
                permisos.setIdModulo(idModulo);
                permisos.setIdUsuario(idUsuario);
                ProcesosPermisos procesosPermisos = new ProcesosPermisos();

                if (procesosPermisos.insertarPermisos(permisos)==true)
                {
                    
                }
            }
            MessageBox.Show("¡Listo! Recuerde que para iniciar seción debe ingresar con su usuario: " + txtUsuario.Text + " y su contraseña: " + txtConfirmarPass.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Dispose();
            new Login().ShowDialog();
        }

        private void insertarModulos()
        {
            Modulos modulos = new Modulos();
            List<String> mod = new List<String>() { "Pre planilla", "Personal", "Registro", "Usuarios", "Restaurar BD", "Crear Backup", "Estanciones" };
            foreach (String modulo in mod)
            {
                modulos.setModulo(modulo.ToUpper());
                new ProcesosModulos().insertarModulos(modulos);
            }
        }

        private void UsuarioPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
