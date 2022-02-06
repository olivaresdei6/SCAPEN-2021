using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SCAPEN_2021.Logica;

namespace SCAPEN_2021.Datos
{
    public class ConexionMaestra
    {
        public static string directorioDeLaBD = Convert.ToString(Decencriptacion.checkServer());
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


