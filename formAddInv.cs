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
    public partial class formAddInv : Form
    {
        public formAddInv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Capture inputs
            string itemName = textBox3.Text.Trim();
            string quantityText = textBox1.Text.Trim();
            string unit = textBox2.Text.Trim();
            string restockLevelText = textBox5.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(unit) || string.IsNullOrEmpty(restockLevelText))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Quantity must be a non-negative integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(restockLevelText, out int restockLevel) || restockLevel < 0)
            {
                MessageBox.Show("Restock Level must be a non-negative integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert into database
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO inventory (item_name, quantity, unit, restock_level) 
                             VALUES (@item_name, @quantity, @unit, @restock_level)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", itemName);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@restock_level", restockLevel);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inventory item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear inputs
                            textBox3.Clear();
                            textBox1.Clear();
                            textBox2.Clear();
                            textBox5.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add inventory item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
