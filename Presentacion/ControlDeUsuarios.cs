using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using SCAPEN_2021.Datos;
using SCAPEN_2021.Logica;
using System.IO;

namespace SCAPEN_2021.Presentacion
{
    public partial class ControlDeUsuarios : UserControl
    {
        public Image imagen;
        public String usuario;
        public int idUser;
        int idUsuario;
        int desde = 1;
        int hasta = 10;
        int contador = 0;
        int itemsPorPagina = 10;
        string estado;
        int totalPaginas = 0;
        bool selecionoImg = false;
        public ControlDeUsuarios()
        {
            InitializeComponent();
            mostrarUsuarios();
            reiniciarPaginado();
        }

        private void PtBxAgregarIcono_Click(object sender, EventArgs e)
        {
            habilitarIconos();
        }

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {
            habilitarIconos();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox1.Image;
            ocultarPanelIconos();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox2.Image;
            ocultarPanelIconos();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox3.Image;
            ocultarPanelIconos();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox4.Image;
            ocultarPanelIconos();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox5.Image;
            ocultarPanelIconos();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox6.Image;
            ocultarPanelIconos();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox7.Image;
            ocultarPanelIconos();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            selecionoImg = true;
            ptBxAgregarIcono.Image = pictureBox8.Image;
            ocultarPanelIconos();
        }

        private void PictureBoxIconoDesedeLaCompu_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Selecciona una imagen";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ptBxAgregarIcono.BackgroundImage = null;
                ptBxAgregarIcono.Image = new Bitmap(dlg.FileName);
                selecionoImg = true;
                ocultarPanelIconos();
            }
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            ocultarPanelIconos();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            panelIconos.Visible = false;
            ptBxAgregarIcono.Visible = true;
            panel7.Visible = true;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

            limpiar();
            habilitarPaneles();
            dtModulos.Visible = true;
            mostrarModulos();
            ptBxAgregarIcono.Image = Properties.Resources.foto__1_;
            lblAnuncioIcono.Visible = true;
            selecionoImg = false;


        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            validarCampos(false);
        }

        private void ControlDeUsuarios_Load(object sender, EventArgs e)
        {

            mostrarUsuarios();
            reiniciarPaginado();
        }

        private void BtnPaginaSiguiente_Click(object sender, EventArgs e)
        {

            irAPaginaSiguiente();
        }

        private void BtnPaginaAnterior_Click(object sender, EventArgs e)
        {
            irAPaginaAnterior();
        }

        private void BtnPrimeraPagina_Click(object sender, EventArgs e)
        {
            irAPrimeraPagina();
        }

        private void BtnUltimaPagina_Click(object sender, EventArgs e)
        {
            irAUltimaPagina();
        }

        private void TxtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || txtContraseña.Text.Length <= 6)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
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

        private void TxtContraseña_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (txtContraseña.Text.Length <= 5)
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

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            validarCampos(true);

        }

        private void BtnRegresar_Click_1(object sender, EventArgs e)
        {
            panelBusqueda.Visible = true;
            panelRegistro.Visible = false;
        }

        private void DtListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string est = dtListado.SelectedCells[7].Value.ToString();
            idUsuario = Convert.ToInt32(dtListado.SelectedCells[2].Value.ToString());
            if (e.ColumnIndex == dtListado.Columns["Eliminar"].Index && est == "ACTIVO")
            {
                if (dtListado.SelectedCells[6].Value.ToString() == "admin")
                {
                    MessageBox.Show("Esta acción no es permitada, el administrador es el unico usuario que no se puede eliminar", "Acción no valida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Solo se cambiara el estado para que no pueda acceder, ¿Desea continuar?", "Eliminar Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        eliminarUsuarios();
                    }
                }
            }
            if (e.ColumnIndex == dtListado.Columns["Editar"].Index)
            {
                selecionoImg = true;
                obtenerDatos();
            }
        }

        private void TxtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar) == true || Char.IsControl(e.KeyChar) == true || Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void TxtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar) == true || Char.IsControl(e.KeyChar) == true || Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void TxtBuscador_TextChanged(object sender, EventArgs e)
        {
            buscarUsuarios();
        }

        /* **************************************Zona de métodos****************************************** */

        /* ********** Métodos para mostrar usuarios *************** */
        private void obtenerIdUsuario()
        {
            new ProcesosUsuarios().obtenerIdUsuario(ref idUsuario, txtUsuario.Text);
        }

        private void mostrarUsuarios()
        {
            labelUser.Text = usuario;
            DataTable dt = new DataTable();
            if (labelUser.Text != "admin")
            {
                new ProcesosUsuarios().mostrarUsuarios(ref dt, desde, hasta);
            }
            else
            {
                new ProcesosUsuarios().mostrarUsuariosAdministrador(ref dt, desde, hasta);
            }
            dtListado.DataSource = dt;
            Bases.DiseñoDtv(ref dtListado);
            Bases.DiseñoDtvEliminar(ref dtListado);
            panelPaginado.Visible = true;

            dtListado.Columns[8].Visible = false;
            dtListado.Columns[2].HeaderText = "N° De Usuario";
        }

        /* ******************************************************** */


        /* ********** Métodos para controlar el paginado ********** */

        private void reiniciarPaginado()
        {
            desde = 1;
            hasta = 10;
            contarUsuarios();
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

        private void irAPaginaAnterior()
        {
            desde -= 10;
            hasta -= 10;
            mostrarUsuarios();
            contarUsuarios();
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

        private void irAPaginaSiguiente()
        {
            desde += 10;
            hasta += 10;
            mostrarUsuarios();
            contarUsuarios();
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

        private void irAUltimaPagina()
        {
            hasta = totalPaginas * itemsPorPagina;
            desde = hasta - 9;
            mostrarUsuarios();
            contarUsuarios();
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

        private void irAPrimeraPagina()
        {
            reiniciarPaginado();
            mostrarUsuarios();
        }

        private void contarUsuarios()
        {
            ProcesosUsuarios manipularBD = new ProcesosUsuarios();
            manipularBD.contarUsuarios(ref contador);

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

        /* ******************************************************** */


        /* ********** Métodos para registrar Usuarios ************* */

        private void validarCampos(bool editar)
        {
            Boolean modificar = false;
            if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtApellidos.Text) &&
                !string.IsNullOrEmpty(txtIdentificacion.Text) && !string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtContraseña.Text) && selecionoImg == true &&
                txtNombres.Text.Length > 3 && txtApellidos.Text.Length > 3 && txtIdentificacion.Text.Length > 5)
            {
                if (txtUsuario.Text.ToLower() == "admin" && labelUser.Text=="admin")
                {
                    modificar = true;
                }
                else
                {
                    if (txtUsuario.Text.ToLower() != "admin")
                    {
                        modificar = true;
                    }
                    else
                    {
                        MessageBox.Show("El usuario no es valido, ingrese otro nombre de usuario");
                        modificar = false;
                    }
                }
                

            }
            else
            {
                MessageBox.Show("Todos los campos incluyendo la imagen son obligatorios y deben diligenciarce correctamente");
                modificar = false;
            }
            if (modificar == true)
            {
                if (editar == true)
                {
                    editarUsuarios();
                }
                else
                {
                    insertarUsuarios();
                }
                reiniciarPaginado();
                panelBusqueda.Visible = true;
            }
        }

        private void insertarUsuarios()
        {
            string nombre = txtNombres.Text.ToUpper();
            string apellidos = txtApellidos.Text.ToUpper();
            string identificacion = txtIdentificacion.Text.ToUpper();
            string usuario = txtUsuario.Text.ToLower();
            string password = txtContraseña.Text;
            MemoryStream ms = new MemoryStream();
            ptBxAgregarIcono.Image.Save(ms, ptBxAgregarIcono.Image.RawFormat);
            byte[] icono = ms.GetBuffer();
            Usuario user = new Usuario(nombre, apellidos, identificacion, usuario, password, icono);
            if (new ProcesosUsuarios().insertarUsuarios(user) == true)
            {
                obtenerIdUsuario();
                insertarPermisos();
            }
        }


        /* ******************************************************** */

        /* ********** Métdos para buscar Usuarios ***************** */

        private void buscarUsuarios()
        {
            DataTable dt = new DataTable();
            new ProcesosUsuarios().buscarUsuariosAdministrador(ref dt, txtBuscador.Text, desde, hasta, labelUser.Text);
            dtListado.DataSource = dt;
        }

        /* ******************************************************** */


        /* ********** Métodos para eliminar usuarios ************** */

        private void eliminarUsuarios()
        {
            idUsuario = Convert.ToInt32(dtListado.SelectedCells[2].Value);
            ProcesosUsuarios manipularBD = new ProcesosUsuarios();
            if (manipularBD.EliminarUsuarios(idUsuario) == true)
            {
                mostrarUsuarios();
            }

        }

        /* ******************************************************** */


        /* ********** Nétodos para modificar usuarios ************* */

        private void obtenerDatos()
        {
            idUsuario = Convert.ToInt32(dtListado.SelectedCells[2].Value);
            estado = dtListado.SelectedCells[7].Value.ToString();
            if (estado == "ELIMINADO")
            {
                restaurarPersonal();
            }
            else
            {
                panelBusqueda.Visible = false;
                limpiar();
                habilitarPaneles();
                mostrarModulos();
                txtNombres.Text = dtListado.SelectedCells[4].Value.ToString();
                txtApellidos.Text = dtListado.SelectedCells[5].Value.ToString();
                txtIdentificacion.Text = dtListado.SelectedCells[3].Value.ToString();
                txtUsuario.Text = dtListado.SelectedCells[6].Value.ToString();
                byte[] bi = (Byte[])dtListado.SelectedCells[8].Value;
                MemoryStream ms = new MemoryStream(bi);
                ptBxAgregarIcono.Image = Image.FromStream(ms);
                ptBxAgregarIcono.SizeMode = PictureBoxSizeMode.Zoom;
                validarPermisos();
                lblAnuncioIcono.Visible = false;
                panelActualizar.Visible = true;
                panelAgregarUsuario.Visible = false;
                if (txtUsuario.Text == "admin")
                {
                    dtModulos.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                }
            }
        }

        private void restaurarPersonal()
        {
            DialogResult result = MessageBox.Show("Este usuario se ha eliminado, ¿Desea restaurarlo?", "Restauración de Registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                habilitarUsuarios();
            }
        }

        private void habilitarUsuarios()
        {
            idUsuario = Convert.ToInt32(dtListado.SelectedCells[2].Value);
            ProcesosUsuarios manipularBD = new ProcesosUsuarios();
            if (manipularBD.RestaurarUsuarios(idUsuario) == true)
            {
                mostrarUsuarios();
            }
        }

        private void editarUsuarios()
        {
            string nombre = txtNombres.Text.ToUpper();
            string apellidos = txtApellidos.Text.ToUpper();
            string identificacion = txtIdentificacion.Text.ToUpper();
            string usuario = txtUsuario.Text.ToLower();
            string password = txtContraseña.Text;
            MemoryStream ms = new MemoryStream();
            ptBxAgregarIcono.Image.Save(ms, ptBxAgregarIcono.Image.RawFormat);
            byte[] icono = ms.GetBuffer();
            Usuario user = new Usuario(nombre, apellidos, identificacion, usuario, password, icono);
            if (new ProcesosUsuarios().editarUsuarios(user, idUsuario) == true)
            {
                new ProcesosPermisos().eliminarPermisos(idUsuario);
                obtenerIdUsuario();
                insertarPermisos();
                if (dtListado.SelectedCells[6].Value.ToString() == labelUser.Text)
                {
                    MessageBox.Show("La seción sera cerrada para que los cambios surgan efecto.\nTenga en cuenta que si cambio su usuaro o contraseña debe ingresar con los datos que acabo de actualizar", "Su sesción sera cerrada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Restart();
                }
            }
        }

        /* ******************************************************** */


        /* **********Métodos para controlar los permisos ********** */
        private void validarPermisos()
        {
            DataTable dt = new DataTable();
            ProcesosPermisos procesosPermisos = new ProcesosPermisos();
            Permisos permisos = new Permisos();
            permisos.setIdUsuario(idUsuario);
            procesosPermisos.mostrarPermisos(ref dt, permisos);
            int fila = 0;
            foreach (DataRow row in dt.Rows)
            {
                String modulo = Convert.ToString(row["Modulo"]);
                if (modulo == "Pre planilla".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                if (modulo == "Personal".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                if (modulo == "Registro".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                if (modulo == "Usuarios".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                if (modulo == "Restaurar BD".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                if (modulo == "Crear Backup".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                if (modulo == "Estanciones".ToUpper())
                {
                    dtModulos.Rows[fila].Cells[0].Value = true;
                }
                fila++;
            }
        }

        private void insertarPermisos()
        {
            foreach (DataGridViewRow row in dtModulos.Rows)
            {
                int idModulo = Convert.ToInt32(row.Cells["IdModulo"].Value);
                bool marcado = Convert.ToBoolean(row.Cells["Marcar"].Value);

                if (marcado == true)
                {
                    Permisos permisos = new Permisos(0, idModulo, idUsuario);
                    new ProcesosPermisos().insertarPermisos(permisos);
                }
            }
            mostrarUsuarios();
            panelRegistro.Visible = false;
        }

        private void mostrarModulos()
        {
            ProcesosModulos manipularBD = new ProcesosModulos();
            DataTable dt = new DataTable();
            manipularBD.mostrarModulos(ref dt);
            dtModulos.DataSource = dt;
            Bases.DiseñoDtv(ref dtModulos);
            dtModulos.Columns[1].Visible = false;
            dtModulos.Columns[2].ReadOnly = true;
            dtModulos.RowHeadersWidth = 12;

        }

        /* ******************************************************** */


        /* ********** Otros Métodos ******************************* */

        private void ocultarPanelIconos()
        {
            panelIconos.Visible = false;
            lblAnuncioIcono.Visible = false;
            ptBxAgregarIcono.Visible = true;
            panel7.Visible = true;
        }

        private void habilitarIconos()
        {
            panel7.Visible = false;
            panelIconos.Visible = true;
            panelIconos.Dock = DockStyle.Fill;
            panelIconos.BringToFront();
        }

        private void limpiar()
        {
            txtNombres.Clear();
            txtApellidos.Clear();
            txtIdentificacion.Clear();
            txtContraseña.Clear();
            txtUsuario.Clear();
        }

        private void habilitarPaneles()
        {
            panelBusqueda.Visible = false;

            panel7.Visible = true;
            panelRegistro.Visible = true;
            panelSeleccionarImg.Visible = true;
            panelIconos.Visible = false;
            panelRegistro.Dock = DockStyle.Fill;
            panelRegistro.BringToFront();
            panelAgregarUsuario.Visible = true;
            panelActualizar.Visible = false;
            panelRegresar.Visible = true;
            panelPaginado.Visible = false;
            panel2.Visible = true;
            dtModulos.Visible = true;
        }



        /* ******************************************************** */
    }
}
