using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.DTOs;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    public partial class SearchScreen : Form
    {
        public SearchScreen()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
        }

        private async Task SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                flowResults.Controls.Clear();
                return;
            }

            using var client = new HttpClient();
            var url = $"{ApiConfig.BaseUrl}/api/Content/search?query={query}";

            try
            {
                var json = await client.GetStringAsync(url);
                var results = JsonSerializer.Deserialize<List<ContentCardDto>>(
                     json,
                     new JsonSerializerOptions
                     {
                         PropertyNameCaseInsensitive = true
                     });

                flowResults.Controls.Clear();

                foreach (var item in results)
                {
                    var card = new MovieCard();
                    card.SetData(item.Title, item.PosterUrl, item.TmdbId, item.MediaType);
                    flowResults.Controls.Add(card);
                }
            }
            catch
            {
                MessageBox.Show("Cannot fetch search results");
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            await SearchAsync(txtSearch.Text.Trim());
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await SearchAsync(txtSearch.Text.Trim());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen();
            home.Show();
            this.Close();
        }
    }
}
