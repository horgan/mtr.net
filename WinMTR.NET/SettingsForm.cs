using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WinMTR.NET
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            if (SaveSettings())
            {
                DialogResult = DialogResult.OK; 
                Close();
            }
            
                

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
            label3.Text = "WinMTR.NET V" + Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
        }

        private void LoadSettings()
        {
            intervalTextBox.Text = string.Format("{0:0.0}", (decimal)MtrSettings.Instance.SettingsObject.Interval / 1000);
            pingSizeTextBox.Text = string.Format("{0}", MtrSettings.Instance.SettingsObject.PingSize);
            resolveNamesCheckBox.Checked = MtrSettings.Instance.SettingsObject.ResolveNames;
            maxHopsTextBox.Text = MtrSettings.Instance.SettingsObject.MaxHops.ToString();
            maxTimeoutTextBox.Text = MtrSettings.Instance.SettingsObject.MaxTimeout.ToString();
        }

        private bool SaveSettings()
        {
            try
            {
                MtrSettings.Instance.SettingsObject.Interval = (Int32)(1000 * Decimal.Parse(intervalTextBox.Text));

                MtrSettings.Instance.SettingsObject.MaxHops= (Int32)(Decimal.Parse(maxHopsTextBox.Text));
                MtrSettings.Instance.SettingsObject.MaxTimeout = (Int32)(Decimal.Parse(maxTimeoutTextBox.Text));

                MtrSettings.Instance.SettingsObject.PingSize = Int32.Parse(pingSizeTextBox.Text);
                if (MtrSettings.Instance.SettingsObject.PingSize > 65500)
                {
                    throw new ArgumentOutOfRangeException("PingSize");
                }
                MtrSettings.Instance.SettingsObject.ResolveNames = resolveNamesCheckBox.Checked;
                MtrSettings.Instance.Save();
                return true;
            }
            catch (Exception e) {
                if (e is ArgumentOutOfRangeException && (e as ArgumentOutOfRangeException).ParamName=="PingSize")
                {

                    MessageBox.Show("Ping size is larger than 65500 bytes. Please lower the value to continue");
                }
                return false;
            }

        }

    }
}
