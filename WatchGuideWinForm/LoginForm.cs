using System;
using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsApp1.Services;
using WinFormsApp1.DTOs;
using WinFormsApp1.Core;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
           string.IsNullOrWhiteSpace(txtPassword.Text) ||
           txtUsername.Text == "Enter Username" ||
           txtPassword.Text == "Enter Password")
            {
                MessageBox.Show("Please enter username and password");
                return;
            }
            try
            {
                var loginRequest = new LoginRequest
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text
                };

                using var client = new HttpClient();
                var json = JsonSerializer.Serialize(loginRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    $"{ApiConfig.BaseUrl}/api/auth/login",
                    content
                );

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Invalid username or password");
                    return;
                }
                // read response JSON
                var responseJson = await response.Content.ReadAsStringAsync();

                // convert JSON → C# object
                var auth = JsonSerializer.Deserialize<AuthResponse>(
                    responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                // store user UUID globally
                Session.UserId = auth.UserId;

                MessageBox.Show("Login successful");

                // existing user → HOME
                HomeScreen home = new HomeScreen();
                home.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Cannot connect to server. Is backend running?");
            }
        }



        private void cancel_btn_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Hide();
        }



        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPasswordForm = new ForgotPassword();
            forgotPasswordForm.ShowDialog(); // blocks login until closed
        }

        // 🔽 🔽 🔽 PASTE PLACEHOLDER CODE HERE 🔽 🔽 🔽

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

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Enter Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.Text = "Enter Password";
                txtPassword.ForeColor = Color.Gray;
            }
        }
    }
}
