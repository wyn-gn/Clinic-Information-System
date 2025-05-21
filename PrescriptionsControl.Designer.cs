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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.prescription_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.record_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medicine_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medication_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.prescription_id,
            this.record_id,
            this.doctor_id,
            this.patient_id,
            this.medicine_name,
            this.medication_name,
            this.dosage,
            this.instructions});
            this.dataGridView1.Location = new System.Drawing.Point(50, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 532);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // prescription_id
            // 
            this.prescription_id.HeaderText = "Prescription ID";
            this.prescription_id.MinimumWidth = 6;
            this.prescription_id.Name = "prescription_id";
            // 
            // record_id
            // 
            this.record_id.HeaderText = "Record ID";
            this.record_id.MinimumWidth = 6;
            this.record_id.Name = "record_id";
            // 
            // doctor_id
            // 
            this.doctor_id.HeaderText = "Doctor ID";
            this.doctor_id.MinimumWidth = 6;
            this.doctor_id.Name = "doctor_id";
            // 
            // patient_id
            // 
            this.patient_id.HeaderText = "Patient ID";
            this.patient_id.MinimumWidth = 6;
            this.patient_id.Name = "patient_id";
            // 
            // medicine_name
            // 
            this.medicine_name.HeaderText = "Medicine ID";
            this.medicine_name.MinimumWidth = 6;
            this.medicine_name.Name = "medicine_name";
            // 
            // medication_name
            // 
            this.medication_name.HeaderText = "Medication Name";
            this.medication_name.MinimumWidth = 6;
            this.medication_name.Name = "medication_name";
            // 
            // dosage
            // 
            this.dosage.HeaderText = "Dosage";
            this.dosage.MinimumWidth = 6;
            this.dosage.Name = "dosage";
            // 
            // instructions
            // 
            this.instructions.HeaderText = "Instructions";
            this.instructions.MinimumWidth = 6;
            this.instructions.Name = "instructions";
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
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(933, 45);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 26);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // PrescriptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Doctors);
            this.Name = "PrescriptionsControl";
            this.Size = new System.Drawing.Size(1060, 647);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Doctors;
        private System.Windows.Forms.DataGridViewTextBoxColumn prescription_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn record_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn medicine_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn medication_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructions;
        private System.Windows.Forms.Button btnExport;
    }
}
