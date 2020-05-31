﻿using BillingSystem.BLL;
using BillingSystem.DAL;
using System;
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
    public partial class frmUsers : Form
    {
        userBLL u = new userBLL();
        userDAL dal = new userDAL();
        public frmUsers()
        {
            InitializeComponent();

        }
        
        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        
        private void refreshDataGridView(string type = null) { 
            DataTable dt = type != null ? dal.Search(type) : dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUserName.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;

            string loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIDFromUsername(loggedUser);
            u.added_by = usr.id;

            bool success = dal.Insert(u);
            if (success) clearFields();
            MessageBox.Show(success ? "User-i eshte krijuar me sukses" : "Krijimi i User-it Deshtoi");

            refreshDataGridView();


        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            refreshDataGridView();
        }
        private void clearFields() {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            cmbGender.Text = "";
            cmbUserType.Text = "";
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Func<int, string> currentRow = x => dgvUsers.Rows[rowIndex].Cells[x].Value.ToString();
            txtUserID.Text = currentRow(0);
            txtFirstName.Text = currentRow(1);
            txtLastName.Text = currentRow(2);
            txtEmail.Text = currentRow(3);
            txtUserName.Text = currentRow(4);
            txtPassword.Text = currentRow(5);
            txtContact.Text = currentRow(6);
            txtAddress.Text = currentRow(7);
            cmbGender.Text = currentRow(8);
            cmbUserType.Text = currentRow(9);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtUserID.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUserName.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUserType.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            bool success = dal.Update(u);
            if (success) clearFields();
            MessageBox.Show(success ? "User-i eshte bere Update me sukses" : "Update i User-it Deshtoi");
            

            refreshDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtUserID.Text);
            bool success = dal.Delete(u);
            if (success) clearFields();
            MessageBox.Show(success ? "User-i eshte shlyer me sukses" : "Shlyerja e User-it Deshtoi");

            refreshDataGridView();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtSearch.Text;
            refreshDataGridView(keywords);
        }
    }
}
