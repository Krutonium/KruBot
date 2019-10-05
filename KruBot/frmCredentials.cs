using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using CefSharp;
using CefSharp.WinForms;

namespace KruBot
{
    public partial class frmCredentials : Form
    {
        public static ChromiumWebBrowser browser;
        public frmCredentials()
        {
            InitializeComponent();
        }

        private void CmdGetOauth_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("https://twitchapps.com/tmi/");
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            List<string> lsErrors = new List<string>();

            var creds = new creds();
            HandleEmptyCredentials("Account name", tbAccountName.Text, ref creds.username, ref lsErrors);
            HandleEmptyCredentials("OAuth", tbOauth.Text, ref creds.oauth, ref lsErrors);
            HandleEmptyCredentials("Client ID", tbClientID.Text.ToLower(), ref creds.clientID, ref lsErrors);
            HandleEmptyCredentials("Channel name", tbChannelName.Text.ToLower(), ref creds.channeltomod, ref lsErrors);

            if (lsErrors.Count <= 0)
            {
                File.WriteAllText("creds.json", JsonConvert.SerializeObject(creds, Formatting.Indented));
                System.Threading.Thread.Sleep(1000);
                this.Close();
            }
            else
            {
                foreach (string sError in lsErrors)
                {
                    MessageBox.Show(sError);
                }
            }
        }

        private void HandleEmptyCredentials(string sLabel, string field, ref string cred, ref List<string> lsErrors)
        {
            if (String.IsNullOrWhiteSpace(field))
            {
                lsErrors.Add(sLabel + " cannot be left blank.");
            }
            else
            {
                cred = field;
            }
        }

        private void FrmCredentials_Load(object sender, EventArgs e)
        {
            browser = new ChromiumWebBrowser("https://twitchapps.com/tmi/");
            browser.Dock = DockStyle.Fill;
            gbAuth.Controls.Add(browser);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        public class creds
        {
            public string oauth;
            public string clientID;
            public string username;
            public string channeltomod;
            public string alertsURL;
            //This is an object used for Twitch Authentication
        }

        private void BtnClearCookies_Click(object sender, EventArgs e)
        {
            browser.GetCookieManager().DeleteCookies();
            browser.GetBrowser().Reload();
        }
    }
}
