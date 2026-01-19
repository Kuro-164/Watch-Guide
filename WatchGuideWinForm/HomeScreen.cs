using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Core;
using WinFormsApp1.DTOs;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
            flpTrending.BackColor = System.Drawing.Color.Transparent;
            flpRecommended.BackColor = System.Drawing.Color.Transparent;
        }

        private async void HomeScreen_Load(object sender, EventArgs e)
        {
            await LoadTrendingAsync();
            await LoadRecommendedAsync();
        }

        // ---------------- TRENDING ----------------
        private async Task LoadTrendingAsync()
        {
            try
            {
                using var client = new HttpClient();
                var url = $"{ApiConfig.BaseUrl}/api/Content/trending";

                var json = await client.GetStringAsync(url);

                var response = JsonSerializer.Deserialize<ApiResponse<List<HomeContentDto>>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                flpTrending.Controls.Clear();

                foreach (var item in response.Data)
                {
                    var card = new MovieCard();
                    card.SetData(item.Title, item.PosterUrl, item.TmdbId, item.MediaType);
                    flpTrending.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load trending\n" + ex.Message);
            }
        }


        // ---------------- RECOMMENDED ----------------
        private async Task LoadRecommendedAsync()
        {
            try
            {
                using var client = new HttpClient();
                var url = $"{ApiConfig.BaseUrl}/api/Content/recommendations/{Session.UserId}";

                var json = await client.GetStringAsync(url);

                var results = JsonSerializer.Deserialize<List<HomeContentDto>>(
                     json,
                     new JsonSerializerOptions
                     {
                         PropertyNameCaseInsensitive = true
                     });

                flpRecommended.Controls.Clear();

                foreach (var item in results)
                {
                    var card = new MovieCard();
                    card.SetData(item.Title, item.PosterUrl, item.TmdbId, item.MediaType);
                    flpRecommended.Controls.Add(card);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load recommendations\n" + ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new SearchScreen();
            search.Show();
            this.Hide();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            PreferenceForm pref = new PreferenceForm();
            pref.Owner = this;
            pref.ShowDialog();

            this.Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            About about = new About();
            about.Owner = this;   // optional but clean
            about.ShowDialog();

            this.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Session.UserId = Guid.Empty;

            // Show welcome screen
            WelcomeForm welcome = new WelcomeForm();
            welcome.Show();

            // Close current screen
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            cmsMenu.Show(btnMenu, new Point(0, btnMenu.Height));
        }

        public async Task RefreshForNewPreferencesAsync()
        {
            // Clear UI
            flpTrending.Controls.Clear();
            flpRecommended.Controls.Clear();

            // Reload data
            await LoadTrendingAsync();
            await LoadRecommendedAsync();
        }
    }
}
