using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SCAPEN_2021.Logica;
using System.Windows.Forms;

namespace SCAPEN_2021.Datos
{
    public class Procesos
    {
        public bool InsertarPersonal(Persona persona)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("InsertarPersonal", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@Nombres", persona.getNombres());
                ejecutarStoredProc.Parameters.AddWithValue("@Apellidos", persona.getApellidos());
                ejecutarStoredProc.Parameters.AddWithValue("@Identificacion", persona.getIdentificacion()); 
                ejecutarStoredProc.Parameters.AddWithValue("@Pais", persona.getPais());
                ejecutarStoredProc.Parameters.AddWithValue("@Id_cargo", persona.getId_Cargo());
                ejecutarStoredProc.Parameters.AddWithValue("@SueldoPorHora", persona.getSueldoPorHora());
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

        public bool EditarPersonal(Persona persona)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("EditarPersonal", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@IdPersonal", persona.getIdPersonal());
                ejecutarStoredProc.Parameters.AddWithValue("@Nombres", persona.getNombres());
                ejecutarStoredProc.Parameters.AddWithValue("@Apellidos", persona.getApellidos());
                ejecutarStoredProc.Parameters.AddWithValue("@Identificacion", persona.getIdentificacion());
                ejecutarStoredProc.Parameters.AddWithValue("@Pais", persona.getPais());
                ejecutarStoredProc.Parameters.AddWithValue("@Id_cargo", persona.getId_Cargo());
                ejecutarStoredProc.Parameters.AddWithValue("@SueldoPorHora", persona.getSueldoPorHora());
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

        public bool EliminarPersonal(int idPersonal)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("EliminarPersonal", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@IdPersonal", idPersonal);
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

        public bool RestaurarPersonal(int idPersonal)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("RestaurarPersonal", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@IdPersonal", idPersonal);
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

        public bool MostrarPersonal(ref DataTable dt, int desde, int hasta)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("MostrarPersonal", ConexionMaestra.establecerConexion);
                
                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                ejecutarStoredProc.Fill(dt);
                ConexionMaestra.cerrarConexionConLaBD();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool BuscarPersonal(ref DataTable dt, int desde, int hasta, String buscador)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("BuscarPersonal", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Desde", desde);
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Hasta", hasta);
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@Buscador", buscador);
                ejecutarStoredProc.Fill(dt);
                ConexionMaestra.cerrarConexionConLaBD();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                
            }
        }

        public void contarPersonal(ref int contador)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("select COUNT([Id_Personal]) from TblPersonal", ConexionMaestra.establecerConexion);
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

        public bool BuscarPersonalPorIdentificacion(ref DataTable dt, String buscador)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter ejecutarStoredProc = new SqlDataAdapter("BuscarPersonalPorIdentificacion", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.SelectCommand.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
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
    }
}
