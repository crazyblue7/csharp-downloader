namespace c___downloader
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button Download;
        private ProgressBar Progress;
        private Label Size;
        private TextBox URLlink;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Download = new Button();
            Progress = new ProgressBar();
            Size = new Label();
            URLlink = new TextBox();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            SuspendLayout();
            // 
            // Download
            // 
            Download.Location = new Point(175, 255);
            Download.Name = "Download";
            Download.Size = new Size(260, 32);
            Download.TabIndex = 0;
            Download.Text = "Download File";
            Download.UseVisualStyleBackColor = true;
            Download.Click += Download_Click;
            // 
            // Progress
            // 
            Progress.Location = new Point(175, 293);
            Progress.Name = "Progress";
            Progress.Size = new Size(260, 23);
            Progress.Style = ProgressBarStyle.Continuous;
            Progress.TabIndex = 1;
            // 
            // Size
            // 
            Size.AutoSize = true;
            Size.Location = new Point(175, 319);
            Size.Name = "Size";
            Size.Size = new Size(196, 20);
            Size.TabIndex = 2;
            Size.Text = "Downloading: 0 MB of 0 MB";
            // 
            // URLlink
            // 
            URLlink.Location = new Point(12, 222);
            URLlink.Name = "URLlink";
            URLlink.Size = new Size(602, 27);
            URLlink.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(-9, 20);
            label1.Name = "label1";
            label1.Size = new Size(639, 84);
            label1.TabIndex = 4;
            label1.Text = "very good downloader";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1, 401);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // Form1
            // 
            ClientSize = new Size(626, 427);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(URLlink);
            Controls.Add(Size);
            Controls.Add(Progress);
            Controls.Add(Download);
            Name = "Form1";
            Text = "File Downloader";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private DateTimePicker dateTimePicker1;
    }
}
