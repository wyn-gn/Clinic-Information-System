namespace Clinis_infosys
{
    partial class PrescriptionsControl
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.Doctors = new System.Windows.Forms.Label();
            this.col_presid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_recid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_patid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_docid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_medname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_ins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(933, 51);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_presid,
            this.col_recid,
            this.col_patid,
            this.col_docid,
            this.col_medname,
            this.col_ins,
            this.col_dosage});
            this.dataGridView1.Location = new System.Drawing.Point(50, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 532);
            this.dataGridView1.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(840, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Doctors
            // 
            this.Doctors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Doctors.AutoSize = true;
            this.Doctors.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold);
            this.Doctors.Location = new System.Drawing.Point(48, 23);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(156, 31);
            this.Doctors.TabIndex = 5;
            this.Doctors.Text = "Prescriptions";
            // 
            // col_presid
            // 
            this.col_presid.HeaderText = "Prescription ID";
            this.col_presid.MinimumWidth = 6;
            this.col_presid.Name = "col_presid";
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
            // col_medname
            // 
            this.col_medname.HeaderText = "Medicine Name";
            this.col_medname.MinimumWidth = 6;
            this.col_medname.Name = "col_medname";
            // 
            // col_ins
            // 
            this.col_ins.HeaderText = "Instructions";
            this.col_ins.MinimumWidth = 6;
            this.col_ins.Name = "col_ins";
            // 
            // col_dosage
            // 
            this.col_dosage.HeaderText = "Dosage";
            this.col_dosage.MinimumWidth = 6;
            this.col_dosage.Name = "col_dosage";
            // 
            // PrescriptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Doctors);
            this.Name = "PrescriptionsControl";
            this.Size = new System.Drawing.Size(1060, 647);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label Doctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_presid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_recid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_patid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_docid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_medname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ins;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dosage;
    }
}
