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
    public partial class Juego : DevExpress.XtraEditors.XtraForm
    {
        int idBateador;
        int idPitcher;
        int regionBateo;
        string conexionBateo;
        byte[] lanzamiento;
        byte[] zonaBateo;
        byte[] swing;
        string conteoBateo;
        int strike; int ball; int ultimoLance;
        byte[] arrStrike;
        byte[] arrBall;
        byte[] mph;
        int inn;
        string embasado;

        //************************** variables auxiliares
        string[] imagenes = {"imagen\\1B.png","imagen\\2B.png","imagen\\3B.png","imagen\\RF.png",
                "imagen\\CF.png","imagen\\LF.png","imagen\\1Bs.png","imagen\\2Bs.png","imagen\\3Bs.png",
                "imagen\\RFs.png","imagen\\CFs.png","imagen\\LFs.png","imagen\\y.gif"};
        string[] imagenes1 = { "imagen\\cuadro1.png", "imagen\\cuadro2.png", "imagen\\cuadro3.png",
                                 "imagen\\cuadro4.png", "imagen\\cuadro5.png", "imagen\\ball.png",
                             "imagen\\ball1.png"};
        string[] imagenes2 = { "imagen\\img_jug\\kien1.png", "imagen\\img_jug\\" };
        bool lanzamiento1, lanzamiento2, lanzamiento3, lanzamiento4, lanzamiento5, bate;
        int contador;

        public Juego()
        {
            InitializeComponent();

            regionBateo = -1;
            lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false; lanzamiento4 = false; lanzamiento5 = false; bate = false;
            lanzamiento = new byte[12];            // esta cantidad(de 12) puede variar en dpendencia de la cant de lanz ke ha realizado un pitcher
            zonaBateo = new byte[12];              // esta es la zonaDeBateo x cada lanzamiento pitchado  
            swing = new byte[12];                  // si se le ha realizado swing a la bola
            conteoBateo = ""; conexionBateo = "";
            idBateador = -1; idPitcher = -1;
            contador = 0;
            strike = 0; ball = 0; ultimoLance = 0;
            arrStrike = new byte[12];
            arrBall = new byte[12];
            mph = new byte[12];
            inn = 0;
            embasado = "";
            for (int i = 0; i < arrStrike.Length; i++)
            {
                arrStrike[i] = 7;
                arrBall[i] = 7;
                swing[i] = 7;
            }

            //personales
            pictureEdit1.Image = Image.FromFile(imagenes2[0]); pictureEdit2.Image = Image.FromFile(imagenes2[0]);

            //strikes
            pictureEdit3.Image = Image.FromFile(imagenes1[0]); pictureEdit4.Image = Image.FromFile(imagenes1[4]); pictureEdit5.Image = Image.FromFile(imagenes1[1]);
            pictureEdit6.Image = Image.FromFile(imagenes1[4]); pictureEdit7.Image = Image.FromFile(imagenes1[4]); pictureEdit8.Image = Image.FromFile(imagenes1[4]);
            pictureEdit9.Image = Image.FromFile(imagenes1[2]); pictureEdit10.Image = Image.FromFile(imagenes1[4]); pictureEdit11.Image = Image.FromFile(imagenes1[3]);

            //balls
            pictureEdit13.Image = Image.FromFile(imagenes1[5]); pictureEdit14.Image = Image.FromFile(imagenes1[5]);
            pictureEdit12.Image = Image.FromFile(imagenes1[6]); pictureEdit15.Image = Image.FromFile(imagenes1[6]);
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            //this.comparecenciaTableAdapter.Fill(this.enZonaBDDataSet.Comparecencia);
            groupControl2.Enabled = false;
        }

        public string ConvertirByte(byte[] x)
        {
            string conv = Convert.ToBase64String(x);
            return conv;
        }

        public void ResetearPitcher()
        {
            pictureEdit2.Image = Image.FromFile(imagenes2[0]);
            labelControl16.Text = ""; labelControl17.Text = ""; labelControl18.Text = ""; labelControl19.Text = ""; labelControl20.Text = "";

            idPitcher = -1;
            lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false; lanzamiento4 = false;
            lanzamiento = new byte[12];            // esta cantidad(de 12) puede variar en dpendencia de la cant de lanz ke ha realizado un pitcher
            zonaBateo = new byte[12];              // esta es la zonaDeBateo x cada lanzamiento pitchado  
            swing = new byte[12];
            conteoBateo = ""; conexionBateo = "";
            contador = 0;
            strike = 0;
            ball = 0;
            labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            ultimoLance = 0;
            arrStrike = new byte[12];
            arrBall = new byte[12];
            for (int i = 0; i < arrStrike.Length; i++)
            {
                arrStrike[i] = 7;
                arrBall[i] = 7;
                swing[i] = 7;
            }
        }

        public void ResetearBateador()
        {
            pictureEdit1.Image = Image.FromFile(imagenes2[0]);
            labelControl11.Text = ""; labelControl12.Text = ""; labelControl13.Text = ""; labelControl14.Text = ""; labelControl15.Text = "";

            idBateador = -1;
            lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false; lanzamiento4 = false;
            lanzamiento = new byte[12];            // esta cantidad(de 12) puede variar en dpendencia de la cant de lanz ke ha realizado un pitcher
            zonaBateo = new byte[12];              // esta es la zonaDeBateo x cada lanzamiento pitchado  
            swing = new byte[12];
            conteoBateo = ""; conexionBateo = "";
            contador = 0;
            strike = 0;
            ball = 0;
            labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            ultimoLance = 0;
            arrStrike = new byte[12];
            arrBall = new byte[12];
            for (int i = 0; i < arrStrike.Length; i++)
            {
                arrStrike[i] = 7;
                arrBall[i] = 7;
                swing[i] = 7;
            }
        }

        public void ResetearDatos()
        {
            regionBateo = -1;
            lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false; lanzamiento4 = false;
            lanzamiento = new byte[12];            // esta cantidad(de 12) puede variar en dpendencia de la cant de lanz ke ha realizado un pitcher
            zonaBateo = new byte[12];              // esta es la zonaDeBateo x cada lanzamiento pitchado  
            swing = new byte[12];
            conteoBateo = ""; conexionBateo = "";
            idBateador = -1; idPitcher = -1;
            contador = 0;
            strike = 0;
            ball = 0;
            labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            ultimoLance = 0;
            arrStrike = new byte[12];
            arrBall = new byte[12];
            for (int i = 0; i < arrStrike.Length; i++)
            {
                arrStrike[i] = 7;
                arrBall[i] = 7;
                swing[i] = 7;
            }
        }

        public void ResetearVisual()
        {
            //strikes
            pictureEdit3.Image = Image.FromFile(imagenes1[0]); pictureEdit4.Image = Image.FromFile(imagenes1[4]); pictureEdit5.Image = Image.FromFile(imagenes1[1]);
            pictureEdit6.Image = Image.FromFile(imagenes1[4]); pictureEdit7.Image = Image.FromFile(imagenes1[4]); pictureEdit8.Image = Image.FromFile(imagenes1[4]);
            pictureEdit9.Image = Image.FromFile(imagenes1[2]); pictureEdit10.Image = Image.FromFile(imagenes1[4]); pictureEdit11.Image = Image.FromFile(imagenes1[3]);

            //balls
            pictureEdit13.Image = Image.FromFile(imagenes1[5]); pictureEdit14.Image = Image.FromFile(imagenes1[5]);
            pictureEdit12.Image = Image.FromFile(imagenes1[6]); pictureEdit15.Image = Image.FromFile(imagenes1[6]);

            pictureEdit18.Image = Image.FromFile(imagenes[2]); pictureEdit16.Image = Image.FromFile(imagenes[0]); pictureEdit17.Image = Image.FromFile(imagenes[1]);
            pictureEdit19.Image = Image.FromFile(imagenes[3]); pictureEdit20.Image = Image.FromFile(imagenes[4]); pictureEdit21.Image = Image.FromFile(imagenes[5]);

            labelControl11.Text = ""; labelControl12.Text = ""; labelControl13.Text = ""; labelControl14.Text = ""; labelControl15.Text = "";
            labelControl16.Text = ""; labelControl17.Text = ""; labelControl18.Text = ""; labelControl19.Text = ""; labelControl20.Text = "";

            pictureEdit1.Image = Image.FromFile(imagenes2[0]); pictureEdit2.Image = Image.FromFile(imagenes2[0]);
            comboBoxEdit1.ResetText(); textEdit1.Text = ""; comboBoxEdit4.ResetText(); comboBoxEdit5.ResetText(); comboBoxEdit6.ResetText(); comboBoxEdit7.ResetText();
        }       

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetearBateador(); ResetearVisual(); groupControl2.Enabled = false; idPitcher = -1;
            if ((comboBoxEdit2.SelectedIndex == null || comboBoxEdit3.SelectedIndex == null) && (comboBoxEdit2.SelectedIndex == comboBoxEdit3.SelectedIndex))
            {
                groupControl2.Enabled = false;
                ResetearVisual(); ResetearDatos();
            }
            else
            {
                labelControl11.Text = ""; labelControl12.Text = ""; labelControl13.Text = ""; labelControl14.Text = ""; labelControl15.Text = "";
                groupControl2.Enabled = false;
                if (comboBoxEdit2.SelectedIndex == 0)
                {
                    try
                    {
                        this.jugadoresTableAdapter.FillByProvinciaBateador(this.enZonaBDDataSet.Jugadores, "Pinar de Río", "p");
                        //this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                if (comboBoxEdit2.SelectedIndex == 1)
                {
                    try
                    {
                        this.jugadoresTableAdapter.FillByProvinciaBateador(this.enZonaBDDataSet.Jugadores, "Artemisa", "p");
                        //this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit2.SelectedIndex == 2)// Industriales Matanza Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter.FillByProvinciaBateador(this.enZonaBDDataSet.Jugadores, "Mayabeque", "p");
                        //this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit2.SelectedIndex == 3)//  Matanza Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter.FillByProvinciaBateador(this.enZonaBDDataSet.Jugadores, "Industriales", "p");
                        //this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit2.SelectedIndex == 4)//   Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter.FillByProvinciaBateador(this.enZonaBDDataSet.Jugadores, "Matanza", "p");
                        //this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit2.SelectedIndex == 5)                {
                    try
                    {
                        this.jugadoresTableAdapter.FillByProvinciaBateador(this.enZonaBDDataSet.Jugadores, "Isla de la Juventud", "p");
                        //this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } 
        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetearPitcher(); ResetearVisual(); groupControl2.Enabled = false; idBateador = -1;
            if ((comboBoxEdit2.SelectedIndex == null || comboBoxEdit3.SelectedIndex == null) && comboBoxEdit2.SelectedIndex == comboBoxEdit3.SelectedIndex)
            {
                groupControl2.Enabled = false;
                ResetearVisual(); ResetearDatos();
            }
            else
            {
                labelControl16.Text = ""; labelControl17.Text = ""; labelControl18.Text = ""; labelControl19.Text = ""; labelControl20.Text = "";
                groupControl2.Enabled = false;

                if (comboBoxEdit3.SelectedIndex == 0)
                {
                    try
                    {
                        this.jugadoresTableAdapter1.FillByProvinciaPichet(this.enZonaBDDataSet1.Jugadores, "Pinar de Río", "p");
                        //this.jugadoresTableAdapter1.Fill(this.enZonaBDDataSet1.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                if (comboBoxEdit3.SelectedIndex == 1)// Industriales Matanza Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter1.FillByProvinciaPichet(this.enZonaBDDataSet1.Jugadores, "Artemisa", "p");
                        //this.jugadoresTableAdapter1.Fill(this.enZonaBDDataSet1.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit3.SelectedIndex == 2)// Industriales Matanza Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter1.FillByProvinciaPichet(this.enZonaBDDataSet1.Jugadores, "Mayabeque", "p");
                        //this.jugadoresTableAdapter1.Fill(this.enZonaBDDataSet1.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit3.SelectedIndex == 3)//  Matanza Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter1.FillByProvinciaPichet(this.enZonaBDDataSet1.Jugadores, "Industriales", "p");
                        //this.jugadoresTableAdapter1.Fill(this.enZonaBDDataSet1.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit3.SelectedIndex == 4)//   Isla de la Juventud
                {
                    try
                    {
                        this.jugadoresTableAdapter1.FillByProvinciaPichet(this.enZonaBDDataSet1.Jugadores, "Matanza", "p");
                        //this.jugadoresTableAdapter1.Fill(this.enZonaBDDataSet1.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (comboBoxEdit3.SelectedIndex == 5)//   
                {
                    try
                    {
                        this.jugadoresTableAdapter1.FillByProvinciaPichet(this.enZonaBDDataSet1.Jugadores, "Isla de la Juventud", "p");
                        //this.jugadoresTableAdapter1.Fill(this.enZonaBDDataSet1.Jugadores);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la conexión en la Base de Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {           
            if (regionBateo == -1 && comboBoxEdit1.Text != "K" && comboBoxEdit1.Text != "BB" && comboBoxEdit1.Text != "DB" && comboBoxEdit1.Text != "")
            {
                comboBoxEdit1.ResetText();
                MessageBox.Show("Error, Debe seleccional la región de la conexión que se seleccionó");
            }
            else if ((regionBateo != -1 && comboBoxEdit1.Text != "Hit") && (regionBateo != -1 && comboBoxEdit1.Text != "Doble") &&
                (regionBateo != -1 && comboBoxEdit1.Text != "Triple") && (regionBateo != -1 && comboBoxEdit1.Text != "Jonron") &&
                (regionBateo != -1 && comboBoxEdit1.Text != "Error") && (regionBateo != -1 && comboBoxEdit1.Text != "Out"))
            {
                comboBoxEdit1.ResetText();
                pictureEdit18.Image = Image.FromFile(imagenes[2]); pictureEdit16.Image = Image.FromFile(imagenes[0]); pictureEdit17.Image = Image.FromFile(imagenes[1]);
                pictureEdit19.Image = Image.FromFile(imagenes[3]); pictureEdit20.Image = Image.FromFile(imagenes[4]); pictureEdit21.Image = Image.FromFile(imagenes[5]);
            }
            else if (contador == 0)
            {
                MessageBox.Show("Error, Debe de seleccionar algun lanzamiento");
            }
            else if (idBateador == -1 || idPitcher == -1)
            {
                MessageBox.Show("Error, Debe de seleccionar pitcher y bateador");
            }
            else if (comboBoxEdit4.Text != "1" && comboBoxEdit4.Text != "2" && comboBoxEdit4.Text != "3" && comboBoxEdit4.Text != "4" &&
                comboBoxEdit4.Text != "5" && comboBoxEdit4.Text != "6" && comboBoxEdit4.Text != "7" && comboBoxEdit4.Text != "8" &&
                comboBoxEdit4.Text != "9" && comboBoxEdit4.Text != "10" && comboBoxEdit4.Text != "11" && comboBoxEdit4.Text != "12" &&
                comboBoxEdit4.Text != "13")
            {
                MessageBox.Show("Error, Debe de seleccionar el Inning");
            }
            else if (comboBoxEdit7.Text != "0" && comboBoxEdit7.Text != "1" || comboBoxEdit6.Text != "0" && comboBoxEdit6.Text != "1" ||
                comboBoxEdit5.Text != "0" && comboBoxEdit5.Text != "1")
            {
                MessageBox.Show("Error, Debe de seleccionar los embasados");
            }
            else
            {
                try
                {
                    if (comboBoxEdit1.Text != "K" && comboBoxEdit1.Text != "BB" && comboBoxEdit1.Text != "DB")
                    {
                        swing[contador - 1] = 1;
                        arrBall[contador - 1] = 0;
                        arrStrike[contador - 1] = 0;
                    }
                    inn = int.Parse(comboBoxEdit4.Text);
                    embasado = comboBoxEdit7.Text + comboBoxEdit6.Text + comboBoxEdit5.Text;
                    conexionBateo = comboBoxEdit1.Text;
                    string p1 = ConvertirByte(lanzamiento); string p2 = ConvertirByte(zonaBateo); string p3 = ConvertirByte(swing);
                    string p4 = ConvertirByte(arrStrike); string p5 = ConvertirByte(arrBall); string p6 = ConvertirByte(mph);
                    this.comparecenciaTableAdapter.InsertComparecencia(idPitcher, idBateador, p1, p2, p3, conexionBateo, regionBateo, p4, p5,p6,inn,embasado);
                    ResetearDatos(); ResetearVisual();
                    groupControl2.Enabled = false; comboBoxEdit1.Enabled = false;
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al enviar los datos");
                }

            }
        }

        private void pictureEdit21_Click(object sender, EventArgs e)
        {
            pictureEdit21.Image = Image.FromFile(imagenes[5 + 6]);
            regionBateo = 6;
            pictureEdit16.Image = Image.FromFile(imagenes[0]);
            pictureEdit17.Image = Image.FromFile(imagenes[1]);
            pictureEdit19.Image = Image.FromFile(imagenes[3]);
            pictureEdit20.Image = Image.FromFile(imagenes[4]);
            pictureEdit18.Image = Image.FromFile(imagenes[2]);
        }

        private void pictureEdit20_Click(object sender, EventArgs e)
        {
            pictureEdit20.Image = Image.FromFile(imagenes[4 + 6]);
            regionBateo = 5;
            pictureEdit16.Image = Image.FromFile(imagenes[0]);
            pictureEdit17.Image = Image.FromFile(imagenes[1]);
            pictureEdit19.Image = Image.FromFile(imagenes[3]);
            pictureEdit18.Image = Image.FromFile(imagenes[2]);
            pictureEdit21.Image = Image.FromFile(imagenes[5]);
        }

        private void pictureEdit19_Click(object sender, EventArgs e)
        {
            pictureEdit19.Image = Image.FromFile(imagenes[3 + 6]);
            regionBateo = 4;
            pictureEdit16.Image = Image.FromFile(imagenes[0]);
            pictureEdit17.Image = Image.FromFile(imagenes[1]);
            pictureEdit18.Image = Image.FromFile(imagenes[2]);
            pictureEdit20.Image = Image.FromFile(imagenes[4]);
            pictureEdit21.Image = Image.FromFile(imagenes[5]);
        }

        private void pictureEdit18_Click(object sender, EventArgs e)
        {
            pictureEdit18.Image = Image.FromFile(imagenes[2 + 6]);
            regionBateo = 3;
            pictureEdit16.Image = Image.FromFile(imagenes[0]);
            pictureEdit17.Image = Image.FromFile(imagenes[1]);
            pictureEdit19.Image = Image.FromFile(imagenes[3]);
            pictureEdit20.Image = Image.FromFile(imagenes[4]);
            pictureEdit21.Image = Image.FromFile(imagenes[5]);
        }

        private void pictureEdit17_Click(object sender, EventArgs e)
        {
            pictureEdit17.Image = Image.FromFile(imagenes[1 + 6]);
            regionBateo = 2;
            pictureEdit16.Image = Image.FromFile(imagenes[0]);
            pictureEdit18.Image = Image.FromFile(imagenes[2]);
            pictureEdit19.Image = Image.FromFile(imagenes[3]);
            pictureEdit20.Image = Image.FromFile(imagenes[4]);
            pictureEdit21.Image = Image.FromFile(imagenes[5]);
        }

        private void pictureEdit16_Click(object sender, EventArgs e)
        {
            pictureEdit16.Image = Image.FromFile(imagenes[0 + 6]);
            regionBateo = 1;
            pictureEdit18.Image = Image.FromFile(imagenes[2]);
            pictureEdit17.Image = Image.FromFile(imagenes[1]);
            pictureEdit19.Image = Image.FromFile(imagenes[3]);
            pictureEdit20.Image = Image.FromFile(imagenes[4]);
            pictureEdit21.Image = Image.FromFile(imagenes[5]);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ResetearDatos(); ResetearVisual(); groupControl2.Enabled = false;
        }

        private void pictureEdit22_Click(object sender, EventArgs e)
        {
            lanzamiento1 = true; lanzamiento2 = false; lanzamiento3 = false; lanzamiento4 = false; lanzamiento5 = false;
        }

        private void pictureEdit23_Click(object sender, EventArgs e)
        {
            lanzamiento1 = false; lanzamiento2 = true; lanzamiento3 = false; lanzamiento4 = false; lanzamiento5 = false;
        }

        private void pictureEdit24_Click(object sender, EventArgs e)
        {
            lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = true; lanzamiento4 = false; lanzamiento5 = false;
        }

        private void pictureEdit25_Click(object sender, EventArgs e)
        {
            lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false; lanzamiento4 = true; lanzamiento5 = false;
        }

        private void pictureEdit26_Click(object sender, EventArgs e)
        {
            bate = true;
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado ?");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 1;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 1;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 1;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit3.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 1;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }
        
        private void pictureEdit4_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 2;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 2;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 2;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit4.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 2;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit5_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 3;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 3;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 3;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit5.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 3;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 4;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 4;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 4;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit6.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 4;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit7_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 5;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 5;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 5;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit7.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 5;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit8_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 6;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 6;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 6;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit8.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 6;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit9_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 7;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 7;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 7;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit9.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 7;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit10_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 8;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                }
                else
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 8;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 8;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit10.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 8;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit11_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 9;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 9;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 9;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Foul ?");
                    }
                }
                else
                {
                    pictureEdit11.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (strike < 2)
                    {
                        strike++;
                    }
                    else
                    {
                        MessageBox.Show("Jugador Ponchado...");
                        comboBoxEdit1.Text = "K";
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 1;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 9;
                arrStrike[contador] = 1;
                arrBall[contador] = 0;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit12_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 10;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 10;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 10;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit12.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 10;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit13_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 11;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 11;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 11;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit13.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 11;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit14_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 12;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 12;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 12;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit14.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 12;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void pictureEdit15_Click_1(object sender, EventArgs e)
        {
            if (textEdit1.Text != "")
            {
                mph[contador] = byte.Parse(textEdit1.Text);
                textEdit1.Text = "";
            }
            if (lanzamiento1)
            {
                if (bate)
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento1.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento1.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 1;
                zonaBateo[contador] = 13;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento2)
            {
                if (bate)
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento2.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento2.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 2;
                zonaBateo[contador] = 13;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento3)
            {
                if (bate)
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento3.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento3.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 3;
                zonaBateo[contador] = 13;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else if (lanzamiento4)
            {
                if (bate)
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento4.png");//lanzamiento con bate
                    swing[contador] = 1;
                    if (strike < 2)
                    {
                        strike++;
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                    }
                    else
                    {
                        arrStrike[contador] = 1;
                        arrBall[contador] = 0;
                        MessageBox.Show("Foul");
                    }
                }
                else
                {
                    pictureEdit15.Image = Image.FromFile("imagen\\lazamiento4.png");
                    swing[contador] = 0;
                    if (ball < 3)
                    {
                        ball++;
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                    else
                    {
                        MessageBox.Show("Base por Bola");
                        comboBoxEdit1.Text = "BB";
                        arrStrike[contador] = 0;
                        arrBall[contador] = 1;
                    }
                }
                lanzamiento1 = false; lanzamiento2 = false; lanzamiento3 = false;
                lanzamiento4 = false; lanzamiento5 = false; bate = false;

                ultimoLance = 2;

                lanzamiento[contador] = 4;
                zonaBateo[contador] = 13;

                contador++;
                labelControl21.Text = ball.ToString() + " - " + strike.ToString();
            }
            else
            {
                MessageBox.Show("Error, Debe seleccional el lanzamiento realizado");
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Int32 rowSelect = this.dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);

                idBateador = int.Parse(this.dataGridView1.Rows[rowSelect].Cells[0].Value.ToString());
                labelControl11.Text = this.dataGridView1.Rows[rowSelect].Cells[1].Value.ToString();
                labelControl12.Text = this.dataGridView1.Rows[rowSelect].Cells[2].Value.ToString() + " " + this.dataGridView1.Rows[rowSelect].Cells[3].Value.ToString();
                labelControl13.Text = this.dataGridView1.Rows[rowSelect].Cells[4].Value.ToString();
                labelControl14.Text = this.dataGridView1.Rows[rowSelect].Cells[5].Value.ToString();
                labelControl15.Text = this.dataGridView1.Rows[rowSelect].Cells[6].Value.ToString();

                try
                {
                    pictureEdit1.Image = Image.FromFile(imagenes2[1] + idBateador.ToString() +
                                this.dataGridView1.Rows[rowSelect].Cells[1].Value.ToString() + ".jpg");      // Tomar la imagen de la BD y mostrarla
                }
                catch (Exception)
                {
                    
                    pictureEdit1.Image = Image.FromFile(imagenes2[0]);
                }


                if (idPitcher != -1)
                {
                    groupControl2.Enabled = true;
                    comboBoxEdit1.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione correctamente la fila");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Int32 rowSelect = this.dataGridView2.Rows.GetFirstRow(DataGridViewElementStates.Selected);

                idPitcher = int.Parse(this.dataGridView2.Rows[rowSelect].Cells[0].Value.ToString());
                labelControl16.Text = this.dataGridView2.Rows[rowSelect].Cells[1].Value.ToString();
                labelControl17.Text = this.dataGridView2.Rows[rowSelect].Cells[2].Value.ToString() + " " + this.dataGridView2.Rows[rowSelect].Cells[3].Value.ToString();
                labelControl18.Text = this.dataGridView2.Rows[rowSelect].Cells[4].Value.ToString();
                labelControl19.Text = this.dataGridView2.Rows[rowSelect].Cells[5].Value.ToString();
                labelControl20.Text = this.dataGridView2.Rows[rowSelect].Cells[6].Value.ToString();

                try
                {
                    pictureEdit2.Image = Image.FromFile(imagenes2[1] + idPitcher.ToString() +
                                this.dataGridView2.Rows[rowSelect].Cells[1].Value.ToString() + ".jpg");       // Tomar la imagen de la BD y mostrarla
                }
                catch (Exception)
                {
                    
                    pictureEdit1.Image = Image.FromFile(imagenes2[0]);
                }

                if (idBateador != -1)
                {
                    groupControl2.Enabled = true;
                    comboBoxEdit1.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione correctamente la fila");
            }
        }      
    }
}