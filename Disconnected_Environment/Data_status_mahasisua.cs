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
    public partial class Data_status_mahasisua : Form
    {


        private string stringConnection = "data source=MY-PREDATOR;database=school;" +
        "user ID=sa;password=111qq";

        private SqlConnection koneksi;

        public Data_status_mahasisua()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            refreshForm();
        }

        private void Data_status_mahasisua_Load(object sender, EventArgs e)
        {

        }


        private void refreshForm()
        {
            cbxNama.Enabled = false;
            cbxstatusM.Enabled = false;
            cbxTahunma.Enabled = false;
            cbxNama.SelectedIndex = -1;
            cbxstatusM.SelectedIndex = -1;
            cbxTahunma.SelectedIndex = -1;
            txtNim.Visible = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void dataGridview()
        {
            koneksi.Open();
            string str = "Select * from dbo.status_mahasiswa";
            SqlDataAdapter da = new SqlDataAdapter(str, koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            koneksi.Close();   

        }
        

        private void cbNama()
        {
            koneksi.Open();
            string str = "Select nama_mahasiswa from dbo.mahasiswa where not EXISTS(select id_status from dbo.status_mahasiswa where status_mahasiswa.nim = mahasiswa.nim)";
            SqlCommand cmd = new SqlCommand(str,koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str,koneksi);
            DataSet ds = new DataSet();

            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();


            cbxNama.DisplayMember = "nama_mahasiswa";
            cbxNama.ValueMember = "NIM";
            cbxNama.DataSource = ds.Tables[0];

        }

        private void cbTahunMasuk()
        {
            int y = DateTime.Now.Year - 2010;
            string[] type = new string[y];
            int i = 0;

            for (i = 0; i < type.Length; i++)
            {
                if (i == 0)
                {
                    cbxTahunma.Items.Add("2010");
                }
                else
                {
                    int l = 2010 + i;
                    cbxTahunma.Items.Add(l.ToString());
                }
            }
        }

        private void cbxNama_SelectedIndexChanged(object sender, EventArgs e)
        {
            koneksi.Open();
            string nim = "";
            string strs = "SELECT NIM from dbo.mahasiswa where nama_mahasiswa = @nm";
            SqlCommand cm = new SqlCommand(strs,koneksi);
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@nm", cbxNama.Text));
            SqlDataReader dr = cm.ExecuteReader();
            
            while (dr.Read())
            {
                nim = dr["NIM"].ToString();
            }
            dr.Close();
            koneksi.Close();

            txtNim.Text = nim;
        }

        private void btnOprn_Click(object sender, EventArgs e)
        {
            dataGridview();
            btnOprn.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbxTahunma.Enabled = true;
            cbxNama.Enabled = true;
            cbxstatusM.Enabled = true;
            txtNim.Visible = true;
            cbTahunMasuk();
            cbNama();
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nim = txtNim.Text;
            string statusMahasiswa = cbxstatusM.Text;
            string tahunMasuk = cbxTahunma.Text;
            int count = 0;
            string tempKodeStatus = "";
            string KodeStatus = "";
            koneksi.Open();

            string str = "select count (*) from dbo.status_mahasiswa";
            SqlCommand cm = new SqlCommand(str, koneksi);
            count = (int)cm.ExecuteScalar();

            if (count == 0) 
            {
                KodeStatus = "1";
            }
            else
            {
                string queryString = "select Max(id_status) from dbo.status_mahasiswa";
                SqlCommand cmStatusMahasisuaSum = new SqlCommand(queryString,koneksi);
                int totalStatusMahasiswa = (int)cmStatusMahasisuaSum.ExecuteScalar();
                int finalKodeStatusInt = totalStatusMahasiswa + 1;
                KodeStatus = Convert.ToString(finalKodeStatusInt);
            }

            string quearysting = "INSERT INTO status_mahasiswa (id_status, nim, status_mahasiswa, tahun_masuk) VALUES (@ids, @NIM, @sm, @tm)";

            SqlCommand cmd = new SqlCommand(quearysting, koneksi);
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add(new SqlParameter("ids", KodeStatus));
            cmd.Parameters.Add(new SqlParameter("NIM", nim));
            cmd.Parameters.Add(new SqlParameter("sm",statusMahasiswa));
            cmd.Parameters.Add(new SqlParameter("tm",tahunMasuk));
            cmd.ExecuteNonQuery();
            koneksi.Close();

            MessageBox.Show("Data have been added", "Sucsess", MessageBoxButtons.OK,  MessageBoxIcon.Information);
            refreshForm();
            dataGridview();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshForm();
        }

        private void Data_status_mahasisua_FormClosed(object sender, FormClosedEventArgs e)
        {
            Datamaster datamaster = new Datamaster();
            datamaster.Show();
            this.Hide();
        }

    }
}
