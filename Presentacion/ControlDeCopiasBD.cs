using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCAPEN_2021.Datos;
using System.Threading;
using System.Data.SqlClient;
using SCAPEN_2021.Logica;

namespace SCAPEN_2021.Presentacion
{
    public partial class ControlDeCopiasBD : UserControl
    {
        String ruta;
        public static  String txtSoftware = "SCAPEN2021";
        public static  String bd = "SCAPEN";
        private Thread hilo;
        private bool procesoFinalizado = false;
        public ControlDeCopiasBD()
        {
            InitializeComponent();
        }

        private void ControlDeCopiasBD_Load(object sender, EventArgs e)
        {
            mostrarRuta();
        }

        private void mostrarRuta()
        {
            ProcesosCopiasBD copiasBD = new ProcesosCopiasBD();
            copiasBD.MostrarRuta(ref ruta);
            txtRuta.Text = ruta;
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            generarCopia();
        }

        private void generarCopia()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRuta.Text))
                {
                    hilo = new Thread(new ThreadStart(ejecutarProceso));
                    hilo.Start();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Por favor seleccione la ruta donde desea almacenar las Copias De Seguridad", "Seleccione una ruta en su pc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRuta.Focus();
                }
            }
            catch (Exception)
            {
                               
            }
        }

        private void ejecutarProceso()
        {
            string miCarpeta = "Copia_de_Seguridad_de_" + txtSoftware;
            if (!System.IO.Directory.Exists(txtRuta.Text+miCarpeta))
            {
                System.IO.Directory.CreateDirectory(txtRuta.Text+miCarpeta);
            }
            string rutaCompleta = txtRuta.Text + miCarpeta;
            string subcarpeta = rutaCompleta + @"\Respaldo_creado_el_"+DateTime.Now.Day+"_"+DateTime.Now.Month+"_"+DateTime.Now.Year+"_"+DateTime.Now.Hour+"_"+DateTime.Now.Minute;
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(rutaCompleta, subcarpeta));
                string v_nombre_respaldo = bd + ".bak";
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand command = new SqlCommand("BACKUP DATABASE " + bd + " TO DISK = '" + subcarpeta + @"\" + v_nombre_respaldo + "'", ConexionMaestra.establecerConexion);
                command.ExecuteNonQuery();
                procesoFinalizado = true;
            }
            catch (Exception)
            {
                if (txtRuta.Text == "-")
                {
                    MessageBox.Show("Por favor seleccione la ruta del sistema donde desea almacenar la copia de seguridad. Para ello de click en el icono del folder", "Directorio no valido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("La copia de seguridad se debe guardar en una particion o disco que no sea donde se almacena el sistema operativo, ya que si este falla los datos se perderan", "Directorio o ruta no valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                procesoFinalizado = false;
            }
        }

        private void PbxAbrirCarpeta_Click(object sender, EventArgs e)
        {
            obtenerRuta();
        }

        private void obtenerRuta()
        {
            if (folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if(procesoFinalizado == true)
            {
                timer1.Stop();
                editarRespaldos();
            }
        }

        private void editarRespaldos()
        {
            CopiasBD copiasBD = new CopiasBD();
            ProcesosCopiasBD procesos = new ProcesosCopiasBD();
            copiasBD.ruta = txtRuta.Text;
            if (procesos.EditarCopiasBD(copiasBD) == true)
            {
                MessageBox.Show("Copia de seguridad de la base de datos generada satisfactoriamente", "Generación de copias de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
