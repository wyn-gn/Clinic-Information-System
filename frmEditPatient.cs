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
    public partial class frmEditPatient : Form
    {
        private int patientId;

        public event Action PatientUpdated;

        public frmEditPatient(int id, string name, string dob, string gender, string phone, string age, string address)
        {
            InitializeComponent();
            patientId = id;
            textBox7.Text = patientId.ToString();
            textBox2.Text = name;
            textBox1.Text = dob;
            textBox3.Text = gender;
            textBox4.Text = phone;
            textBox5.Text = age;
            textBox6.Text = address;
        }

        private void frmEditPatient_Load(object sender, EventArgs e)
        {
            // You can optionally set focus to the first textbox
            textBox2.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE patients 
                                     SET name=@name, date_of_birth=@dob, gender=@gender, phone=@phone, age=@age, address=@address 
                                     WHERE patient_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                        cmd.Parameters.AddWithValue("@dob", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@gender", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", textBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@age", textBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", textBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", patientId);

                        int result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Patient updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PatientUpdated?.Invoke(); // Trigger event
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. No rows affected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
