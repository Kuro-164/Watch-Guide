namespace WinFormsApp1
{
    partial class WelcomeForm
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
            proj_tit_lbl = new Label();
            btnLogin = new Button();
            signup_btn = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // proj_tit_lbl
            // 
            proj_tit_lbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            proj_tit_lbl.AutoSize = true;
            proj_tit_lbl.BackColor = Color.Black;
            proj_tit_lbl.Font = new Font("Segoe UI", 35F, FontStyle.Bold);
            proj_tit_lbl.ForeColor = SystemColors.InactiveCaption;
            proj_tit_lbl.Location = new Point(469, 251);
            proj_tit_lbl.Margin = new Padding(2, 0, 2, 0);
            proj_tit_lbl.Name = "proj_tit_lbl";
            proj_tit_lbl.Size = new Size(338, 62);
            proj_tit_lbl.TabIndex = 27;
            proj_tit_lbl.Tag = "";
            proj_tit_lbl.Text = "OTT TRACKER";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ActiveCaptionText;
            btnLogin.Location = new Point(554, 349);
            btnLogin.Margin = new Padding(2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(126, 36);
            btnLogin.TabIndex = 28;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // signup_btn
            // 
            signup_btn.BackColor = SystemColors.ActiveCaption;
            signup_btn.Cursor = Cursors.Hand;
            signup_btn.FlatAppearance.BorderSize = 0;
            signup_btn.FlatStyle = FlatStyle.Flat;
            signup_btn.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            signup_btn.ForeColor = SystemColors.ActiveCaptionText;
            signup_btn.Location = new Point(554, 409);
            signup_btn.Margin = new Padding(2);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new Size(126, 36);
            signup_btn.TabIndex = 29;
            signup_btn.Text = "Signup";
            signup_btn.UseVisualStyleBackColor = false;
            signup_btn.Click += signup_btn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.WatchGuideBG;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1280, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 30;
            pictureBox1.TabStop = false;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 720);
            Controls.Add(signup_btn);
            Controls.Add(btnLogin);
            Controls.Add(proj_tit_lbl);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ActiveCaption;
            Margin = new Padding(2);
            MinimumSize = new Size(1280, 720);
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "WelcomeScreen";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label proj_tit_lbl;
        private Button btnLogin;
        private Button signup_btn;
        private PictureBox pictureBox1;
    }
}
