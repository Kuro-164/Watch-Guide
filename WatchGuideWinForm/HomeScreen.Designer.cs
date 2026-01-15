namespace WinFormsApp1
{
    partial class HomeScreen
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
            components = new System.ComponentModel.Container();
            btnSearch = new Button();
            flpRecommended = new FlowLayoutPanel();
            lblRecommended = new Label();
            flpTrending = new FlowLayoutPanel();
            lblTrending = new Label();
            panel1 = new Panel();
            btnMenu = new Button();
            pnlTopBar = new Panel();
            panelContent = new Panel();
            cmsMenu = new ContextMenuStrip(components);
            settingsToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            logOutToolStripMenuItem = new ToolStripMenuItem();
            pnlTopBar.SuspendLayout();
            panelContent.SuspendLayout();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.BackColor = SystemColors.Control;
            btnSearch.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(84, 6);
            btnSearch.Margin = new Padding(4, 3, 4, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(933, 37);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Search 🔍";
            btnSearch.TextAlign = ContentAlignment.MiddleRight;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // flpRecommended
            // 
            flpRecommended.AutoScroll = true;
            flpRecommended.BackColor = Color.Transparent;
            flpRecommended.Dock = DockStyle.Top;
            flpRecommended.Location = new Point(0, 300);
            flpRecommended.Margin = new Padding(4, 3, 4, 3);
            flpRecommended.Name = "flpRecommended";
            flpRecommended.Size = new Size(1115, 230);
            flpRecommended.TabIndex = 4;
            flpRecommended.WrapContents = false;
            // 
            // lblRecommended
            // 
            lblRecommended.BackColor = Color.Transparent;
            lblRecommended.Dock = DockStyle.Top;
            lblRecommended.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecommended.ForeColor = SystemColors.Control;
            lblRecommended.Location = new Point(0, 265);
            lblRecommended.Margin = new Padding(4, 0, 4, 0);
            lblRecommended.Name = "lblRecommended";
            lblRecommended.Size = new Size(1115, 35);
            lblRecommended.TabIndex = 3;
            lblRecommended.Text = "RECOMMEND FOR YOU";
            lblRecommended.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpTrending
            // 
            flpTrending.AutoScroll = true;
            flpTrending.BackColor = Color.Transparent;
            flpTrending.Dock = DockStyle.Top;
            flpTrending.Location = new Point(0, 35);
            flpTrending.Margin = new Padding(4, 3, 4, 3);
            flpTrending.Name = "flpTrending";
            flpTrending.Size = new Size(1115, 230);
            flpTrending.TabIndex = 2;
            flpTrending.WrapContents = false;
            // 
            // lblTrending
            // 
            lblTrending.BackColor = Color.Transparent;
            lblTrending.Dock = DockStyle.Top;
            lblTrending.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTrending.ForeColor = SystemColors.Control;
            lblTrending.Location = new Point(0, 0);
            lblTrending.Margin = new Padding(4, 0, 4, 0);
            lblTrending.Name = "lblTrending";
            lblTrending.Size = new Size(1115, 35);
            lblTrending.TabIndex = 1;
            lblTrending.Text = "TRENDING";
            lblTrending.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Location = new Point(989, 78);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(57, 538);
            panel1.TabIndex = 5;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.Transparent;
            btnMenu.BackgroundImageLayout = ImageLayout.Stretch;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(25, 12);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(34, 31);
            btnMenu.TabIndex = 8;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // pnlTopBar
            // 
            pnlTopBar.Controls.Add(btnMenu);
            pnlTopBar.Controls.Add(btnSearch);
            pnlTopBar.Dock = DockStyle.Top;
            pnlTopBar.Location = new Point(0, 0);
            pnlTopBar.Name = "pnlTopBar";
            pnlTopBar.Size = new Size(1110, 70);
            pnlTopBar.TabIndex = 9;
            // 
            // panelContent
            // 
            panelContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelContent.BackColor = Color.Transparent;
            panelContent.Controls.Add(flpRecommended);
            panelContent.Controls.Add(lblRecommended);
            panelContent.Controls.Add(flpTrending);
            panelContent.Controls.Add(lblTrending);
            panelContent.Location = new Point(0, 49);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1115, 583);
            panelContent.TabIndex = 10;
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, aboutToolStripMenuItem, logOutToolStripMenuItem });
            cmsMenu.Name = "cmsMenu";
            cmsMenu.Size = new Size(117, 70);
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // logOutToolStripMenuItem
            // 
            logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            logOutToolStripMenuItem.Size = new Size(116, 22);
            logOutToolStripMenuItem.Text = "Log out";
            logOutToolStripMenuItem.Click += logOutToolStripMenuItem_Click;
            // 
            // HomeScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.BlackBG;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1110, 630);
            Controls.Add(panelContent);
            Controls.Add(pnlTopBar);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "HomeScreen";
            Text = "HomeScreen";
            Load += HomeScreen_Load;
            pnlTopBar.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblRecommended;
        private System.Windows.Forms.FlowLayoutPanel flpRecommended;
        private System.Windows.Forms.FlowLayoutPanel flpTrending;
        private System.Windows.Forms.Label lblTrending;
        private System.Windows.Forms.Panel panel1;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnMenu;
        private Panel pnlTopBar;
        private Panel panelContent;
        private ContextMenuStrip cmsMenu;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
    }
}

