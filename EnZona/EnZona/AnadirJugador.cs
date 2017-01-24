using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace EnZona
{
    public partial class AnadirJugador : DevExpress.XtraEditors.XtraForm
    {
        public AnadirJugador()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                if (textEdit1.Text != "" && textEdit2.Text != "" && textEdit3.Text != "" && textEdit4.Text != ""
                    && textEdit5.Text != "" && textEdit6.Text != "" && textEdit7.Text != "" && comboBoxEdit1.Text != ""
                    && comboBoxEdit2.Text != "" && comboBoxEdit3.Text != "")
                {
                    int id = int.Parse(jugadoresTableAdapter.CountIdJugadores().ToString()); id = id + 1;
                    File.Copy(openFileDialog1.FileName, "imagen/img_jug/" + id.ToString() + textEdit1.Text + ".jpg");// hay ke realizar tratamiento de excepciones
                    pictureEdit1.Image = Image.FromFile("imagen\\img_jug\\" + id.ToString() + textEdit1.Text + ".jpg");
                }
                else
                {
                    MessageBox.Show("LLene los campos de de texto primero");
                }
                
            }
            catch
            {
                MessageBox.Show("Existe un fichero con el mismo nombre");
            }
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Imagen de Jugador";
            openFileDialog1.Filter = "(*.jpg)|*.jpg"; //ver trabajo con el string del filtro
            openFileDialog1.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.jugadoresTableAdapter.Insert(textEdit1.Text, textEdit2.Text, textEdit3.Text,int.Parse(textEdit6.Text), double.Parse(textEdit4.Text), double.Parse(textEdit5.Text), comboBoxEdit1.Text, int.Parse(textEdit7.Text), comboBoxEdit2.Text, comboBoxEdit3.Text);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Falta algun campos por llenar");
            }            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnadirJugador_Load(object sender, EventArgs e)
        {
        }
    }
}