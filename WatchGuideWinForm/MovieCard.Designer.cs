namespace WinFormsApp1
{
    partial class MovieCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            picPoster = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(30, 30, 30);
            lblTitle.Cursor = Cursors.Hand;
            lblTitle.Dock = DockStyle.Bottom;
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 180);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(5);
            lblTitle.Size = new Size(140, 40);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += MovieCard_Click;
            // 
            // picPoster
            // 
            picPoster.Cursor = Cursors.Hand;
            picPoster.Dock = DockStyle.Top;
            picPoster.Location = new Point(0, 0);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(140, 180);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabIndex = 3;
            picPoster.TabStop = false;
            // 
            // MovieCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            Controls.Add(picPoster);
            Controls.Add(lblTitle);
            Margin = new Padding(10);
            Name = "MovieCard";
            Size = new Size(140, 220);
            Click += MovieCard_Click;
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTitle;
        private PictureBox picPoster;
    }
}
