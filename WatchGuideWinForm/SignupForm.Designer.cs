namespace WinFormsApp1
{
    partial class SignupForm : Form
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
            label3 = new Label();
            signup_lbl = new Label();
            cancel_btn = new Button();
            txtUsername = new TextBox();
            signup_btn = new Button();
            txtPassword = new TextBox();
            txtEmail = new TextBox();
            cnf_pass_lbl = new Label();
            pass_lbl = new Label();
            username_lbl = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(112, 200);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 2;
            // 
            // signup_lbl
            // 
            signup_lbl.AutoSize = true;
            signup_lbl.BackColor = SystemColors.ActiveCaptionText;
            signup_lbl.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signup_lbl.ForeColor = SystemColors.ActiveCaption;
            signup_lbl.Location = new Point(582, 209);
            signup_lbl.Margin = new Padding(2, 0, 2, 0);
            signup_lbl.Name = "signup_lbl";
            signup_lbl.Size = new Size(133, 46);
            signup_lbl.TabIndex = 9;
            signup_lbl.Text = "Signup";
            // 
            // cancel_btn
            // 
            cancel_btn.BackColor = SystemColors.ActiveCaption;
            cancel_btn.Cursor = Cursors.Hand;
            cancel_btn.FlatAppearance.BorderSize = 0;
            cancel_btn.FlatStyle = FlatStyle.Flat;
            cancel_btn.Font = new Font("Segoe UI", 9F);
            cancel_btn.ForeColor = SystemColors.ActiveCaptionText;
            cancel_btn.Location = new Point(667, 413);
            cancel_btn.Margin = new Padding(2);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.RightToLeft = RightToLeft.No;
            cancel_btn.Size = new Size(83, 28);
            cancel_btn.TabIndex = 14;
            cancel_btn.Text = "Cancel";
            cancel_btn.UseVisualStyleBackColor = false;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.ScrollBar;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(667, 274);
            txtUsername.Margin = new Padding(2);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(209, 23);
            txtUsername.TabIndex = 11;
            txtUsername.Text = "Enter Username";
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.Leave += txtUsername_Leave;
            // 
            // signup_btn
            // 
            signup_btn.BackColor = SystemColors.ActiveCaption;
            signup_btn.Cursor = Cursors.Hand;
            signup_btn.FlatAppearance.BorderSize = 0;
            signup_btn.FlatStyle = FlatStyle.Flat;
            signup_btn.Font = new Font("Segoe UI", 9F);
            signup_btn.ForeColor = SystemColors.ActiveCaptionText;
            signup_btn.Location = new Point(533, 413);
            signup_btn.Margin = new Padding(2);
            signup_btn.Name = "signup_btn";
            signup_btn.Size = new Size(78, 26);
            signup_btn.TabIndex = 15;
            signup_btn.Text = "Signup";
            signup_btn.UseVisualStyleBackColor = false;
            signup_btn.Click += signup_btn_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ScrollBar;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(667, 362);
            txtPassword.Margin = new Padding(2);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(209, 23);
            txtPassword.TabIndex = 17;
            txtPassword.Text = "Enter Password";
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = SystemColors.ScrollBar;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Location = new Point(667, 319);
            txtEmail.Margin = new Padding(2);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(209, 23);
            txtEmail.TabIndex = 13;
            txtEmail.Text = "Enter Your Email";
            txtEmail.Enter += txtEmail_Enter;
            txtEmail.Leave += txtEmail_Leave;
            // 
            // cnf_pass_lbl
            // 
            cnf_pass_lbl.AutoSize = true;
            cnf_pass_lbl.BackColor = SystemColors.ActiveCaptionText;
            cnf_pass_lbl.Font = new Font("Segoe UI", 13F);
            cnf_pass_lbl.ForeColor = SystemColors.ActiveCaption;
            cnf_pass_lbl.Location = new Point(492, 360);
            cnf_pass_lbl.Margin = new Padding(2, 0, 2, 0);
            cnf_pass_lbl.Name = "cnf_pass_lbl";
            cnf_pass_lbl.Size = new Size(87, 25);
            cnf_pass_lbl.TabIndex = 16;
            cnf_pass_lbl.Text = "Password";
            // 
            // pass_lbl
            // 
            pass_lbl.BackColor = SystemColors.ActiveCaptionText;
            pass_lbl.FlatStyle = FlatStyle.System;
            pass_lbl.Font = new Font("Segoe UI", 13F);
            pass_lbl.ForeColor = SystemColors.ActiveCaption;
            pass_lbl.Location = new Point(459, 320);
            pass_lbl.Margin = new Padding(2, 0, 2, 0);
            pass_lbl.Name = "pass_lbl";
            pass_lbl.Size = new Size(154, 22);
            pass_lbl.TabIndex = 12;
            pass_lbl.Text = "Email";
            pass_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // username_lbl
            // 
            username_lbl.BackColor = SystemColors.ActiveCaptionText;
            username_lbl.Font = new Font("Segoe UI", 13F);
            username_lbl.ForeColor = SystemColors.ActiveCaption;
            username_lbl.Location = new Point(459, 271);
            username_lbl.Margin = new Padding(2, 0, 2, 0);
            username_lbl.Name = "username_lbl";
            username_lbl.Size = new Size(154, 25);
            username_lbl.TabIndex = 10;
            username_lbl.Text = "Username";
            username_lbl.TextAlign = ContentAlignment.MiddleCenter;
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
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 720);
            Controls.Add(signup_lbl);
            Controls.Add(cancel_btn);
            Controls.Add(txtUsername);
            Controls.Add(signup_btn);
            Controls.Add(txtPassword);
            Controls.Add(txtEmail);
            Controls.Add(cnf_pass_lbl);
            Controls.Add(pass_lbl);
            Controls.Add(username_lbl);
            Controls.Add(label3);
            Controls.Add(pictureBox1);
            Margin = new Padding(2);
            MinimumSize = new Size(1280, 720);
            Name = "SignupForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label signup_lbl;
        private Button cancel_btn;
        private TextBox txtUsername;
        private Button signup_btn;
        private TextBox txtPassword;
        private TextBox txtEmail;
        private Label cnf_pass_lbl;
        private Label pass_lbl;
        private Label username_lbl;
        private PictureBox pictureBox1;
    }
}