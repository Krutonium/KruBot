namespace KruBot
{
    partial class frmCredentials
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
            this.tbOauth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAccountName = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.gbAuth = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbChannelName = new System.Windows.Forms.TextBox();
            this.btnClearCookies = new System.Windows.Forms.Button();
            this.tbClientID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbOauth
            // 
            this.tbOauth.Location = new System.Drawing.Point(153, 11);
            this.tbOauth.Name = "tbOauth";
            this.tbOauth.Size = new System.Drawing.Size(484, 20);
            this.tbOauth.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twitch OAuth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Twitch Bot Username";
            // 
            // tbAccountName
            // 
            this.tbAccountName.Location = new System.Drawing.Point(153, 65);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(484, 20);
            this.tbAccountName.TabIndex = 2;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(562, 120);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // gbAuth
            // 
            this.gbAuth.Location = new System.Drawing.Point(12, 147);
            this.gbAuth.Name = "gbAuth";
            this.gbAuth.Size = new System.Drawing.Size(625, 431);
            this.gbAuth.TabIndex = 6;
            this.gbAuth.TabStop = false;
            this.gbAuth.Text = "Authenticate Here as your Bot (not implemented yet)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Channel name to Moderate";
            // 
            // tbChannelName
            // 
            this.tbChannelName.Location = new System.Drawing.Point(153, 92);
            this.tbChannelName.Name = "tbChannelName";
            this.tbChannelName.Size = new System.Drawing.Size(484, 20);
            this.tbChannelName.TabIndex = 3;
            // 
            // btnClearCookies
            // 
            this.btnClearCookies.Location = new System.Drawing.Point(457, 120);
            this.btnClearCookies.Name = "btnClearCookies";
            this.btnClearCookies.Size = new System.Drawing.Size(99, 23);
            this.btnClearCookies.TabIndex = 4;
            this.btnClearCookies.Text = "Clear Cookies";
            this.btnClearCookies.UseVisualStyleBackColor = true;
            this.btnClearCookies.Click += new System.EventHandler(this.BtnClearCookies_Click);
            // 
            // tbClientID
            // 
            this.tbClientID.Location = new System.Drawing.Point(153, 38);
            this.tbClientID.Name = "tbClientID";
            this.tbClientID.Size = new System.Drawing.Size(484, 20);
            this.tbClientID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Twitch Client ID";
            // 
            // frmCredentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 592);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbClientID);
            this.Controls.Add(this.btnClearCookies);
            this.Controls.Add(this.tbChannelName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbAuth);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.tbAccountName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOauth);
            this.Name = "frmCredentials";
            this.Text = "Please Provide Credentials";
            this.Load += new System.EventHandler(this.FrmCredentials_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOauth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAccountName;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.GroupBox gbAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbChannelName;
        private System.Windows.Forms.Button btnClearCookies;
        private System.Windows.Forms.TextBox tbClientID;
        private System.Windows.Forms.Label label4;
    }
}