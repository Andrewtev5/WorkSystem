namespace WorkSystem
{
    partial class EmployeeInfoForm
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
            lblFirstName = new Label();
            lblLastName = new Label();
            lblHeight = new Label();
            lblWeight = new Label();
            lblEyeColor = new Label();
            lblPassport = new Label();
            lblSalary = new Label();
            lblTotalEarned = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 23);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "First name - ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 57);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 1;
            label2.Text = "Last name - ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 97);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Height - ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 133);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 3;
            label4.Text = "Weight - ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 171);
            label5.Name = "label5";
            label5.Size = new Size(65, 15);
            label5.TabIndex = 4;
            label5.Text = "Eye color - ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 215);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 5;
            label6.Text = "Passport - ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 258);
            label7.Name = "label7";
            label7.Size = new Size(117, 15);
            label7.TabIndex = 6;
            label7.Text = "Salary - ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 297);
            label8.Name = "label8";
            label8.Size = new Size(115, 15);
            label8.TabIndex = 7;
            label8.Text = "Total earned - ";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(150, 23);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(0, 15);
            lblFirstName.TabIndex = 8;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(150, 57);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(0, 15);
            lblLastName.TabIndex = 9;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new Point(150, 97);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(0, 15);
            lblHeight.TabIndex = 10;
            // 
            // lblWeight
            // 
            lblWeight.AutoSize = true;
            lblWeight.Location = new Point(150, 133);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(0, 15);
            lblWeight.TabIndex = 11;
            // 
            // lblEyeColor
            // 
            lblEyeColor.AutoSize = true;
            lblEyeColor.Location = new Point(150, 171);
            lblEyeColor.Name = "lblEyeColor";
            lblEyeColor.Size = new Size(0, 15);
            lblEyeColor.TabIndex = 12;
            // 
            // lblPassport
            // 
            lblPassport.AutoSize = true;
            lblPassport.Location = new Point(150, 215);
            lblPassport.Name = "lblPassport";
            lblPassport.Size = new Size(0, 15);
            lblPassport.TabIndex = 13;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Location = new Point(150, 258);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(0, 15);
            lblSalary.TabIndex = 14;
            // 
            // lblTotalEarned
            // 
            lblTotalEarned.AutoSize = true;
            lblTotalEarned.Location = new Point(150, 297);
            lblTotalEarned.Name = "lblTotalEarned";
            lblTotalEarned.Size = new Size(0, 15);
            lblTotalEarned.TabIndex = 15;
            // 
            // EmployeeInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 331);
            Controls.Add(lblTotalEarned);
            Controls.Add(lblSalary);
            Controls.Add(lblPassport);
            Controls.Add(lblEyeColor);
            Controls.Add(lblWeight);
            Controls.Add(lblHeight);
            Controls.Add(lblLastName);
            Controls.Add(lblFirstName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeInfoForm";
            Text = "Employee Information";
            Load += EmployeeInfoForm_Load;
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
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblHeight;
        private Label lblWeight;
        private Label lblEyeColor;
        private Label lblPassport;
        private Label lblSalary;
        private Label lblTotalEarned;
    }
}
