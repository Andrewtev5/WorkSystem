using Microsoft.Data.SqlClient;

namespace WorkSystem
{
    public class EditEmployeeForm : Form
    {
        private readonly TextBox txtFirstName;
        private readonly TextBox txtLastName;
        private readonly DateTimePicker dtpBirthDate;
        private readonly NumericUpDown numHeight;
        private readonly NumericUpDown numWeight;
        private readonly TextBox txtEyeColor;
        private readonly TextBox txtPassport;
        private readonly NumericUpDown numSalary;
        private readonly Button btnSave;
        private readonly Button btnCancel;

        public int EmployeeId;

        public EditEmployeeForm()
        {
            Text = "Edit Employee";
            ClientSize = new Size(640, 390);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label title = new Label
            {
                Text = "Edit Employee",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                Location = new Point(28, 22),
                Size = new Size(300, 40)
            };

            txtFirstName = CreateTextBox(150, 86);
            txtLastName = CreateTextBox(460, 86);
            dtpBirthDate = new DateTimePicker { Location = new Point(150, 132), Size = new Size(180, 23) };
            numHeight = CreateNumber(150, 178, 300);
            numWeight = CreateNumber(460, 132, 200);
            txtEyeColor = CreateTextBox(460, 178);
            txtPassport = CreateTextBox(150, 224);
            numSalary = CreateNumber(460, 224, 999999999);

            btnSave = new Button { Text = "Save Changes", Location = new Point(196, 304), Size = new Size(140, 48) };
            btnCancel = new Button { Text = "Cancel", Location = new Point(356, 304), Size = new Size(100, 48) };

            Controls.Add(title);
            AddField("First name -", 28, 90, txtFirstName);
            AddField("Last name -", 352, 90, txtLastName);
            AddField("Date of birth -", 28, 136, dtpBirthDate);
            AddField("Weight -", 352, 136, numWeight);
            AddField("Height -", 28, 182, numHeight);
            AddField("Eye color -", 352, 182, txtEyeColor);
            AddField("Passport number -", 28, 228, txtPassport);
            AddField("Salary -", 352, 228, numSalary);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);

            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;

            AppTheme.Apply(this);
            AppTheme.StyleSecondaryButton(btnCancel);
            title.ForeColor = AppTheme.PrimaryDark;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadEmployee();
        }

        private static TextBox CreateTextBox(int x, int y)
        {
            return new TextBox { Location = new Point(x, y), Size = new Size(160, 23) };
        }

        private static NumericUpDown CreateNumber(int x, int y, int maximum)
        {
            return new NumericUpDown
            {
                Location = new Point(x, y),
                Size = new Size(160, 23),
                Maximum = maximum
            };
        }

        private void AddField(string labelText, int x, int y, Control input)
        {
            Label label = new Label
            {
                Text = labelText,
                Location = new Point(x, y + 3),
                Size = new Size(120, 22)
            };

            Controls.Add(label);
            Controls.Add(input);
        }

        private void LoadEmployee()
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
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    dtpBirthDate.Value = Convert.ToDateTime(reader["BirthDate"]);
                    numHeight.Value = Convert.ToDecimal(reader["Height"]);
                    numWeight.Value = Convert.ToDecimal(reader["Weight"]);
                    txtEyeColor.Text = reader["EyeColor"].ToString();
                    txtPassport.Text = reader["PassportNumber"].ToString();
                    numSalary.Value = Convert.ToDecimal(reader["Salary"]);
                }

                connection.Close();
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

        private void btnSave_Click(object? sender, EventArgs e)
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
                @"UPDATE Employees
    SET FirstName = @FirstName,
        LastName = @LastName,
        BirthDate = @BirthDate,
        Height = @Height,
        Weight = @Weight,
        EyeColor = @EyeColor,
        PassportNumber = @Passport,
        Salary = @Salary
    WHERE Id = @Id";

                SqlCommand cmd =
                new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@BirthDate", dtpBirthDate.Value.Date);
                cmd.Parameters.AddWithValue("@Height", numHeight.Value);
                cmd.Parameters.AddWithValue("@Weight", numWeight.Value);
                cmd.Parameters.AddWithValue("@EyeColor", txtEyeColor.Text.Trim());
                cmd.Parameters.AddWithValue("@Passport", txtPassport.Text.Trim());
                cmd.Parameters.AddWithValue("@Salary", numSalary.Value);
                cmd.Parameters.AddWithValue("@Id", EmployeeId);

                cmd.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Employee updated successfully!");

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
