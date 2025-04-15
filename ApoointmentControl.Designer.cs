namespace Clinis_infosys
{
    partial class ApoointmentControl
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
            this.Patients = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.col_apptid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_patid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_docid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_apptdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Patients
            // 
            this.Patients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Patients.AutoSize = true;
            this.Patients.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold);
            this.Patients.Location = new System.Drawing.Point(48, 23);
            this.Patients.Name = "Patients";
            this.Patients.Size = new System.Drawing.Size(164, 31);
            this.Patients.TabIndex = 6;
            this.Patients.Text = "Appointments";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_apptid,
            this.col_patid,
            this.col_docid,
            this.col_apptdate,
            this.col_status});
            this.dataGridView1.Location = new System.Drawing.Point(50, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 532);
            this.dataGridView1.TabIndex = 8;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(933, 51);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 26);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(840, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // col_apptid
            // 
            this.col_apptid.HeaderText = "Appointment ID";
            this.col_apptid.MinimumWidth = 6;
            this.col_apptid.Name = "col_apptid";
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
            // col_apptdate
            // 
            this.col_apptdate.HeaderText = "Appointment Date";
            this.col_apptdate.MinimumWidth = 6;
            this.col_apptdate.Name = "col_apptdate";
            // 
            // col_status
            // 
            this.col_status.HeaderText = "Status";
            this.col_status.MinimumWidth = 6;
            this.col_status.Name = "col_status";
            // 
            // ApoointmentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Patients);
            this.Name = "ApoointmentControl";
            this.Size = new System.Drawing.Size(1060, 647);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Patients;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_apptid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_patid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_docid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_apptdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_status;
    }
}
