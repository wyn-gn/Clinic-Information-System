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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clinis_infosys
{
    public partial class formAddPatient : Form
    {
        public event Action PatientAdded;

        public formAddPatient()
        {
            InitializeComponent();
        }

        private void formAddPatient_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Replace these textBox names with your actual controls for patient data
            string name = textBox1.Text.Trim();
            string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string gender = textBox2.Text.Trim();
            string phone = textBox3.Text.Trim();
            string age = textBox4.Text.Trim();
            string address = textBox5.Text.Trim();

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"INSERT INTO patients (name, date_of_birth, gender, phone, age, address)
                                     VALUES (@name, @dob, @gender, @phone, @age, @address)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@address", address);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Patient added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            PatientAdded?.Invoke();  // notify parent form to refresh

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
