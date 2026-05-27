using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WorkSystem
{
    using Microsoft.Data.SqlClient;
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
            AppTheme.Apply(this);
            AppTheme.StyleSecondaryButton(btnBack);
            label9.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label9.ForeColor = AppTheme.PrimaryDark;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {

        }

        private void btnHireEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInput())
            {
                return;
            }

            try
            {
                SqlConnection connection =
                new SqlConnection(
                @"Server=.\SQLEXPRESS;
    Database=EmployeeDB;
    Trusted_Connection=True;
    TrustServerCertificate=True;");

                connection.Open();

                string query =
                @"INSERT INTO Employees
    (
        FirstName,
        LastName,
        BirthDate,
        Height,
        Weight,
        EyeColor,
        PassportNumber,
        Salary,
        TotalEarned,
        WorkedMinutes,
        LastSalaryTime
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @BirthDate,
        @Height,
        @Weight,
        @EyeColor,
        @Passport,
        @Salary,
        0,
        0,
        GETDATE()
    )";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());

                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());

                cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value.Date);

                cmd.Parameters.AddWithValue("@Height", numHeight.Value);

                cmd.Parameters.AddWithValue("@Weight", numWeight.Value);

                cmd.Parameters.AddWithValue("@EyeColor", txtEyeColor.Text.Trim());

                cmd.Parameters.AddWithValue("@Passport", txtPassport.Text.Trim());

                cmd.Parameters.AddWithValue("@Salary", numSalary.Value);

                cmd.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Employee hired successfully!");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool ValidateEmployeeInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Enter a first name!");
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Enter a last name!");
                txtLastName.Focus();
                return false;
            }

            if (dtpBirthDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Birth date cannot be in the future!");
                dtpBirthDate.Focus();
                return false;
            }

            if (numHeight.Value <= 0)
            {
                MessageBox.Show("Enter a valid height!");
                numHeight.Focus();
                return false;
            }

            if (numWeight.Value <= 0)
            {
                MessageBox.Show("Enter a valid weight!");
                numWeight.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEyeColor.Text))
            {
                MessageBox.Show("Enter an eye color!");
                txtEyeColor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassport.Text))
            {
                MessageBox.Show("Enter a passport number!");
                txtPassport.Focus();
                return false;
            }

            if (txtPassport.Text.Trim().Length < 4)
            {
                MessageBox.Show("Passport number must contain at least 4 characters!");
                txtPassport.Focus();
                return false;
            }

            if (numSalary.Value <= 0)
            {
                MessageBox.Show("Enter a salary!");
                numSalary.Focus();
                return false;
            }

            return true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEmployeeForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
