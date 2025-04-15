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
    public partial class DoctorsControl : UserControl
    {
        public DoctorsControl()
        {
            InitializeComponent();
        }

        private void DoctorsTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DoctorsControl_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            formAddDoc addForm = new formAddDoc();
            addForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
