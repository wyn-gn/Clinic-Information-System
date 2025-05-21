using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clinis_infosys
{
    public partial class frmEditAppt : Form
    {
        public string AppointmentId { get; set; }  // To receive the appointment ID to edit

        public frmEditAppt()
        {
            InitializeComponent();
            this.Load += frmEditAppt_Load; // Ensure correct event is attached
        }

        private void frmEditAppt_Load(object sender, EventArgs e)
        {
            LoadAppointmentDetails();
        }

        private void LoadAppointmentDetails()
        {
            if (string.IsNullOrEmpty(AppointmentId))
            {
                MessageBox.Show("No appointment ID was passed to the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!int.TryParse(AppointmentId, out int appointmentIdInt))
            {
                MessageBox.Show("AppointmentId is not a valid integer: " + AppointmentId, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT appointments_id, patient_id, doctor_id, appointment_date, status
                                    FROM appointments 
                                    WHERE appointments_id = @appointments_id";


                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appointments_id", appointmentIdInt);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                textBox3.Text = reader["appointments_id"].ToString();
                                textBox1.Text = reader["patient_id"].ToString();
                                textBox2.Text = reader["doctor_id"].ToString();
                                dateTimePicker1.Value = Convert.ToDateTime(reader["appointment_date"]);
                                textBox4.Text = reader["status"] == DBNull.Value ? "" : reader["status"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No appointment found with ID: " + AppointmentId, "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(AppointmentId, out int appointmentIdInt))
            {
                MessageBox.Show("Invalid Appointment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string patientId = textBox1.Text.Trim();
            string doctorId = textBox2.Text.Trim();
            string status = textBox4.Text.Trim();
            DateTime appointmentDate = dateTimePicker1.Value;

            if (string.IsNullOrWhiteSpace(patientId) || string.IsNullOrWhiteSpace(doctorId))
            {
                MessageBox.Show("Please fill in both Patient ID and Doctor ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE appointments 
                                     SET patient_id = @patient_id, 
                                         doctor_id = @doctor_id, 
                                         appointment_date = @appointment_date, 
                                         status = @status 
                                     WHERE appointments_id = @appointments_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                        cmd.Parameters.AddWithValue("@appointment_date", appointmentDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@appointments_id", appointmentIdInt);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Appointment may no longer exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating appointment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
