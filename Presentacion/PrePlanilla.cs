using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCAPEN_2021.Datos;
using System.Globalization;

namespace SCAPEN_2021.Presentacion
{
    public partial class PrePlanilla : UserControl
    {
        public PrePlanilla()
        {
            InitializeComponent();
        }

        private void PrePlanilla_Load(object sender, EventArgs e)
        {
            calcular_numero_de_semana();
        }

        private void ReporteAsistencias()
        {
            Reportes.ReportAsistencias rpt = new Reportes.ReportAsistencias();
            DataTable dt = new DataTable();
            ProcesosAsistencia funcion = new ProcesosAsistencia();
            funcion.mostrarAsistenciasDiarias(ref dt, txtdesde.Value, txthasta.Value, Convert.ToInt32(lblnumerosemana.Text));
            rpt.DataSource = dt;
            rpt.table1.DataSource = dt;
            reportViewer1.Report = rpt;
            reportViewer1.RefreshReport();
        }

        private int calcular_numero_de_semana()
        {
            DateTime v2 = txthasta.Value;
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(v2, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            lblnumerosemana.Text = weekNum.ToString();
            return weekNum;
        }

        private void Txtdesde_ValueChanged(object sender, EventArgs e)
        {
            calcular_numero_de_semana();
            ReporteAsistencias();
            calcular_numero_de_semana();
        }

        private void Txthasta_ValueChanged(object sender, EventArgs e)
        {
            calcular_numero_de_semana();
            ReporteAsistencias();
            calcular_numero_de_semana();
        }
    }
}
