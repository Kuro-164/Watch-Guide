using WinFormsApp1.DTOs;
using System.Net.Http;
using System.Text.Json;
using System.Linq;


namespace WinFormsApp1
{
    public partial class ShowDetailForm : Form
    {
        private int _tmdbId;
        private string _mediaType;

        public ShowDetailForm(int tmdbId, string mediaType)
        {
            InitializeComponent();
            _tmdbId = tmdbId;
            _mediaType = mediaType.ToLower();
        }

        private async void ShowDetailForm_Load(object sender, EventArgs e)
        {
            await LoadShowDetailsAsync();
        }

        private async Task LoadShowDetailsAsync()
        {
            using HttpClient client = new HttpClient();

            try
            {
                string url =
                    $"https://localhost:7041/api/Content/{_tmdbId}/details?mediaType={_mediaType}";


                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show(
                        $"Failed: {(int)response.StatusCode} - {response.ReasonPhrase}"
                    );
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();

                var details = JsonSerializer.Deserialize<ShowDetailDto>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (details == null) return;

                BindDetailsToUI(details);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading show details: " + ex.Message);
            }
        }


        private void BindDetailsToUI(ShowDetailDto details)
        {
            lblTitle.Text = details.Title;

            lblMeta.Text = $"⭐ {details.Rating}";

            lblLanguage.Text = string.IsNullOrWhiteSpace(details.Language)
                ? "N/A"
                : FormatLanguage(details.Language);


            lblGenres.Text = string.Join(" • ", details.Genres);

            lblAboutText.Text = details.Description;

            // Images
            if (!string.IsNullOrEmpty(details.PosterUrl))
                picPoster.LoadAsync(details.PosterUrl);

            if (!string.IsNullOrEmpty(details.BackdropUrl))
                picBanner.LoadAsync(details.BackdropUrl);

            // Platforms
            RenderPlatforms(details.StreamingPlatforms);

            // Cast
            RenderCast(details.Cast);
        }

        private void RenderPlatforms(List<StreamingPlatformDto> platforms)
        {
            flpPlatforms.Controls.Clear();

            if (platforms == null || platforms.Count == 0)
                return;

            foreach (var platform in platforms)
            {
                var card = new PlatformLogoCard();
                card.Bind(platform);
                flpPlatforms.Controls.Add(card);
            }
        }



        private void RenderCast(List<CastDto> cast)
        {
            flpCrew.Controls.Clear();

            foreach (var actor in cast)
            {
                var card = new CrewCard();
                card.Bind(actor);
                flpCrew.Controls.Add(card);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string FormatLanguage(string code)
        {
            return code switch
            {
                "en" => "English",
                "hi" => "Hindi",
                "ta" => "Tamil",
                "te" => "Telugu",
                "ml" => "Malayalam",
                "ja" => "Japanese",
                "ko" => "Korean",
                _ => code.ToUpper()
            };
        }

    }
}
