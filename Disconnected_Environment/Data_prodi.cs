using System;
using System.Collections;
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

        static string GenerateRandomNonRepetitiveString(int size)
        {
            Random random = new Random();
            const string chars = "0123456789abcdef";
            char[] hexChars = new char[size];

            for (int i = 0; i < size; i++)
            {
                hexChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(hexChars);
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
                string randomCode = GenerateRandomNonRepetitiveString(5);


                string str = "INSERT INTO dbo.prodi (id_prodi,nama_prodi) " + "VALUES(@randomcode,@id)";
                using (SqlCommand command = new SqlCommand(str, koneksi))
                {
                    command.Parameters.Add("@randomcode", SqlDbType.VarChar).Value = randomCode;
                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = nmprodi;
                    command.ExecuteNonQuery();
                }

                koneksi.Close();
                MessageBox.Show("Data Have been added", "sucsses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView();
                refreshform();



            }
        }
    }
}
