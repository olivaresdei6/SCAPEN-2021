using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCAPEN_2021.Logica;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace SCAPEN_2021.Datos
{
    public class ProcesosAsistencia
    {
        public bool insertarAsistencias(Asistencia asistencia)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("insertarAsistencias", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@Id_personal", asistencia.getIdPersonal());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Fecha_entrada", asistencia.getFechaEntrada());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Fecha_Salida", asistencia.getFechaSalida());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Estado", asistencia.getEstado());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Horas", asistencia.getHora());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Observacion", asistencia.getObservacion());
                ejecutarStoredProcedures.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public bool BuscarAsistenciaPorId(ref DataTable dt, int IdPersonal)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("BuscarAsistenciaPorId", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@IdPersonal", IdPersonal);
                ejecutarStoredProc.Fill(dt);
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

        public bool ConfirmarSalida(Asistencia asistencia)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("ConfirmarSalida", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@Id_personal", asistencia.getIdPersonal());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Fecha_salida", asistencia.getFechaSalida());
                ejecutarStoredProcedures.Parameters.AddWithValue("@Horas", asistencia.getHora());
                ejecutarStoredProcedures.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public void mostrarAsistenciasDiarias(ref DataTable dt, DateTime desde, DateTime hasta, int semana)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter da = new SqlDataAdapter("MostrarAsistenciasDiarias", ConexionMaestra.establecerConexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@desde", desde);
                da.SelectCommand.Parameters.AddWithValue("@hasta", hasta);
                da.SelectCommand.Parameters.AddWithValue("@semana", semana);
                da.Fill(dt);
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
    }
}
