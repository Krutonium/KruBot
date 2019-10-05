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
using System.Runtime.InteropServices;
using System.Diagnostics;

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
        public static creds cred = new creds();
        public static ChromiumWebBrowser browser;
        public static ConnectionCredentials credentials;
        public static Currency currency = new Currency();

        TwitchAPI api = new TwitchAPI();

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
                    if (File.Exists("creds.json")) // Stops an error when both .old and .json exist (rare case)
                    {
                        File.Delete("creds.json");
                    }
                    File.Move("creds.json.old", "creds.json");
                }
                else
                {
                    File.Delete("creds.json.old");
                }
            }
            if (File.Exists("ChatCurrency.json"))
            {
                currency = JsonConvert.DeserializeObject<Currency>(File.ReadAllText("ChatCurrency.json"));
            } else
            {
                currency = new Currency();
                currency.CurrencyName = "Krutons";
                currency.CurrencySymbol = "K";
                currency.users = new List<KeyValuePair<string, int>>();
                currency.users.Add(new KeyValuePair<string, int>("PFCKrutonium", 1));
            }

            CefSettings settings = new CefSettings();
            settings.CachePath = "./browsercache";
            settings.PersistSessionCookies = true;
            settings.PersistUserPreferences = true;
            settings.CefCommandLineArgs.Add("autoplay-policy", "no-user-gesture-required");
            Cef.Initialize(settings);

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
            //browser. <INJECT JAVASCRIPT ON POPUPS>
            browser.ActivateBrowserOnCreation = true;
            ResetConnection.Enabled = true;
            var tmpBrowser = new ChromiumWebBrowser(cred.alertsURL);
            tmpBrowser.ActivateBrowserOnCreation = true;
            gbAlerts.Controls.Add(tmpBrowser);
            client.OnDisconnected += Client_OnDisconnected1;

            api.Settings.ClientId = cred.clientID;
            api.Settings.AccessToken = cred.oauth;
        }

        private void Client_OnDisconnected1(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            client.Connect();
        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            browser.ExecuteScriptAsyncWhenPageLoaded(new WebClient().DownloadString("https://cdn.frankerfacez.com/script/ffz_injector.user.js"));
        }


        private void Client_OnReconnected(object sender, TwitchLib.Communication.Events.OnReconnectedEventArgs e)
        {
            client.SendMessage(ChannelToMod, "Reconnected to Chat");
        }

        private void Client_OnDisconnected(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            //client.Reconnect();
        }

        private void GiveCurrency(string Username, int Amount)
        {
            if (Username.StartsWith("@"))
            {
                Username = Username.Substring(1, Username.Length - 1);
            }
            int indexx = -1;
            int index = 0;
            foreach (var user in currency.users)
            {
                if (user.Key == Username)
                {
                    indexx = index;
                    break;
                }
                index += 1;
            }
            if (indexx == -1 == false)
            {
                currency.users[indexx] = new KeyValuePair<string, int>(Username, currency.users[indexx].Value + Amount);
            }
            else
            {
                currency.users.Add(new KeyValuePair<string, int>(Username, Amount));
            }
        }

        private int GetCurrency(string Username)
        {
            if (Username.StartsWith("@"))
            {
                Username = Username.Substring(1, Username.Length - 1);
            }
            foreach (var user in currency.users)
            {
                if (user.Key == Username)
                {
                    return user.Value;
                }
            }
            return 0;
        }

        private void SaveCurrency()
        {
            File.WriteAllText("ChatCurrency.json", JsonConvert.SerializeObject(currency, Formatting.Indented));
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
                        //client.SendMessage(e.ChatMessage.Message,SearchForVideo(e.ChatMessage.Message));
                        client.SendMessage(e.ChatMessage.Channel, "Invalid Video");
                        return;
                    }
                    var exists = qt.Any(x => x.ytlink.ToLower() == url.ToLower()); //Does any existing song request have the
                    if (exists) //Same youtube URL.
                    {
                        client.SendMessage(e.ChatMessage.Channel, "Song already exists in Queue.");
                    }
                    else
                    {
                        if (GetCurrency(e.ChatMessage.Username) < 100 && !e.ChatMessage.IsModerator && !e.ChatMessage.IsSubscriber)
                        {
                            client.SendMessage(e.ChatMessage.Channel, "You don't have enough " + currency.CurrencyName);
                            return;
                        } else
                        {
                            GiveCurrency(e.ChatMessage.Username, -100);
                        }
                        var p = new songreq();
                        p.requester = e.ChatMessage.Username;
                        p.ytlink = ytLink[1];
                        p.name = GetVideoTitle(ytLink[1]);
                        qt.Enqueue(p);
                        client.SendMessage(e.ChatMessage.Channel, "Added " + p.name + " to Queue.");
                        //Added song to the Queue.
                        PlayPauseSpotify();
                    }
                }
                catch
                {
                }
            if (e.ChatMessage.Message.ToUpper() == "!LIST")
            {
                List<songreq> songlist = qt.ToList<songreq>();
                //string Queue = "Songs in Queue:" + Environment.NewLine;
                client.SendWhisper(e.ChatMessage.Username, "Queue");
                if (songlist.Count > 0)
                {
                    foreach (var song in songlist)
                    {

                        client.SendWhisper(e.ChatMessage.Username, song.name);
                        //Queue += song.name + Environment.NewLine;
                    }
                }
                else
                {
                    //Queue = "No Songs in Queue";
                }

            }

            if (e.ChatMessage.Message.ToUpper() == "!LURK")
            {
                client.SendMessage(e.ChatMessage.Channel, e.ChatMessage.Username + " is now lurking!");
            }
            if (e.ChatMessage.Message.ToUpper() == "!BACK")
            {
                client.SendMessage(e.ChatMessage.Channel, e.ChatMessage.Username + " is back from their lurk! Rejoice!");
            }
            if (e.ChatMessage.Message.ToUpper().Contains("LEWD")) {
                client.SendMessage(e.ChatMessage.Channel, "LEWD? WHERE?! OWO!!!");
            }
            if (e.ChatMessage.Message.ToUpper().StartsWith("!HUG"))
            {
                string[] command = e.ChatMessage.Message.Split(' ');
                if (command.Length == 2)
                {
                    client.SendMessage(e.ChatMessage.Channel, e.ChatMessage.Username + " has given " + command[1] + " a hug! CUTE!");
                }
            }
            if (e.ChatMessage.Message.ToUpper() == "!FOLLOWAGE")
            {
                client.SendMessage(e.ChatMessage.Channel, "Implement this on GitHub! https://github.com/PFCKrutonium/KruBot");
            }
            if (e.ChatMessage.Message.ToUpper() == "!UPTIME")
            {
                var userID = api.V5.Users.GetUserByNameAsync(e.ChatMessage.Username).Result;
                var foundChannel = userID.Matches.FirstOrDefault();
                var online = api.V5.Streams.BroadcasterOnlineAsync(foundChannel.Id).Result;
                if (online)
                {
                    var uptime = api.V5.Streams.GetUptimeAsync(foundChannel.Id).Result;
                    if (uptime.HasValue)
                    {
                        client.SendMessage(e.ChatMessage.Channel, foundChannel.Name + " has been online for " + uptime.Value.Hours + " hours and " + uptime.Value.Minutes + " minutes.");
                    }
                    else
                    {
                        //client.SendMessage(e.ChatMessage.Channel, "uptime did not return a value.");
                    }
                }
            }
            if (e.ChatMessage.Message.ToUpper() == "!COMMANDS")
            {
                client.SendWhisper(e.ChatMessage.Username, "https://pastebin.com/raw/Qn13QpyH <= Commands");
            }
            if (e.ChatMessage.Message.ToUpper() == "!SKIP")
            {
                if (e.ChatMessage.IsModerator == true || e.ChatMessage.IsBroadcaster == true)
                {
                    OutputDevice.Stop();
                    client.SendMessage(e.ChatMessage.Channel, "Song Skipped");
                }
            }
            //Money Commands
            if (e.ChatMessage.Message.ToUpper().StartsWith("!" + currency.CurrencyName.ToUpper()))
            {

                string[] command = e.ChatMessage.Message.Split(' ');
                if (command.Length == 1)
                {
                    client.SendMessage(e.ChatMessage.Channel, e.ChatMessage.Username + " has " + currency.CurrencySymbol + " " + GetCurrency(e.ChatMessage.Username));
                } else
                {
                    client.SendMessage(e.ChatMessage.Channel, command[1] + " has " + GetCurrency(command[1]).ToString() + " " + currency.CurrencyName);
                }
            }



            if (e.ChatMessage.Message.ToUpper().StartsWith("!GIVE")) {
                if (e.ChatMessage.UserType == TwitchLib.Client.Enums.UserType.Moderator || e.ChatMessage.UserType == TwitchLib.Client.Enums.UserType.Broadcaster)
                { //!give pfckrutonium 5 <= Gives PFCKrutonium 5 Krutons
                    string[] command = e.ChatMessage.Message.Split(' ');
                    try
                    {
                        GiveCurrency(command[1], Int32.Parse(command[2]));
                        client.SendMessage(e.ChatMessage.Channel, "Gave " + command[1] + " " + command[2] + " " + currency.CurrencyName);
                    }
                    catch
                    {
                        client.SendMessage(e.ChatMessage.Channel, "Invalid Input");
                    }
                }
            }
            if (e.ChatMessage.Message.ToUpper().StartsWith("!RESET"))
            {
                if (e.ChatMessage.UserType == TwitchLib.Client.Enums.UserType.Moderator || e.ChatMessage.UserType == TwitchLib.Client.Enums.UserType.Broadcaster)
                {
                    string[] command = e.ChatMessage.Message.Split(' ');
                    client.SendMessage(e.ChatMessage.Channel, "Resetting " + e.ChatMessage.Username + " from " + GetCurrency(command[1]) + " to 0");
                    GiveCurrency(command[1], GetCurrency(command[1]) * -1);

                }
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
                if (OutputDevice.PlaybackState == PlaybackState.Stopped)
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
                        File.WriteAllText(cred.songTitleTxt, "Now Playing: " + video.Title);
                        File.WriteAllText("./Requester.txt", "Requested by: " + songinfo.requester);
                        this.Text = "KruBot - Playing";

                    }
                    catch { client.SendMessage(ChannelToMod, "Song failed to play: " + songinfo.name); }
                }
            }
            if (qt.Count == 0 && OutputDevice.PlaybackState == PlaybackState.Stopped)
            {
                File.WriteAllText(cred.songTitleTxt, "");
                File.WriteAllText("./Requester.txt", "");
            }
            processing = false;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            OutputDevice.Stop();
        }


        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        private void PlayPauseSpotify()
        {
            Process[] p = Process.GetProcessesByName("Spotify.exe");
            foreach (Process q in p)
            {
                IntPtr h = q.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait("{MediaPlayPause}");
            }
        }


        public class creds
        {
            public string oauth;
            public string clientID;
            public string username;
            public string channeltomod;
            public string alertsURL;
            public string songTitleTxt = "./SongTitle.txt";
            //This is an object used for Twitch Authentication
        }

        public class Currency
        {
            public string CurrencyName;
            public string CurrencySymbol;
            public List<KeyValuePair<string, int>> users = new List<KeyValuePair<string, int>>();
        }



        public class songreq
        {
            public string requester;
            public string ytlink;
            public string name;
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

            //Double Duty, lets give currency at the same time
            foreach (var user in Viewers.chatters.admins.ToArray())
            {
                GiveCurrency(user.ToString(), 10);
            }
            foreach (var user in Viewers.chatters.global_mods.ToArray())
            {
                GiveCurrency(user.ToString(), 10);
            }
            foreach (var user in Viewers.chatters.moderators.ToArray())
            {
                GiveCurrency(user.ToString(), 10);
            }
            foreach (var user in Viewers.chatters.vips.ToArray())
            {
                GiveCurrency(user.ToString(), 10);
            }
            foreach (var user in Viewers.chatters.viewers.ToArray())
            {
                GiveCurrency(user.ToString(), 10);
            }
            SaveCurrency();
        }

        private void CmdReAuthenticate_Click(object sender, EventArgs e)
        {
            File.Move("./creds.json", "creds.json.old");
            frmCredentials credForm = new frmCredentials();
            if (credForm.ShowDialog(this) == DialogResult.OK)
            {
                //MessageBox.Show("Restart the bot for the changes to take effect.");
                var tempvars = JsonConvert.DeserializeObject<creds>(File.ReadAllText("creds.json"));
                ChannelToMod = tempvars.channeltomod;
                browser.Load("https://www.twitch.tv/popout/" + ChannelToMod + "/chat?popout=");
                UpdateViewerList.Interval = 1;
            }
            else
            {
                File.Move("creds.json.old", "./creds.json");
                DialogResult dialogResult = MessageBox.Show("Your credentials were not changed.", "", MessageBoxButtons.OK);
            }

            if (File.Exists("creds.json"))
            {
                File.Delete("creds.json.old");
            }
        }

        private void ResetConnection_Tick(object sender, EventArgs e)
        {
            //This works around an issue with Twitch where the IRC Client gets randomly disconnected.,

            client.Disconnect();
            client.Connect();
        }

        private void BtnSaveAlert_Click(object sender, EventArgs e)
        {
            cred.alertsURL = tbAlertURL.Text;
            SaveOptions();
        }

        public void SaveOptions()
        {
            File.WriteAllText("creds.json", JsonConvert.SerializeObject(cred, Formatting.Indented));
        }

        private void btnSongRequestTitle_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog_SongRequest.ShowDialog();
            if(result == DialogResult.OK)
            {
                cred.songTitleTxt = saveFileDialog_SongRequest.FileName;
                SaveOptions();
            }
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            if(OutputDevice.PlaybackState == PlaybackState.Paused)
            {
                //client.SendMessage(cred.channeltomod, "Resumed Music");
                this.Text = "KruBot - Playing";
                btnPause.Text = "⏸️";
                OutputDevice.Play();
            } else
            {
                //client.SendMessage(cred.channeltomod, "Paused Music");
                OutputDevice.Pause();
                btnPause.Text = "▶️";
                this.Text = "KruBot - Paused";
            }
        }
    }
}