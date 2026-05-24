namespace WorkSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addemp = new Button();
            btnAllEmployees = new Button();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblStatus = new Label();
            chkDarkMode = new CheckBox();
            SuspendLayout();
            // 
            // addemp
            // 
            addemp.Location = new Point(88, 210);
            addemp.Name = "addemp";
            addemp.Size = new Size(180, 58);
            addemp.TabIndex = 0;
            addemp.Text = "Add Employee";
            addemp.UseVisualStyleBackColor = true;
            addemp.Click += addemp_Click;
            // 
            // btnAllEmployees
            // 
            btnAllEmployees.Location = new Point(312, 210);
            btnAllEmployees.Name = "btnAllEmployees";
            btnAllEmployees.Size = new Size(180, 58);
            btnAllEmployees.TabIndex = 1;
            btnAllEmployees.Text = "All Employees";
            btnAllEmployees.UseVisualStyleBackColor = true;
            btnAllEmployees.Click += btnAllEmployees_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.Location = new Point(56, 54);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(470, 60);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Work System";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = false;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.Location = new Point(74, 123);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(430, 52);
            lblSubtitle.TabIndex = 3;
            lblSubtitle.Text = "Manage employees, salaries, and staff records from one place.";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = false;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(74, 318);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(430, 24);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkDarkMode
            // 
            chkDarkMode.AutoSize = true;
            chkDarkMode.Location = new Point(238, 364);
            chkDarkMode.Name = "chkDarkMode";
            chkDarkMode.Size = new Size(88, 19);
            chkDarkMode.TabIndex = 5;
            chkDarkMode.Text = "Dark theme";
            chkDarkMode.UseVisualStyleBackColor = true;
            chkDarkMode.CheckedChanged += chkDarkMode_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 450);
            Controls.Add(chkDarkMode);
            Controls.Add(lblStatus);
            Controls.Add(lblSubtitle);
            Controls.Add(lblTitle);
            Controls.Add(btnAllEmployees);
            Controls.Add(addemp);
            Name = "Form1";
            Text = "Work System";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button addemp;
        private Button btnAllEmployees;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblStatus;
        private CheckBox chkDarkMode;
    }
}
