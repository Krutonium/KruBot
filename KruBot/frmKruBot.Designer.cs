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
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.SidePanel = new System.Windows.Forms.TableLayoutPanel();
            this.tbMusicVolume = new System.Windows.Forms.TrackBar();
            this.tblInfo = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRequester = new System.Windows.Forms.Label();
            this.lblPlayerTime = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.SongStarter = new System.Windows.Forms.Timer(this.components);
            this.TabControl.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.BrowserWindow.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).BeginInit();
            this.tblInfo.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabChat);
            this.TabControl.Controls.Add(this.tabSettings);
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
            this.BrowserWindow.Controls.Add(this.tbMsg, 0, 1);
            this.BrowserWindow.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.BrowserWindow.Controls.Add(this.SidePanel, 1, 0);
            this.BrowserWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserWindow.Location = new System.Drawing.Point(3, 3);
            this.BrowserWindow.Name = "BrowserWindow";
            this.BrowserWindow.RowCount = 2;
            this.BrowserWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.06009F));
            this.BrowserWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.939914F));
            this.BrowserWindow.Size = new System.Drawing.Size(803, 466);
            this.BrowserWindow.TabIndex = 1;
            // 
            // tbMsg
            // 
            this.tbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMsg.Location = new System.Drawing.Point(5, 439);
            this.tbMsg.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(597, 20);
            this.tbMsg.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.36842F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.63158F));
            this.tableLayoutPanel2.Controls.Add(this.btnSendMessage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSkip, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(610, 432);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(190, 31);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(3, 3);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSendMessage.TabIndex = 3;
            this.btnSendMessage.Text = "Send";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Location = new System.Drawing.Point(92, 3);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 4;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
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
            this.SidePanel.Size = new System.Drawing.Size(190, 423);
            this.SidePanel.TabIndex = 5;
            // 
            // tbMusicVolume
            // 
            this.tbMusicVolume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMusicVolume.Location = new System.Drawing.Point(3, 3);
            this.tbMusicVolume.Maximum = 100;
            this.tbMusicVolume.Name = "tbMusicVolume";
            this.tbMusicVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbMusicVolume.Size = new System.Drawing.Size(47, 417);
            this.tbMusicVolume.TabIndex = 1;
            this.tbMusicVolume.Value = 70;
            this.tbMusicVolume.Scroll += new System.EventHandler(this.tbMusicVolume_Scroll_1);
            // 
            // tblInfo
            // 
            this.tblInfo.ColumnCount = 1;
            this.tblInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.Controls.Add(this.lblTitle, 0, 3);
            this.tblInfo.Controls.Add(this.lblRequester, 0, 2);
            this.tblInfo.Controls.Add(this.lblPlayerTime, 0, 1);
            this.tblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblInfo.Location = new System.Drawing.Point(56, 3);
            this.tblInfo.Name = "tblInfo";
            this.tblInfo.RowCount = 4;
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tblInfo.Size = new System.Drawing.Size(131, 417);
            this.tblInfo.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 400);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Song Title";
            // 
            // lblRequester
            // 
            this.lblRequester.AutoSize = true;
            this.lblRequester.Location = new System.Drawing.Point(3, 383);
            this.lblRequester.Name = "lblRequester";
            this.lblRequester.Size = new System.Drawing.Size(56, 13);
            this.lblRequester.TabIndex = 3;
            this.lblRequester.Text = "Requester";
            // 
            // lblPlayerTime
            // 
            this.lblPlayerTime.AutoSize = true;
            this.lblPlayerTime.Location = new System.Drawing.Point(3, 360);
            this.lblPlayerTime.Name = "lblPlayerTime";
            this.lblPlayerTime.Size = new System.Drawing.Size(70, 13);
            this.lblPlayerTime.TabIndex = 2;
            this.lblPlayerTime.Text = "Current Time:";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tableLayoutPanel3);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(809, 472);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.16181F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.83819F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(809, 472);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // SongStarter
            // 
            this.SongStarter.Enabled = true;
            this.SongStarter.Interval = 200;
            this.SongStarter.Tick += new System.EventHandler(this.SongStarter_Tick);
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
            this.BrowserWindow.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMusicVolume)).EndInit();
            this.tblInfo.ResumeLayout(false);
            this.tblInfo.PerformLayout();
            this.tabSettings.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.TableLayoutPanel SidePanel;
        private System.Windows.Forms.TrackBar tbMusicVolume;
        private System.Windows.Forms.TableLayoutPanel tblInfo;
        private System.Windows.Forms.Label lblPlayerTime;
        private System.Windows.Forms.Label lblRequester;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

