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
using YoutubeExplode; //GPL3
using YoutubeExplode.Models.MediaStreams;
using NAudio;
using NAudio.Wave;
using CefSharp.WinForms;
using CefSharp;
using TwitchLib.Api;
using System.Net;

//TODO:
// Capture More Information from Song Requests for Display ✔
// Deny Duplicate Song Requests ✔
// Display Extra Information ✔
// 
namespace KruBot
{
    public partial class frmKruBot : Form
    {
        public static TwitchClient client = new TwitchClient();
        public static Queue<songreq> qt = new Queue<songreq>();
        public static WaveOutEvent OutputDevice = new WaveOutEvent();
        public static string ChannelToMod;

        public static ChromiumWebBrowser browser;
        public static ConnectionCredentials credentials;
        public frmKruBot()
        {
            InitializeComponent();
        }

        private void frmKruBot_Load(object sender, EventArgs e)
        {

            if (File.Exists("creds.json.old"))
            {
                DialogResult dialogResult = MessageBox.Show("We detected that your credentials were in the middle of being replaced. Recover?", "Recover Credentials?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    File.Move("creds.json.old", "creds.json");
                }
                else
                {
                    File.Delete("creds.json.old");
                }
            }


            CefSettings settings = new CefSettings();
            settings.CachePath = "./browsercache";
            settings.PersistSessionCookies = true;
            settings.PersistUserPreferences = true;
            Cef.Initialize(settings);
            var cred = new creds();
            if (File.Exists("creds.json"))
            {
                cred = JsonConvert.DeserializeObject<creds>(File.ReadAllText("creds.json"));
            } else
            {
                frmCredentials frmcreds = new frmCredentials();
                frmcreds.ShowDialog();
                cred = JsonConvert.DeserializeObject<creds>(File.ReadAllText("creds.json"));
            }
            ChannelToMod = cred.channeltomod;
            //Loads our Twitch Credentials from the Json file.
            credentials = new ConnectionCredentials(cred.username, cred.oauth);
            client.Initialize(credentials, ChannelToMod); //Channel were connecting to.
            client.OnConnected += Client_OnConnected;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.Connect();
            browser = new ChromiumWebBrowser("https://www.twitch.tv/popout/" + ChannelToMod + "/chat?popout=");
            browser.Dock = DockStyle.Fill;
            tbMusicVolume.MaximumSize = new System.Drawing.Size(tbMusicVolume.Width, 0);
            BrowserWindow.Controls.Add(browser);
            UpdateViewerList.Enabled = true;
            
            client.OnDisconnected += Client_OnDisconnected;
            client.OnReconnected += Client_OnReconnected;
            browser.AddressChanged += Browser_AddressChanged;
            ResetConnection.Enabled = true;
        }
        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            browser.ExecuteScriptAsyncWhenPageLoaded(new WebClient().DownloadString("https://cdn.frankerfacez.com/script/ffz_injector.user.js"));
        }

        private void Client_OnReconnected(object sender, TwitchLib.Communication.Events.OnReconnectedEventArgs e)
        {
            client.SendMessage(ChannelToMod,"Reconnected to Chat");
        }

        private void Client_OnDisconnected(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            //client.Reconnect();
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            //Act on Commands
            if (e.ChatMessage.Message.ToLower().StartsWith("!songrequest") || e.ChatMessage.Message.ToLower().StartsWith("!sr")) //user sent a song request.
                try
                {

                    var ytLink = e.ChatMessage.Message.Split(' '); 
                    var url = ytLink[1];
                    if (url.ToUpper().Contains("YOUTUBE") == false && url.ToUpper().Contains("YOUTU.BE") == false)
                    {
                        client.SendMessage(ChannelToMod, "That's not a valid video");
                        return;
                    }
                    var exists = qt.Any(x => x.ytlink.ToLower() == url.ToLower()); //Does any existing song request have the
                    if (exists) //Same youtube URL.
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
                        //Added song to the Queue.
                    }
                }
                catch
                {
                }
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            //client.SendMessage(ChannelToMod, "Successfully Joined");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
           
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
                return "Not a valid video.";
            }
        }
        static bool processing = false;
        private void SongStarter_Tick(object sender, EventArgs e)
        {
            if (qt.Count > 0 && processing == false)
            {
                processing = true;
                if(OutputDevice.PlaybackState == PlaybackState.Stopped)
                {
                    var songinfo = qt.Dequeue();
                    try
                    {
                        var id = YoutubeClient.ParseVideoId(songinfo.ytlink);
                        var ytclient = new YoutubeClient();
                        var video = ytclient.GetVideoAsync(id).Result;
                        var streamset = ytclient.GetVideoMediaStreamInfosAsync(id).Result;
                        var streamInfo = streamset.Audio;
                        using (var mf = new MediaFoundationReader(streamInfo[0].Url))
                        {
                            OutputDevice.Init(mf);
                            OutputDevice.Play();
                        }
                        lblTitle.Text = video.Title;
                        lblRequester.Text = songinfo.requester;
                        lblPlayerTime.Text = video.Duration.ToString();
                        client.SendMessage(ChannelToMod, "Playing " + video.Title);
                        File.WriteAllText("./SongTitle.txt", "Now Playing: " + video.Title);
                        File.WriteAllText("./Requester.txt", "Requested by: "  + songinfo.requester);  
                    }
                    catch { client.SendMessage(ChannelToMod, "Song failed to play: " + songinfo.ytlink); }
                }
            }
            if(qt.Count == 0 && OutputDevice.PlaybackState == PlaybackState.Stopped)
            {
                File.WriteAllText("./SongTitle.txt", "");
                File.WriteAllText("./Requester.txt", "");
            }
            processing = false;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            OutputDevice.Stop();
        }

        public class creds
        {
            public string oauth;
            public string username;
            public string channeltomod;
            //This is an object used for Twitch Authentication
        }

        public class songreq
        {
            public string requester;
            public string ytlink;
            //Information that is stored in the queue. More can be added easily.
        }

        private void tbMusicVolume_Scroll_1(object sender, EventArgs e)
        {
            //Make the volume slider functional.
            OutputDevice.Volume = (float)tbMusicVolume.Value /100;
        }
        public class Links
        {
        }

        public class Chatters
        {
            public IList<string> broadcaster { get; set; }
            public IList<string> vips { get; set; }
            public IList<string> moderators { get; set; }
            public IList<object> staff { get; set; }
            public IList<object> admins { get; set; }
            public IList<object> global_mods { get; set; }
            public IList<string> viewers { get; set; }
        }

        public class ViewerListJson
        {
            public Links _links { get; set; }
            public int chatter_count { get; set; }
            public Chatters chatters { get; set; }
        }

        private void UpdateViewerList_Tick(object sender, EventArgs e)
        {
            UpdateViewerList.Interval = 60000;
            var wc = new WebClient();
            var Viewers = JsonConvert.DeserializeObject<ViewerListJson>(wc.DownloadString("http://tmi.twitch.tv/group/user/"+ChannelToMod+"/chatters"));
            lbViewers.Items.Clear();

            if(Viewers.chatters.admins.Count > 0)
            {
                lbViewers.Items.Add("Admins:");
                lbViewers.Items.AddRange(Viewers.chatters.admins.ToArray());
                lbViewers.Items.AddRange(Viewers.chatters.staff.ToArray());
                lbViewers.Items.Add("");
            }
            if(Viewers.chatters.global_mods.Count > 0)
            {
                lbViewers.Items.Add("Global Moderators:");
                lbViewers.Items.AddRange(Viewers.chatters.global_mods.ToArray());
                lbViewers.Items.Add("");
            }
            if(Viewers.chatters.moderators.Count > 0)
            {
                lbViewers.Items.Add("Moderators:");
                lbViewers.Items.AddRange(Viewers.chatters.moderators.ToArray());
                lbViewers.Items.Add("");
            }
            if(Viewers.chatters.vips.Count > 0)
            {
                lbViewers.Items.Add("VIP:");
                lbViewers.Items.AddRange(Viewers.chatters.vips.ToArray());
                lbViewers.Items.Add("");
            }
            if(Viewers.chatters.viewers.Count > 0)
            {
                lbViewers.Items.Add("Viewers:");
                lbViewers.Items.AddRange(Viewers.chatters.viewers.ToArray());
            }
        }

        private void CmdReAuthenticate_Click(object sender, EventArgs e)
        {
            File.Move("./creds.json", "creds.json.old");
            frmCredentials credForm = new frmCredentials();
            credForm.ShowDialog();
            if (File.Exists("creds.json"))
            {
                File.Delete("creds.json.old");
            }
            //MessageBox.Show("Restart the bot for the changes to take effect.");
            var tempvars = JsonConvert.DeserializeObject<creds>(File.ReadAllText("creds.json"));
            ChannelToMod = tempvars.channeltomod;
            browser.Load("https://www.twitch.tv/popout/" + ChannelToMod + "/chat?popout=");
            UpdateViewerList.Interval = 1;
        }

        private void ResetConnection_Tick(object sender, EventArgs e)
        {
            //This works around an issue with Twitch where the IRC Client gets randomly disconnected.,

            client.Disconnect();
            client.Connect();
        }
    }
}