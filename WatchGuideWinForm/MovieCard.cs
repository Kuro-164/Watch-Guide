using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MovieCard : UserControl
    {
        public int TmdbId { get; private set; }
        public string MediaType { get; private set; }

        public MovieCard()
        {
            InitializeComponent();
        }

        public void SetData(string title, string posterUrl, int tmdbId, string mediaType)
        {
            lblTitle.Text = title;
            TmdbId = tmdbId;
            MediaType = mediaType;

            if (!string.IsNullOrEmpty(posterUrl))
            {
                picPoster.LoadAsync(posterUrl);
            }
        }

        private void MovieCard_Click(object sender, EventArgs e)
        {
            var details = new ShowDetailForm(TmdbId, MediaType);
            details.Show();
        }
    }
}
