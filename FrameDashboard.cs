using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinis_infosys
{
    public partial class FrameDashboard : Form
    {
        DoctorsControl doctorsControl = new DoctorsControl();
        PatientControls patientControls = new PatientControls();
        DashboardControl dashboardControl = new DashboardControl();
        ApoointmentControl appointmentControl = new ApoointmentControl();
        PaymentControl paymentControl = new PaymentControl();
        PrescriptionsControl prescriptionsControl = new PrescriptionsControl();
        InventoryControl inventoryControl = new InventoryControl();
        MedicalRecordsControl medicalRecordsControl = new MedicalRecordsControl();

        public FrameDashboard()
        {
            InitializeComponent();

            doctorsControl.Dock = DockStyle.Fill;
            patientControls.Dock = DockStyle.Fill;
            dashboardControl.Dock = DockStyle.Fill;
            appointmentControl.Dock = DockStyle.Fill;
            paymentControl.Dock = DockStyle.Fill;
            prescriptionsControl.Dock = DockStyle.Fill;
            inventoryControl.Dock = DockStyle.Fill;
            medicalRecordsControl.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(doctorsControl);
            mainPanel.Controls.Add(patientControls);
            mainPanel.Controls.Add(dashboardControl);
            mainPanel.Controls.Add(appointmentControl);
            mainPanel.Controls.Add(paymentControl);
            mainPanel.Controls.Add(prescriptionsControl);
            mainPanel.Controls.Add(inventoryControl);
            mainPanel.Controls.Add(medicalRecordsControl);

            dashboardControl.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dashboardControl.Show();
            dashboardControl.BringToFront();
        }

        private void btnDoctors_Click(object sender, EventArgs e)
        {
            doctorsControl.BringToFront();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            patientControls.BringToFront();
        }


        private void FrameDashboard_Load(object sender, EventArgs e)
        {

        }

        private void doctorsControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            appointmentControl.BringToFront();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            paymentControl.BringToFront();
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            prescriptionsControl.BringToFront();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            inventoryControl.BringToFront();
        }

        private void btnMedrecords_Click(object sender, EventArgs e)
        {
            medicalRecordsControl.BringToFront();
        }
    }
}
