using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace Clinis_infosys
{
    public partial class frmEditDoctor : Form
    {
        public frmEditDoctor()
        {
            InitializeComponent();
        }

        public string DoctorId
        {
            get => textBox7.Text;
            set => textBox7.Text = value;
        }

        public string DoctorName
        {
            get => textBox2.Text;
            set => textBox2.Text = value;
        }

        public string Specialization
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }

        public string Phone
        {
            get => textBox3.Text;
            set => textBox3.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE doctors SET name = @name, specialization = @specialization, phone = @phone WHERE doctor_id = @doctor_id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@specialization", textBox1.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                    cmd.Parameters.AddWithValue("@doctor_id", textBox7.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor information updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating doctor: " + ex.Message);
                }
            }
        }

        private void frmEditDoctor_Load(object sender, EventArgs e)
        {

        }
    }
}
