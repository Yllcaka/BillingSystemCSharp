﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.UI
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
        }
    }
}
