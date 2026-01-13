using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value =
        Math.Max(flowLayoutPanel1.VerticalScroll.Minimum,
                 flowLayoutPanel1.VerticalScroll.Value - 60);

            flowLayoutPanel1.PerformLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value =
        Math.Min(flowLayoutPanel1.VerticalScroll.Maximum,
                 flowLayoutPanel1.VerticalScroll.Value + 60);

            flowLayoutPanel1.PerformLayout();
        }
    }
}
