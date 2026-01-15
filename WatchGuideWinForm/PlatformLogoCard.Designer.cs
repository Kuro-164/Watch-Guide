namespace WinFormsApp1
{
    partial class PlatformLogoCard
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
            picLogo = new PictureBox();
            lblType = new Label();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Cursor = Cursors.Hand;
            picLogo.Dock = DockStyle.Fill;
            picLogo.Location = new Point(0, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(48, 48);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            picLogo.Click += picLogo_Click;
            // 
            // lblType
            // 
            lblType.BackColor = Color.Green;
            lblType.Dock = DockStyle.Bottom;
            lblType.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.White;
            lblType.Location = new Point(0, 34);
            lblType.Name = "lblType";
            lblType.Size = new Size(48, 14);
            lblType.TabIndex = 1;
            lblType.Text = "label1";
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PlatformLogoCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(lblType);
            Controls.Add(picLogo);
            Name = "PlatformLogoCard";
            Size = new Size(48, 48);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picLogo;
        private Label lblType;
    }
}
