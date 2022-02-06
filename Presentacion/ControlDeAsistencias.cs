using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using SCAPEN_2021.Datos;
using SCAPEN_2021.Logica;

namespace SCAPEN_2021.Presentacion
{
    public partial class ControlDeAsistencias : UserControl
    {
        Boolean maximizar;
        String identificacion;
        int idPersonal;
        int contador;
        public int idUsuario;
        public string usuario;
        public Image icono;
        DateTime fechaDeRegistro;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        [DllImport("Gdi32.dll", EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
        public ControlDeAsistencias()
        {

            InitializeComponent();
            this.AutoScroll = true;
        }



        private void PanelBarra_MouseDown(object sender, MouseEventArgs e)
        {
            this.Size = new System.Drawing.Size(1184, 699);
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;
            maximizar = false;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void RegistroDeAsistencias_Load(object sender, EventArgs e)
        {

        }

        private void buscarIdentificacion()
        {
            DataTable dtb = new DataTable();
            Procesos manipularBD = new Procesos();
            manipularBD.BuscarPersonalPorIdentificacion(ref dtb, txtIdentificacion.Text);
            if (dtb.Rows.Count > 0)
            {
                identificacion = dtb.Rows[0]["Identificacion"].ToString();
                idPersonal = Convert.ToInt32(dtb.Rows[0]["Id_Personal"].ToString());
                lblNombre.Text = dtb.Rows[0]["Nombres"].ToString() + " " + dtb.Rows[0]["Apellidos"].ToString();
            }
            else
            {
                lblAviso.Text = "";
                lblNombre.Text = "";
            }
        }
        private void buscarPersonalPorIdentificacion()
        {
            buscarIdentificacion();
            DataTable dt = new DataTable();
            ProcesosAsistencia maipularBD = new ProcesosAsistencia();
            maipularBD.BuscarAsistenciaPorId(ref dt, idPersonal);
            if (identificacion == txtIdentificacion.Text)
            {
                contador = dt.Rows.Count;
                if (contador == 0)
                {
                    DialogResult result = MessageBox.Show("¿Desea agregar una observación?", "Observación", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                    if (result == DialogResult.Yes)
                    {
                        panelObservacion.Visible = true;
                        panelObservacion.Location = new Point(panelRegistro.Location.X, panelRegistro.Location.Y);
                        panelObservacion.Size = new Size(panelRegistro.Width, panelRegistro.Height);
                        panelObservacion.BringToFront();
                        rchTxtObserbacion.Clear();
                        rchTxtObserbacion.Focus();

                    }
                    else
                    {
                        insertarAsistencias();

                    }
                }
                else
                {
                    fechaDeRegistro = Convert.ToDateTime(dt.Rows[0]["Fecha_entrada"]);
                    confirmarSalida();
                }
            }
        }
        private void insertarAsistencias()
        {
            Asistencia asistencia = new Asistencia(idPersonal, DateTime.Now, DateTime.Now, "ENTRADA", 0, rchTxtObserbacion.Text);
            if (new ProcesosAsistencia().insertarAsistencias(asistencia) == true)
            {
                lblAviso.Text = "Asistencia registrada exitosamente";
                txtIdentificacion.Clear();
                panelObservacion.Visible = false;
                txtIdentificacion.Focus();
                lblAviso.Text = "¡Asistencia registrada exitosamente!";
            }
            else
            {
                MessageBox.Show("Intentelo nuevamente, ha ocurrido un error");
            }
        }
        private void confirmarSalida()
        {
            double hora = Bases.DateDiff(Bases.DateInterval.Hour, fechaDeRegistro, DateTime.Now);
            Asistencia asistencia = new Asistencia(idPersonal, DateTime.Now, DateTime.Now, "SALIDA", hora, rchTxtObserbacion.Text);
            if (new ProcesosAsistencia().ConfirmarSalida(asistencia) == true)
            {
                lblAviso.Text = "Salida registrada";
                txtIdentificacion.Clear();
                txtIdentificacion.Focus();
            }
        }


        private void TimerHora_Tick_1(object sender, EventArgs e)
        {
            lblHora2.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha2.Text = DateTime.Now.ToShortDateString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void TbnIniciarSesion_Click(object sender, EventArgs e)
        {
            panelAsistencias.Controls.Clear();
            panelAsistencias.Controls.Add(new Login());
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            buscarIdentificacion();
            if (identificacion == txtIdentificacion.Text)
            {
                buscarPersonalPorIdentificacion();
            }
        }

        private void BtnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rchTxtObserbacion.Text))
            {
                insertarAsistencias();
            }
            else
            {
                MessageBox.Show("Debe ingresar una observación");
            }
        }

        private void BtnRegresar_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("La asistencia no se ha registrado, intentelo nuevamente");
            panelObservacion.Visible = false;
            panelRegistro.Visible = true;
            panelRegistro.Location = new Point(panelObservacion.Location.X, panelObservacion.Location.Y);
            panelRegistro.Size = new Size(panelObservacion.Width, panelObservacion.Height);
            panelRegistro.BringToFront();
            txtIdentificacion.Clear();
            txtIdentificacion.Focus();
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            
            MenuPrincipal frm = new MenuPrincipal();
            frm.imagen = icono;
            frm.idUsuario = idUsuario;
            frm.usuario = usuario;
            this.ParentForm.Visible = false;
            frm.ShowDialog();
        }

        private void TxtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtIdentificacion_KeyUp(object sender, KeyEventArgs e)
        {
            buscarIdentificacion();
        }
    }
}
