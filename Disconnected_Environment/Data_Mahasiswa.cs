﻿using System;
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
    public partial class Data_Mahasiswa : Form
    {

        private string stringConnection = "data source=MY-PREDATOR;database=school;" +
        "user ID=sa;password=111qq";

        private SqlConnection koneksi;

        private string nim, nama, alamat, jk, prodi;
        private DateTime tgl;
        BindingSource customersBindingSource = new BindingSource();



        private void Data_Mahasiswa_load()
        {
            koneksi.Open();

            SqlDataAdapter dataAdapter1 = new SqlDataAdapter(new SqlCommand("Select m.nim,m.nama_mahasiswa, m.alamat, m.jenis_kelamin,m.tgl_lahir,p.nama_prodi from dbo.Mahasiswa m  join dbo.prodi p on m.id_prodi = p.id_prodi", koneksi));

            DataSet ds = new DataSet();
            dataAdapter1.Fill(ds);




            this.customersBindingSource.DataSource = ds.Tables[0];
            this.txtNIM.DataBindings.Add(
                new Binding("Text", this.customersBindingSource, "NIM", true));
            this.txtNama.DataBindings.Add(
                new Binding("Text", this.customersBindingSource, "nama_mahasiswa", true));
            this.txtAlamat.DataBindings.Add(
                new Binding("Text", this.customersBindingSource, "alamat", true));
            BindingContext bindingContext = new BindingContext();
            cbxJenis.BindingContext = bindingContext;
            this.cbxJenis.DataBindings.Add(new Binding("Text", this.customersBindingSource, "jenis_kel", true));
            this.dtTanggalL.DataBindings.Add(new Binding("text", this.customersBindingSource, "tgl_lahir", true));
            this.cbxProdi.DataBindings.Add(new Binding("Text", this.customersBindingSource, "nama_prodi", true));
            koneksi.Close();
        }


        private void Data_Mahasiswa_Load(object sender, EventArgs e)
        {

        }

        private void clearBinding()
        {
            this.txtNIM.DataBindings.Clear();
            this.txtNama.DataBindings.Clear();
            this.txtAlamat.DataBindings.Clear();
            this.cbxJenis.DataBindings.Clear();
            this.dtTanggalL.DataBindings.Clear();
            this.cbxProdi.DataBindings.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            nim = txtNIM.Text;
            nama = txtNama.Text;
            jk = cbxJenis.Text;
            alamat = txtAlamat.Text;
            tgl = dtTanggalL.Value;
            prodi = cbxProdi.Text;
            int hs = 0;

            koneksi.Open();
            string strs = "SELECT  id_prodi from dbo.Prodi where nama_prodi = @dd";

            SqlCommand cm = new SqlCommand(strs, koneksi);
            cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@dd", prodi));
            SqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {
                hs = int.Parse(dr["id_prodi"].ToString());
            }
            dr.Close();
            string str = "INSERT INTO mahasiswa (nim, nama_mahasiswa, jenis_kelamin, alamat, tgl_lahir, id_prodi) VALUES (@NIM, @Nm, @JK, @AL, @Tgll, @Idp)";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("NIM",nim));
            cmd.Parameters.Add(new SqlParameter("Nm",nama));
            cmd.Parameters.Add(new SqlParameter("JK",jk));
            cmd.Parameters.Add(new SqlParameter("AL",alamat));
            cmd.Parameters.Add(new SqlParameter("Tgll",tgl));
            cmd.Parameters.Add(new SqlParameter("Idp",hs));
            cmd.ExecuteNonQuery();

            koneksi.Close();

            MessageBox.Show("Data have been added", "Sucsess", MessageBoxButtons.OK, MessageBoxIcon.Information);

            refreshform();


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            refreshform();

        }

        private void Data_Mahasiswa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Datamaster datamaster = new Datamaster();
            datamaster.Show();
            this.Hide();
        }

        private void refreshform()
        {
            txtNIM.Enabled = false;
            txtNama.Enabled = false;
            txtAlamat.Enabled = false;
            cbxJenis.Enabled = false;
            cbxProdi.Enabled = false;
            dtTanggalL.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
            clearBinding();
            Data_Mahasiswa_load();
        }


        public Data_Mahasiswa()
        {
            InitializeComponent();
            koneksi = new SqlConnection(stringConnection);
            this.bnMahasiswa.BindingSource = this.customersBindingSource;
            refreshform();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtNIM.Text = "";
            txtNama.Text = "";
            txtAlamat.Text = "";
            dtTanggalL.Value = DateTime.Today;
            txtNIM.Enabled = true;
            txtNama.Enabled = true;
            txtAlamat.Enabled = true;
            cbxJenis.Enabled = true;
            cbxProdi.Enabled = true;
            dtTanggalL.Enabled = true;
            Prodicbx();
            btnSave.Enabled = true;
            btnClear.Enabled = true;    
            btnAdd.Enabled = false;
        }


        private void Prodicbx()
        {
            koneksi.Open();
            string str = "select nama_prodi from dbo.prodi";
            SqlCommand cmd = new SqlCommand(str, koneksi);
            SqlDataAdapter da = new SqlDataAdapter(str,koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteReader();
            koneksi.Close();
            cbxProdi.DisplayMember = "nama_prodi";
            cbxProdi.ValueMember = "id_prodi";
            cbxProdi.DataSource = ds.Tables[0];
        }






    }
}
