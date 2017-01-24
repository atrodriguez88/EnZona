using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace EnZona
{
    public partial class Report : DevExpress.XtraReports.UI.XtraReport
    {
        string nombre;
        string apellido1;
        string apellido2;
        string[] reporte1; string[] reporte2; string[] reporte3; string[] reporte4; string[] reporte5;
        int vb;

        public Report(string nombre, string apellido1, string apellido2, string[] reporte1, string[] reporte2, string[] reporte3, string[] reporte4, string[] reporte5, int vb)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.reporte1 = reporte1; this.reporte2 = reporte2; this.reporte3 = reporte3; this.reporte4 = reporte4; this.reporte5 = reporte5;
            this.vb = vb;
            DatosPersonales(); Reporte();
        }

        public void DatosPersonales()
        {
            xrLabel4.Text = nombre;
            xrLabel5.Text = apellido1;
            xrLabel6.Text = apellido2;
        }
        public void Reporte()
        {
            xrLabel53.Text = vb.ToString();
            // Reporte 1
            xrTableCell1.Text = reporte1[0]; xrTableCell2.Text = reporte1[1]; xrTableCell3.Text = reporte1[2];
            xrTableCell4.Text = reporte1[3]; xrTableCell5.Text = reporte1[4]; xrTableCell6.Text = reporte1[5];
            xrTableCell7.Text = reporte1[6]; xrTableCell8.Text = reporte1[7]; xrTableCell9.Text = reporte1[8];
            // Error en la linea de abajo
            xrTableCell11.Text = reporte1[9]; xrTableCell17.Text = reporte1[10]; xrTableCell23.Text = reporte1[11]; xrTableCell14.Text = reporte1[12];
            // Reporte 2
            xrTableCell19.Text = reporte2[0]; xrTableCell20.Text = reporte2[1]; xrTableCell21.Text = reporte2[2];
            xrTableCell25.Text = reporte2[3]; xrTableCell26.Text = reporte2[4]; xrTableCell27.Text = reporte2[5];
            xrTableCell28.Text = reporte2[6]; xrTableCell29.Text = reporte2[7]; xrTableCell30.Text = reporte2[8];
            // Error en la linea de abajo
            xrTableCell32.Text = reporte2[9]; xrTableCell38.Text = reporte2[10]; xrTableCell41.Text = reporte2[11]; xrTableCell35.Text = reporte2[12];
            //Reporte 3
            xrLabel15.Text = reporte3[0]; xrLabel16.Text = reporte3[1]; xrLabel17.Text = reporte3[2];
            xrLabel18.Text = reporte3[3]; xrLabel19.Text = reporte3[4];
            //Reporte 4
            xrLabel20.Text = reporte4[0]; xrLabel21.Text = reporte4[1]; xrLabel22.Text = reporte4[2];
            xrLabel23.Text = reporte4[3]; xrLabel24.Text = reporte4[4]; xrLabel25.Text = reporte4[5];
            xrLabel34.Text = reporte4[6]; xrLabel35.Text = reporte4[7]; xrLabel36.Text = reporte4[8];
            xrLabel37.Text = reporte4[9]; xrLabel38.Text = reporte4[10]; xrLabel39.Text = reporte4[11];
            //Reporte 5
            xrLabel46.Text = reporte5[0]; xrLabel47.Text = reporte5[1]; xrLabel48.Text = reporte5[2];
            xrLabel49.Text = reporte5[3]; xrLabel50.Text = reporte5[4]; xrLabel51.Text = reporte5[5];
        }

    }
}
