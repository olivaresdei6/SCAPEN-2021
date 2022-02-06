using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCAPEN_2021.Datos;
using SCAPEN_2021.Logica;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SCAPEN_2021.Presentacion
{
    public partial class ControlDePersonal : UserControl
    {
        public Image imagen;
        public String usuario;
        public int idUser;
        int idCargo = 0;
        int desde = 1;
        int hasta = 10;
        int contador = 0;
        int idPersonal;
        int itemsPorPagina = 10;
        string estado;
        int totalPaginas = 0;
        Boolean modificar;
        public ControlDePersonal()
        {
            InitializeComponent();
        }
        public void centraX(Control padre, Control hijo)
        {
            int x = 0;
            x = (padre.Width / 2) - (hijo.Width / 2);
            hijo.Location = new System.Drawing.Point(x, hijo.Location.Y);
        }

        private void TxtCargo_TextChanged(object sender, EventArgs e)
        {
            buscarCargos();

        }

        private void BtnAgregarCargo_Click(object sender, EventArgs e)
        {
            panelAgregarCargos.Visible = true;
            panelAgregarCargos.Dock = DockStyle.Fill;
            panelAgregarCargos.BringToFront();
            btnGuardarCambiosCargos.Visible = false;
            lblGuardarCambiosCargos.Visible = false;
            btnGuardarCargo.Visible = true;
            lblGuardarCargo.Visible = true;
            txtCargo2.Clear();
            txtSueldoHora2.Clear();
        }

        private void TxtSueldoHora2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Bases.Decimales(txtSueldoHora2, e);
        }
        private void ControlDePersonal_Load(object sender, EventArgs e)
        {
            String[] paises = new string[] {"Afganistán","Albania","Alemania","Andorra","Angola","Antigua y Barbuda",
                               "Arabia Saudita","Argelia","Argentina","Armenia","Australia","Austria","Azerbaiyán","Bahamas",
                               "Bangladés","Barbados","Baréin","Bélgica","Belice","Benín","Bielorrusia","Birmania / Myanmar",
                               "Bolivia","Bosnia y Herzegovina","Botsuana","Brasil","Brunéi","Bulgaria","Burkina","Burundi",
                               "Bután","Cabo Verde","Camboya","Camerún", "Canadá", "Catar","Chad","Chile","China","Chipre",
                               "Ciudad del Vaticano","Colombia","Comoras","Corea del Norte","Corea del Sur","Costa de Marfil",
                               "Costa Rica","Croacia","Cuba","Dinamarca","Dominica","Ecuador","Egipto","El Salvador",
                                "Emiratos Árabes Unidos","Eritrea.","Eslovaquia","Eslovenia.","España","Estados Unidos","Estonia.",
                                "Etiopía","Filipinas","Finlandia","Fiyi","Francia","Gabón","Gambia","Georgia","Ghana","Granada",
                                "Grecia","Guatemala","Guinea Ecuatorial","Guinea","Guinea-Bisáu","Guyana","Haití","Honduras",
                                "Hungría","India","Indonesia","Irak","Irán","Irlanda","Islandia","Islas Marshall","Islas Salomón",
                                "Israel","Italia","Jamaica","Japón","Jordania","Kazajistán","Kenia","Kirguistán","Kiribati",
                                "Kuwait","Laos","Lesoto","Letonia","Líbano","Liberia","Libia","Liechtenstein","Lituania",
                                "Luxemburgo","Macedonia del Norte","Madagascar","Malasia","Malaui","Maldivas","Malí o Mali",
                                "Malta","Marruecos","Mauricio","Mauritania","México","Micronesia","Moldavia","Mónaco",
                                "Mongolia","Montenegro","Mozambique","Namibia","Nauru","Nepal","Nicaragua","Níger","Nigeria",
                                "Noruega","Nueva Zelanda","Omán","Pakistán","Palaos","Panamá","Papúa Nueva Guinea","Paraguay",
                                "Perú","Polonia","Portugal","Reino Unido","República Centroafricana","República Checa",
                                "República del Congo","República Democrática del Congo","República Dominicana","Ruanda",
                                "Rumanía","Rusia","Samoa","San Cristóbal y Nieves","San Marino","San Vicente y las Granadinas",
                                "Santa Lucía","Santo Tomé y Príncipe","Senegal","Serbia","Seychelles","Sierra Leona",
                                "Singapur","Siria","Somalia","Sri Lanka","Suazilandia","Sudáfrica","Sudán del Sur",
                                "Sudán","Suecia","Suiza","Surinam","Tailandia","Tanzania","Tayikistán","Timor Oriental",
                                "Togo","Tonga","Trinidad y Tobago","Túnez","Turkmenistán","Turquía","Tuvalu","Ucrania",
                                "Uganda","Uruguay","Uzbekistán","Vanuatu","Venezuela","Vietnam","Yemen","Yibuti","Zambia","Zimbabue"};
            for (int i = 0; i < paises.Length; i++)
            {
                cmbxPais.Items.Add(paises[i].ToUpper());
                if (paises[i].Equals("Colombia"))
                {
                    cmbxPais.Text = "Colombia";
                }
            }
            mostrarPersonal();
            reiniciarPaginado();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            panelAgregarCargos.Visible = false;
            panelCargo2.Visible = false;
            panelPaginado.Visible = false;
            panelRegistro.Visible = true;
            panelRegistro.Dock = DockStyle.Fill;
            panelGuardar.Visible = false;
            limpiarCamposDeRegistro();
            panelCargo2.Visible = true;
            LocalizarDtvCargos();
            pbxBusqueda.Visible = false;
            txtBuscador.Visible = false;
            panelBuscador.Visible = false;
            panelRegistro.Dock = DockStyle.Fill;
            panelBusqueda.Visible = false;
            modificar = false;

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtNombres.Text) &&
                !string.IsNullOrEmpty(txtApellidos.Text) && !string.IsNullOrEmpty(txtCargo.Text) && idCargo > 0)
            {
                InsertarPersonal();
            }
        }

        private void BtnGuardarCargo_Click(object sender, EventArgs e)
        {
            insertarCargos();
            txtCargo.Text = txtCargo2.Text;
            buscarCargos();
        }

        private void BtnVolverARegistro_Click(object sender, EventArgs e)
        {
            panelAgregarCargos.Visible = false;
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            panelBusqueda.Visible = true;
            pbxBusqueda.Visible = true;
            txtBuscador.Visible = true;
            panelBuscador.Visible = true;
            panelPaginado.Visible = true;
            reiniciarPaginado();
            mostrarPersonal();
        }

        private void BtnGuardarCambiosCargos_Click(object sender, EventArgs e)
        {
            txtSueldoHora2.Text = txtSueldoHora2.Text.Replace(".", "");
            txtSueldoHora2.Text = txtSueldoHora2.Text.Replace(",", "");
            Cargo modificarCargo = new Cargo(idCargo, float.Parse(txtSueldoHora2.Text), txtCargo2.Text.ToUpper());
            ProcesosCargo manipularBD = new ProcesosCargo();
            if (manipularBD.editarCargo(modificarCargo) == true)
            {
                txtCargo2.Clear();
                buscarCargos();
                panelAgregarCargos.Visible = false;
                MessageBox.Show("La modificación del cargo se ha realizado exitosamente");
            }
        }

        private void DataPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataPersonal.Columns["Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("Solo se cambiara el estado para que pueda no acceder, ¿Desea continuar?", "Eliminar Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    eliminarPersonal();
                }
            }
            if (e.ColumnIndex == dataPersonal.Columns["Editar"].Index)
            {
                obtenerDatos();
            }
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtNombres.Text) &&
                !string.IsNullOrEmpty(txtApellidos.Text) && !string.IsNullOrEmpty(txtCargo.Text) && idCargo > 0)
            {
                editarPersonal();
                btnGuardarCambios.Visible = false;
                lblGuardarCambios.Visible = false;
                btnGuardar.Visible = true;
                lblGuardar.Visible = true;
                panelBusqueda.Visible = true;
            }
        }

        private void BtnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            desde += 10;
            hasta += 10;
            mostrarPersonal();
            contarPersonal();
            if (contador > hasta)
            {
                panelPagSiguiente.Visible = true;
                panelPagAnterior.Visible = true;
            }
            else
            {
                panelPagSiguiente.Visible = false;
                panelPagAnterior.Visible = true;
            }
            paginar();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            diseñarTablaPersonal();
            timer1.Stop();
        }

        private void DataListadoCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListadoCargo.Columns["EditarC"].Index)
            {
                obtenerCargoAEditar();
            }
            if (e.ColumnIndex == dataListadoCargo.Columns[2].Index)
            {
                obtenerCargo();
            }
        }

        private void BtnPaginaAnterior_Click(object sender, EventArgs e)
        {
            desde -= 10;
            hasta -= 10;
            mostrarPersonal();
            contarPersonal();
            if (contador > hasta)
            {
                panelPagSiguiente.Visible = true;
                panelPagAnterior.Visible = true;
            }
            else
            {
                panelPagSiguiente.Visible = false;
                panelPagAnterior.Visible = true;
            }
            if (desde == 1)
            {
                reiniciarPaginado();
            }
            paginar();

        }
        private void BtnUltimaPagina_Click(object sender, EventArgs e)
        {
            ultimaPagina();
        }
        private void ultimaPagina()
        {
            hasta = totalPaginas * itemsPorPagina;
            desde = hasta - 9;
            mostrarPersonal();
            contarPersonal();
            if (contador > hasta)
            {
                panelPagSiguiente.Visible = true;
                panelPagAnterior.Visible = true;
            }
            else
            {
                panelPagSiguiente.Visible = false;
                panelPagAnterior.Visible = true;
            }
            paginar();
        }

        private void BtnPrimeraPagina_Click(object sender, EventArgs e)
        {
            reiniciarPaginado();
            mostrarPersonal();
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            buscarPersonal();
        }

        //Método para buscar personal
        private void buscarPersonal()
        {
            DataTable dt = new DataTable();
            Procesos manipularBD = new Procesos();
            manipularBD.BuscarPersonal(ref dt, desde, hasta, txtBuscador.Text);
            dataPersonal.DataSource = dt;
            diseñarTablaPersonal();
        }

        //Métodos para insertar Personal

        private void InsertarPersonal()
        {
            if (!string.IsNullOrEmpty(txtCargo.Text) && !string.IsNullOrEmpty(txtSueldo.Text))
            {
                string identificacion = txtIdentificacion.Text.ToUpper();
                string nombres = txtNombres.Text.ToUpper();
                string apellidos = txtApellidos.Text.ToUpper();
                string pais = Convert.ToString(cmbxPais.SelectedItem).ToUpper();
                txtSueldo.Text = txtSueldo.Text.Replace(",", "");
                txtSueldo.Text = txtSueldo.Text.Replace(".", "");
                float sueldo = float.Parse(txtSueldo.Text);
                txtSueldoHora2.Text = Convert.ToString(sueldo);
                Persona nuevaPersona = new Persona(0, identificacion, nombres, apellidos, 0, pais, idCargo, sueldo, "");
                Procesos manipularBD = new Procesos();
                if (manipularBD.InsertarPersonal(nuevaPersona) == true)
                {
                    reiniciarPaginado();
                    mostrarPersonal();
                    panelCargo.Visible = false;
                    panelRegistro.Visible = false;
                    panelBusqueda.Visible = true;
                    ultimaPagina();
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios. ", "Por favor digitar el cargo y el sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Métodos para Mostrar Personal

        private void mostrarPersonal()
        {
            DataTable dt = new DataTable();
            Procesos manipularBD = new Procesos();
            if (manipularBD.MostrarPersonal(ref dt, desde, hasta) == true)
            {
                dataPersonal.DataSource = dt;
                diseñarTablaPersonal();
                pbxBusqueda.Visible = true;
                txtBuscador.Visible = true;
                panelBuscador.Visible = true;
            }
        }

        //Personalizar Componentes gráficos

        private void diseñarTablaPersonal()
        {
            Bases.DiseñoDtv(ref dataPersonal);
            Bases.DiseñoDtvEliminar(ref dataPersonal);
            panelPaginado.Visible = true;
            dataPersonal.Columns[7].HeaderText = "Sueldo Hr";
            dataPersonal.Columns[2].HeaderText = "N°";
        }

        private void LocalizarDtvCargos()
        {
            panelCargo.Visible = true;
            dataListadoCargo.Location = new Point(txtSueldo.Location.X, txtSueldo.Location.Y+3);
            dataListadoCargo.Size = new Size(251, 236);
            dataListadoCargo.Visible = true;
            lblSueldoPorHora.Visible = false;
            panelGuardar.Visible = false;

        }

        private void limpiarCamposDeRegistro()
        {
            txtApellidos.Clear();
            txtBuscador.Clear();
            txtCargo.Clear();
            txtNombres.Clear();
            txtSueldo.Clear();
            txtIdentificacion.Clear();
            buscarCargos();
        }

        private void limpiarCamposDeCargo()
        {
            txtCargo2.Clear();
            txtSueldoHora2.Clear();
        }

        //Métodos para los cargos

        private void insertarCargos()
        {
            txtSueldoHora2.Text = txtSueldoHora2.Text.Replace(".", "");
            txtSueldoHora2.Text = txtSueldoHora2.Text.Replace(",", "");
            Cargo nuevoCargo = new Cargo(0, float.Parse(txtSueldoHora2.Text), txtCargo2.Text.ToUpper());
            ProcesosCargo manipularBD = new ProcesosCargo();
            if (manipularBD.insertarCargo(nuevoCargo) == true)
            {
                MessageBox.Show("Cargo registrado satisfactoriamente");
                panelAgregarCargos.Visible = false;
            }
        }

        private void buscarCargos()
        {
            DataTable dt = new DataTable();
            ProcesosCargo manipularCargosEnLaBD = new ProcesosCargo();
            manipularCargosEnLaBD.buscarCargos(ref dt, txtCargo.Text);
            if (dt.Rows.Count>0)
            {
                dataListadoCargo.DataSource = dt;
                Bases.DiseñoDtv(ref dataListadoCargo);
                dataListadoCargo.Columns[3].HeaderText = "Saldo Por Hora";
                dataListadoCargo.Visible = true;
                lblSueldoPorHora.Visible = false;
                panelGuardar.Visible = false;
                dataListadoCargo.Columns[1].Visible = false;
                dataListadoCargo.Columns[3].Visible = false;
                foreach (DataGridViewRow row in dataListadoCargo.Rows)
                {
                    if (row.Cells[2].Value.ToString() == txtCargo.Text)
                    {
                        dataListadoCargo.Rows[row.Index].Selected = true;
                    }
                }
                idCargo = Convert.ToInt32(dataListadoCargo.SelectedCells[1].Value.ToString());
            }
            else
            {
                Bases.DiseñoDtv(ref dataListadoCargo);

            }
        }

        private void obtenerCargo()
        {
            idCargo = Convert.ToInt32(dataListadoCargo.SelectedCells[1].Value);
            txtCargo.Text = dataListadoCargo.SelectedCells[2].Value.ToString();
            string sueldo = dataListadoCargo.SelectedCells[3].Value.ToString();
            sueldo = sueldo.Replace("$", string.Empty);
            sueldo = sueldo.Replace(",", ".");
            txtSueldo.Text = sueldo;
            dataListadoCargo.Visible = false;
            lblSueldoPorHora.Visible = true;
            panelGuardar.Visible = true;
            if (modificar == true)
            {
                btnGuardarCambios.Visible = true;
                lblGuardarCambios.Visible = true;
                lblGuardar.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                btnGuardarCambios.Visible = false;
                lblGuardarCambios.Visible = false;
                lblGuardar.Visible = true;
                btnGuardar.Visible = true;
            }
            
        }

        //Métodos para el paginado

        private void reiniciarPaginado()
        {
            desde = 1;
            hasta = 10;
            contarPersonal();
            if (contador > hasta)
            {
                panelPagSiguiente.Visible = true;
                panelPagAnterior.Visible = false;
                panelUltimaPagina.Visible = true;
                panelPrimeraPagina.Visible = true;
            }
            else
            {
                panelPagSiguiente.Visible = false;
                panelPagAnterior.Visible = false;
                panelUltimaPagina.Visible = false;
                panelPrimeraPagina.Visible = false;
            }
            paginar();
        }

        private void contarPersonal()
        {
            Procesos manipularBD = new Procesos();
            manipularBD.contarPersonal(ref contador);

        }

        private void paginar()
        {
            try
            {
                lblPaginaActual.Text = (hasta / itemsPorPagina).ToString();
                lblTotalPaginas.Text = Math.Ceiling(Convert.ToSingle(contador) / itemsPorPagina).ToString();
                totalPaginas = Convert.ToInt32(lblTotalPaginas.Text);
            }
            catch (Exception)
            {


            }
        }

        //Métodos Para Editar Personal

        private void obtenerCargoAEditar()
        {
            idCargo = Convert.ToInt32(dataListadoCargo.SelectedCells[1].Value);
            txtCargo2.Text = dataListadoCargo.SelectedCells[2].Value.ToString();
            string sueldo = dataListadoCargo.SelectedCells[3].Value.ToString();
            sueldo = sueldo.Replace("$", string.Empty);
            sueldo = sueldo.Replace(",", ".");
            sueldo = sueldo.Substring(0, sueldo.Length-3);
            txtSueldo.Text = sueldo;
            txtSueldoHora2.Text = sueldo;
            lblGuardarCargo.Visible = false;
            btnGuardarCargo.Visible = false;
            btnGuardarCambiosCargos.Visible = true;
            lblGuardarCambiosCargos.Visible = true;
            panelGuardar.Visible = false;
            txtCargo2.Focus();
            txtSueldoHora2.SelectAll();
            panelAgregarCargos.Visible = true;
            panelAgregarCargos.Dock = DockStyle.Fill;
            panelAgregarCargos.BringToFront();
        }

        private void obtenerDatos()
        {
            idPersonal = Convert.ToInt32(dataPersonal.SelectedCells[2].Value);
            estado = dataPersonal.SelectedCells[9].Value.ToString();
            if (estado == "ELIMINADO")
            {
                restaurarPersonal();
            }
            else
            {
                modificar = true;
                panelBusqueda.Visible = false;
                txtCargo.Text = dataPersonal.SelectedCells[8].Value.ToString();
                buscarCargos();
                obtenerCargo();
                txtNombres.Text = dataPersonal.SelectedCells[4].Value.ToString();
                txtApellidos.Text = dataPersonal.SelectedCells[5].Value.ToString();
                txtIdentificacion.Text = dataPersonal.SelectedCells[3].Value.ToString();
                cmbxPais.Text = dataPersonal.SelectedCells[6].Value.ToString();
                panelPaginado.Visible = false;
                panelRegistro.Visible = true;
                panelRegistro.Dock = DockStyle.Fill;
                LocalizarDtvCargos();
                dataListadoCargo.Visible = false;
                lblSueldoPorHora.Visible = true;
                panelGuardar.Visible = true;
                lblGuardarCambios.Visible = true;
                btnGuardar.Visible = false;
                lblGuardar.Visible = false;
                btnGuardarCambios.Visible = true;
                panelAgregarCargos.Visible = false;
            }
        }

        private void editarPersonal()
        {
            if (!string.IsNullOrEmpty(txtCargo.Text) && !string.IsNullOrEmpty(txtSueldo.Text))
            {
                string identificacion = txtIdentificacion.Text.ToUpper();
                string nombres = txtNombres.Text.ToUpper();
                string apellidos = txtApellidos.Text.ToUpper();
                string pais = Convert.ToString(cmbxPais.SelectedItem).ToUpper();
                txtSueldo.Text = txtSueldo.Text.Replace(",", "");
                float sueldo = float.Parse(txtSueldo.Text.Replace(".", ""));
                txtSueldoHora2.Text = Convert.ToString(sueldo);
                Persona nuevaPersona = new Persona(idPersonal, identificacion, nombres, apellidos, 0, pais, idCargo, sueldo, "");
                Procesos manipularBD = new Procesos();
                if (manipularBD.EditarPersonal(nuevaPersona) == true)
                {
                    mostrarPersonal();
                    panelCargo.Visible = false;
                    panelRegistro.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Todos los campos son obligatorios. ", "Por favor digitar el cargo y el sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Métodos para restaurar Personal

        private void habilitarPersonal()
        {
            idPersonal = Convert.ToInt32(dataPersonal.SelectedCells[2].Value);
            Procesos manipularBD = new Procesos();
            if (manipularBD.RestaurarPersonal(idPersonal) == true)
            {
                mostrarPersonal();
            }
        }

        private void restaurarPersonal()
        {
            DialogResult result = MessageBox.Show("Esta persona se ha eliminado, ¿Desea restaurarla?", "Restauración de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                habilitarPersonal();
            }
        }

        //Método para eliminar personal

        private void eliminarPersonal()
        {
            idPersonal = Convert.ToInt32(dataPersonal.SelectedCells[2].Value);
            Procesos manipularBD = new Procesos();
            if (manipularBD.EliminarPersonal(idPersonal) == true)
            {
                mostrarPersonal();
            }

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
    }
}
