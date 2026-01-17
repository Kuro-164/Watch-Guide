namespace WinFormsApp1
{
    partial class ShowDetailForm
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
            pnlRoot = new Panel();
            panel1 = new Panel();
            flpCrew = new FlowLayoutPanel();
            lblCrewTitle = new Label();
            pnlAbout = new Panel();
            lblAboutText = new Label();
            lblAboutTitle = new Label();
            pnlInfo = new Panel();
            tblInfo = new TableLayoutPanel();
            picPoster = new PictureBox();
            pnlTextInfo = new Panel();
            flpPlatforms = new FlowLayoutPanel();
            lblPlatforms = new Label();
            lblLanguage = new Label();
            lblGenres = new Label();
            lblMeta = new Label();
            lblTitle = new Label();
            btnBack = new Button();
            picBanner = new PictureBox();
            pnlRoot.SuspendLayout();
            panel1.SuspendLayout();
            pnlAbout.SuspendLayout();
            pnlInfo.SuspendLayout();
            tblInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPoster).BeginInit();
            pnlTextInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBanner).BeginInit();
            SuspendLayout();
            // 
            // pnlRoot
            // 
            pnlRoot.AutoScroll = true;
            pnlRoot.Controls.Add(panel1);
            pnlRoot.Controls.Add(pnlAbout);
            pnlRoot.Controls.Add(pnlInfo);
            pnlRoot.Controls.Add(btnBack);
            pnlRoot.Controls.Add(picBanner);
            pnlRoot.Dock = DockStyle.Fill;
            pnlRoot.Location = new Point(0, 0);
            pnlRoot.Name = "pnlRoot";
            pnlRoot.Size = new Size(1264, 746);
            pnlRoot.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(flpCrew);
            panel1.Controls.Add(lblCrewTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 527);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(12);
            panel1.Size = new Size(1247, 255);
            panel1.TabIndex = 4;
            // 
            // flpCrew
            // 
            flpCrew.AutoScroll = true;
            flpCrew.Dock = DockStyle.Top;
            flpCrew.Location = new Point(12, 32);
            flpCrew.Margin = new Padding(0, 8, 0, 0);
            flpCrew.Name = "flpCrew";
            flpCrew.Size = new Size(1223, 211);
            flpCrew.TabIndex = 1;
            flpCrew.WrapContents = false;
            // 
            // lblCrewTitle
            // 
            lblCrewTitle.AutoSize = true;
            lblCrewTitle.Dock = DockStyle.Top;
            lblCrewTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCrewTitle.ForeColor = Color.White;
            lblCrewTitle.Location = new Point(12, 12);
            lblCrewTitle.Name = "lblCrewTitle";
            lblCrewTitle.Size = new Size(39, 20);
            lblCrewTitle.TabIndex = 0;
            lblCrewTitle.Text = "Cast";
            // 
            // pnlAbout
            // 
            pnlAbout.AutoSize = true;
            pnlAbout.Controls.Add(lblAboutText);
            pnlAbout.Controls.Add(lblAboutTitle);
            pnlAbout.Dock = DockStyle.Top;
            pnlAbout.Location = new Point(0, 460);
            pnlAbout.Name = "pnlAbout";
            pnlAbout.Padding = new Padding(12);
            pnlAbout.Size = new Size(1247, 67);
            pnlAbout.TabIndex = 3;
            // 
            // lblAboutText
            // 
            lblAboutText.AutoSize = true;
            lblAboutText.Dock = DockStyle.Top;
            lblAboutText.ForeColor = Color.Gainsboro;
            lblAboutText.Location = new Point(12, 32);
            lblAboutText.Name = "lblAboutText";
            lblAboutText.Padding = new Padding(0, 8, 0, 0);
            lblAboutText.Size = new Size(38, 23);
            lblAboutText.TabIndex = 1;
            lblAboutText.Text = "label1";
            // 
            // lblAboutTitle
            // 
            lblAboutTitle.AutoSize = true;
            lblAboutTitle.Dock = DockStyle.Top;
            lblAboutTitle.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAboutTitle.ForeColor = Color.White;
            lblAboutTitle.Location = new Point(12, 12);
            lblAboutTitle.Name = "lblAboutTitle";
            lblAboutTitle.Size = new Size(53, 20);
            lblAboutTitle.TabIndex = 0;
            lblAboutTitle.Text = "About";
            // 
            // pnlInfo
            // 
            pnlInfo.Controls.Add(tblInfo);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(0, 240);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Padding = new Padding(16);
            pnlInfo.Size = new Size(1247, 220);
            pnlInfo.TabIndex = 2;
            // 
            // tblInfo
            // 
            tblInfo.ColumnCount = 2;
            tblInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            tblInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblInfo.Controls.Add(picPoster, 0, 0);
            tblInfo.Controls.Add(pnlTextInfo, 1, 0);
            tblInfo.Dock = DockStyle.Fill;
            tblInfo.Location = new Point(16, 16);
            tblInfo.Name = "tblInfo";
            tblInfo.RowCount = 1;
            tblInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tblInfo.Size = new Size(1215, 188);
            tblInfo.TabIndex = 1;
            // 
            // picPoster
            // 
            picPoster.Location = new Point(0, 0);
            picPoster.Margin = new Padding(0, 0, 16, 0);
            picPoster.Name = "picPoster";
            picPoster.Size = new Size(140, 188);
            picPoster.SizeMode = PictureBoxSizeMode.Zoom;
            picPoster.TabIndex = 0;
            picPoster.TabStop = false;
            // 
            // pnlTextInfo
            // 
            pnlTextInfo.Controls.Add(flpPlatforms);
            pnlTextInfo.Controls.Add(lblPlatforms);
            pnlTextInfo.Controls.Add(lblLanguage);
            pnlTextInfo.Controls.Add(lblGenres);
            pnlTextInfo.Controls.Add(lblMeta);
            pnlTextInfo.Controls.Add(lblTitle);
            pnlTextInfo.Dock = DockStyle.Fill;
            pnlTextInfo.Location = new Point(163, 3);
            pnlTextInfo.Name = "pnlTextInfo";
            pnlTextInfo.Size = new Size(1049, 214);
            pnlTextInfo.TabIndex = 1;
            // 
            // flpPlatforms
            // 
            flpPlatforms.AutoScroll = true;
            flpPlatforms.BackColor = Color.Transparent;
            flpPlatforms.Location = new Point(0, 130);
            flpPlatforms.Margin = new Padding(0);
            flpPlatforms.Name = "flpPlatforms";
            flpPlatforms.Size = new Size(500, 70);
            flpPlatforms.TabIndex = 5;
            flpPlatforms.WrapContents = false;
            // 
            // lblPlatforms
            // 
            lblPlatforms.AutoSize = true;
            lblPlatforms.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPlatforms.ForeColor = Color.WhiteSmoke;
            lblPlatforms.Location = new Point(0, 105);
            lblPlatforms.Name = "lblPlatforms";
            lblPlatforms.Size = new Size(72, 15);
            lblPlatforms.TabIndex = 4;
            lblPlatforms.Text = "Available on";
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.ForeColor = Color.Gray;
            lblLanguage.Location = new Point(0, 78);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(38, 15);
            lblLanguage.TabIndex = 3;
            lblLanguage.Text = "label1";
            // 
            // lblGenres
            // 
            lblGenres.AutoSize = true;
            lblGenres.ForeColor = Color.Gainsboro;
            lblGenres.Location = new Point(0, 58);
            lblGenres.Name = "lblGenres";
            lblGenres.Size = new Size(38, 15);
            lblGenres.TabIndex = 2;
            lblGenres.Text = "label1";
            // 
            // lblMeta
            // 
            lblMeta.AutoSize = true;
            lblMeta.ForeColor = Color.LightGray;
            lblMeta.Location = new Point(0, 36);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(38, 15);
            lblMeta.TabIndex = 1;
            lblMeta.Text = "label1";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(83, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(30, 30, 30);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.ImageAlign = ContentAlignment.TopCenter;
            btnBack.Location = new Point(12, -12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(36, 46);
            btnBack.TabIndex = 1;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // picBanner
            // 
            picBanner.Dock = DockStyle.Top;
            picBanner.Location = new Point(0, 0);
            picBanner.Name = "picBanner";
            picBanner.Size = new Size(1247, 240);
            picBanner.SizeMode = PictureBoxSizeMode.Zoom;
            picBanner.TabIndex = 0;
            picBanner.TabStop = false;
            // 
            // ShowDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1264, 746);
            Controls.Add(pnlRoot);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimumSize = new Size(1280, 720);
            Name = "ShowDetailForm";
            Text = "ShowDetailForm";
            Load += ShowDetailForm_Load;
            pnlRoot.ResumeLayout(false);
            pnlRoot.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            pnlAbout.ResumeLayout(false);
            pnlAbout.PerformLayout();
            pnlInfo.ResumeLayout(false);
            tblInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picPoster).EndInit();
            pnlTextInfo.ResumeLayout(false);
            pnlTextInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBanner).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRoot;
        private PictureBox picBanner;
        private Panel pnlInfo;
        private Button btnBack;
        private TableLayoutPanel tblInfo;
        private PictureBox picPoster;
        private Panel pnlTextInfo;
        private Label lblMeta;
        private Label lblTitle;
        private Label lblGenres;
        private Label lblPlatforms;
        private Label lblLanguage;
        private FlowLayoutPanel flpPlatforms;
        private Panel pnlAbout;
        private Label lblAboutText;
        private Label lblAboutTitle;
        private Panel panel1;
        private FlowLayoutPanel flpCrew;
        private Label lblCrewTitle;
    }
}