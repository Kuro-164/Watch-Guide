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
            flowResults = new FlowLayoutPanel();
            btnSearch = new Button();
            panel1 = new Panel();
            btnBack = new Button();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowResults
            // 
            flowResults.AutoScroll = true;
            flowResults.BackColor = Color.Transparent;
            flowResults.Dock = DockStyle.Fill;
            flowResults.Location = new Point(0, 52);
            flowResults.Name = "flowResults";
            flowResults.Size = new Size(1264, 629);
            flowResults.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1189, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search  🔍︎ ";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(btnBack);
            panel1.Controls.Add(txtSearch);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 52);
            panel1.TabIndex = 3;
            panel1.Visible = false;
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
            // txtSearch
            // 
            txtSearch.Location = new Point(118, 2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1151, 23);
            txtSearch.TabIndex = 0;
            // 
            // SearchScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BlackBG;
            ClientSize = new Size(1264, 681);
            Controls.Add(btnSearch);
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

        private FlowLayoutPanel flowResults;
        private Button btnSearch;
        private Panel panel1;
        private TextBox txtSearch;
        private Button btnBack;
    }
}