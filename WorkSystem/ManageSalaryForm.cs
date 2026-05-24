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

    public partial class ManageSalaryForm : Form
    {
        public int EmployeeId;
        public decimal CurrentSalary;

        public ManageSalaryForm()
        {
            InitializeComponent();
            AppTheme.Apply(this);
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCurrentSalary.ForeColor = AppTheme.PrimaryDark;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            lblCurrentSalary.Text = CurrentSalary.ToString();
            numNewSalary.Value = CurrentSalary;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveSalary_Click(object sender, EventArgs e)
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
                @"UPDATE Employees
    SET Salary = @Salary
    WHERE Id = @Id";

                SqlCommand cmd =
                new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Salary", numNewSalary.Value);
                cmd.Parameters.AddWithValue("@Id", EmployeeId);

                cmd.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Salary updated successfully!");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
