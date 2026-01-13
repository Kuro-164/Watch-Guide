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

                var response = JsonSerializer.Deserialize<ApiResponse<List<HomeContentDto>>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                flpRecommended.Controls.Clear();

                foreach (var item in response.Data)
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
    }
}
