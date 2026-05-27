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
            btnStartTimer = new Button();
            btnStopTimer = new Button();
            btnResetTimer = new Button();
            lblTimerState = new Label();
            lblTimerDetails = new Label();
            SuspendLayout();
            // 
            // addemp
            // 
            addemp.Location = new Point(88, 190);
            addemp.Name = "addemp";
            addemp.Size = new Size(180, 58);
            addemp.TabIndex = 0;
            addemp.Text = "Add Employee";
            addemp.UseVisualStyleBackColor = true;
            addemp.Click += addemp_Click;
            // 
            // btnAllEmployees
            // 
            btnAllEmployees.Location = new Point(312, 190);
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
            lblStatus.Location = new Point(74, 402);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(430, 24);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkDarkMode
            // 
            chkDarkMode.AutoSize = true;
            chkDarkMode.Location = new Point(238, 430);
            chkDarkMode.Name = "chkDarkMode";
            chkDarkMode.Size = new Size(88, 19);
            chkDarkMode.TabIndex = 5;
            chkDarkMode.Text = "Dark theme";
            chkDarkMode.UseVisualStyleBackColor = true;
            chkDarkMode.CheckedChanged += chkDarkMode_CheckedChanged;
            // 
            // btnStartTimer
            // 
            btnStartTimer.Location = new Point(88, 286);
            btnStartTimer.Name = "btnStartTimer";
            btnStartTimer.Size = new Size(120, 42);
            btnStartTimer.TabIndex = 6;
            btnStartTimer.Text = "Start Timer";
            btnStartTimer.UseVisualStyleBackColor = true;
            btnStartTimer.Click += btnStartTimer_Click;
            // 
            // btnStopTimer
            // 
            btnStopTimer.Location = new Point(230, 286);
            btnStopTimer.Name = "btnStopTimer";
            btnStopTimer.Size = new Size(120, 42);
            btnStopTimer.TabIndex = 7;
            btnStopTimer.Text = "Stop Timer";
            btnStopTimer.UseVisualStyleBackColor = true;
            btnStopTimer.Click += btnStopTimer_Click;
            // 
            // btnResetTimer
            // 
            btnResetTimer.Location = new Point(372, 286);
            btnResetTimer.Name = "btnResetTimer";
            btnResetTimer.Size = new Size(120, 42);
            btnResetTimer.TabIndex = 8;
            btnResetTimer.Text = "Reset";
            btnResetTimer.UseVisualStyleBackColor = true;
            btnResetTimer.Click += btnResetTimer_Click;
            // 
            // lblTimerState
            // 
            lblTimerState.AutoSize = false;
            lblTimerState.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTimerState.Location = new Point(88, 338);
            lblTimerState.Name = "lblTimerState";
            lblTimerState.Size = new Size(404, 24);
            lblTimerState.TabIndex = 9;
            lblTimerState.Text = "Payroll timer: stopped";
            lblTimerState.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTimerDetails
            // 
            lblTimerDetails.AutoSize = false;
            lblTimerDetails.Font = new Font("Segoe UI", 9F);
            lblTimerDetails.Location = new Point(88, 365);
            lblTimerDetails.Name = "lblTimerDetails";
            lblTimerDetails.Size = new Size(404, 24);
            lblTimerDetails.TabIndex = 10;
            lblTimerDetails.Text = "1 real minute = 1 worked month";
            lblTimerDetails.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 470);
            Controls.Add(lblTimerDetails);
            Controls.Add(lblTimerState);
            Controls.Add(btnResetTimer);
            Controls.Add(btnStopTimer);
            Controls.Add(btnStartTimer);
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
        private Button btnStartTimer;
        private Button btnStopTimer;
        private Button btnResetTimer;
        private Label lblTimerState;
        private Label lblTimerDetails;
    }
}
