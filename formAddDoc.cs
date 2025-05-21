using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Clinis_infosys
{
    public partial class formAddDoc : Form
    {
        public event Action DoctorAdded; // Custom event

        public formAddDoc()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill all fields", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    // Corrected query with matching parameters
                    string query = "INSERT INTO doctors (name, specialization, phone) VALUES (@Name, @Specialization, @Phone)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Specialization", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", textBox3.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Doctor added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DoctorAdded?.Invoke();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add doctor", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}\nError number: {ex.Number}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void formAddDoc_Load(object sender, EventArgs e)
        {
            // Optional: Set focus to first field when form loads
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Input validation
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill all fields", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO doctors (name, specialization, phone) VALUES (@Name, @Specialization, @Phone)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Specialization", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@Phone", textBox3.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Doctor added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DoctorAdded?.Invoke();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add doctor", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}\nError number: {ex.Number}",
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}