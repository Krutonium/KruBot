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
            var creds = new creds();
            creds.username = tbAccountName.Text;
            creds.oauth = tbOauth.Text;
            creds.channeltomod = tbChannelName.Text.ToLower();
            File.WriteAllText("creds.json", JsonConvert.SerializeObject(creds, Formatting.Indented));
            System.Threading.Thread.Sleep(1000);
            this.Close();
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
            public string username;
            public string channeltomod;
            //This is an object used for Twitch Authentication
        }

        private void BtnClearCookies_Click(object sender, EventArgs e)
        {
            browser.GetCookieManager().DeleteCookies();
            browser.GetBrowser().Reload();
        }
    }
}
