namespace Clinis_infosys
{
    partial class MedicalRecordsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_recid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_patid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_docid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_treatment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_recdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Doctors = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_recid,
            this.col_patid,
            this.col_docid,
            this.col_diagnosis,
            this.col_treatment,
            this.col_recdate});
            this.dataGridView1.Location = new System.Drawing.Point(50, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 532);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // col_recid
            // 
            this.col_recid.HeaderText = "Record ID";
            this.col_recid.MinimumWidth = 6;
            this.col_recid.Name = "col_recid";
            // 
            // col_patid
            // 
            this.col_patid.HeaderText = "Patient ID";
            this.col_patid.MinimumWidth = 6;
            this.col_patid.Name = "col_patid";
            // 
            // col_docid
            // 
            this.col_docid.HeaderText = "Doctor ID";
            this.col_docid.MinimumWidth = 6;
            this.col_docid.Name = "col_docid";
            // 
            // col_diagnosis
            // 
            this.col_diagnosis.HeaderText = "Diagnosis";
            this.col_diagnosis.MinimumWidth = 6;
            this.col_diagnosis.Name = "col_diagnosis";
            // 
            // col_treatment
            // 
            this.col_treatment.HeaderText = "Treatment";
            this.col_treatment.MinimumWidth = 6;
            this.col_treatment.Name = "col_treatment";
            // 
            // col_recdate
            // 
            this.col_recdate.HeaderText = "Record Date";
            this.col_recdate.MinimumWidth = 6;
            this.col_recdate.Name = "col_recdate";
            // 
            // Doctors
            // 
            this.Doctors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Doctors.AutoSize = true;
            this.Doctors.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold);
            this.Doctors.Location = new System.Drawing.Point(48, 23);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(189, 31);
            this.Doctors.TabIndex = 9;
            this.Doctors.Text = "Medical Records";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(933, 43);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 26);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // MedicalRecordsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Doctors);
            this.Name = "MedicalRecordsControl";
            this.Size = new System.Drawing.Size(1060, 647);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Doctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_recid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_patid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_docid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_treatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_recdate;
        private System.Windows.Forms.Button btnExport;
    }
}
