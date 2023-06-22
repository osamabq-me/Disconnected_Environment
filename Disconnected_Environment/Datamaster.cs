using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class Datamaster : Form
    {
        public Datamaster()
        {
            InitializeComponent();
        }

        private void Datamaster_Load(object sender, EventArgs e)
        {

        }

        private void dataProdiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Data_prodi dp = new Data_prodi();
            dp.Show();

        }

        private void dataMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Data_Mahasiswa dm = new Data_Mahasiswa();
            dm.Show();
        }

        private void dataStatusMahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Data_status_mahasisua dsm = new Data_status_mahasisua();
            dsm.Show();
        }
    }
}
