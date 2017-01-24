using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EnZona
{
    public partial class FormReporte : DevExpress.XtraEditors.XtraForm
    {
        string nombre;
        string apellido1;
        string apellido2;
        string[] reporte1; string[] reporte2; string[] reporte3; string[] reporte4; string[] reporte5;
        int vb;
        public FormReporte(string nombre, string apellido1, string apellido2, string[] reporte1, string[] reporte2, string[] reporte3, string[] reporte4, string[] reporte5, int vb)
        {
            InitializeComponent();
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.reporte1 = reporte1; this.reporte2 = reporte2; this.reporte3 = reporte3; this.reporte4 = reporte4; this.reporte5 = reporte5;
            this.vb = vb;
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            Report obj = new Report(nombre, apellido1, apellido2, reporte1, reporte2, reporte3, reporte4, reporte5, vb);
            obj.CreateDocument();
            printControl1.PrintingSystem = obj.PrintingSystem;
        }
    }
}