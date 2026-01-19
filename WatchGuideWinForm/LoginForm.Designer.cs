using System.Net.Http;
using System.Text;
using System.Text.Json;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    partial class LoginForm
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
            login_lbl = new Label();
            cancel_btn = new Button();
            btnForgotPassword = new Button();
            login_btn = new Button();
            username_lbl = new Label();
            password_lbl = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // login_lbl
            // 
            login_lbl.AutoSize = true;
            login_lbl.BackColor = SystemColors.ActiveCaptionText;
            login_lbl.Font = new Font("Segoe UI", 25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            login_lbl.ForeColor = SystemColors.ActiveCaption;
            login_lbl.Location = new Point(625, 237);
            login_lbl.Margin = new Padding(2, 0, 2, 0);
            login_lbl.Name = "login_lbl";
            login_lbl.Size = new Size(110, 46);
            login_lbl.TabIndex = 10;
            login_lbl.Text = "Login";
            // 
            // cancel_btn
            // 
            cancel_btn.BackColor = SystemColors.ActiveCaption;
            cancel_btn.FlatAppearance.BorderSize = 0;
            cancel_btn.FlatStyle = FlatStyle.Flat;
            cancel_btn.Font = new Font("Segoe UI", 11F);
            cancel_btn.ForeColor = SystemColors.ActiveCaptionText;
            cancel_btn.Location = new Point(675, 443);
            cancel_btn.Margin = new Padding(2);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.RightToLeft = RightToLeft.No;
            cancel_btn.Size = new Size(83, 28);
            cancel_btn.TabIndex = 16;
            cancel_btn.Text = "Cancel";
            cancel_btn.UseVisualStyleBackColor = false;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.BackColor = SystemColors.ActiveCaption;
            btnForgotPassword.Cursor = Cursors.Hand;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.Font = new Font("Segoe UI", 7F);
            btnForgotPassword.ForeColor = SystemColors.ActiveCaptionText;
            btnForgotPassword.Location = new Point(663, 387);
            btnForgotPassword.Margin = new Padding(2);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.RightToLeft = RightToLeft.No;
            btnForgotPassword.Size = new Size(111, 20);
            btnForgotPassword.TabIndex = 17;
            btnForgotPassword.Text = "Forgot Password";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // login_btn
            // 
            login_btn.BackColor = SystemColors.ActiveCaption;
            login_btn.Cursor = Cursors.Hand;
            login_btn.FlatAppearance.BorderSize = 0;
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Segoe UI", 11F);
            login_btn.ForeColor = SystemColors.ActiveCaptionText;
            login_btn.Location = new Point(538, 443);
            login_btn.Margin = new Padding(2);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(78, 28);
            login_btn.TabIndex = 15;
            login_btn.Text = "Login";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += login_btn_Click;
            // 
            // username_lbl
            // 
            username_lbl.AutoSize = true;
            username_lbl.BackColor = SystemColors.ActiveCaptionText;
            username_lbl.Font = new Font("Segoe UI", 13F);
            username_lbl.ForeColor = SystemColors.ActiveCaption;
            username_lbl.Location = new Point(502, 303);
            username_lbl.Margin = new Padding(2, 0, 2, 0);
            username_lbl.Name = "username_lbl";
            username_lbl.Size = new Size(91, 25);
            username_lbl.TabIndex = 11;
            username_lbl.Text = "Username";
            username_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // password_lbl
            // 
            password_lbl.BackColor = SystemColors.ActiveCaptionText;
            password_lbl.FlatStyle = FlatStyle.System;
            password_lbl.Font = new Font("Segoe UI", 13F);
            password_lbl.ForeColor = SystemColors.ActiveCaption;
            password_lbl.Location = new Point(502, 351);
            password_lbl.Margin = new Padding(2, 0, 2, 0);
            password_lbl.Name = "password_lbl";
            password_lbl.Size = new Size(92, 22);
            password_lbl.TabIndex = 13;
            password_lbl.Text = "Password";
            password_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = SystemColors.ScrollBar;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(663, 302);
            txtUsername.Margin = new Padding(2);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(209, 23);
            txtUsername.TabIndex = 12;
            txtUsername.Text = "Enter Username";
            txtUsername.Enter += txtUsername_Enter;
            txtUsername.Leave += txtUsername_Leave;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.ScrollBar;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(663, 350);
            txtPassword.Margin = new Padding(2);
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(209, 23);
            txtPassword.TabIndex = 14;
            txtPassword.Text = "Enter Password";
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Enter += txtPassword_Enter;
            txtPassword.Leave += txtPassword_Leave;
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
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1280, 720);
            Controls.Add(login_lbl);
            Controls.Add(cancel_btn);
            Controls.Add(btnForgotPassword);
            Controls.Add(login_btn);
            Controls.Add(username_lbl);
            Controls.Add(password_lbl);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(pictureBox1);
            ForeColor = SystemColors.ActiveCaption;
            Margin = new Padding(2);
            MinimumSize = new Size(1280, 720);
            Name = "LoginForm";
            Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label login_lbl;
        private Button cancel_btn;
        private Button btnForgotPassword;
        private Button login_btn;
        internal Label username_lbl;
        private Label password_lbl;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
    }
}