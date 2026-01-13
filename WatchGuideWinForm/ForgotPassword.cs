using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();

            txtUsername.Text = "Enter Username";
            txtUsername.ForeColor = Color.Gray;

            txtNewPassword.Text = "Enter New Password";
            txtNewPassword.ForeColor = Color.Gray;
            txtNewPassword.UseSystemPasswordChar = false;
        }

        // CONFIRM BUTTON
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter username",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter new password",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            ResetPassword(username, newPassword);
        }

        // CANCEL BUTTON
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // API CALL (OPTION A)
        private async Task ResetPassword(string username, string newPassword)
        {
            try
            {
                var data = new
                {
                    Username = username,
                    NewPassword = newPassword
                };

                string json = JsonSerializer.Serialize(data);

                using HttpClient client = new HttpClient();
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    "https://localhost:7041/api/auth/reset-password",
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        "Password reset successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Username not found",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server error: " + ex.Message);
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Enter Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "Enter Username";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtNewPassword_Enter(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == "Enter New Password")
            {
                txtNewPassword.Text = "";
                txtNewPassword.ForeColor = Color.Black;
                txtNewPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtNewPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                txtNewPassword.UseSystemPasswordChar = false;
                txtNewPassword.Text = "Enter New Password";
                txtNewPassword.ForeColor = Color.Gray;
            }
        }
    }
}