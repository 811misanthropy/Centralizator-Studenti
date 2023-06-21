using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form24ReportStudentiDupaOrigine : Form
    {
        public Form24ReportStudentiDupaOrigine()
        {
            InitializeComponent();
        }

        private void Form24ReportStudentiPerAnAcademic_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
