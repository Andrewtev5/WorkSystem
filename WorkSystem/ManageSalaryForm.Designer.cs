namespace WorkSystem
{
    partial class ManageSalaryForm
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
            lblCurrentSalary = new Label();
            numNewSalary = new NumericUpDown();
            btnSaveSalary = new Button();
            ((System.ComponentModel.ISupportInitialize)numNewSalary).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(126, 15);
            label1.TabIndex = 0;
            label1.Text = "Current salary - ";
            label1.Click += label1_Click;
            // 
            // lblCurrentSalary
            // 
            lblCurrentSalary.AutoSize = true;
            lblCurrentSalary.Location = new Point(144, 9);
            lblCurrentSalary.Name = "lblCurrentSalary";
            lblCurrentSalary.Size = new Size(0, 15);
            lblCurrentSalary.TabIndex = 1;
            // 
            // numNewSalary
            // 
            numNewSalary.Location = new Point(12, 37);
            numNewSalary.Maximum = new decimal(new int[] { 1874919424, 2328306, 0, 0 });
            numNewSalary.Name = "numNewSalary";
            numNewSalary.Size = new Size(120, 23);
            numNewSalary.TabIndex = 2;
            // 
            // btnSaveSalary
            // 
            btnSaveSalary.Location = new Point(12, 77);
            btnSaveSalary.Name = "btnSaveSalary";
            btnSaveSalary.Size = new Size(111, 46);
            btnSaveSalary.TabIndex = 3;
            btnSaveSalary.Text = "Save";
            btnSaveSalary.UseVisualStyleBackColor = true;
            btnSaveSalary.Click += btnSaveSalary_Click;
            // 
            // ManageSalaryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 141);
            Controls.Add(btnSaveSalary);
            Controls.Add(numNewSalary);
            Controls.Add(lblCurrentSalary);
            Controls.Add(label1);
            Name = "ManageSalaryForm";
            Text = "Manage Salary";
            ((System.ComponentModel.ISupportInitialize)numNewSalary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCurrentSalary;
        private NumericUpDown numNewSalary;
        private Button btnSaveSalary;
    }
}
