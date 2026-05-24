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
    public partial class EmployeeInfoForm : Form
    {
        public int EmployeeId;
        public EmployeeInfoForm()
        {
            InitializeComponent();
            AppTheme.Apply(this);
            lblFirstName.ForeColor = AppTheme.PrimaryDark;
            lblLastName.ForeColor = AppTheme.PrimaryDark;
            lblHeight.ForeColor = AppTheme.PrimaryDark;
            lblWeight.ForeColor = AppTheme.PrimaryDark;
            lblEyeColor.ForeColor = AppTheme.PrimaryDark;
            lblPassport.ForeColor = AppTheme.PrimaryDark;
            lblSalary.ForeColor = AppTheme.PrimaryDark;
            lblTotalEarned.ForeColor = AppTheme.PrimaryDark;
        }

        private void LoadEmployeeInfo()
        {
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
                @"SELECT *
        FROM Employees
        WHERE Id = @Id";

                SqlCommand cmd =
                new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Id", EmployeeId);

                SqlDataReader reader =
                cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblFirstName.Text =
                    reader["FirstName"].ToString();

                    lblLastName.Text =
                    reader["LastName"].ToString();

                    lblHeight.Text =
                    reader["Height"].ToString();

                    lblWeight.Text =
                    reader["Weight"].ToString();

                    lblEyeColor.Text =
                    reader["EyeColor"].ToString();

                    lblPassport.Text =
                    reader["PassportNumber"].ToString();

                    lblSalary.Text =
                    reader["Salary"].ToString();

                    lblTotalEarned.Text =
                    reader["TotalEarned"].ToString();
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeeInfoForm_Load(object sender, EventArgs e)
        {
            LoadEmployeeInfo();
        }

    }
}
