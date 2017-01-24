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
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        int a;
        public XtraForm1(int a)
        {
            this.a = a;
            InitializeComponent();
            XtraReport1 obj = new XtraReport1();
            obj.CreateDocument();
            printControl1.PrintingSystem = obj.PrintingSystem;
        }
    }
}