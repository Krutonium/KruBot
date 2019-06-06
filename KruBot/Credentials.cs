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
namespace KruBot
{
    public partial class frmCredentials : Form
    {
        public frmCredentials()
        {
            InitializeComponent();
        }

        private void CmdGetOauth_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitchapps.com/tmi/");
        }

        private void CmdSave_Click(object sender, EventArgs e)
        {
            var creds = new creds();
            creds.username = tbAccountName.Text;
            creds.oauth = tbOauth.Text;
            File.WriteAllText("creds.json", JsonConvert.SerializeObject(creds, Formatting.Indented));
            System.Threading.Thread.Sleep(1000);
            this.Close();
        }

        private void FrmCredentials_Load(object sender, EventArgs e)
        {
            
        }
        public class creds
        {
            public string oauth;
            public string username;
            //This is an object used for Twitch Authentication
        }
    }
}
