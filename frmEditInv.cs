using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clinis_infosys
{
    public partial class frmEditInv : Form
    {
        public int InventoryId { get; set; } // Set this before showing the form

        public frmEditInv()
        {
            InitializeComponent();
            this.Load += frmEditInv_Load;
            button1.Click += button1_Click;
        }

        private void frmEditInv_Load(object sender, EventArgs e)
        {
            LoadInventoryDetails();
        }

        private void LoadInventoryDetails()
        {
            if (InventoryId == 0)
            {
                MessageBox.Show("Invalid Inventory ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT inventory_id, actual_quantity, item_name, quantity, unit, restock_level 
                             FROM inventory 
                             WHERE inventory_id = @inventory_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@inventory_id", InventoryId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                textBox7.Text = reader["inventory_id"].ToString();     
                                textBox1.Text = reader["quantity"].ToString();          // quantity
                                textBox2.Text = reader["item_name"].ToString();         // item name
                                textBox3.Text = reader["unit"].ToString();              // unit
                                textBox4.Text = reader["restock_level"].ToString();     // restock level
                                textBox5.Text = reader["actual_quantity"].ToString();   // actual quantity
                            }
                            else
                            {
                                MessageBox.Show("Inventory item not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string itemName = textBox2.Text.Trim();
            string quantityText = textBox1.Text.Trim();
            string unit = textBox3.Text.Trim();
            string restockLevelText = textBox4.Text.Trim();
            string actualQuantityText = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(itemName) || string.IsNullOrEmpty(quantityText) ||
                string.IsNullOrEmpty(unit) || string.IsNullOrEmpty(restockLevelText) ||
                string.IsNullOrEmpty(actualQuantityText))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity < 0 ||
                !int.TryParse(restockLevelText, out int restockLevel) || restockLevel < 0 ||
                !int.TryParse(actualQuantityText, out int actualQuantity) || actualQuantity < 0)
            {
                MessageBox.Show("Quantity values must be non-negative integers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE inventory 
                             SET item_name = @item_name, 
                                 quantity = @quantity, 
                                 unit = @unit, 
                                 restock_level = @restock_level,
                                 actual_quantity = @actual_quantity
                             WHERE inventory_id = @inventory_id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@item_name", itemName);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@restock_level", restockLevel);
                        cmd.Parameters.AddWithValue("@actual_quantity", actualQuantity);
                        cmd.Parameters.AddWithValue("@inventory_id", InventoryId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Inventory updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Update failed. Inventory item may no longer exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating inventory: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}