using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clinis_infosys
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            this.Load += DashboardControl_Load;
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            LoadDashboardStats();
            LoadScheduledAppointments();
        }

        private void LoadDashboardStats()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Count Doctors
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM doctors", conn))
                    {
                        numDoc.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Count Patients
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM patients", conn))
                    {
                        numPatient.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Count Scheduled Appointments
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM appointments WHERE status = 'Scheduled'", conn))
                    {
                        numAppointment.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Count Pending Payments using your MySQL function
                    using (MySqlCommand cmd = new MySqlCommand("SELECT CheckPendingPayments()", conn))
                    {
                        numPending.Text = cmd.ExecuteScalar().ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading dashboard stats: " + ex.Message);
                }
            }
        }

        private void LoadScheduledAppointments()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    a.appointments_id AS 'Appointment ID', 
                    p.name AS 'Patient Name', 
                    d.name AS 'Doctor Name', 
                    a.appointment_date AS 'Date', 
                    a.status AS 'Status'
                FROM appointments a
                JOIN patients p ON a.patient_id = p.patient_id
                JOIN doctors d ON a.doctor_id = d.doctor_id
                WHERE a.status = 'Scheduled'";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Clear previous data/columns to avoid duplicates
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();

                    dataGridView1.DataSource = table;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading appointments: " + ex.Message);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numDoc_Click(object sender, EventArgs e)
        {

        }

        private void numPatient_Click(object sender, EventArgs e)
        {

        }

        private void numAppointment_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numPending_Click(object sender, EventArgs e)
        {

        }
    }
}
