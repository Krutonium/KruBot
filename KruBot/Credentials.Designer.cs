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
            this.cmdGetOauth = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbOauth
            // 
            this.tbOauth.Location = new System.Drawing.Point(124, 12);
            this.tbOauth.Name = "tbOauth";
            this.tbOauth.Size = new System.Drawing.Size(298, 20);
            this.tbOauth.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Twitch OAuth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Twitch Bot Username";
            // 
            // tbAccountName
            // 
            this.tbAccountName.Location = new System.Drawing.Point(124, 46);
            this.tbAccountName.Name = "tbAccountName";
            this.tbAccountName.Size = new System.Drawing.Size(298, 20);
            this.tbAccountName.TabIndex = 3;
            // 
            // cmdGetOauth
            // 
            this.cmdGetOauth.Location = new System.Drawing.Point(428, 10);
            this.cmdGetOauth.Name = "cmdGetOauth";
            this.cmdGetOauth.Size = new System.Drawing.Size(75, 23);
            this.cmdGetOauth.TabIndex = 4;
            this.cmdGetOauth.Text = "Get";
            this.cmdGetOauth.UseVisualStyleBackColor = true;
            this.cmdGetOauth.Click += new System.EventHandler(this.CmdGetOauth_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(428, 44);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 5;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.CmdSave_Click);
            // 
            // frmCredentials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 85);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdGetOauth);
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
        private System.Windows.Forms.Button cmdGetOauth;
        private System.Windows.Forms.Button cmdSave;
    }
}