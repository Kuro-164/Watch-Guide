using System.Windows.Forms;

namespace WinFormsApp1

{
    partial class PreferenceForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cancel_btn = new Button();
            save_btn = new Button();
            genre_lbl = new Label();
            language_lbl = new Label();
            preference_lbl = new Label();
            chkScifi = new CheckBox();
            chkFantasy = new CheckBox();
            chkMystery = new CheckBox();
            chkHorror = new CheckBox();
            chkRomance = new CheckBox();
            chkThriller = new CheckBox();
            chkCrime = new CheckBox();
            chkDrama = new CheckBox();
            chkComedy = new CheckBox();
            chkAction = new CheckBox();
            chkEnglish = new CheckBox();
            chkHindi = new CheckBox();
            chkMarathi = new CheckBox();
            chkTamil = new CheckBox();
            chkGujrati = new CheckBox();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cancel_btn
            // 
            cancel_btn.BackColor = SystemColors.ActiveCaption;
            cancel_btn.FlatAppearance.BorderSize = 0;
            cancel_btn.FlatStyle = FlatStyle.Flat;
            cancel_btn.Font = new Font("Segoe UI", 11F);
            cancel_btn.ForeColor = SystemColors.ActiveCaptionText;
            cancel_btn.Location = new Point(649, 480);
            cancel_btn.Margin = new Padding(2);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.RightToLeft = RightToLeft.No;
            cancel_btn.Size = new Size(83, 28);
            cancel_btn.TabIndex = 30;
            cancel_btn.Text = "Cancel";
            cancel_btn.UseVisualStyleBackColor = false;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // save_btn
            // 
            save_btn.BackColor = SystemColors.ActiveCaption;
            save_btn.FlatAppearance.BorderSize = 0;
            save_btn.FlatStyle = FlatStyle.Flat;
            save_btn.Font = new Font("Segoe UI", 11F);
            save_btn.ForeColor = SystemColors.ActiveCaptionText;
            save_btn.Location = new Point(488, 480);
            save_btn.Margin = new Padding(2);
            save_btn.Name = "save_btn";
            save_btn.Size = new Size(78, 26);
            save_btn.TabIndex = 29;
            save_btn.Text = "Save";
            save_btn.UseVisualStyleBackColor = false;
            save_btn.Click += save_btn_Click;
            // 
            // genre_lbl
            // 
            genre_lbl.BackColor = Color.Black;
            genre_lbl.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            genre_lbl.ForeColor = SystemColors.ActiveCaption;
            genre_lbl.Location = new Point(707, 199);
            genre_lbl.Margin = new Padding(2, 0, 2, 0);
            genre_lbl.Name = "genre_lbl";
            genre_lbl.Size = new Size(254, 27);
            genre_lbl.TabIndex = 28;
            genre_lbl.Text = "Genre";
            genre_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // language_lbl
            // 
            language_lbl.BackColor = Color.Black;
            language_lbl.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            language_lbl.ForeColor = SystemColors.ActiveCaption;
            language_lbl.Location = new Point(306, 199);
            language_lbl.Margin = new Padding(2, 0, 2, 0);
            language_lbl.Name = "language_lbl";
            language_lbl.Size = new Size(254, 27);
            language_lbl.TabIndex = 27;
            language_lbl.Text = "Language";
            language_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // preference_lbl
            // 
            preference_lbl.BackColor = Color.Black;
            preference_lbl.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            preference_lbl.ForeColor = SystemColors.ActiveCaption;
            preference_lbl.Location = new Point(544, 143);
            preference_lbl.Margin = new Padding(2, 0, 2, 0);
            preference_lbl.Name = "preference_lbl";
            preference_lbl.Size = new Size(187, 32);
            preference_lbl.TabIndex = 26;
            preference_lbl.Text = "Your preference";
            preference_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chkScifi
            // 
            chkScifi.Appearance = Appearance.Button;
            chkScifi.BackColor = SystemColors.ActiveCaptionText;
            chkScifi.FlatAppearance.BorderSize = 0;
            chkScifi.FlatStyle = FlatStyle.Flat;
            chkScifi.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkScifi.ForeColor = SystemColors.ActiveCaption;
            chkScifi.Location = new Point(842, 427);
            chkScifi.Margin = new Padding(2);
            chkScifi.Name = "chkScifi";
            chkScifi.Size = new Size(105, 30);
            chkScifi.TabIndex = 47;
            chkScifi.Text = "Sci-fic";
            chkScifi.TextAlign = ContentAlignment.MiddleCenter;
            chkScifi.UseVisualStyleBackColor = false;
            // 
            // chkFantasy
            // 
            chkFantasy.Appearance = Appearance.Button;
            chkFantasy.BackColor = SystemColors.ActiveCaptionText;
            chkFantasy.FlatAppearance.BorderSize = 0;
            chkFantasy.FlatStyle = FlatStyle.Flat;
            chkFantasy.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkFantasy.ForeColor = SystemColors.ActiveCaption;
            chkFantasy.Location = new Point(842, 379);
            chkFantasy.Margin = new Padding(2);
            chkFantasy.Name = "chkFantasy";
            chkFantasy.Size = new Size(105, 30);
            chkFantasy.TabIndex = 46;
            chkFantasy.Text = "Fantasy";
            chkFantasy.TextAlign = ContentAlignment.MiddleCenter;
            chkFantasy.UseVisualStyleBackColor = false;
            // 
            // chkMystery
            // 
            chkMystery.Appearance = Appearance.Button;
            chkMystery.BackColor = SystemColors.ActiveCaptionText;
            chkMystery.FlatAppearance.BorderSize = 0;
            chkMystery.FlatStyle = FlatStyle.Flat;
            chkMystery.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMystery.ForeColor = SystemColors.ActiveCaption;
            chkMystery.Location = new Point(842, 332);
            chkMystery.Margin = new Padding(2);
            chkMystery.Name = "chkMystery";
            chkMystery.Size = new Size(105, 30);
            chkMystery.TabIndex = 45;
            chkMystery.Text = "Mystery";
            chkMystery.TextAlign = ContentAlignment.MiddleCenter;
            chkMystery.UseVisualStyleBackColor = false;
            // 
            // chkHorror
            // 
            chkHorror.Appearance = Appearance.Button;
            chkHorror.BackColor = SystemColors.ActiveCaptionText;
            chkHorror.FlatAppearance.BorderSize = 0;
            chkHorror.FlatStyle = FlatStyle.Flat;
            chkHorror.Font = new Font("Showcard Gothic", 12F);
            chkHorror.ForeColor = SystemColors.ActiveCaption;
            chkHorror.Location = new Point(842, 286);
            chkHorror.Margin = new Padding(2);
            chkHorror.Name = "chkHorror";
            chkHorror.Size = new Size(105, 30);
            chkHorror.TabIndex = 44;
            chkHorror.Text = "Horror";
            chkHorror.TextAlign = ContentAlignment.MiddleCenter;
            chkHorror.UseVisualStyleBackColor = false;
            // 
            // chkRomance
            // 
            chkRomance.Appearance = Appearance.Button;
            chkRomance.BackColor = SystemColors.ActiveCaptionText;
            chkRomance.FlatAppearance.BorderSize = 0;
            chkRomance.FlatStyle = FlatStyle.Flat;
            chkRomance.Font = new Font("Showcard Gothic", 12F);
            chkRomance.ForeColor = SystemColors.ActiveCaption;
            chkRomance.Location = new Point(842, 241);
            chkRomance.Margin = new Padding(2);
            chkRomance.Name = "chkRomance";
            chkRomance.Size = new Size(105, 30);
            chkRomance.TabIndex = 43;
            chkRomance.Text = "Romance";
            chkRomance.TextAlign = ContentAlignment.MiddleCenter;
            chkRomance.UseVisualStyleBackColor = false;
            chkRomance.CheckedChanged += chkRomance_CheckedChanged;
            // 
            // chkThriller
            // 
            chkThriller.Appearance = Appearance.Button;
            chkThriller.BackColor = SystemColors.ActiveCaptionText;
            chkThriller.FlatAppearance.BorderSize = 0;
            chkThriller.FlatStyle = FlatStyle.Flat;
            chkThriller.Font = new Font("Showcard Gothic", 12F);
            chkThriller.ForeColor = SystemColors.ActiveCaption;
            chkThriller.Location = new Point(713, 427);
            chkThriller.Margin = new Padding(2);
            chkThriller.Name = "chkThriller";
            chkThriller.Size = new Size(105, 30);
            chkThriller.TabIndex = 42;
            chkThriller.Text = "Thriller";
            chkThriller.TextAlign = ContentAlignment.MiddleCenter;
            chkThriller.UseVisualStyleBackColor = false;
            // 
            // chkCrime
            // 
            chkCrime.Appearance = Appearance.Button;
            chkCrime.BackColor = SystemColors.ActiveCaptionText;
            chkCrime.FlatAppearance.BorderSize = 0;
            chkCrime.FlatStyle = FlatStyle.Flat;
            chkCrime.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkCrime.ForeColor = SystemColors.ActiveCaption;
            chkCrime.Location = new Point(713, 379);
            chkCrime.Margin = new Padding(2);
            chkCrime.Name = "chkCrime";
            chkCrime.Size = new Size(105, 30);
            chkCrime.TabIndex = 41;
            chkCrime.Text = "Crime";
            chkCrime.TextAlign = ContentAlignment.MiddleCenter;
            chkCrime.UseVisualStyleBackColor = false;
            // 
            // chkDrama
            // 
            chkDrama.Appearance = Appearance.Button;
            chkDrama.BackColor = SystemColors.ActiveCaptionText;
            chkDrama.FlatAppearance.BorderSize = 0;
            chkDrama.FlatStyle = FlatStyle.Flat;
            chkDrama.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkDrama.ForeColor = SystemColors.ActiveCaption;
            chkDrama.Location = new Point(713, 332);
            chkDrama.Margin = new Padding(2);
            chkDrama.Name = "chkDrama";
            chkDrama.Size = new Size(105, 30);
            chkDrama.TabIndex = 40;
            chkDrama.Text = "Drama";
            chkDrama.TextAlign = ContentAlignment.MiddleCenter;
            chkDrama.UseVisualStyleBackColor = false;
            // 
            // chkComedy
            // 
            chkComedy.Appearance = Appearance.Button;
            chkComedy.BackColor = SystemColors.ActiveCaptionText;
            chkComedy.FlatAppearance.BorderSize = 0;
            chkComedy.FlatStyle = FlatStyle.Flat;
            chkComedy.Font = new Font("Showcard Gothic", 12F);
            chkComedy.ForeColor = SystemColors.ActiveCaption;
            chkComedy.Location = new Point(713, 286);
            chkComedy.Margin = new Padding(2);
            chkComedy.Name = "chkComedy";
            chkComedy.Size = new Size(105, 30);
            chkComedy.TabIndex = 39;
            chkComedy.Text = "Comedy";
            chkComedy.TextAlign = ContentAlignment.MiddleCenter;
            chkComedy.UseVisualStyleBackColor = false;
            // 
            // chkAction
            // 
            chkAction.Appearance = Appearance.Button;
            chkAction.BackColor = SystemColors.ActiveCaptionText;
            chkAction.FlatAppearance.BorderSize = 0;
            chkAction.FlatStyle = FlatStyle.Flat;
            chkAction.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkAction.ForeColor = SystemColors.ActiveCaption;
            chkAction.Location = new Point(713, 241);
            chkAction.Margin = new Padding(2);
            chkAction.Name = "chkAction";
            chkAction.Size = new Size(105, 30);
            chkAction.TabIndex = 38;
            chkAction.Text = "Action";
            chkAction.TextAlign = ContentAlignment.MiddleCenter;
            chkAction.UseVisualStyleBackColor = false;
            // 
            // chkEnglish
            // 
            chkEnglish.Appearance = Appearance.Button;
            chkEnglish.BackColor = SystemColors.ActiveCaptionText;
            chkEnglish.FlatAppearance.BorderSize = 0;
            chkEnglish.FlatStyle = FlatStyle.Flat;
            chkEnglish.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkEnglish.ForeColor = SystemColors.ActiveCaption;
            chkEnglish.Location = new Point(386, 241);
            chkEnglish.Margin = new Padding(2);
            chkEnglish.Name = "chkEnglish";
            chkEnglish.Size = new Size(105, 30);
            chkEnglish.TabIndex = 48;
            chkEnglish.Text = "English";
            chkEnglish.TextAlign = ContentAlignment.MiddleCenter;
            chkEnglish.UseVisualStyleBackColor = false;
            // 
            // chkHindi
            // 
            chkHindi.Appearance = Appearance.Button;
            chkHindi.BackColor = SystemColors.ActiveCaptionText;
            chkHindi.FlatAppearance.BorderSize = 0;
            chkHindi.FlatStyle = FlatStyle.Flat;
            chkHindi.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkHindi.ForeColor = SystemColors.ActiveCaption;
            chkHindi.Location = new Point(386, 286);
            chkHindi.Margin = new Padding(2);
            chkHindi.Name = "chkHindi";
            chkHindi.Size = new Size(105, 30);
            chkHindi.TabIndex = 49;
            chkHindi.Text = "Hindi";
            chkHindi.TextAlign = ContentAlignment.MiddleCenter;
            chkHindi.UseVisualStyleBackColor = false;
            // 
            // chkMarathi
            // 
            chkMarathi.Appearance = Appearance.Button;
            chkMarathi.BackColor = SystemColors.ActiveCaptionText;
            chkMarathi.FlatAppearance.BorderSize = 0;
            chkMarathi.FlatStyle = FlatStyle.Flat;
            chkMarathi.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkMarathi.ForeColor = SystemColors.ActiveCaption;
            chkMarathi.Location = new Point(386, 332);
            chkMarathi.Margin = new Padding(2);
            chkMarathi.Name = "chkMarathi";
            chkMarathi.Size = new Size(105, 30);
            chkMarathi.TabIndex = 50;
            chkMarathi.Text = "Marathi";
            chkMarathi.TextAlign = ContentAlignment.MiddleCenter;
            chkMarathi.UseVisualStyleBackColor = false;
            // 
            // chkTamil
            // 
            chkTamil.Appearance = Appearance.Button;
            chkTamil.BackColor = SystemColors.ActiveCaptionText;
            chkTamil.FlatAppearance.BorderSize = 0;
            chkTamil.FlatStyle = FlatStyle.Flat;
            chkTamil.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkTamil.ForeColor = SystemColors.ActiveCaption;
            chkTamil.Location = new Point(386, 379);
            chkTamil.Margin = new Padding(2);
            chkTamil.Name = "chkTamil";
            chkTamil.Size = new Size(105, 30);
            chkTamil.TabIndex = 51;
            chkTamil.Text = "Tamil";
            chkTamil.TextAlign = ContentAlignment.MiddleCenter;
            chkTamil.UseVisualStyleBackColor = false;
            chkTamil.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // chkGujrati
            // 
            chkGujrati.Appearance = Appearance.Button;
            chkGujrati.BackColor = SystemColors.ActiveCaptionText;
            chkGujrati.FlatAppearance.BorderSize = 0;
            chkGujrati.FlatStyle = FlatStyle.Flat;
            chkGujrati.Font = new Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkGujrati.ForeColor = SystemColors.ActiveCaption;
            chkGujrati.Location = new Point(386, 427);
            chkGujrati.Margin = new Padding(2);
            chkGujrati.Name = "chkGujrati";
            chkGujrati.Size = new Size(105, 30);
            chkGujrati.TabIndex = 52;
            chkGujrati.Text = "Gujrati";
            chkGujrati.TextAlign = ContentAlignment.MiddleCenter;
            chkGujrati.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(chkGujrati);
            panel2.Controls.Add(chkTamil);
            panel2.Controls.Add(chkMarathi);
            panel2.Controls.Add(chkHindi);
            panel2.Controls.Add(chkEnglish);
            panel2.Controls.Add(chkScifi);
            panel2.Controls.Add(chkFantasy);
            panel2.Controls.Add(chkMystery);
            panel2.Controls.Add(chkHorror);
            panel2.Controls.Add(chkRomance);
            panel2.Controls.Add(chkThriller);
            panel2.Controls.Add(chkCrime);
            panel2.Controls.Add(chkDrama);
            panel2.Controls.Add(chkComedy);
            panel2.Controls.Add(chkAction);
            panel2.Controls.Add(cancel_btn);
            panel2.Controls.Add(save_btn);
            panel2.Controls.Add(genre_lbl);
            panel2.Controls.Add(language_lbl);
            panel2.Controls.Add(preference_lbl);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1280, 720);
            panel2.TabIndex = 53;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.WatchGuideBG;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1280, 720);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 55;
            pictureBox1.TabStop = false;
            // 
            // PreferenceForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1280, 720);
            Controls.Add(panel2);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            Margin = new Padding(2);
            MinimumSize = new Size(1280, 720);
            Name = "PreferenceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form4";
            Load += Form4_Load;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private CheckBox checkBox5;
        private CheckBox chkGujrati;
        private CheckBox chkTamil;
        private CheckBox chkMarathi;
        private Button cancel_btn;
        private Button save_btn;
        private Label genre_lbl;
        private Label language_lbl;
        private Label preference_lbl;
        private CheckBox chkScifi;
        private CheckBox chkFantasy;
        private CheckBox chkMystery;
        private CheckBox chkHorror;
        private CheckBox chkRomance;
        private CheckBox chkThriller;
        private CheckBox chkCrime;
        private CheckBox chkDrama;
        private CheckBox chkComedy;
        private CheckBox chkAction;
        private CheckBox chkEnglish;
        private CheckBox chkHindi;
        private Panel panel2;
        private PictureBox pictureBox1;
    }
}