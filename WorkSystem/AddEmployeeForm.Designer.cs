namespace WorkSystem
{
    partial class AddEmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtEyeColor = new TextBox();
            txtPassport = new TextBox();
            btnHireEmployee = new Button();
            label9 = new Label();
            numSalary = new NumericUpDown();
            numHeight = new NumericUpDown();
            numWeight = new NumericUpDown();
            btnBack = new Button();
            dtpBirthDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)numSalary).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 74);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "First name -";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(347, 77);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 1;
            label2.Text = "Last name -";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 114);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 2;
            label3.Text = "Date of birth - ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 153);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 3;
            label4.Text = "Height - ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(352, 117);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 4;
            label5.Text = "Weight - ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(352, 156);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 5;
            label6.Text = "Eye color - ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 191);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 6;
            label7.Text = "Passport number - ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(355, 194);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 7;
            label8.Text = "Starting salary - ";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(130, 71);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(100, 23);
            txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(445, 74);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(100, 23);
            txtLastName.TabIndex = 9;
            // 
            // txtEyeColor
            // 
            txtEyeColor.Location = new Point(445, 153);
            txtEyeColor.Name = "txtEyeColor";
            txtEyeColor.Size = new Size(100, 23);
            txtEyeColor.TabIndex = 13;
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(138, 188);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(100, 23);
            txtPassport.TabIndex = 14;
            // 
            // btnHireEmployee
            // 
            btnHireEmployee.Location = new Point(242, 251);
            btnHireEmployee.Name = "btnHireEmployee";
            btnHireEmployee.Size = new Size(125, 48);
            btnHireEmployee.TabIndex = 16;
            btnHireEmployee.Text = "Hire";
            btnHireEmployee.UseVisualStyleBackColor = true;
            btnHireEmployee.Click += btnHireEmployee_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(172, 22);
            label9.Name = "label9";
            label9.Size = new Size(271, 15);
            label9.TabIndex = 17;
            label9.Text = "Enter a new employee into the database";
            // 
            // numSalary
            // 
            numSalary.Location = new Point(455, 189);
            numSalary.Maximum = new decimal(new int[] { 1874919424, 2328306, 0, 0 });
            numSalary.Name = "numSalary";
            numSalary.Size = new Size(120, 23);
            numSalary.TabIndex = 18;
            // 
            // numHeight
            // 
            numHeight.Location = new Point(130, 151);
            numHeight.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(120, 23);
            numHeight.TabIndex = 19;
            // 
            // numWeight
            // 
            numWeight.Location = new Point(445, 112);
            numWeight.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            numWeight.Name = "numWeight";
            numWeight.Size = new Size(120, 23);
            numWeight.TabIndex = 20;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(546, 251);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(51, 48);
            btnBack.TabIndex = 21;
            btnBack.Text = "<-";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(130, 108);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(200, 23);
            dtpBirthDate.TabIndex = 22;
            // 
            // AddEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(609, 311);
            Controls.Add(dtpBirthDate);
            Controls.Add(btnBack);
            Controls.Add(numWeight);
            Controls.Add(numHeight);
            Controls.Add(numSalary);
            Controls.Add(label9);
            Controls.Add(btnHireEmployee);
            Controls.Add(txtPassport);
            Controls.Add(txtEyeColor);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Cursor = Cursors.Hand;
            Name = "AddEmployeeForm";
            Text = "Add Employee";
            Load += AddEmployeeForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)numSalary).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWeight).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox txtEyeColor;
        private TextBox txtPassport;
        private TextBox textBox8;
        private Button btnHireEmployee;
        private Label label9;
        private NumericUpDown numSalary;
        private NumericUpDown numHeight;
        private NumericUpDown numWeight;
        private Button btnBack;
        private DateTimePicker dtpBirthDate;
    }
}
