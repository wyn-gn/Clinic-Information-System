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
    public partial class frmEditPayment : Form
    {
        private int paymentId;

        public frmEditPayment(int id)
        {
            InitializeComponent();
            paymentId = id;
            this.Load += frmEditPayment_Load;
        }

        private void frmEditPayment_Load(object sender, EventArgs e)
        {
            LoadPaymentData();
        }

        private void LoadPaymentData()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT payment_id, patient_id, amount, payment_method, payment_status, payment_date 
                                     FROM payments WHERE payment_id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", paymentId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox7.Text = reader["payment_id"].ToString();
                                textBox2.Text = reader["patient_id"].ToString();        // patient_id
                                textBox1.Text = reader["amount"].ToString();            // amount
                                textBox3.Text = reader["payment_method"].ToString();    // payment_method
                                textBox4.Text = reader["payment_status"].ToString();    // payment_status
                                dateTimePicker1.Value = Convert.ToDateTime(reader["payment_date"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate amount
            if (!decimal.TryParse(textBox1.Text.Trim(), out decimal amount))
            {
                MessageBox.Show("Invalid amount.");
                return;
            }

            // Validate patient_id
            if (!int.TryParse(textBox2.Text.Trim(), out int patientId))
            {
                MessageBox.Show("Invalid Patient ID.");
                return;
            }

            string paymentMethod = textBox3.Text.Trim();
            string[] allowedMethods = { "Cash", "Credit Card", "Insurance" };

            if (!allowedMethods.Contains(paymentMethod))
            {
                MessageBox.Show("Invalid payment method. Allowed values: Cash, Credit Card, Insurance.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentStatus = textBox4.Text.Trim();
            // You can validate paymentStatus here if you have fixed allowed statuses, e.g.
            // string[] allowedStatuses = { "Paid", "Pending", "Cancelled" };
            // if (!allowedStatuses.Contains(paymentStatus)) { /* error */ }

            DateTime paymentDate = dateTimePicker1.Value;

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE payments 
                                     SET patient_id = @patient_id,
                                         amount = @amount, 
                                         payment_method = @method, 
                                         payment_status = @status,
                                         payment_date = @date 
                                     WHERE payment_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patient_id", patientId);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@method", paymentMethod);
                        cmd.Parameters.AddWithValue("@status", paymentStatus);
                        cmd.Parameters.AddWithValue("@date", paymentDate);
                        cmd.Parameters.AddWithValue("@id", paymentId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Payment updated successfully.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made.");
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
