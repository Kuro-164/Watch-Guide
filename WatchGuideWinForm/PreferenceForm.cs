using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsApp1.Core;
using WinFormsApp1.DTOs;

namespace WinFormsApp1
{
    public partial class PreferenceForm : Form
    {
        public PreferenceForm()
        {
            InitializeComponent();
        }
        private readonly HashSet<string> selectedLanguages = new();
        private readonly HashSet<string> selectedGenres = new();

        private List<string> oldLanguages = new();
        private List<string> oldGenres = new();

        private async void save_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saving for user: " + Session.UserId);

            // NEW selections (current UI state)
            var newLanguages = selectedLanguages.ToList();
            var newGenres = selectedGenres.ToList();

            if (newLanguages.Count == 0 || newGenres.Count == 0)
            {
                MessageBox.Show("Please select at least one language and one genre");
                return;
            }

            // DIFF logic
            var languagesToRemove = oldLanguages.Except(newLanguages).ToList();
            var languagesToAdd = newLanguages.Except(oldLanguages).ToList();

            var genresToRemove = oldGenres.Except(newGenres).ToList();
            var genresToAdd = newGenres.Except(oldGenres).ToList();

            // No changes check
            bool hasChanges =
                languagesToAdd.Any() || languagesToRemove.Any() ||
                genresToAdd.Any() || genresToRemove.Any();

            if (!hasChanges)
            {
                MessageBox.Show("No changes to save");
                return;
            }

            // TEMP: still posting final merged list
            var payload = new
            {
                languages = newLanguages,
                genres = newGenres
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.PostAsync(
                    $"https://localhost:7041/api/UserPreferences/{Session.UserId}",
                    content
                );

                if (response.IsSuccessStatusCode)
                {
                    oldLanguages = newLanguages;
                    oldGenres = newGenres;

                    MessageBox.Show("Preferences saved successfully!");

                    if (this.Owner is HomeScreen home)
                    {
                        // HomeScreen already exists → refresh it
                        await home.RefreshForNewPreferencesAsync();
                    }
                    else
                    {
                        // Opened from Signup / Welcome → create HomeScreen
                        HomeScreen newHome = new HomeScreen();
                        newHome.Show();
                    }

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


        private void SyncCheckbox(
            CheckBox chk,
            HashSet<string> collection,
            string value)
        {
            if (chk.Checked)
                collection.Add(value);
            else
                collection.Remove(value);
        }



        private void cancel_btn_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.Show();
            this.Close();
        }

        private void chkEnglish_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkEnglish, selectedLanguages, "English");
        }

        private void chkHindi_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkHindi, selectedLanguages, "Hindi");
        }

        private void chkMarathi_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkMarathi, selectedLanguages, "Marathi");
        }

        private void chkTamil_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkTamil, selectedLanguages, "Tamil");
        }

        private void chkGujrati_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkGujrati, selectedLanguages, "Gujarati");
        }

        private void chkAction_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkAction, selectedGenres, "Action");
        }

        private void chkRomance_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkRomance, selectedGenres, "Romance");
        }

        private void chkComedy_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkComedy, selectedGenres, "Comedy");
        }

        private void chkHorror_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkHorror, selectedGenres, "Horror");
        }

        private void chkDrama_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkDrama, selectedGenres, "Drama");
        }

        private void chkMystery_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkMystery, selectedGenres, "Mystery");
        }

        private void chkCrime_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkCrime, selectedGenres, "Crime");
        }

        private void chkFantasy_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkFantasy, selectedGenres, "Fantasy");
        }

        private void chkThriller_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkThriller, selectedGenres, "Thriller");
        }

        private void chkScifi_CheckedChanged(object sender, EventArgs e)
        {
            SyncCheckbox(chkScifi, selectedGenres, "Sci-Fi");
        }

        private async void PreferenceForm_Load(object sender, EventArgs e)
        {
            await LoadPreferencesAsync();
        }

        private async Task LoadPreferencesAsync()
        {
            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(
                    $"https://localhost:7041/api/UserPreferences/{Session.UserId}"
                );

                if (!response.IsSuccessStatusCode)
                    return;

                var json = await response.Content.ReadAsStringAsync();

                var prefs = JsonSerializer.Deserialize<UserPreferencesResponse>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                if (prefs == null) return;

                // Store OLD preferences for diff
                oldLanguages = prefs.Languages ?? new List<string>();
                oldGenres = prefs.Genres ?? new List<string>();

                // Clear current state
                selectedLanguages.Clear();
                selectedGenres.Clear();

                // Apply to UI (CheckedChanged will update HashSets)
                ApplyLanguageSelections(oldLanguages);
                ApplyGenreSelections(oldGenres);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load preferences: " + ex.Message);
            }
        }

        private void ApplyLanguageSelections(List<string> languages)
        {
            if (languages == null) return;

            chkEnglish.Checked = languages.Contains("English");
            chkHindi.Checked = languages.Contains("Hindi");
            chkMarathi.Checked = languages.Contains("Marathi");
            chkTamil.Checked = languages.Contains("Tamil");
            chkGujrati.Checked = languages.Contains("Gujarati");
        }

        private void ApplyGenreSelections(List<string> genres)
        {
            if (genres == null) return;

            chkAction.Checked = genres.Contains("Action");
            chkComedy.Checked = genres.Contains("Comedy");
            chkDrama.Checked = genres.Contains("Drama");
            chkCrime.Checked = genres.Contains("Crime");
            chkThriller.Checked = genres.Contains("Thriller");
            chkRomance.Checked = genres.Contains("Romance");
            chkHorror.Checked = genres.Contains("Horror");
            chkMystery.Checked = genres.Contains("Mystery");
            chkFantasy.Checked = genres.Contains("Fantasy");
            chkScifi.Checked = genres.Contains("Sci-Fi");
        }


    }
}
