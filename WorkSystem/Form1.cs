namespace WorkSystem
{
    using Microsoft.Data.SqlClient;
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer salaryTimer;
        private bool isSalaryTimerRunning;

        public Form1()
        {
            InitializeComponent();

            salaryTimer = new System.Windows.Forms.Timer();
            salaryTimer.Interval = 1000;
            salaryTimer.Tick += salaryTimer_Tick;

            ApplyTheme();
        }

        private void ApplyTheme()
        {
            AppTheme.Apply(this);
            AppTheme.StyleSecondaryButton(btnAllEmployees);
            AppTheme.StyleButton(btnStartTimer);
            AppTheme.StyleSecondaryButton(btnStopTimer);
            AppTheme.StyleSecondaryButton(btnResetTimer);
            lblSubtitle.ForeColor = AppTheme.Muted;
            lblStatus.ForeColor = AppTheme.Muted;
            lblTimerDetails.ForeColor = AppTheme.Muted;

            chkDarkMode.CheckedChanged -= chkDarkMode_CheckedChanged;
            chkDarkMode.Checked = AppTheme.IsDarkMode;
            chkDarkMode.CheckedChanged += chkDarkMode_CheckedChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                SalaryTimerManager.EnsureDatabase();

                SqlConnection connection =
                new SqlConnection(
                @"Server=.\SQLEXPRESS;
    Database=EmployeeDB;
    Trusted_Connection=True;
    TrustServerCertificate=True;");

                connection.Open();
                lblStatus.Text = "Database connection is ready";

                connection.Close();

                isSalaryTimerRunning = SalaryTimerManager.IsRunning();

                if (isSalaryTimerRunning)
                {
                    SalaryTimerManager.AccrueDueSalaries();
                    salaryTimer.Start();
                }

                UpdateTimerDisplay();
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

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isSalaryTimerRunning)
                {
                    SalaryTimerManager.MarkSalaryClockNow();
                }

                isSalaryTimerRunning = true;
                SalaryTimerManager.SetRunning(true);
                salaryTimer.Start();
                UpdateTimerDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            try
            {
                SalaryTimerManager.AccrueDueSalaries();
                SalaryTimerManager.MarkSalaryClockNow();
                isSalaryTimerRunning = false;
                SalaryTimerManager.SetRunning(false);
                salaryTimer.Stop();
                UpdateTimerDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResetTimer_Click(object sender, EventArgs e)
        {
            DialogResult result =
            MessageBox.Show(
                "Reset payroll timer, total earned money, and worked time for all employees?",
                "Reset payroll timer",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                salaryTimer.Stop();
                SalaryTimerManager.Reset();
                isSalaryTimerRunning = false;
                UpdateTimerDisplay();
                MessageBox.Show("Payroll timer reset successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void salaryTimer_Tick(object? sender, EventArgs e)
        {
            try
            {
                int updatedEmployees = SalaryTimerManager.AccrueDueSalaries();

                if (updatedEmployees > 0)
                {
                    lblStatus.Text = "Salary accrued for " + updatedEmployees + " employee(s)";
                }

                UpdateTimerDisplay();
            }
            catch (Exception ex)
            {
                salaryTimer.Stop();
                isSalaryTimerRunning = false;
                SalaryTimerManager.SetRunning(false);
                lblStatus.Text = "Payroll timer stopped: " + ex.Message;
                UpdateTimerDisplay();
            }
        }

        private void UpdateTimerDisplay()
        {
            lblTimerState.Text =
                isSalaryTimerRunning
                    ? "Payroll timer: running"
                    : "Payroll timer: stopped";

            lblTimerDetails.Text =
                "1 real minute = 1 worked month | Total worked months: " +
                SalaryTimerManager.GetTotalWorkedMinutes();

            btnStartTimer.Enabled = !isSalaryTimerRunning;
            btnStopTimer.Enabled = isSalaryTimerRunning;
        }
    }
}
