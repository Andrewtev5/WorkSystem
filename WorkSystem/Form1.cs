namespace WorkSystem
{
    using Microsoft.Data.SqlClient;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            AppTheme.Apply(this);
            AppTheme.StyleSecondaryButton(btnAllEmployees);
            lblSubtitle.ForeColor = AppTheme.Muted;
            lblStatus.ForeColor = AppTheme.Muted;

            chkDarkMode.CheckedChanged -= chkDarkMode_CheckedChanged;
            chkDarkMode.Checked = AppTheme.IsDarkMode;
            chkDarkMode.CheckedChanged += chkDarkMode_CheckedChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
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
                lblStatus.Text = "Database connection is ready";

                connection.Close();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Database connection failed: " + ex.Message;
            }
        }

        private void addemp_Click(object sender, EventArgs e)
        {
            AddEmployeeForm form = new AddEmployeeForm();

            form.ShowDialog();
        }

        private void btnAllEmployees_Click(object sender, EventArgs e)
        {
            EmployeesForm form = new EmployeesForm();

            form.ShowDialog();
        }

        private void chkDarkMode_CheckedChanged(object? sender, EventArgs e)
        {
            AppTheme.IsDarkMode = chkDarkMode.Checked;
            ApplyTheme();
        }
    }
}
