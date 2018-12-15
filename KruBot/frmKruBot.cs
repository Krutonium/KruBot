using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;
using TwitchLib.Client; //MIT
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms; //MIT
using YoutubeExplode; //GPL3
using YoutubeExplode.Models.MediaStreams;


//TODO:
// Capture More Information from Song Requests for Display ✔
// Deny Duplicate Song Requests ✔
// Display Extra Information ✔
// 
namespace KruBot
{
    public partial class frmKruBot : Form
    {
        public static VlcControl vlc = new VlcControl();
        public static TwitchClient client = new TwitchClient();
        public static Queue<songreq> qt = new Queue<songreq>();

        public frmKruBot()
        {
            InitializeComponent();
        }

        private void frmKruBot_Load(object sender, EventArgs e)
        {
            vlc.BeginInit();
            vlc.VlcLibDirectory = Vlc_VlcLibDirectoryNeeded();
            var options = new[]
            {
                "--audio-filter", "normvol", "--norm-max-level", "1.5"
            };
            vlc.VlcMediaplayerOptions = options;
            vlc.EndInit();
            vlc.Dock = DockStyle.Fill;
            tabYouTube.Controls.Add(vlc);
            vlc.Audio.Volume = tbMusicVolume.Value;
            //VLC set up.

            var cred = JsonConvert.DeserializeObject<creds>(File.ReadAllText("creds.json"));
            var credentials = new ConnectionCredentials(cred.username, cred.oauth);
            client.Initialize(credentials, "pfckrutonium");
            client.OnConnected += Client_OnConnected;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.Connect();
            rtbChat.LinkClicked += RtbChat_LinkClicked;
        }

        private void RtbChat_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            //Build Tags
            var userTags = "";
            if (e.ChatMessage.IsMe)
                userTags += "[Me]";
            else if (e.ChatMessage.IsModerator)
                userTags += "[Mod]";
            else if (e.ChatMessage.IsSubscriber)
                userTags += "[Sub]";
            else if (e.ChatMessage.IsTurbo)
                userTags += "[TwPr]";
            else if (e.ChatMessage.IsBroadcaster) userTags += "[Me]";

            userTags += " " + e.ChatMessage.Username + ": ";
            if (rtbChat.InvokeRequired)
                rtbChat.Invoke((Action) delegate
                {
                    rtbChat.AppendText(userTags + e.ChatMessage.Message + Environment.NewLine);
                });
            else
                rtbChat.AppendText(userTags + e.ChatMessage.Message + Environment.NewLine);

            //Act on Commands
            if (e.ChatMessage.Message.ToLower().StartsWith("!songrequest"))
                try
                {
                    var ytLink = e.ChatMessage.Message.Split(' ');
                    var url = ytLink[1];
                    var exists = qt.Any(x => x.ytlink.ToLower() == url.ToLower());
                    if (exists)
                    {
                        client.SendMessage(e.ChatMessage.Channel, "Song already exists in Queue.");
                    }
                    else
                    {
                        var p = new songreq();
                        p.requester = e.ChatMessage.Username;
                        p.ytlink = ytLink[1];
                        qt.Enqueue(p);
                        client.SendMessage(e.ChatMessage.Channel, "Added " + GetVideoTitle(ytLink[1]) + " to Queue.");
                    }
                }
                catch
                {
                }
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            rtbChat.Invoke((Action) delegate
            {
                rtbChat.AppendText("Successfully connected to the channel." + Environment.NewLine);
            });
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            rtbChat.Invoke((Action) delegate { rtbChat.AppendText("Connected to Twitch." + Environment.NewLine); });
        }

        private DirectoryInfo Vlc_VlcLibDirectoryNeeded()
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            // Default installation path of VideoLAN.LibVLC.Windows
            var VlcLibDirectory =
                new DirectoryInfo(Path.Combine(currentDirectory, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));
            return VlcLibDirectory;
        }

        private void SetVideo(songreq request)
        {
            try
            {
                vlc.Position = 0;
                var id = YoutubeClient.ParseVideoId(request.ytlink);
                lblRequester.Text = request.requester;
                var yt = new YoutubeClient();
                var video = yt.GetVideoMediaStreamInfosAsync(id).Result;
                var muxed = video.Muxed.WithHighestVideoQuality();
                lblTitle.Text = GetVideoTitle(request.ytlink);
                vlc.SetMedia(new Uri(muxed.Url));
                vlc.Play();
            }
            catch
            {
            }
        }

        private string GetVideoTitle(string url)
        {
            try
            {
                var id = YoutubeClient.ParseVideoId(url);
                var yt = new YoutubeClient();
                var video = yt.GetVideoAsync(id).Result;
                return video.Title;
            }
            catch
            {
            }

            return "Not a valid video.";
        }

        private void SongStarter_Tick(object sender, EventArgs e)

        {
            var b = (int) vlc.Time / 1000;
            var a = (int) vlc.Length / 1000;
            var c = a / 60; //Total Seconds
            a = a - c * 60; //Total Minutes
            var d = b / 60; //seconds
            b = b - d * 60; //Minutes
            lblPlayerTime.Text = d + @":" + b + @"/" + c + @":" + a;
            //lblPlayerTime.Text = vlc.Time.ToString();
            switch (vlc.State)
            {
                case MediaStates.NothingSpecial:
                {
                    if (qt.Count > 0) SetVideo(qt.Dequeue());
                    break;
                }
                case MediaStates.Ended:
                {
                    if (qt.Count > 0) SetVideo(qt.Dequeue());
                    break;
                }
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            client.SendMessage(client.GetJoinedChannel("pfckrutonium"), tbMsg.Text);
            if (tbMsg.Text.ToLower().StartsWith("!songrequest"))
                try
                {
                    var ytLink = tbMsg.Text.Split(' ');
                    var p = new songreq
                    {
                        requester = "Me",
                        ytlink = ytLink[1]
                    };
                    qt.Enqueue(p);
                    client.SendMessage(client.GetJoinedChannel("pfckrutonium"),
                        "Added " + GetVideoTitle(ytLink[1]) + " to Queue.");
                }
                catch
                {
                }

            rtbChat.Invoke((Action) delegate { rtbChat.AppendText("[Me] " + tbMsg.Text + Environment.NewLine); });
            tbMsg.Text = "";
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            vlc.Position = 1;
        }
        //private void tbMsg_TextChanged_1(object sender, EventArgs e)
        //{
        //    e.Handled = true;
        //    if (e.KeyCode == Keys.Enter) btnSendMessage_Click(this, new EventArgs());
        //}

        private void rtbChat_TextChanged(object sender, EventArgs e)
        {
            rtbChat.SelectionStart = rtbChat.Text.Length;
            rtbChat.ScrollToCaret();

            //Keep our chat scrolling
        }

        public class creds
        {
            public string oauth;
            public string username;
        }

        public class songreq
        {
            public string requester;
            public string ytlink;
        }

        private void tbMusicVolume_Scroll_1(object sender, EventArgs e)
        {
            vlc.Audio.Volume = tbMusicVolume.Value;
        }
    }
}