﻿using System;
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
        public frmKruBot()
        {
            InitializeComponent();
        }

        private void frmKruBot_Load(object sender, EventArgs e)
        {

            var cred = JsonConvert.DeserializeObject<creds>(File.ReadAllText("creds.json"));  
            //Loads our Twitch Credentials from the Json file.
            var credentials = new ConnectionCredentials(cred.username, cred.oauth);
            client.Initialize(credentials, "pfckrutonium"); //Channel were connecting to.
            client.OnConnected += Client_OnConnected;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.Connect();
            CefSettings settings = new CefSettings();
            settings.CachePath = "./browsercache";
            var browser = new ChromiumWebBrowser("https://www.twitch.tv/popout/pfckrutonium/chat?popout=");
            browser.Dock = DockStyle.Fill;
            BrowserWindow.Controls.Add(browser);

        }

        private void RtbChat_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText); //Clicked Links need to do somthing. ANYTHING.
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
                        client.SendMessage("PFCKrutonium", "That's not a valid video");
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
            client.SendMessage("pfckrutonium", "Successfully Joined");
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
                        client.SendMessage("PFCKrutonium", "Playing " + video.Title);
                    }
                    catch { client.SendMessage("PFCKrutonium", "Song failed to play: " + songinfo.ytlink); }
                }
            }
            processing = false;
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            client.SendMessage(client.GetJoinedChannel("pfckrutonium"), tbMsg.Text);
            if (tbMsg.Text.ToLower().StartsWith("!songrequest")) //I sent a song request through my bot
                try //Since it doesn't see this by default, we handle it here instead.
                {   //It doesn't care about duplicates in this code.
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
            tbMsg.Text = "";
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            OutputDevice.Stop();
        }

        public class creds
        {
            public string oauth;
            public string username;
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
    }
}