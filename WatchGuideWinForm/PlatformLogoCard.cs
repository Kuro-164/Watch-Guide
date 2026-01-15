using System;
using System.Windows.Forms;
using WinFormsApp1.DTOs;
using WinFormsApp1.Helpers;
using System.IO;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class PlatformLogoCard : UserControl
    {
        private StreamingPlatformDto _platform;

        public PlatformLogoCard()
        {
            InitializeComponent();
            picLogo.Cursor = Cursors.Hand;
        }

        public void Bind(StreamingPlatformDto platform)
        {
            _platform = platform;

            // Logo from frontend resolver
            string logoPath = PlatformLogoResolver.GetLogoPath(platform.Name);
            if (File.Exists(logoPath))
                picLogo.LoadAsync(logoPath);

            ApplyTypeBadge(platform.Type);
        }

        private void ApplyTypeBadge(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                lblType.Visible = false;
                return;
            }

            lblType.Visible = true;

            switch (type.ToLower())
            {
                case "free":
                    lblType.Text = "FREE";
                    lblType.BackColor = Color.ForestGreen;
                    break;

                case "rent":
                    lblType.Text = "RENT";
                    lblType.BackColor = Color.DarkOrange;
                    break;

                case "buy":
                    lblType.Text = "BUY";
                    lblType.BackColor = Color.IndianRed;
                    break;

                default: // Subscription
                    lblType.Text = "SUB";
                    lblType.BackColor = Color.DodgerBlue;
                    break;
            }
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            if (_platform == null || string.IsNullOrEmpty(_platform.Url))
                return;

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = _platform.Url,
                UseShellExecute = true
            });
        }
    }
}
