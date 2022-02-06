using SCAPEN_2021.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCAPEN_2021.Datos
{
    public class ProcesosCopiasBD
    {
        public bool InsertarCopiasBD()
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("InsertarCopiasBD", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }


        public void MostrarRuta(ref string ruta)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand command = new SqlCommand("Select Ruta from TblCopiasBD", ConexionMaestra.establecerConexion);
                ruta = Convert.ToString(command.ExecuteScalar());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }

        public bool EditarCopiasBD(CopiasBD copiasBD)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProc = new SqlCommand("EditarCopiasBD", ConexionMaestra.establecerConexion);
                ejecutarStoredProc.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProc.Parameters.AddWithValue("@Ruta", copiasBD.ruta);
                ejecutarStoredProc.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                ConexionMaestra.cerrarConexionConLaBD();
            }
        }
    }
}
