using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using SCAPEN_2021.Logica;
using System.Windows.Forms;
using System.Data;

namespace SCAPEN_2021.Datos
{
    public class ProcesosPermisos
    {
        public bool insertarPermisos(Permisos permisos)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("insertarPermisos", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@IdModulo", permisos.getIdModulo());
                ejecutarStoredProcedures.Parameters.AddWithValue("@IdUsuario", permisos.getIdUsuario());
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

        public void mostrarPermisos(ref DataTable dt, Permisos permisos)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter ejecutarStoredProcedures = new SqlDataAdapter("mostrarPermisos", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.SelectCommand.Parameters.AddWithValue("@idUsuario", permisos.getIdUsuario());
                ejecutarStoredProcedures.Fill(dt);

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

        public bool eliminarPermisos(int idUsuario)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("EliminarPermisos", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@idUsuario", idUsuario);
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
