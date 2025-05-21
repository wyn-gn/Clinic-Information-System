using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace Clinis_infosys
{
    public partial class PrescriptionsControl : UserControl
    {
        public PrescriptionsControl()
        {
            InitializeComponent();
            this.Load += new EventHandler(PrescriptionsControl_Load);
        }

        private void PrescriptionsControl_Load(object sender, EventArgs e)
        {
            LoadPrescriptions();
        }

        private void LoadPrescriptions()
        {
            string connStr = "server=localhost;user=root;password=nicolegwyn;database=clinic_infosys;port=3306;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT 
                                        prescription_id,
                                        record_id,
                                        doctor_id,
                                        patient_id,
                                        medicine_name,
                                        medication_name,
                                        dosage,
                                        instructions
                                     FROM prescriptions";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPrescriptionID",
                        DataPropertyName = "prescription_id",
                        HeaderText = "Prescription ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colRecordID",
                        DataPropertyName = "record_id",
                        HeaderText = "Record ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDoctorID",
                        DataPropertyName = "doctor_id",
                        HeaderText = "Doctor ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colPatientID",
                        DataPropertyName = "patient_id",
                        HeaderText = "Patient ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colMedicineID",
                        DataPropertyName = "medicine_id",
                        HeaderText = "Medicine ID"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colMedicationName",
                        DataPropertyName = "medication_name",
                        HeaderText = "Medication Name"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colDosage",
                        DataPropertyName = "dosage",
                        HeaderText = "Dosage"
                    });

                    dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        Name = "colInstructions",
                        DataPropertyName = "instructions",
                        HeaderText = "Instructions"
                    });

                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading prescriptions: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAddPres addPres = new formAddPres();
            addPres.ShowDialog();
            LoadPrescriptions(); // Refresh after add
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No prescriptions to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Prescriptions";

                // Export column headers
                for (int i = 1; i <= dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    ((Excel.Range)worksheet.Cells[1, i]).Font.Bold = true;
                }

                // Export data rows
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        object value = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cells[i + 2, j + 1] = value?.ToString();
                    }
                }

                worksheet.Columns.AutoFit();
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting prescriptions: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
