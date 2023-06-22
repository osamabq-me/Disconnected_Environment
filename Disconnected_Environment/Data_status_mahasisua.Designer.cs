namespace Disconnected_Environment
{
    partial class Data_status_mahasisua
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOprn = new System.Windows.Forms.Button();
            this.cbxTahunma = new System.Windows.Forms.ComboBox();
            this.cbxstatusM = new System.Windows.Forms.ComboBox();
            this.cbxNama = new System.Windows.Forms.ComboBox();
            this.txtNim = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(518, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 41);
            this.btnSave.TabIndex = 25;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(518, 289);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 43);
            this.btnClear.TabIndex = 24;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(518, 239);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 38);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOprn
            // 
            this.btnOprn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOprn.Location = new System.Drawing.Point(668, 44);
            this.btnOprn.Name = "btnOprn";
            this.btnOprn.Size = new System.Drawing.Size(75, 38);
            this.btnOprn.TabIndex = 22;
            this.btnOprn.Text = "Open";
            this.btnOprn.UseVisualStyleBackColor = true;
            this.btnOprn.Click += new System.EventHandler(this.btnOprn_Click);
            // 
            // cbxTahunma
            // 
            this.cbxTahunma.FormattingEnabled = true;
            this.cbxTahunma.Location = new System.Drawing.Point(314, 356);
            this.cbxTahunma.Name = "cbxTahunma";
            this.cbxTahunma.Size = new System.Drawing.Size(179, 28);
            this.cbxTahunma.TabIndex = 21;
            // 
            // cbxstatusM
            // 
            this.cbxstatusM.FormattingEnabled = true;
            this.cbxstatusM.Location = new System.Drawing.Point(314, 317);
            this.cbxstatusM.Name = "cbxstatusM";
            this.cbxstatusM.Size = new System.Drawing.Size(179, 28);
            this.cbxstatusM.TabIndex = 20;
            // 
            // cbxNama
            // 
            this.cbxNama.FormattingEnabled = true;
            this.cbxNama.Location = new System.Drawing.Point(314, 245);
            this.cbxNama.Name = "cbxNama";
            this.cbxNama.Size = new System.Drawing.Size(179, 28);
            this.cbxNama.TabIndex = 19;
            this.cbxNama.SelectedIndexChanged += new System.EventHandler(this.cbxNama_SelectedIndexChanged);
            // 
            // txtNim
            // 
            this.txtNim.AutoSize = true;
            this.txtNim.Location = new System.Drawing.Point(332, 289);
            this.txtNim.Name = "txtNim";
            this.txtNim.Size = new System.Drawing.Size(55, 20);
            this.txtNim.TabIndex = 18;
            this.txtNim.Text = "txtNIM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Tahun Masuk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Status Mahasiswa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nomor Induk Mahasiswa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nama Mahasiswa";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(111, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(535, 196);
            this.dataGridView1.TabIndex = 13;
            // 
            // Data_status_mahasisua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOprn);
            this.Controls.Add(this.cbxTahunma);
            this.Controls.Add(this.cbxstatusM);
            this.Controls.Add(this.cbxNama);
            this.Controls.Add(this.txtNim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Data_status_mahasisua";
            this.Text = "Data_status_mahasisua";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Data_status_mahasisua_FormClosed);
            this.Load += new System.EventHandler(this.Data_status_mahasisua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOprn;
        private System.Windows.Forms.ComboBox cbxTahunma;
        private System.Windows.Forms.ComboBox cbxstatusM;
        private System.Windows.Forms.ComboBox cbxNama;
        private System.Windows.Forms.Label txtNim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}