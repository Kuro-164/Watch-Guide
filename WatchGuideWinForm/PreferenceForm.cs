using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsApp1.Core;

namespace WinFormsApp1
{
    public partial class PreferenceForm : Form
    {
        public PreferenceForm()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void chkRomance_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saving for user: " + Session.UserId);

            List<string> languages = new();
            List<string> genres = new();

            if (chkEnglish.Checked) languages.Add("English");
            if (chkHindi.Checked) languages.Add("Hindi");
            if (chkMarathi.Checked) languages.Add("Marathi");
            if (chkTamil.Checked) languages.Add("Tamil");
            if (chkGujrati.Checked) languages.Add("Gujarati");

            if (chkAction.Checked) genres.Add("Action");
            if (chkComedy.Checked) genres.Add("Comedy");
            if (chkDrama.Checked) genres.Add("Drama");
            if (chkCrime.Checked) genres.Add("Crime");
            if (chkThriller.Checked) genres.Add("Thriller");
            if (chkRomance.Checked) genres.Add("Romance");
            if (chkHorror.Checked) genres.Add("Horror");
            if (chkMystery.Checked) genres.Add("Mystery");
            if (chkFantasy.Checked) genres.Add("Fantasy");
            if (chkScifi.Checked) genres.Add("Sci-Fi");

            if (languages.Count == 0 || genres.Count == 0)
            {
                MessageBox.Show("Please select at least one language and one genre");
                return;
            }

            var payload = new
            {
                languages = languages,
                genres = genres
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            string userId = Session.UserId.ToString();  // UUID from /api/Auth/login

            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.PostAsync(
                    $"https://localhost:7041/api/UserPreferences/{Session.UserId}",
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Preferences saved successfully!");

                    HomeScreen home = new HomeScreen();
                    home.Show();
                    this.Close();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Save failed: " + err);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }


        private void cancel_btn_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }
    }
}
