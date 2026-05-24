namespace WorkSystem
{
    internal static class AppTheme
    {
        public static bool IsDarkMode { get; set; }

        public static Color Background => IsDarkMode ? Color.FromArgb(17, 24, 39) : Color.FromArgb(245, 247, 251);
        public static Color Surface => IsDarkMode ? Color.FromArgb(31, 41, 55) : Color.White;
        public static Color Primary => IsDarkMode ? Color.FromArgb(96, 165, 250) : Color.FromArgb(37, 99, 235);
        public static Color PrimaryDark => Color.FromArgb(30, 64, 175);
        public static Color Text => IsDarkMode ? Color.FromArgb(243, 244, 246) : Color.FromArgb(31, 41, 55);
        public static Color Muted => IsDarkMode ? Color.FromArgb(156, 163, 175) : Color.FromArgb(107, 114, 128);
        public static Color Border => IsDarkMode ? Color.FromArgb(75, 85, 99) : Color.FromArgb(209, 213, 219);

        public static void Apply(Form form)
        {
            form.BackColor = Background;
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            form.StartPosition = FormStartPosition.CenterScreen;

            ApplyToControls(form.Controls);
        }

        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Button button:
                        StyleButton(button);
                        break;
                    case TextBox textBox:
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                        textBox.BackColor = Surface;
                        textBox.ForeColor = Text;
                        break;
                    case Label label:
                        label.ForeColor = Text;
                        break;
                    case CheckBox checkBox:
                        checkBox.ForeColor = Text;
                        checkBox.BackColor = Background;
                        break;
                    case DataGridView grid:
                        StyleGrid(grid);
                        break;
                    case NumericUpDown numeric:
                        numeric.BorderStyle = BorderStyle.FixedSingle;
                        numeric.BackColor = Surface;
                        numeric.ForeColor = Text;
                        break;
                    case DateTimePicker picker:
                        picker.CalendarTitleBackColor = Primary;
                        picker.CalendarTitleForeColor = Color.White;
                        break;
                }

                if (control.HasChildren)
                {
                    ApplyToControls(control.Controls);
                }
            }
        }

        public static void StyleButton(Button button)
        {
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        public static void StyleSecondaryButton(Button button)
        {
            button.BackColor = Surface;
            button.ForeColor = Text;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Border;
            button.FlatAppearance.BorderSize = 1;
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Border;
            grid.RowHeadersVisible = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryDark;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            grid.DefaultCellStyle.SelectionForeColor = IsDarkMode ? Color.FromArgb(17, 24, 39) : Text;
            grid.AlternatingRowsDefaultCellStyle.BackColor = IsDarkMode ? Color.FromArgb(38, 48, 66) : Color.FromArgb(249, 250, 251);
        }
    }
}
