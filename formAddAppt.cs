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
using Mysqlx.Crud;

namespace Clinis_infosys
{
    public partial class formAddAppt : Form
    {
        public formAddAppt()
        {
            InitializeComponent();
        }

        // Event to notify parent control (like DoctorsControl or AppointmentsControl)
        public event Action AppointmentAdded;

        private void formAddAppt_Load(object sender, EventArgs e)
        {
            // Optional: preload data into dropdowns (if needed)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patientId = textBox1.Text.Trim();
            string doctorId = textBox2.Text.Trim();
            string appointmentDate = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string status = textBox4.Text.Trim();

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
                    string query = "INSERT INTO appointments (patient_id, doctor_id, appointment_date, status) " +
                                   "VALUES (@patient_id, @doctor_id, @appointment_date, @status)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@doctor_id", doctorId);
                        cmd.Parameters.AddWithValue("@appointment_date", appointmentDate);
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Appointment added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AppointmentAdded?.Invoke(); // Notify the control to reload data
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving appointment: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
