using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;
using SCAPEN_2021.Logica;

namespace SCAPEN_2021.Datos
{
    public class ProcesosUsuarios
    {
        public bool insertarUsuarios(Usuario usuario)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("InsertarUsuario", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@nombre", usuario.getNombre());
                ejecutarStoredProcedures.Parameters.AddWithValue("@apellidos", usuario.getApellidos());
                ejecutarStoredProcedures.Parameters.AddWithValue("@identificacion", usuario.getIdentificacion());
                ejecutarStoredProcedures.Parameters.AddWithValue("@usuario", usuario.getUsuario());
                ejecutarStoredProcedures.Parameters.AddWithValue("@password", usuario.getPassword());
                ejecutarStoredProcedures.Parameters.AddWithValue("@icono", usuario.getIcono());
                ejecutarStoredProcedures.Parameters.AddWithValue("@estado","ACTIVO");
                ejecutarStoredProcedures.ExecuteNonQuery();
                ConexionMaestra.cerrarConexionConLaBD();
                return true;
            }
            catch (Exception ex)
            {
                ConexionMaestra.cerrarConexionConLaBD();
                MessageBox.Show(ex.Message);
                return false;
            }
           
        }

        public void mostrarUsuarios(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("MostrarUsuarios", ConexionMaestra.establecerConexion);

                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                ejecutarStoredProc.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void mostrarUsuariosAdministrador(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("MostrarUsuariosAdministrador", ConexionMaestra.establecerConexion);

                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                ejecutarStoredProc.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void mostrarTodosLosUsuarios(ref DataTable dt)
        {
            try
            {
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("MostrarTodosLosUsuarios", ConexionMaestra.establecerConexion);

                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void obtenerIdUsuario(ref int IdUsuario, string usuario)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("ObtenerIdUsuario", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@usuario", usuario);
                IdUsuario = Convert.ToInt32(ejecutarStoredProcedures.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void contarUsuarios(ref int contador)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("select COUNT([IdUsuario]) from TblUsuarios", ConexionMaestra.establecerConexion);
                contador = Convert.ToInt32(ejecutarStoredProcedures.ExecuteScalar());
            }
            catch (Exception)
            {
                contador = 0;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void verificarUsuarios(ref String indicador)
        {
            try
            {
                int idUser;
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("Select IdUsuario from TblUsuarios", ConexionMaestra.establecerConexion);
                idUser = Convert.ToInt32(ejecutarStoredProcedures.ExecuteScalar());
                indicador = "Correcto";
                ConexionMaestra.cerrarConexionConLaBD();
            }
            catch (Exception)
            {
                indicador = "Incorrecto";
            }
        }

        public void validarUsuarios( String password, String usuario, ref int id)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("validarUsuarios", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@password", password);
                ejecutarStoredProcedures.Parameters.AddWithValue("@usuario", usuario);
                id = Convert.ToInt32(ejecutarStoredProcedures.ExecuteScalar());
            }
            catch (Exception)
            {
                id = 0;
                
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public bool EliminarUsuarios(int idUsuario )
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("eliminarUsuarios", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@IdUsuario", idUsuario);
                ejecutarStoredProc.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public bool RestaurarUsuarios(int idUsuario)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("restaurarUsuarios", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@IdUsuario", idUsuario);
                ejecutarStoredProc.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void buscarUsuariosAdministrador(ref DataTable dt, String buscador, int desde, int hasta, String usuario)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter sqlData = new SqlDataAdapter();
                if (usuario == "admin")
                {
                    sqlData = new SqlDataAdapter("BuscarUsuariosAdministrador", ConexionMaestra.establecerConexion);
                }
                else
                {
                    sqlData = new SqlDataAdapter("BuscarUsuarios", ConexionMaestra.establecerConexion);
                }
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                sqlData.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                sqlData.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                sqlData.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void buscarUsuarios(ref DataTable dt)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public bool editarUsuarios(Usuario usuario, int idUsuario)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("EditarUsuarios", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@nombre", usuario.getNombre());
                ejecutarStoredProcedures.Parameters.AddWithValue("@apellidos", usuario.getApellidos());
                ejecutarStoredProcedures.Parameters.AddWithValue("@identificacion", usuario.getIdentificacion());
                ejecutarStoredProcedures.Parameters.AddWithValue("@usuario", usuario.getUsuario());
                ejecutarStoredProcedures.Parameters.AddWithValue("@password", usuario.getPassword());
                ejecutarStoredProcedures.Parameters.AddWithValue("@icono", usuario.getIcono());
                ejecutarStoredProcedures.Parameters.AddWithValue("@IdUsuario", idUsuario);
                ejecutarStoredProcedures.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }
    }
}

