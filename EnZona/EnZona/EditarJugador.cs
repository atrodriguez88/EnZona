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
    public partial class EditarJugador : DevExpress.XtraEditors.XtraForm
    {
        public EditarJugador()
        {
            InitializeComponent();
        }

        private void EditarJugador_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'enZonaBDDataSet.Jugadores' table. You can move, or remove it, as needed.
            this.jugadoresTableAdapter.Fill(this.enZonaBDDataSet.Jugadores);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
                this.jugadoresTableAdapter.Update(enZonaBDDataSet.Jugadores);
                this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Campo inválido");
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.jugadoresTableAdapter.FillByProvincia(this.enZonaBDDataSet.Jugadores,comboBoxEdit1.Text);
        }
    }
}