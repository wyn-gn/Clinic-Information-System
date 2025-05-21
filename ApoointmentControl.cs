using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clinis_infosys
{
    public partial class ApoointmentControl : UserControl
    {
        public ApoointmentControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(ApoointmentControl_Load);
        }

        private void ApoointmentControl_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            LoadAppointments(""); // Call the search-based method with an empty string
        }

        private void LoadAppointments(string searchTerm)
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT a.appointments_id, p.name AS patient_name, d.name AS doctor_name, 
                                    a.appointment_date, a.status 
                             FROM appointments a
                             JOIN patients p ON a.patient_id = p.patient_id
                             JOIN doctors d ON a.doctor_id = d.doctor_id
                             WHERE CONCAT(p.name, ' ', d.name, ' ', a.status) LIKE @search";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", $"%{searchTerm}%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colApptId",
                        DataPropertyName = "appointments_id",
                        HeaderText = "Appointment ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPatient",
                        DataPropertyName = "patient_name",
                        HeaderText = "Patient"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDoctor",
                        DataPropertyName = "doctor_name",
                        HeaderText = "Doctor"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDate",
                        DataPropertyName = "appointment_date",
                        HeaderText = "Date"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colStatus",
                        DataPropertyName = "status",
                        HeaderText = "Status"
                    });

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointments: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAddAppt addAppt = new formAddAppt();
            addAppt.AppointmentAdded += LoadAppointments; // Make sure formAddAppt triggers this event
            addAppt.ShowDialog();
        }

        // New method to add an appointment (trigger runs automatically in MySQL)
        public void AddAppointment(int patientId, int doctorId, DateTime appointmentDate, string status)
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string insertQuery = @"INSERT INTO appointments (patient_id, doctor_id, appointment_date, status)
                                           VALUES (@patient_id, @doctor_id, @appointment_date, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                        cmd.Parameters.AddWithValue("@appointment_date", appointmentDate);
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Appointment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the appointment list
                    LoadAppointments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding appointment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: add actions for clicking cells
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete the selected appointment?",
                                                         "Confirm Delete",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string appointmentId = selectedRow.Cells["colApptId"].Value.ToString();

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM appointments WHERE appointments_id = @appointments_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appointments_id", appointmentId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAppointments(); // Refresh the appointment list
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete appointment. It may no longer exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting appointment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ApoointmentControl_Load_1(object sender, EventArgs e)
        {
            // You can leave this empty or add code if needed
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string appointmentId = selectedRow.Cells["colApptId"].Value.ToString();

                frmEditAppt editForm = new frmEditAppt
                {
                    AppointmentId = appointmentId
                };

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAppointments();
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No appointment data available to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Appointments Report";

                // Write column headers
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    ((Excel.Range)worksheet.Cells[1, i]).Font.Bold = true;
                }

                // Write data
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
                MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = textBoxSearch.Text.Trim();
            LoadAppointments(keyword);
        }
    }
}
