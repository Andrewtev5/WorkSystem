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
    public partial class EmployeesForm : Form
    {
        private void LoadEmployees()
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
                @"SELECT
        Id,
        FirstName,
        LastName,
        Salary,
        TotalEarned
        FROM Employees";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvEmployees.DataSource = table;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchEmployees()
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
                @"SELECT
        Id,
        FirstName,
        LastName,
        Salary,
        TotalEarned
        FROM Employees
        WHERE
        FirstName LIKE @Search
        OR
        LastName LIKE @Search
        OR
        (FirstName + ' ' + LastName) LIKE @Search";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue(
                "@Search",
                "%" + txtSearch.Text + "%");

                SqlDataAdapter adapter =
                new SqlDataAdapter(cmd);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dgvEmployees.DataSource = table;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public EmployeesForm()
        {
            InitializeComponent();
            AppTheme.Apply(this);
            AppTheme.StyleSecondaryButton(btnRefresh);
            AppTheme.StyleSecondaryButton(btnBack);
            lblHint.ForeColor = AppTheme.Muted;
        }

        private void miEmployeeInfo_Click(object sender,EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                return;
            }

            int employeeId =
            Convert.ToInt32(
            dgvEmployees.SelectedRows[0].Cells["Id"].Value);

            EmployeeInfoForm form =
            new EmployeeInfoForm();

            form.EmployeeId = employeeId;

            form.ShowDialog();
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEmployees();
        }

        private void dgvEmployees_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvEmployees.ClearSelection();

                dgvEmployees.Rows[e.RowIndex].Selected = true;
            }
        }

        private void miFireEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                return;
            }

            int employeeId =
            Convert.ToInt32(
            dgvEmployees.SelectedRows[0].Cells["Id"].Value);

            string firstName =
            dgvEmployees.SelectedRows[0].Cells["FirstName"].Value.ToString();

            string lastName =
            dgvEmployees.SelectedRows[0].Cells["LastName"].Value.ToString();

            DialogResult result =
            MessageBox.Show(
            "Are you sure you want to fire " +
            firstName + " " + lastName + "?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
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
                @"DELETE FROM Employees
    WHERE Id = @Id";

                SqlCommand cmd =
                new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Id", employeeId);

                cmd.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Employee fired!");

                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void miManageSalary_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                return;
            }

            int employeeId =
            Convert.ToInt32(
            dgvEmployees.SelectedRows[0].Cells["Id"].Value);

            decimal currentSalary =
            Convert.ToDecimal(
            dgvEmployees.SelectedRows[0].Cells["Salary"].Value);

            ManageSalaryForm form =
            new ManageSalaryForm();

            form.EmployeeId = employeeId;
            form.CurrentSalary = currentSalary;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void miEditEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                return;
            }

            int employeeId =
            Convert.ToInt32(
            dgvEmployees.SelectedRows[0].Cells["Id"].Value);

            EditEmployeeForm form =
            new EditEmployeeForm();

            form.EmployeeId = employeeId;

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void cmsEmployeeMenu_Opening(object sender, CancelEventArgs e)
        {
            bool employeeSelected = dgvEmployees.SelectedRows.Count > 0;

            miFireEmployee.Enabled = employeeSelected;
            miEmployeeInfo.Enabled = employeeSelected;
            miEditEmployee.Enabled = employeeSelected;
            miManageSalary.Enabled = employeeSelected;
        }
    }
}
