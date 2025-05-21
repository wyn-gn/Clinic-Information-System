// (rest of your existing using statements)
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
using Excel = Microsoft.Office.Interop.Excel;

namespace Clinis_infosys
{
    public partial class PaymentControl : UserControl
    {
        private NumericUpDown numericIncrease;

        public PaymentControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(PaymentControl_Load);
            this.Resize += PaymentControl_Resize;
        }

        private void PaymentControl_Load(object sender, EventArgs e)
        {
            LoadPayments();
            AddRaisePaymentControls();
            ShowPaymentsDueToday();
        }

        private void ShowPaymentsDueToday()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT check_due_today();", conn);
                    string result = cmd.ExecuteScalar()?.ToString();
                    lblDueToday.Text = result ?? "No data";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving due payments info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPayments()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT payment_id, patient_id, amount, payment_method, payment_status, payment_date FROM payments";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPaymentId",
                        DataPropertyName = "payment_id",
                        HeaderText = "Payment ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPatientId",
                        DataPropertyName = "patient_id",
                        HeaderText = "Patient ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colAmount",
                        DataPropertyName = "amount",
                        HeaderText = "Amount"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPaymentMethod",
                        DataPropertyName = "payment_method",
                        HeaderText = "Payment Method"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPaymentStatus",
                        DataPropertyName = "payment_status",
                        HeaderText = "Payment Status"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPaymentDate",
                        DataPropertyName = "payment_date",
                        HeaderText = "Payment Date"
                    });

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading payments: " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAddPayment addPayment = new formAddPayment();
            addPayment.ShowDialog();
            LoadPayments();
            ShowPaymentsDueToday();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedPaymentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["colPaymentId"].Value);

            frmEditPayment editForm = new frmEditPayment(selectedPaymentId);
            editForm.ShowDialog();

            LoadPayments();
            ShowPaymentsDueToday();
        }

        private void AddRaisePaymentControls()
        {
            // Assuming numericUpDown1 is already added via Designer
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10000;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = 10;
            numericUpDown1.Value = 100; // Default value
        }

        private void PaymentControl_Resize(object sender, EventArgs e)
        {
        }

        private void BtnRaisePayments_Click(object sender, EventArgs e)
        {
        }

        private void btnRaisePayments_Click_1(object sender, EventArgs e)
        {
            double increase = (double)numericUpDown1.Value / 100.0; // convert to percentage

            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("raisePayment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@increase", increase); // match parameter name

                    MySqlDataReader reader = cmd.ExecuteReader();

                    string message = "";
                    while (reader.Read())
                    {
                        message += $"Before: {reader["Total Before"]?.ToString()}\n";

                        if (reader["Total After"] != DBNull.Value)
                            message += $"After: {reader["Total After"]?.ToString()}\n";

                        message += $"{reader["message"]?.ToString()}";
                    }

                    reader.Close();

                    MessageBox.Show(message, "Raise Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPayments();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error calling raisePayment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No payment data available to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Payments Report";

                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    ((Excel.Range)worksheet.Cells[1, i]).Font.Bold = true;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        var cellValue = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 2, j + 1] = cellValue?.ToString();
                    }
                }

                worksheet.Columns.AutoFit();
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting payments to Excel: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
