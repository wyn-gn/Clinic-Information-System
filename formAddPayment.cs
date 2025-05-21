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
    public partial class formAddPayment : Form
    {
        public formAddPayment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patientIdText = textBox1.Text.Trim();
            string amountText = textBox2.Text.Trim();
            string paymentMethod = textBox3.Text.Trim();
            DateTime paymentDate = dateTimePicker1.Value;

            if (!int.TryParse(patientIdText, out int patientId) || !decimal.TryParse(amountText, out decimal amount))
            {
                MessageBox.Show("Please enter valid Patient ID and Amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Allowed ENUM values exactly matching the MySQL column
            string[] allowedMethods = { "Cash", "Credit Card", "Insurance"};
            if (!allowedMethods.Contains(paymentMethod))
            {
                MessageBox.Show("Invalid payment method. Allowed: Cash, Card, Check, Online.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Debug print
            MessageBox.Show($"Payment Method to insert: '{paymentMethod}'");

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;charset=utf8;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO payments (patient_id, amount, payment_method, payment_date)
                             VALUES (@patient_id, @amount, @method, @payment_date)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@method", paymentMethod);
                        cmd.Parameters.AddWithValue("@payment_date", paymentDate);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Payment added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}

