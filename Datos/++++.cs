using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SCAPEN_2021.Datos
{
    public class ConexionMaestra
    {
        public static string directorioDeLaBD = @"Data source = DEIBER_OLIVARES\SQLEXPRESS; Initial Catalog=SCAPEN; Integrated Security=true";
        public static SqlConnection establecerConexion = new SqlConnection(directorioDeLaBD);
        public static void abrirConexionConLaBD()
        {
            if (establecerConexion.State == ConnectionState.Closed)
            {
                establecerConexion.Open();
            }
        }

        public static void cerrarConexionConLaBD()
        {
            if (establecerConexion.State == ConnectionState.Open)
            {
                establecerConexion.Close();
            }
        }
    }
}
