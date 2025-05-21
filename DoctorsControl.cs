using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clinis_infosys
{
    public partial class DoctorsControl : UserControl
    {
        public DoctorsControl()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.DoctorsControl_Load);
        }

        private void DoctorsControl_Load(object sender, EventArgs e)
        {
            LoadDoctors();
        }

        private void LoadDoctors(string searchTerm = "")
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT d.doctor_id, d.name, d.specialization, d.phone,
                       COUNT(DISTINCT da.patient_name) AS patient_count
                FROM doctors d
                LEFT JOIN doctors_appointments da ON d.name = da.doctor_name
                WHERE d.name LIKE @search OR d.specialization LIKE @search
                GROUP BY d.doctor_id, d.name, d.specialization, d.phone";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDoctorId",
                        DataPropertyName = "doctor_id",
                        HeaderText = "Doctor ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colName",
                        DataPropertyName = "name",
                        HeaderText = "Name"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colSpecialization",
                        DataPropertyName = "specialization",
                        HeaderText = "Specialization"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPhone",
                        DataPropertyName = "phone",
                        HeaderText = "Phone"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPatientCount",
                        DataPropertyName = "patient_count",
                        HeaderText = "Patient Count"
                    });

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading doctors: " + ex.Message);
                }
            }
        }

        private void LoadDoctors()
        {
            LoadDoctors("");
        }

        //This is the Update button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                frmEditDoctor editForm = new frmEditDoctor
                {
                    DoctorId = row.Cells["colDoctorId"].Value.ToString(),
                    DoctorName = row.Cells["colName"].Value.ToString(),
                    Specialization = row.Cells["colSpecialization"].Value.ToString(),
                    Phone = row.Cells["colPhone"].Value.ToString()
                };

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDoctors(); // Refresh the doctor list
                }
            }
            else
            {
                MessageBox.Show("Please select a doctor to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string doctorId = selectedRow.Cells["colDoctorId"].Value.ToString();

                DialogResult result = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM doctors WHERE doctor_id = @doctorId";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@doctorId", doctorId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Doctor deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadDoctors();
                            }
                            else
                            {
                                MessageBox.Show("Doctor not found or could not be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting doctor: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a doctor to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            formAddDoc addForm = new formAddDoc();
            addForm.DoctorAdded += LoadDoctors;
            addForm.ShowDialog();
        }

        private void labelTotalPatients_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Doctors Report";

                // Add header
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    ((Excel.Range)worksheet.Cells[1, i]).Font.Bold = true;
                }

                // Add rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 2, j + 1] = cellValue?.ToString();
                    }
                }

                worksheet.Columns.AutoFit(); // Autofit columns
                excelApp.Visible = true; // Show Excel to user
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBoxSearch.Text.Trim();
            LoadDoctors(searchTerm);
        }
    }
}
