namespace Clinis_infosys
{
    partial class InventoryControl
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
            this.col_invid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_itemname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_reslev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_actquan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_needres = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.col_invid,
            this.col_itemname,
            this.col_quantity,
            this.col_unit,
            this.col_reslev,
            this.col_actquan,
            this.col_needres});
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
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(840, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 26);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
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
            this.Doctors.Size = new System.Drawing.Size(114, 31);
            this.Doctors.TabIndex = 5;
            this.Doctors.Text = "Inventory";
            // 
            // col_invid
            // 
            this.col_invid.HeaderText = "Inventory ID";
            this.col_invid.MinimumWidth = 6;
            this.col_invid.Name = "col_invid";
            // 
            // col_itemname
            // 
            this.col_itemname.HeaderText = "Item Name";
            this.col_itemname.MinimumWidth = 6;
            this.col_itemname.Name = "col_itemname";
            // 
            // col_quantity
            // 
            this.col_quantity.HeaderText = "Quantity";
            this.col_quantity.MinimumWidth = 6;
            this.col_quantity.Name = "col_quantity";
            // 
            // col_unit
            // 
            this.col_unit.HeaderText = "Unit";
            this.col_unit.MinimumWidth = 6;
            this.col_unit.Name = "col_unit";
            // 
            // col_reslev
            // 
            this.col_reslev.HeaderText = "Restock Level";
            this.col_reslev.MinimumWidth = 6;
            this.col_reslev.Name = "col_reslev";
            // 
            // col_actquan
            // 
            this.col_actquan.HeaderText = "Actual Quantity";
            this.col_actquan.MinimumWidth = 6;
            this.col_actquan.Name = "col_actquan";
            // 
            // col_needres
            // 
            this.col_needres.HeaderText = "Needs Restock";
            this.col_needres.MinimumWidth = 6;
            this.col_needres.Name = "col_needres";
            // 
            // InventoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Doctors);
            this.Name = "InventoryControl";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn col_invid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_itemname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_reslev;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_actquan;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_needres;
    }
}
