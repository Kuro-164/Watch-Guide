namespace WinFormsApp1
{
    partial class SearchScreen
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
            panel1 = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            btnBack = new Button();
            flowResults = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnSearch);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnBack);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.MaximumSize = new Size(0, 70);
            panel1.MinimumSize = new Size(0, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 70);
            panel1.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(43, 43, 43);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(1194, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search  🔍︎ ";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new Point(118, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1151, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI Emoji", 25.75F, FontStyle.Bold);
            btnBack.ImageAlign = ContentAlignment.TopCenter;
            btnBack.Location = new Point(12, -12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(53, 50);
            btnBack.TabIndex = 1;
            btnBack.Text = "«";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // flowResults
            // 
            flowResults.AutoScroll = true;
            flowResults.BackColor = Color.Black;
            flowResults.Dock = DockStyle.Fill;
            flowResults.Location = new Point(0, 70);
            flowResults.Name = "flowResults";
            flowResults.Size = new Size(1264, 611);
            flowResults.TabIndex = 4;
            // 
            // SearchScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1264, 681);
            Controls.Add(flowResults);
            Controls.Add(panel1);
            MinimumSize = new Size(1280, 720);
            Name = "SearchScreen";
            Text = "SearchScreen";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSearch;
        private Panel panel1;
        private TextBox txtSearch;
        private Button btnBack;
        private FlowLayoutPanel flowResults;
    }
}