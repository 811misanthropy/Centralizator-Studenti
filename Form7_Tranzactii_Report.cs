﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Centralizator_Studenti
{
    public partial class Form7_Tranzactii_Report : Form
    {
        public Form7_Tranzactii_Report()
        {
            InitializeComponent();
        }

        private void Form7_Tranzactii_Report_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'dataSet2.DataTable1' table. You can move, or remove it, as needed.
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.dataTable1TableAdapter.Fill(this.dataSet2.DataTable1, textBox1.Text);
                this.dataTable11TableAdapter.Fill(this.dataSet2.DataTable11, textBox1.Text);

                this.reportViewer1.RefreshReport();
            }
            else
                MessageBox.Show("Introduceti numarul de dosat!");
        }
    }
}
