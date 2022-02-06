using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCAPEN_2021.Logica;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SCAPEN_2021.Datos
{
    class ProcesosCargo
    {
        public bool insertarCargo(Cargo cargo)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand manipularStoredProcedures = new SqlCommand("InsertarCargo", ConexionMaestra.establecerConexion);
                manipularStoredProcedures.CommandType = CommandType.StoredProcedure;
                manipularStoredProcedures.Parameters.AddWithValue("@SueldoPorHora", cargo.getSueldo());
                manipularStoredProcedures.Parameters.AddWithValue("@Cargo", cargo.getCargo());
                manipularStoredProcedures.ExecuteNonQuery();
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

        public bool editarCargo(Cargo cargo)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand manipularStoredProcedures = new SqlCommand("EditarCargo", ConexionMaestra.establecerConexion);
                manipularStoredProcedures.CommandType = CommandType.StoredProcedure;
                manipularStoredProcedures.Parameters.AddWithValue("@Id", cargo.getId());
                manipularStoredProcedures.Parameters.AddWithValue("@SueldoPorHora", cargo.getSueldo());
                manipularStoredProcedures.Parameters.AddWithValue("@Cargo", cargo.getCargo());
                manipularStoredProcedures.ExecuteNonQuery();
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

        public void buscarCargos(ref DataTable dt, string buscador)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter extrerDatosDeLaBD = new SqlDataAdapter("BuscarCargos", ConexionMaestra.establecerConexion);
                extrerDatosDeLaBD.SelectCommand.CommandType = CommandType.StoredProcedure;
                extrerDatosDeLaBD.SelectCommand.Parameters.AddWithValue("@buscador", buscador);
                extrerDatosDeLaBD.Fill(dt);
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
