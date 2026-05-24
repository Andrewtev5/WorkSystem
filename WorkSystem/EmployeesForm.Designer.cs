namespace WorkSystem
{
    partial class EmployeesForm
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
            components = new System.ComponentModel.Container();
            txtSearch = new TextBox();
            dgvEmployees = new DataGridView();
            cmsEmployeeMenu = new ContextMenuStrip(components);
            miFireEmployee = new ToolStripMenuItem();
            miEmployeeInfo = new ToolStripMenuItem();
            miEditEmployee = new ToolStripMenuItem();
            btnRefresh = new Button();
            label1 = new Label();
            btnBack = new Button();
            btnSearch = new Button();
            miManageSalary = new ToolStripMenuItem();
            lblTitle = new Label();
            lblHint = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            cmsEmployeeMenu.SuspendLayout();
            SuspendLayout();
            // 
            // txtSearch
            // 
            txtSearch.BackColor = SystemColors.ButtonHighlight;
            txtSearch.Location = new Point(151, 76);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(257, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.ContextMenuStrip = cmsEmployeeMenu;
            dgvEmployees.Location = new Point(31, 118);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.Size = new Size(522, 263);
            dgvEmployees.TabIndex = 1;
            dgvEmployees.CellContentClick += dgvEmployees_CellContentClick;
            dgvEmployees.CellMouseDown += dgvEmployees_CellMouseDown;
            // 
            // cmsEmployeeMenu
            // 
            cmsEmployeeMenu.Items.AddRange(new ToolStripItem[] { miEmployeeInfo, miEditEmployee, miManageSalary, miFireEmployee });
            cmsEmployeeMenu.Name = "cmsEmployeeMenu";
            cmsEmployeeMenu.Size = new Size(186, 92);
            cmsEmployeeMenu.Opening += cmsEmployeeMenu_Opening;
            // 
            // miFireEmployee
            // 
            miFireEmployee.Name = "miFireEmployee";
            miFireEmployee.Size = new Size(185, 22);
            miFireEmployee.Text = "Fire Employee";
            miFireEmployee.Click += miFireEmployee_Click;
            // 
            // miEmployeeInfo
            // 
            miEmployeeInfo.Name = "miEmployeeInfo";
            miEmployeeInfo.Size = new Size(185, 22);
            miEmployeeInfo.Text = "Information";
            miEmployeeInfo.Click += miEmployeeInfo_Click;
            // 
            // miEditEmployee
            // 
            miEditEmployee.Name = "miEditEmployee";
            miEditEmployee.Size = new Size(185, 22);
            miEditEmployee.Text = "Edit Employee";
            miEditEmployee.Click += miEditEmployee_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(228, 406);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(116, 42);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 79);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 3;
            label1.Text = "Find employee - ";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(502, 406);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(51, 48);
            btnBack.TabIndex = 22;
            btnBack.Text = "<-";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.AppWorkspace;
            btnSearch.FlatStyle = FlatStyle.Popup;
            btnSearch.Location = new Point(424, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 23;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // miManageSalary
            // 
            miManageSalary.Name = "miManageSalary";
            miManageSalary.Size = new Size(185, 22);
            miManageSalary.Text = "Manage Salary";
            miManageSalary.Click += miManageSalary_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.Location = new Point(31, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(320, 38);
            lblTitle.TabIndex = 24;
            lblTitle.Text = "Employees";
            // 
            // lblHint
            // 
            lblHint.AutoSize = false;
            lblHint.Location = new Point(357, 27);
            lblHint.Name = "lblHint";
            lblHint.Size = new Size(196, 24);
            lblHint.TabIndex = 25;
            lblHint.Text = "Right-click a row for actions";
            lblHint.TextAlign = ContentAlignment.MiddleRight;
            // 
            // EmployeesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(575, 452);
            Controls.Add(lblHint);
            Controls.Add(lblTitle);
            Controls.Add(btnSearch);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(btnRefresh);
            Controls.Add(dgvEmployees);
            Controls.Add(txtSearch);
            Name = "EmployeesForm";
            Text = "Employees";
            Load += EmployeesForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            cmsEmployeeMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSearch;
        private DataGridView dgvEmployees;
        private Button btnRefresh;
        private Label label1;
        private Button btnBack;
        private Button btnSearch;
        private ContextMenuStrip cmsEmployeeMenu;
        private ToolStripMenuItem miFireEmployee;
        private ToolStripMenuItem miEmployeeInfo;
        private ToolStripMenuItem miEditEmployee;
        private ToolStripMenuItem miManageSalary;
        private Label lblTitle;
        private Label lblHint;
    }
}
