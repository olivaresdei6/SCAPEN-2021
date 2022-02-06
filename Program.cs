using SCAPEN_2021.AsistenteDeInstalacion;
using SCAPEN_2021.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SCAPEN_2021
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login login = new Login();
            login.FormClosed += Login_FormClosed;
            login.ShowDialog();
            Application.Run();
        }

        private static void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        
    }
}
