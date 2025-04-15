namespace Clinis_infosys
{
    partial class PaymentControl
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_payid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_patid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paymet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paystatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_paydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patients = new System.Windows.Forms.Label();
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
            this.btnDelete.TabIndex = 14;
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
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_payid,
            this.col_patid,
            this.col_amount,
            this.col_paymet,
            this.col_paystatus,
            this.col_paydate});
            this.dataGridView1.Location = new System.Drawing.Point(50, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(958, 532);
            this.dataGridView1.TabIndex = 12;
            // 
            // col_payid
            // 
            this.col_payid.HeaderText = "Payment ID";
            this.col_payid.MinimumWidth = 6;
            this.col_payid.Name = "col_payid";
            // 
            // col_patid
            // 
            this.col_patid.HeaderText = "Patient ID";
            this.col_patid.MinimumWidth = 6;
            this.col_patid.Name = "col_patid";
            // 
            // col_amount
            // 
            this.col_amount.HeaderText = "Amount";
            this.col_amount.MinimumWidth = 6;
            this.col_amount.Name = "col_amount";
            // 
            // col_paymet
            // 
            this.col_paymet.HeaderText = "Payment Method";
            this.col_paymet.MinimumWidth = 6;
            this.col_paymet.Name = "col_paymet";
            // 
            // col_paystatus
            // 
            this.col_paystatus.HeaderText = "Status";
            this.col_paystatus.MinimumWidth = 6;
            this.col_paystatus.Name = "col_paystatus";
            // 
            // col_paydate
            // 
            this.col_paydate.HeaderText = "Payment Date";
            this.col_paydate.MinimumWidth = 6;
            this.col_paydate.Name = "col_paydate";
            // 
            // Patients
            // 
            this.Patients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Patients.AutoSize = true;
            this.Patients.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold);
            this.Patients.Location = new System.Drawing.Point(48, 23);
            this.Patients.Name = "Patients";
            this.Patients.Size = new System.Drawing.Size(118, 31);
            this.Patients.TabIndex = 11;
            this.Patients.Text = "Payments";
            // 
            // PaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Patients);
            this.Name = "PaymentControl";
            this.Size = new System.Drawing.Size(1061, 647);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label Patients;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_payid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_patid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paymet;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paystatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_paydate;
    }
}
