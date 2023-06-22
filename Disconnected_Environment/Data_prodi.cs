using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Environment
{
    public partial class Data_prodi : Form
    {
        private string stringConnection = "data source=MY-PREDATOR;database=school;" +
             "user ID=sa;password=111qq";

        private SqlConnection koneksi;


        private void refreshform()
        {
            nmp.Text = "";
            nmp.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
        }

        public Data_prodi()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshform();
        }

        private void dataGridView()
        {
            koneksi.Open();
            String str = "select nama_prodi from dbo.Prodi";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();

        }

        private void Data_prodi_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dataGridView();
            btnOpen.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            nmp.Enabled = true;
            btnSave.Enabled = true;
            btnClear.Enabled = true;
        }

        private void Data_prodi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Datamaster mm = new Datamaster();
            mm.Show();
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nmprodi = nmp.Text;
            if (nmprodi == "")
            {
                MessageBox.Show("Enter the prodi name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                koneksi.Open();
                string str = "INSERT INTO dbo.prodi (nama_prodi) " + "VALUES(@id)";
                SqlCommand cmd = new SqlCommand(str, koneksi);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("id", nmprodi));
                cmd.ExecuteNonQuery();


                koneksi.Close();
                MessageBox.Show("Data Have been added", "sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();

            }
        }
    }
}
