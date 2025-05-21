namespace Clinis_infosys
{
    partial class DashboardControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelDoctors = new System.Windows.Forms.Panel();
            this.numDoc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numPatient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numAppointment = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.appointment_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_pat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointment_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numPending = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelDoctors.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            // 
            // panelDoctors
            // 
            this.panelDoctors.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelDoctors.Controls.Add(this.numDoc);
            this.panelDoctors.Controls.Add(this.label2);
            this.panelDoctors.Location = new System.Drawing.Point(57, 73);
            this.panelDoctors.Name = "panelDoctors";
            this.panelDoctors.Size = new System.Drawing.Size(200, 159);
            this.panelDoctors.TabIndex = 1;
            this.panelDoctors.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // numDoc
            // 
            this.numDoc.AutoSize = true;
            this.numDoc.Font = new System.Drawing.Font("Arial Narrow", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDoc.ForeColor = System.Drawing.Color.White;
            this.numDoc.Location = new System.Drawing.Point(72, 55);
            this.numDoc.Name = "numDoc";
            this.numDoc.Size = new System.Drawing.Size(62, 52);
            this.numDoc.TabIndex = 1;
            this.numDoc.Text = "10";
            this.numDoc.Click += new System.EventHandler(this.numDoc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "No. of Doctors";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.numPatient);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(303, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 159);
            this.panel1.TabIndex = 2;
            // 
            // numPatient
            // 
            this.numPatient.AutoSize = true;
            this.numPatient.Font = new System.Drawing.Font("Arial Narrow", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPatient.ForeColor = System.Drawing.Color.White;
            this.numPatient.Location = new System.Drawing.Point(75, 55);
            this.numPatient.Name = "numPatient";
            this.numPatient.Size = new System.Drawing.Size(62, 52);
            this.numPatient.TabIndex = 1;
            this.numPatient.Text = "10";
            this.numPatient.Click += new System.EventHandler(this.numPatient_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(18, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "No. of Patients";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.numAppointment);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(555, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 159);
            this.panel2.TabIndex = 3;
            // 
            // numAppointment
            // 
            this.numAppointment.AutoSize = true;
            this.numAppointment.Font = new System.Drawing.Font("Arial Narrow", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAppointment.ForeColor = System.Drawing.Color.White;
            this.numAppointment.Location = new System.Drawing.Point(71, 55);
            this.numAppointment.Name = "numAppointment";
            this.numAppointment.Size = new System.Drawing.Size(62, 52);
            this.numAppointment.TabIndex = 1;
            this.numAppointment.Text = "10";
            this.numAppointment.Click += new System.EventHandler(this.numAppointment_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(7, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Upcoming Appointments";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointment_id,
            this.name,
            this.name_pat,
            this.appointment_date,
            this.status});
            this.dataGridView1.Location = new System.Drawing.Point(57, 278);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(945, 341);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // appointment_id
            // 
            this.appointment_id.HeaderText = "Appointment ID";
            this.appointment_id.MinimumWidth = 6;
            this.appointment_id.Name = "appointment_id";
            // 
            // name
            // 
            this.name.HeaderText = "Doctor";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            // 
            // name_pat
            // 
            this.name_pat.HeaderText = "Patient";
            this.name_pat.MinimumWidth = 6;
            this.name_pat.Name = "name_pat";
            // 
            // appointment_date
            // 
            this.appointment_date.HeaderText = "Appointment Date";
            this.appointment_date.MinimumWidth = 6;
            this.appointment_date.Name = "appointment_date";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 6;
            this.status.Name = "status";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.numPending);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(802, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 159);
            this.panel3.TabIndex = 4;
            // 
            // numPending
            // 
            this.numPending.AutoSize = true;
            this.numPending.Font = new System.Drawing.Font("Arial Narrow", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPending.ForeColor = System.Drawing.Color.White;
            this.numPending.Location = new System.Drawing.Point(73, 55);
            this.numPending.Name = "numPending";
            this.numPending.Size = new System.Drawing.Size(62, 52);
            this.numPending.TabIndex = 1;
            this.numPending.Text = "10";
            this.numPending.Click += new System.EventHandler(this.numPending_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(18, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Pending Payments";
            // 
            // DashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDoctors);
            this.Controls.Add(this.label1);
            this.Name = "DashboardControl";
            this.Size = new System.Drawing.Size(1060, 647);
            this.panelDoctors.ResumeLayout(false);
            this.panelDoctors.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDoctors;
        private System.Windows.Forms.Label numDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label numPatient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label numAppointment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointment_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_pat;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointment_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label numPending;
        private System.Windows.Forms.Label label5;
    }
}
