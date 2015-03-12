using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Winbrella
{
    public partial class credits : Form
    {
        public credits()
        {
            InitializeComponent();
        }

        private void credits_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void linklbltwitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo k = new ProcessStartInfo("http://twitter.com/@ih8x0r");
            Process.Start(k);
        }

        private void lblcredits1_Click(object sender, EventArgs e)
        {

        }

        private void credits_Load(object sender, EventArgs e)
        {
            this.lblcredits1.Text = "W|NbR3LL@ " + winbrella.appversion;
        }
    }
}
