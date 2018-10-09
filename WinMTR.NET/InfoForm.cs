using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace WinMTR.NET
{
    public partial class InfoForm : Form
    {
        public RouteEntry Item { get; set; }
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            if (Item != null)
            {
                textBoxHostname.Text = string.IsNullOrEmpty(Item.HostName) ? Item.Address.ToString() : Item.HostName;
                textBoxIPAddress.Text = Item.Address.ToString();
                textBoxHostStatus.Text = "?";
                textBoxSent.Text = Item.SentPings.ToString();
                textBoxReceived.Text = Item.RecvPings.ToString();
                textBoxLoss.Text = ((int)(100 * Item.Loss)).ToString() + " %";

                textBoxBest.Text =Item.BestRoundTrip==long.MaxValue?"-": Item.BestRoundTrip.ToString();
                textBoxLast.Text = Item.LastRoundTrip.ToString();
                textBoxAverage.Text = Item.AvgRoundTrip.ToString();
                textBoxWorst.Text = Item.WorstRoundTrip.ToString();
                textBoxHostStatus.Text = Item.Address == null ||Item.Address==IPAddress.Any  ? "N/A" : "Alive";

            }
            else { Close(); }
        }
    }
}
