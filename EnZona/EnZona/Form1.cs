using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using System.Windows.Forms.DataVisualization.Charting;


namespace EnZona
{
    public partial class Form1 : XtraForm
    {
        int id;
        string[] reporte1; string[] reporte2; string[] reporte3; string[] reporte4; string[] reporte5;
        int vb;
        
        public Form1()
        {
            InitializeComponent();
            InitSkinGallery();
            id = -1;
            reporte1 = new string[13]; reporte2 = new string[13];
            reporte3 = new string[5]; reporte4 = new string[12];
            reporte5 = new string[6]; vb = 0;
        }
        void InitSkinGallery()
        {
            //SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        BindingList<Person> gridDataList = new BindingList<Person>();

        private void iNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Juego obj = new Juego();
            obj.ShowDialog();
        }

        private void iExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enZonaBDDataSet.Comparecencia' table. You can move, or remove it, as needed.
            this.comparecenciaTableAdapter.Fill(this.enZonaBDDataSet.Comparecencia);
            xtraTabPage2.PageEnabled = false;
            xtraTabPage3.PageEnabled = false;
            xtraTabPage4.PageEnabled = false;
            xtraTabPage5.PageEnabled = false;
            barButtonItem4.Enabled = false;
        }

        private void bt_pinar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores, "Pinar de Río");
            barButtonItem4.Enabled = false; id = -1;
            xtraTabPage2.PageEnabled = false;xtraTabPage3.PageEnabled = false;xtraTabPage4.PageEnabled = false;xtraTabPage5.PageEnabled = false;
        }

        private void bt_artemisa_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores, "Artemisa");
            barButtonItem4.Enabled = false; id = -1;
            xtraTabPage2.PageEnabled = false; xtraTabPage3.PageEnabled = false;xtraTabPage4.PageEnabled = false; xtraTabPage5.PageEnabled = false;
        }

        private void bt_mayabeque_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores, "Mayabeque");
            barButtonItem4.Enabled = false; id = -1;
            xtraTabPage2.PageEnabled = false; xtraTabPage3.PageEnabled = false; xtraTabPage4.PageEnabled = false; xtraTabPage5.PageEnabled = false;
        }

        private void bt_industriales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores, "Industriales");
            barButtonItem4.Enabled = false; id = -1;
            xtraTabPage2.PageEnabled = false; xtraTabPage3.PageEnabled = false; xtraTabPage4.PageEnabled = false; xtraTabPage5.PageEnabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Int32 rowSelect = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                id = int.Parse(this.dataGridView1.Rows[rowSelect].Cells[0].Value.ToString());

                if (id > 0)
                {
                    xtraTabPage2.PageEnabled = true; reporte1 = ZonaStrike(); labelControl68.Text = Comparecencia().ToString();
                    xtraTabPage3.PageEnabled = true; reporte2 = ZonaHit(); reporte3 = Tendencia();
                    xtraTabPage4.PageEnabled = true; reporte4 = Agresividad(); labelControl69.Text = labelControl68.Text;
                    xtraTabPage5.PageEnabled = true; reporte5 = RegionBateo(); GraficaVelocidadVB();
                    barButtonItem4.Enabled = true;
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione correctamente la fila");
                xtraTabPage2.PageEnabled = false; xtraTabPage3.PageEnabled = false; xtraTabPage4.PageEnabled = false;
                xtraTabPage5.PageEnabled = false;
            }
        }

        private int Comparecencia()
        {
            DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
            int resultado = 0;
            if (x.Rows.Count == 0)
            {
                x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
            }
            resultado = x.Rows.Count;
            vb = resultado;
            return resultado;
        }

        public byte[] DesConvertirByte(string x)
        {
            byte[] conv = Convert.FromBase64String(x);
            return conv;
        }

        public byte[] Recortar(byte[] x)
        {
            int cont = 0;
            for (int q = 0; q < x.Length; q++)
            {
                if (x[q] != 0)
                {
                    cont++;
                }
            }
            byte[] aux = new byte[cont];
            for (int i = 0; i < cont; i++)
            {
                aux[i] = x[i];
            }
            return aux;
        }

        public byte[] RecorBallStrike(byte[] x)
        {
            int cont = 0;
            for (int q = 0; q < x.Length; q++)
            {
                if (x[q] != 7)
                {
                    cont++;
                }
            }
            byte[] aux = new byte[cont];
            for (int i = 0; i < cont; i++)
            {
                aux[i] = x[i];
            }
            return aux;
        }

        public string[] ZonaStrike()
        {
            DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
            if (x.Rows.Count == 0)
            {
                x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
            }
            byte[] pos = new byte[13];
            byte[] y = new byte[x.Rows.Count];
            byte[] swing = new byte[x.Rows.Count];
            int contador = 0;
            for (int i = 0; i < x.Rows.Count; i++)
            {
                y = DesConvertirByte(x.Rows[i].ItemArray[3].ToString());
                swing = DesConvertirByte(x.Rows[i].ItemArray[4].ToString());//tengo la Zona de Strike de cada fila(comparecencia)
                swing = RecorBallStrike(swing);
                y = Recortar(y);
                if ((x.Rows[i].ItemArray[5]).ToString() != "K" && (x.Rows[i].ItemArray[5]).ToString() != "BB")
                {
                    if (y.Length != 1)
                    {
                        for (int j = 0; j < y.Length - 1; j++)
                        {
                            if ((y[j] != 10) && (y[j] != 11) && (y[j] != 12) && (y[j] != 13))
                            {
                                pos[(y[j] - 1)]++;  // va a tener la cantidad de lanzamientos en cada zona
                                contador++;
                            }
                            else
                            {
                                if (swing[j] == 1)
                                {
                                    pos[(y[j] - 1)]++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < y.Length - 1; j++)
                    {
                        if ((y[j] != 10) && (y[j] != 11) && (y[j] != 12) && (y[j] != 13))
                        {
                            pos[(y[j] - 1)]++;  // va a tener la cantidad de lanzamientos en cada zona
                            contador++;
                        }
                        else
                        {
                            if (swing[j] == 1)
                            {
                                pos[(y[j] - 1)]++;
                            }                            
                        }
                    }
                    if ((x.Rows[i].ItemArray[5]).ToString() == "K")
                    {
                        pos[(y[y.Length - 1])-1]++;
                    }
                }
            }
            if (contador == 0) { contador++; }
            string[] reporte = new string[13];
            for (int k = 0; k < 12 + 1; k++)
            {
                switch (k)
                {
                    case 0:
                        labelControl1.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl1.Text;
                        break;
                    case 1:
                        labelControl2.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl2.Text;
                        break;
                    case 2:
                        labelControl3.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl3.Text;
                        break;
                    case 3:
                        labelControl4.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl4.Text;
                        break;
                    case 4:
                        labelControl5.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl5.Text;
                        break;
                    case 5:
                        labelControl6.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl6.Text;
                        break;
                    case 6:
                        labelControl7.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl7.Text;
                        break;
                    case 7:
                        labelControl8.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl8.Text;
                        break;
                    case 8:
                        labelControl9.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl9.Text;
                        break;
                    case 9:
                        labelControl10.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl10.Text;
                        break;
                    case 10:
                        labelControl11.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl11.Text;
                        break;
                    case 11:
                        labelControl12.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl12.Text;
                        break;
                    case 12:
                        labelControl13.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl13.Text;
                        break;
                }
            }
            return reporte;
        }

        public string[] ZonaHit()
        {
            DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
            if (x.Rows.Count == 0)
            {
                x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
            }
            byte[] pos = new byte[13];
            byte[] y = new byte[x.Rows.Count];
            int contador = 0;
            int ultimo = 0;
            for (int i = 0; i < x.Rows.Count; i++)
            {
                y = DesConvertirByte(x.Rows[i].ItemArray[3].ToString());
                if (x.Rows[i].ItemArray[5].ToString() != "BB" && x.Rows[i].ItemArray[5].ToString() != "K" && x.Rows[i].ItemArray[5].ToString() != "Out" && x.Rows[i].ItemArray[5].ToString() != "DB")
                {
                    for (int z = 0; z < y.Length; z++)
                    {
                        if (y[z] != 0)
                        {
                            ultimo = y[z];
                        }
                    }
                    pos[ultimo - 1]++;  // va a tener la cantidad de lanzamientos en cada zona
                    contador++;
                }
            }
            if (contador == 0) { contador++; }
            string[] reporte = new string[13];
            for (int k = 0; k < 13 + 1; k++)
            {
                switch (k)
                {
                    case 0:
                        labelControl14.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl14.Text;
                        break;
                    case 1:
                        labelControl15.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl15.Text;
                        break;
                    case 2:
                        labelControl16.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl16.Text;
                        break;
                    case 3:
                        labelControl17.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl17.Text;
                        break;
                    case 4:
                        labelControl18.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl18.Text;
                        break;
                    case 5:
                        labelControl19.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl19.Text;
                        break;
                    case 6:
                        labelControl20.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl20.Text;
                        break;
                    case 7:
                        labelControl21.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl21.Text;
                        break;
                    case 8:
                        labelControl22.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl22.Text;
                        break;
                    case 9:
                        labelControl23.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl23.Text;
                        break;
                    case 10:
                        labelControl24.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl24.Text;
                        break;
                    case 11:
                        labelControl25.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl25.Text;
                        break;
                    case 12:
                        labelControl26.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl26.Text;
                        break;
                }
            }
            return reporte;
        }

        public string[] Tendencia()
        {
            DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
            if (x.Rows.Count == 0)
            {
                x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
            }
            byte[] y = new byte[x.Rows.Count];
            float contador = 0;
            float l1 = 0; float l2 = 0; float l3 = 0; float l4 = 0; float l5 = 0;
            for (int i = 0; i < x.Rows.Count; i++)
            {
                y = DesConvertirByte(x.Rows[i].ItemArray[2].ToString());
                y = Recortar(y);
                if (x.Rows[i].ItemArray[5].ToString() != "BB" && x.Rows[i].ItemArray[5].ToString() != "K" && x.Rows[i].ItemArray[5].ToString() != "Out" && x.Rows[i].ItemArray[5].ToString() != "DB" && x.Rows[i].ItemArray[5].ToString() != "Error")
                {
                    switch (y[y.Length - 1])
                    {
                        case 1:
                            l1++;
                            break;
                        case 2:
                            l2++;
                            break;
                        case 3:
                            l3++;
                            break;
                        case 4:
                            l4++;
                            break;
                        case 5:
                            l5++;
                            break;
                    }
                    contador++;
                }
            }
            if (contador == 0) { contador++; }
            string[] reporte = new string[5];
            labelControl32.Text = ((l1 / contador) * 100).ToString() + " %"; reporte[0] = labelControl32.Text;
            labelControl33.Text = ((l2 / contador) * 100).ToString() + " %"; reporte[1] = labelControl33.Text;
            labelControl34.Text = ((l3 / contador) * 100).ToString() + " %"; reporte[2] = labelControl34.Text;
            labelControl35.Text = ((l4 / contador) * 100).ToString() + " %"; reporte[3] = labelControl35.Text;
            labelControl36.Text = ((l5 / contador) * 100).ToString() + " %"; reporte[4] = labelControl36.Text;
            return reporte;
        }

        public string[] Agresividad()
        {
            DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
            if (x.Rows.Count == 0)
            {
                x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
            }
            byte[] ball = new byte[x.Rows.Count];
            byte[] strike = new byte[x.Rows.Count];
            byte[] swing = new byte[x.Rows.Count];

            int s = 0; int b = 0; double contador = 0; bool flag = true;

            double[] array = new double[12];

            for (int i = 0; i < x.Rows.Count; i++)
            {
                ball = DesConvertirByte(x.Rows[i].ItemArray[8].ToString());
                strike = DesConvertirByte(x.Rows[i].ItemArray[7].ToString());
                swing = DesConvertirByte(x.Rows[i].ItemArray[4].ToString());
                ball = RecorBallStrike(ball);
                strike = RecorBallStrike(strike);
                int suma = ball.Length + strike.Length;
                suma = suma / 2;
                swing = RecorBallStrike(swing); b = 0; s = 0;
                for (int j = 0; j < suma; j++)
                {
                    flag = false;
                    if (swing[j] == 1)
                    {
                        flag = true;
                        // le hizo swing vamos a coger el conteo entonces
                        switch (b)
                        {
                            case 0:
                                switch (s)
                                {
                                    case 0:
                                        //aki se guarda el dato del conteo 0 - 0
                                        array[0]++;
                                        break;
                                    case 1:
                                        //aki se guarda el dato del conteo 0 - 1
                                        array[1]++;
                                        break;
                                    case 2:
                                        //aki se guarda el dato del conteo 0 - 2
                                        array[2]++;
                                        break;
                                }
                                break;
                            case 1:
                                switch (s)
                                {
                                    case 0:
                                        //aki se guarda el dato del conteo 1 - 0
                                        array[3]++;
                                        break;
                                    case 1:
                                        //aki se guarda el dato del conteo 1 - 1
                                        array[4]++;
                                        break;
                                    case 2:
                                        //aki se guarda el dato del conteo 1 - 2
                                        array[5]++;
                                        break;
                                }
                                break;
                            case 2:
                                switch (s)
                                {
                                    case 0:
                                        //aki se guarda el dato del conteo 2 - 0
                                        array[6]++;
                                        break;
                                    case 1:
                                        //aki se guarda el dato del conteo 2 - 1
                                        array[7]++;
                                        break;
                                    case 2:
                                        //aki se guarda el dato del conteo 2 - 2
                                        array[8]++;
                                        break;
                                }
                                break;
                            case 3:
                                switch (s)
                                {
                                    case 0:
                                        //aki se guarda el dato del conteo 3 - 0
                                        array[9]++;
                                        break;
                                    case 1:
                                        //aki se guarda el dato del conteo 3 - 1
                                        array[10]++;
                                        break;
                                    case 2:
                                        //aki se guarda el dato del conteo 3 - 2
                                        array[11]++;
                                        break;
                                }
                                break;

                        }
                        if (flag)
                        {
                            if (strike[j] == 1)
                            {
                                if (s != 2)
                                {
                                    s++;
                                }
                            }
                            else if (ball[j] == 1)
                            {
                                if (b != 3)
                                {
                                    b++;
                                }
                            }
                            contador++;
                        }                        
                    }
                    if (flag == false)
                    {
                        if (strike[j] == 1)
                        {
                            s++;
                        }
                        else if (ball[j] == 1)
                        {
                            b++;
                        }
                    }                    
                }
            }
            string[] reporte = new string[12];
            if (contador != 0)
            {
                labelControl49.Text = ((array[0] / contador) * 100).ToString() + " %"; labelControl50.Text = ((array[1] / contador) * 100).ToString() + " %";
                labelControl51.Text = ((array[2] / contador) * 100).ToString() + " %"; labelControl52.Text = ((array[3] / contador) * 100).ToString() + " %";
                labelControl53.Text = ((array[4] / contador) * 100).ToString() + " %"; labelControl54.Text = ((array[5] / contador) * 100).ToString() + " %";
                labelControl55.Text = ((array[6] / contador) * 100).ToString() + " %"; labelControl56.Text = ((array[7] / contador) * 100).ToString() + " %";
                labelControl57.Text = ((array[8] / contador) * 100).ToString() + " %"; labelControl58.Text = ((array[9] / contador) * 100).ToString() + " %";
                labelControl59.Text = ((array[10] / contador) * 100).ToString() + " %"; labelControl60.Text = ((array[11] / contador) * 100).ToString() + " %";
            }
            else
            {
                labelControl49.Text = "0 %"; labelControl51.Text = "0 %"; labelControl53.Text = "0 %"; labelControl55.Text = "0 %"; labelControl57.Text = "0 %"; labelControl59.Text = "0 %";
                labelControl50.Text = "0 %"; labelControl52.Text = "0 %"; labelControl54.Text = "0 %"; labelControl56.Text = "0 %"; labelControl58.Text = "0 %"; labelControl60.Text = "0 %";
            }
            reporte[0] = labelControl49.Text; reporte[1] = labelControl50.Text; reporte[2] = labelControl51.Text;
            reporte[3] = labelControl52.Text; reporte[4] = labelControl53.Text; reporte[5] = labelControl54.Text;
            reporte[6] = labelControl55.Text; reporte[7] = labelControl56.Text; reporte[8] = labelControl57.Text;
            reporte[9] = labelControl58.Text; reporte[10] = labelControl59.Text; reporte[11] = labelControl60.Text;
            return reporte;
        }

        public string[] RegionBateo()
        {
            DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
            if (x.Rows.Count == 0)
            {
                x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
            }
            byte[] pos = new byte[6];
            byte[] y = new byte[x.Rows.Count];
            int contador = 0;
            string ultimo;
            for (int i = 0; i < x.Rows.Count; i++)
            {
                ultimo = x.Rows[i].ItemArray[6].ToString();
                if (x.Rows[i].ItemArray[5].ToString() != "BB" && x.Rows[i].ItemArray[5].ToString() != "K" && x.Rows[i].ItemArray[5].ToString() != "DB")
                {
                    switch (byte.Parse(ultimo))
                    {
                        case 1:
                            pos[0]++;
                            break;
                        case 2:
                            pos[1]++;
                            break;
                        case 3:
                            pos[2]++;
                            break;
                        case 4:
                            pos[3]++;
                            break;
                        case 5:
                            pos[4]++;
                            break;
                        case 6:
                            pos[5]++;
                            break;
                    }
                    contador++;
                }
            }
            if (contador == 0) { contador++; }
            string[] reporte = new string[6];
            for (int k = 0; k < 6; k++)
            {
                switch (k)
                {
                    case 0:
                        labelControl61.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl61.Text;
                        break;
                    case 1:
                        labelControl62.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl62.Text;
                        break;
                    case 2:
                        labelControl63.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl63.Text;
                        break;
                    case 3:
                        labelControl64.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl64.Text;
                        break;
                    case 4:
                        labelControl65.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl65.Text;
                        break;
                    case 5:
                        labelControl66.Text = ((pos[k] * 100) / contador).ToString() + " %";
                        reporte[k] = labelControl66.Text;
                        break;
                }
            }
            return reporte;
        }

        public string[] GraficaVelocidadVB()
        {
            try
            {
                DataTable x = this.comparecenciaTableAdapter.GetDataByIdBateador(id);
                if (x.Rows.Count == 0)
                {
                    x = this.comparecenciaTableAdapter.GetDataByIdPitcher(id);
                }

                byte[] y = new byte[x.Rows.Count];
                //********************************Esto para determinar la cantidad de Rectas lanzadas**************************************
                int l1 = 0; int l2 = 0; int l3 = 0; int l4 = 0; int cantL = 0;
                for (int i = 0; i < x.Rows.Count; i++)
                {
                    y = DesConvertirByte(x.Rows[i].ItemArray[2].ToString());
                    y = Recortar(y);
                    for (int j = 0; j < y.Length; j++)
                    {
                        switch (y[j])
                        {
                            case 1:
                                l1++;
                                break;
                            case 2:
                                l2++;
                                break;
                            case 3:
                                l3++;
                                break;
                            case 4:
                                l4++;
                                break;
                        }
                        cantL++;
                    }

                }


                //**********************************************************************

                byte[] pos = new byte[13];
                byte[] mph = new byte[x.Rows.Count];
                byte[] lanzamiento = new byte[x.Rows.Count];
                int[] pointsArray = new int[l1];  // ahi ke obterner la cantidad de Rectas lanzadas(para inicializar el array)
                int cont = 0;


                this.chart1.Titles.Add("Este es el Titulo");
                string[] seriesArray = { "Recta", "Categoria 2", "Categoria 3" };
                Series series = this.chart1.Series.Add(seriesArray[0]);


                for (int i = 0; i < x.Rows.Count; i++)
                {
                    mph = DesConvertirByte(x.Rows[i].ItemArray[9].ToString());
                    lanzamiento = DesConvertirByte(x.Rows[i].ItemArray[2].ToString());
                    mph = Recortar(mph);
                    lanzamiento = Recortar(lanzamiento);
                    for (int j = 0; j < lanzamiento.Length; j++)
                    {
                        if (lanzamiento[j] == 1)
                        {
                            pointsArray[cont] = mph[j];
                            cont++;
                        }
                    }
                }
                for (int k = 0; k < pointsArray.Length; k++)
                {
                    series.Points.Add(pointsArray[k]);
                }
               
                
            }
            catch (Exception)
            {
               MessageBox.Show("Error en la Gráfica de Velocidad");
            }
            string[] result = new string[1]; // esta mierdfa la hice para debolber algo
            return result;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Int32 rowSelect = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            FormReporte obj = new FormReporte(this.dataGridView1.Rows[rowSelect].Cells[1].Value.ToString(),
                this.dataGridView1.Rows[rowSelect].Cells[2].Value.ToString(),
                this.dataGridView1.Rows[rowSelect].Cells[3].Value.ToString(), reporte1, reporte2, reporte3, reporte4, reporte5, vb);
            obj.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditarJugador obj = new EditarJugador();
            obj.ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EliminarJugador obj = new EliminarJugador();
            obj.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnadirJugador obj = new AnadirJugador();
            obj.ShowDialog();
        }

        private void bt_matanza_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores, "Matanza");
            barButtonItem4.Enabled = false; id = -1;
            xtraTabPage2.PageEnabled = false; xtraTabPage3.PageEnabled = false; xtraTabPage4.PageEnabled = false; xtraTabPage5.PageEnabled = false;
        }

        private void bt_isla_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores, "Isla de la Juventud");
            barButtonItem4.Enabled = false; id = -1;
            xtraTabPage2.PageEnabled = false; xtraTabPage3.PageEnabled = false; xtraTabPage4.PageEnabled = false; xtraTabPage5.PageEnabled = false;
        }
    }
}