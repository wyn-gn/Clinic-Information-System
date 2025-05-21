using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clinis_infosys
{
    public partial class PatientControls : UserControl
    {
        // Store patients data to allow filtering
        private DataTable patientsTable;

        public PatientControls()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.PatientControls_Load);
        }

        private void PatientControls_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void LoadPatients()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT patient_id, name, date_of_birth, gender, phone, age, address FROM patients";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    patientsTable = new DataTable();
                    adapter.Fill(patientsTable);

                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPatientId",
                        DataPropertyName = "patient_id",
                        HeaderText = "Patient ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colName",
                        DataPropertyName = "name",
                        HeaderText = "Name"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDateOfBirth",
                        DataPropertyName = "date_of_birth",
                        HeaderText = "Date of Birth"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colGender",
                        DataPropertyName = "gender",
                        HeaderText = "Gender"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPhone",
                        DataPropertyName = "phone",
                        HeaderText = "Phone"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colAge",
                        DataPropertyName = "age",
                        HeaderText = "Age"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colAddress",
                        DataPropertyName = "address",
                        HeaderText = "Address"
                    });

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = patientsTable;

                    dataGridView1.Columns["colDateOfBirth"].DefaultCellStyle.Format = "yyyy-MM-dd";

                    // --- New code to get total patients count ---
                    MySqlCommand cmdCount = new MySqlCommand("SELECT count_total_patients();", conn);
                    object result = cmdCount.ExecuteScalar();

                    int totalPatients = 0;
                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        totalPatients = count;
                    }

                    labelTotalPatients.Text = $"Total Patients: {totalPatients}";
                    // --- End new code ---
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading patients: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAddPatient addPatient = new formAddPatient();
            addPatient.PatientAdded += LoadPatients;
            addPatient.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int patientId = Convert.ToInt32(selectedRow.Cells["colPatientId"].Value);
                string name = selectedRow.Cells["colName"].Value.ToString();

                DateTime rawDob = Convert.ToDateTime(selectedRow.Cells["colDateOfBirth"].Value);
                string dob = rawDob.ToString("yyyy-MM-dd");

                string gender = selectedRow.Cells["colGender"].Value.ToString();
                string phone = selectedRow.Cells["colPhone"].Value.ToString();
                string age = selectedRow.Cells["colAge"].Value.ToString();
                string address = selectedRow.Cells["colAddress"].Value.ToString();

                frmEditPatient editForm = new frmEditPatient(patientId, name, dob, gender, phone, age, address);
                editForm.PatientUpdated += LoadPatients;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a patient to update.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int patientId = Convert.ToInt32(selectedRow.Cells["colPatientId"].Value);

                DialogResult result = MessageBox.Show($"Are you sure you want to delete Patient ID {patientId}?",
                                                      "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection(connStr))
                        {
                            conn.Open();

                            string deleteQuery = "DELETE FROM patients WHERE patient_id = @id";

                            using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", patientId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Patient deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadPatients();
                                }
                                else
                                {
                                    MessageBox.Show("Delete failed. Patient not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting patient: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a patient to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PatientControls_Load_1(object sender, EventArgs e)
        {

        }

        private void labelTotalPatients_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No patient data available to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Patients Report";

                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    ((Excel.Range)worksheet.Cells[1, i]).Font.Bold = true;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        object value = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 2, j + 1] = value?.ToString();
                    }
                }

                worksheet.Columns.AutoFit();
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting patient data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Search button click event - Filters the DataGridView by search text across multiple columns
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = textBoxSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(searchValue))
            {
                // Clear filter - show all patients
                dataGridView1.DataSource = patientsTable;
                return;
            }

            DataView dv = new DataView(patientsTable);

            // Filter multiple columns: patient_id, name, phone, address, gender
            dv.RowFilter =
                $"Convert(patient_id, 'System.String') LIKE '%{searchValue}%' OR " +
                $"name LIKE '%{searchValue}%' OR " +
                $"phone LIKE '%{searchValue}%' OR " +
                $"address LIKE '%{searchValue}%' OR " +
                $"gender LIKE '%{searchValue}%'";

            dataGridView1.DataSource = dv;
        }

        // Optional: live search as user types (uncomment if you want this)
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Uncomment next line if you want real-time filtering as you type
            // btnSearch_Click(sender, e);
        }
    }
}
