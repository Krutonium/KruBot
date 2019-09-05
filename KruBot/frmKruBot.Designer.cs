namespace KruBot
{
    partial class frmKruBot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.BrowserWindow = new System.Windows.Forms.TableLayoutPanel();
            this.SidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tbMusicVolume = new System.Windows.Forms.TrackBar();
            this.tblInfo = new System.Windows.Forms.TableLayoutPanel();
            this.btnSkip = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPlayerTime = new System.Windows.Forms.Label();
            this.lblRequester = new System.Windows.Forms.Label();
            this.lbViewers = new System.Windows.Forms.ListBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.cmdReAuthenticate = new System.Windows.Forms.Button();
            this.gbStreamSettings = new System.Windows.Forms.GroupBox();
            this.SongStarter = new System.Windows.Forms.Timer(this.components);
            this.UpdateViewerList = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ResetConnection = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbAlerts = new System.Windows.Forms.GroupBox();
            this.tbAlertURL = new System.Windows.Forms.TextBox();
            this.btnSaveAlert = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.BrowserWindow.SuspendLayout();
            this.SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).BeginInit();
            this.tblInfo.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbStreamSettings.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabChat);
            this.TabControl.Controls.Add(this.tabSettings);
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(817, 498);
            this.TabControl.TabIndex = 0;
            // 
            // tabChat
            // 
            this.tabChat.Controls.Add(this.BrowserWindow);
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(809, 472);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            this.tabChat.UseVisualStyleBackColor = true;
            // 
            // BrowserWindow
            // 
            this.BrowserWindow.ColumnCount = 2;
            this.BrowserWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.69975F));
            this.BrowserWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.30025F));
            this.BrowserWindow.Controls.Add(this.SidePanel, 1, 0);
            this.BrowserWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserWindow.Location = new System.Drawing.Point(3, 3);
            this.BrowserWindow.Name = "BrowserWindow";
            this.BrowserWindow.RowCount = 1;
            this.BrowserWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.06009F));
            this.BrowserWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.939914F));
            this.BrowserWindow.Size = new System.Drawing.Size(803, 466);
            this.BrowserWindow.TabIndex = 1;
            // 
            // SidePanel
            // 
            this.SidePanel.ColumnCount = 2;
            this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.42105F));
            this.SidePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.57895F));
            this.SidePanel.Controls.Add(this.tbMusicVolume, 0, 0);
            this.SidePanel.Controls.Add(this.tblInfo, 1, 0);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SidePanel.Location = new System.Drawing.Point(610, 3);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.RowCount = 1;
            this.SidePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.64539F));
            this.SidePanel.Size = new System.Drawing.Size(190, 460);
            this.SidePanel.TabIndex = 5;
            // 
            // tbMusicVolume
            // 
            this.tbMusicVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMusicVolume.Location = new System.Drawing.Point(3, 3);
            this.tbMusicVolume.Maximum = 100;
            this.tbMusicVolume.Name = "tbMusicVolume";
            this.tbMusicVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicVolume.Size = new System.Drawing.Size(47, 454);
            this.tbMusicVolume.TabIndex = 1;
            this.tbMusicVolume.Value = 70;
            this.tbMusicVolume.Scroll += new System.EventHandler(this.tbMusicVolume_Scroll_1);
            // 
            // tblInfo
            // 
            this.tblInfo.ColumnCount = 1;
            this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.Controls.Add(this.btnSkip, 0, 4);
            this.tblInfo.Controls.Add(this.lblTitle, 0, 3);
            this.tblInfo.Controls.Add(this.lblPlayerTime, 0, 2);
            this.tblInfo.Controls.Add(this.lblRequester, 0, 1);
            this.tblInfo.Controls.Add(this.lbViewers, 0, 0);
            this.tblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInfo.Location = new System.Drawing.Point(56, 3);
            this.tblInfo.Name = "tblInfo";
            this.tblInfo.RowCount = 5;
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblInfo.Size = new System.Drawing.Size(131, 454);
            this.tblInfo.TabIndex = 3;
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(3, 428);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 4;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 407);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Song Title";
            // 
            // lblPlayerTime
            // 
            this.lblPlayerTime.AutoSize = true;
            this.lblPlayerTime.Location = new System.Drawing.Point(3, 387);
            this.lblPlayerTime.Name = "lblPlayerTime";
            this.lblPlayerTime.Size = new System.Drawing.Size(70, 13);
            this.lblPlayerTime.TabIndex = 2;
            this.lblPlayerTime.Text = "Current Time:";
            // 
            // lblRequester
            // 
            this.lblRequester.AutoSize = true;
            this.lblRequester.Location = new System.Drawing.Point(3, 368);
            this.lblRequester.Name = "lblRequester";
            this.lblRequester.Size = new System.Drawing.Size(56, 13);
            this.lblRequester.TabIndex = 3;
            this.lblRequester.Text = "Requester";
            // 
            // lbViewers
            // 
            this.lbViewers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbViewers.FormattingEnabled = true;
            this.lbViewers.Location = new System.Drawing.Point(3, 3);
            this.lbViewers.Name = "lbViewers";
            this.lbViewers.Size = new System.Drawing.Size(125, 362);
            this.lbViewers.TabIndex = 5;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.splitContainer1);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(809, 472);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbSettings);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbStreamSettings);
            this.splitContainer1.Size = new System.Drawing.Size(809, 472);
            this.splitContainer1.SplitterDistance = 269;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.cmdReAuthenticate);
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(0, 0);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(269, 472);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Account Settings";
            // 
            // cmdReAuthenticate
            // 
            this.cmdReAuthenticate.Location = new System.Drawing.Point(8, 19);
            this.cmdReAuthenticate.Name = "cmdReAuthenticate";
            this.cmdReAuthenticate.Size = new System.Drawing.Size(255, 23);
            this.cmdReAuthenticate.TabIndex = 0;
            this.cmdReAuthenticate.Text = "Re-Authenticate";
            this.cmdReAuthenticate.UseVisualStyleBackColor = true;
            this.cmdReAuthenticate.Click += new System.EventHandler(this.CmdReAuthenticate_Click);
            // 
            // gbStreamSettings
            // 
            this.gbStreamSettings.Controls.Add(this.btnSaveAlert);
            this.gbStreamSettings.Controls.Add(this.tbAlertURL);
            this.gbStreamSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbStreamSettings.Location = new System.Drawing.Point(0, 0);
            this.gbStreamSettings.Name = "gbStreamSettings";
            this.gbStreamSettings.Size = new System.Drawing.Size(536, 472);
            this.gbStreamSettings.TabIndex = 0;
            this.gbStreamSettings.TabStop = false;
            this.gbStreamSettings.Text = "Stream Settings";
            // 
            // SongStarter
            // 
            this.SongStarter.Enabled = true;
            this.SongStarter.Interval = 200;
            this.SongStarter.Tick += new System.EventHandler(this.SongStarter_Tick);
            // 
            // UpdateViewerList
            // 
            this.UpdateViewerList.Tick += new System.EventHandler(this.UpdateViewerList_Tick);
            // 
            // ResetConnection
            // 
            this.ResetConnection.Interval = 60000;
            this.ResetConnection.Tick += new System.EventHandler(this.ResetConnection_Tick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbAlerts);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(809, 472);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Alerts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbAlerts
            // 
            this.gbAlerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlerts.Location = new System.Drawing.Point(0, 0);
            this.gbAlerts.Name = "gbAlerts";
            this.gbAlerts.Size = new System.Drawing.Size(809, 472);
            this.gbAlerts.TabIndex = 0;
            this.gbAlerts.TabStop = false;
            this.gbAlerts.Text = "Alerts";
            // 
            // tbAlertURL
            // 
            this.tbAlertURL.Location = new System.Drawing.Point(128, 19);
            this.tbAlertURL.Name = "tbAlertURL";
            this.tbAlertURL.Size = new System.Drawing.Size(400, 20);
            this.tbAlertURL.TabIndex = 0;
            // 
            // btnSaveAlert
            // 
            this.btnSaveAlert.Location = new System.Drawing.Point(6, 19);
            this.btnSaveAlert.Name = "btnSaveAlert";
            this.btnSaveAlert.Size = new System.Drawing.Size(116, 23);
            this.btnSaveAlert.TabIndex = 1;
            this.btnSaveAlert.Text = "Save Alert URL";
            this.btnSaveAlert.UseVisualStyleBackColor = true;
            this.btnSaveAlert.Click += new System.EventHandler(this.BtnSaveAlert_Click);
            // 
            // frmKruBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 498);
            this.Controls.Add(this.TabControl);
            this.Name = "frmKruBot";
            this.Text = "KruBot";
            this.Load += new System.EventHandler(this.frmKruBot_Load);
            this.TabControl.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.BrowserWindow.ResumeLayout(false);
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).EndInit();
            this.tblInfo.ResumeLayout(false);
            this.tblInfo.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbStreamSettings.ResumeLayout(false);
            this.gbStreamSettings.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void TbMsg_TextChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.Timer SongStarter;
        private System.Windows.Forms.TableLayoutPanel BrowserWindow;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TableLayoutPanel SidePanel;
        private System.Windows.Forms.TrackBar tbMusicVolume;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Timer UpdateViewerList;
        private System.Windows.Forms.TableLayoutPanel tblInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPlayerTime;
        private System.Windows.Forms.Label lblRequester;
        private System.Windows.Forms.ListBox lbViewers;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Button cmdReAuthenticate;
        private System.Windows.Forms.GroupBox gbStreamSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Timer ResetConnection;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbAlerts;
        private System.Windows.Forms.Button btnSaveAlert;
        private System.Windows.Forms.TextBox tbAlertURL;
    }
}

