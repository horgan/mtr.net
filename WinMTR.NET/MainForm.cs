using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace WinMTR.NET
{
    public partial class MainForm : Form
    {
        private bool isRunning = false;
        private Trace t;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Methods


        /// <summary>
        /// 
        /// </summary>
        private void LoadSettings()
        {
            foreach (string s in MtrSettings.Instance.SettingsObject.SavedHosts)
            {
                if (s != null)
                    addressComboBox.Items.Add(s);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveSettings()
        {
            foreach (object o in addressComboBox.Items)
            {
                if (!MtrSettings.Instance.SettingsObject.SavedHosts.Contains(o.ToString()))
                {
                    MtrSettings.Instance.SettingsObject.SavedHosts.Add(o.ToString());
                }
            }

            MtrSettings.Instance.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Stop()
        {
            //Console.WriteLine("STOP");
            if (t != null)
            {
                t.Stop();
                t.Dispose();
                t = null;
                isRunning = false;
                startButton.Text = "&Start";
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            string host = addressComboBox.Text;
            if (!string.IsNullOrEmpty(host.Trim()) && !addressComboBox.Items.Contains(host))
                addressComboBox.Items.Add(host);
            isRunning = true;
            startButton.Text = "&Stop";
            StartPing(host);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        private void StartPing(string host)
        {

            Stop();
            if (t == null)
            {
                hostsListView.Items.Clear();

                try
                {
                    IPHostEntry ihe = Dns.GetHostEntry(host);
                    if (MtrSettings.Instance.SettingsObject.PingSize > 65500)
                        throw new ArgumentOutOfRangeException("PingSize");

                    t = new Trace(ihe.AddressList[0],
                         MtrSettings.Instance.SettingsObject.MaxTimeout,
                        MtrSettings.Instance.SettingsObject.Interval,
                        MtrSettings.Instance.SettingsObject.ResolveNames,
                        MtrSettings.Instance.SettingsObject.PingSize,
                        MtrSettings.Instance.SettingsObject.MaxHops
                        );
                    t.TraceEvent += new Trace.TraceEventHandler(t_TraceEvent);
                    t.Start();

                }
                catch (Exception)
                {
                    Stop();
                    isRunning = false;
                    startButton.Text = "&Start";
                    MessageBox.Show(this, "Exception occured");
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tt"></param>
        /// <param name="tet"></param>
        private void Update(Trace tt, TraceEventType tet)
        {
            lock (tt.Route)
            {

                foreach (var item in tt.Route)
                {
                    if (!hostsListView.Items.ContainsKey(item.TTL.ToString()))
                    {
                        hostsListView.Items.Add(item.TTL.ToString(), item.Address.ToString(), 0);
                    }

                    ListViewItem lvi = hostsListView.Items[item.TTL.ToString()];

                    if (lvi.SubItems.Count < 8)
                    {

                        ListViewItem.ListViewSubItem lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Hostname";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Nr";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Loss";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Sent";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Recv";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Best";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Avrg";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Worst";
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem(lvi, "");
                        lvsi.Name = "Last";
                        lvi.SubItems.Add(lvsi);

                    }

                    lvi.SubItems[0].Text =// item.TTL.ToString() + "  " + 
                        (item.IsNull ? "*" : (string.IsNullOrEmpty(item.HostName) ? item.Address.ToString() : item.HostName));


                    lvi.SubItems[1].Text = item.TTL.ToString();
                    lvi.SubItems[2].Text = ((int)(100 * item.Loss)).ToString() + " %";
                    lvi.SubItems[3].Text = item.SentPings.ToString();
                    lvi.SubItems[4].Text = item.RecvPings.ToString();


                    lvi.SubItems[5].Text = item.BestRoundTrip.ToString();
                    lvi.SubItems[6].Text = item.AvgRoundTrip.ToString();
                    lvi.SubItems[7].Text = item.WorstRoundTrip.ToString();
                    lvi.SubItems[8].Text = item.LastRoundTrip.ToString();


                    lvi.Tag = item;
                    if (item.BestRoundTrip == Int64.MaxValue)
                        lvi.SubItems[5].Text = "∞";

                }



                //foreach (KeyValuePair<IPAddress, RouteEntry> kvp in tt.Route)
                //{
                //    if (!hostsListView.Items.ContainsKey(kvp.Key.ToString()))
                //    {
                //        hostsListView.Items.Add(kvp.Key.ToString(), kvp.Key.ToString(), 0);
                //    }

                //    ListViewItem lvi = hostsListView.Items[kvp.Key.ToString()];

                //    if (lvi.SubItems.Count < 6)
                //    {
                //        for (int i = 0; i < 6; i++)
                //        {
                //            lvi.SubItems.Add("");
                //        }
                //    }

                //    lvi.SubItems[0].Text = string.IsNullOrEmpty(kvp.Value.HostName) ? kvp.Key.ToString() : kvp.Value.HostName;
                //    lvi.SubItems[1].Text = kvp.Value.LastRoundTrip.ToString();
                //    lvi.SubItems[2].Text = kvp.Value.AvgRoundTrip.ToString();
                //    lvi.SubItems[3].Text = kvp.Value.BestRoundTrip.ToString();
                //    lvi.SubItems[4].Text = kvp.Value.SentPings.ToString();
                //    lvi.SubItems[5].Text = kvp.Value.RecvPings.ToString();
                //    lvi.SubItems[6].Text = ((int)(100 * kvp.Value.Loss)).ToString() + " %";

                //    if (kvp.Value.BestRoundTrip == Int64.MaxValue)
                //        lvi.SubItems[3].Text = "∞";

                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        private string GetVisibleData(bool html)
        {

            string formatLine = "{0}\n";
            string formatItem = "{0}\t";
            if (html)
            {
                formatItem = "<td>{0}</td>";
                formatLine = "<tr>{0}</tr>\n";
            }

            StringBuilder sbMain = new StringBuilder();
            foreach (ListViewItem lvi in hostsListView.Items)
            {
                StringBuilder sb = new StringBuilder(256);
                for (int i = 0; i < lvi.SubItems.Count; i++)
                {
                    sb.AppendFormat(formatItem, lvi.SubItems[i].Text);
                }
                sbMain.AppendFormat(formatLine, sb.ToString());
            }

            if (html)
            {
                sbMain.Insert(0, "<table>");
                sbMain.Append("</table>");
            }
            else
            {
                sbMain.Insert(0, "\n");
                sbMain.Append("\n");
            }

            return sbMain.ToString();
        }

        #endregion


        #region Events

        void t_TraceEvent(object sender, TraceEventArgs e)
        {
            Trace tt = (Trace)sender;

            switch (e.TraceEventType)
            {
                case TraceEventType.PingRecv:
                    goto case TraceEventType.PingSend;
                case TraceEventType.PingSend:
                    if (hostsListView.InvokeRequired)
                    {
                        hostsListView.BeginInvoke(new MethodInvoker(delegate () { Update(tt, e.TraceEventType); }));
                    }
                    else
                    {
                        Update(tt, e.TraceEventType);
                    }
                    break;

                case TraceEventType.PingStopped:
                    //Console.WriteLine("STOP");
                    if (hostsListView.InvokeRequired)
                    {
                        BeginInvoke(new MethodInvoker(delegate () { Stop(); }));
                    }
                    else
                    {
                        Stop();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!isRunning)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }

        private void copyTextButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetVisibleData(false));
        }

        private void copyHTMLButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetVisibleData(true));
        }

        private void exportTEXTButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, GetVisibleData(false));
            }
        }

        private void exportHTMLButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Html files (*.html)|*.html|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, GetVisibleData(true));
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
            SaveSettings();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            toolStripStatusLabel2.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void addressComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Start();
            }
        }


        #endregion

        private void hostsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo lvhti = hostsListView.HitTest(e.Location);
            if (lvhti.Item != null)
            {
                if (lvhti.Item.Tag != null && lvhti.Item.Tag is RouteEntry)
                {
                    RouteEntry re = lvhti.Item.Tag as RouteEntry;
                    InfoForm iForm = new InfoForm();
                    iForm.Item = re;
                    iForm.ShowDialog(this);

                }
            }


        }




    }
}
