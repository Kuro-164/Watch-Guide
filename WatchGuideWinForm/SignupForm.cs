using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsApp1.DTOs;
using WinFormsApp1.Services;
using WinFormsApp1.Core;


namespace WinFormsApp1
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 🔹 INITIAL PLACEHOLDERS (THIS WAS MISSING)
            txtUsername.Text = "Enter Username";
            txtUsername.ForeColor = Color.Gray;

            txtEmail.Text = "Enter Email";
            txtEmail.ForeColor = Color.Gray;

            txtPassword.Text = "Enter Password";
            txtPassword.ForeColor = Color.Gray;
            txtPassword.UseSystemPasswordChar = false;
        }

        private async void signup_btn_Click(object sender, EventArgs e)
        { 
            if (txtUsername.Text == "Enter Username" ||
                txtEmail.Text == "Enter Email" ||
                txtPassword.Text == "Enter Password")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email");
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters");
                return;
            }

            var request = new RegisterRequest
            {
                Username = txtUsername.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiConfig.BaseUrl);

                var json = JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("/api/Auth/register", content);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Signup failed");
                    return;
                }
                // read response JSON from backend
                var responseJson = await response.Content.ReadAsStringAsync();

                // convert JSON → AuthResponse
                var auth = JsonSerializer.Deserialize<AuthResponse>(
                    responseJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
                // store new user UUID globally
                Session.UserId = auth.UserId;
                MessageBox.Show("New user UUID: " + Session.UserId);


                MessageBox.Show("Signup successful");

                PreferenceForm preferenceForm = new PreferenceForm();
                preferenceForm.Show();
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



        // 🔽 PLACEHOLDER HANDLING 🔽

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

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Enter Your Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Enter Your Email";
                txtEmail.ForeColor = Color.Gray;
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

