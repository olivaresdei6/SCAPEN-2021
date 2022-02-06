using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using SCAPEN_2021.Logica;

namespace SCAPEN_2021.Datos
{
    public class ProcesosModulos
    {
        public void mostrarModulos(ref DataTable dt)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlDataAdapter ejecutarStoredProcedures = new SqlDataAdapter("Select * from TblModulos", ConexionMaestra.establecerConexion);
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

        public bool insertarModulos(Modulos modulos)
        {
            try
            {
                ConexionMaestra.abrirConexionConLaBD();
                SqlCommand ejecutarStoredProcedures = new SqlCommand("insertarModulos", ConexionMaestra.establecerConexion);
                ejecutarStoredProcedures.CommandType = CommandType.StoredProcedure;
                ejecutarStoredProcedures.Parameters.AddWithValue("@modulo", modulos.getModulo());
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
