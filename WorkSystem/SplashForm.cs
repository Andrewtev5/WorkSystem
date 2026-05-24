namespace WorkSystem
{
    public class SplashForm : Form
    {
        private readonly ProgressBar progressBar;
        private readonly Label percentLabel;
        private readonly System.Windows.Forms.Timer timer;

        public SplashForm()
        {
            ClientSize = new Size(520, 300);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = AppTheme.PrimaryDark;

            Label titleLabel = new Label
            {
                AutoSize = false,
                Text = "Work System",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(40, 56),
                Size = new Size(440, 56),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label subtitleLabel = new Label
            {
                AutoSize = false,
                Text = "Preparing employee workspace",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.FromArgb(219, 234, 254),
                Location = new Point(40, 118),
                Size = new Size(440, 28),
                TextAlign = ContentAlignment.MiddleCenter
            };

            progressBar = new ProgressBar
            {
                Location = new Point(72, 184),
                Size = new Size(376, 14),
                Style = ProgressBarStyle.Continuous
            };

            percentLabel = new Label
            {
                AutoSize = false,
                Text = "0%",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(72, 206),
                Size = new Size(376, 24),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(titleLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(progressBar);
            Controls.Add(percentLabel);

            timer = new System.Windows.Forms.Timer
            {
                Interval = 25
            };
            timer.Tick += timer_Tick;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            timer.Start();
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            progressBar.Value = Math.Min(progressBar.Value + 2, 100);
            percentLabel.Text = progressBar.Value + "%";

            if (progressBar.Value == 100)
            {
                timer.Stop();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
