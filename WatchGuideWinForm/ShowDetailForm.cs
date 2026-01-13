using System;
using System.Windows.Forms;

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
            _mediaType = mediaType;
        }
    }
}
