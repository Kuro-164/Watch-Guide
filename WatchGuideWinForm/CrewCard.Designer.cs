namespace WinFormsApp1
{
    partial class CrewCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picActor = new PictureBox();
            lblName = new Label();
            lblCharacter = new Label();
            ((System.ComponentModel.ISupportInitialize)picActor).BeginInit();
            SuspendLayout();
            // 
            // picActor
            // 
            picActor.BackColor = Color.Black;
            picActor.Dock = DockStyle.Top;
            picActor.Location = new Point(0, 0);
            picActor.Name = "picActor";
            picActor.Size = new Size(110, 120);
            picActor.SizeMode = PictureBoxSizeMode.Zoom;
            picActor.TabIndex = 0;
            picActor.TabStop = false;
            // 
            // lblName
            // 
            lblName.AutoEllipsis = true;
            lblName.BackColor = Color.Black;
            lblName.Dock = DockStyle.Bottom;
            lblName.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(0, 146);
            lblName.Name = "lblName";
            lblName.Size = new Size(110, 24);
            lblName.TabIndex = 1;
            lblName.Text = "label1";
            lblName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCharacter
            // 
            lblCharacter.AutoEllipsis = true;
            lblCharacter.Dock = DockStyle.Bottom;
            lblCharacter.Font = new Font("Segoe UI", 6.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCharacter.ForeColor = Color.Gray;
            lblCharacter.Location = new Point(0, 123);
            lblCharacter.Name = "lblCharacter";
            lblCharacter.Size = new Size(110, 23);
            lblCharacter.TabIndex = 2;
            lblCharacter.Text = "label1";
            // 
            // CrewCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblCharacter);
            Controls.Add(lblName);
            Controls.Add(picActor);
            Name = "CrewCard";
            Size = new Size(110, 170);
            ((System.ComponentModel.ISupportInitialize)picActor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picActor;
        private Label lblName;
        private Label lblCharacter;
    }
}
