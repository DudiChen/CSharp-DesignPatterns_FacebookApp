namespace FacebookApp.UI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNewsFeed = new System.Windows.Forms.TabPage();
            this.tabPagePosts = new System.Windows.Forms.TabPage();
            this.tabPageFriends = new System.Windows.Forms.TabPage();
            this.tabPagePhotos = new System.Windows.Forms.TabPage();
            this.tabPagePostsStatistics = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxCoverPic = new System.Windows.Forms.PictureBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.listBoxFeedPosts = new System.Windows.Forms.ListBox();
            this.flowLayoutPanelFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxFriendPic = new System.Windows.Forms.PictureBox();
            this.labelFriendName = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBoxFriendAbout = new System.Windows.Forms.ListBox();
            this.labelFriendAbout = new System.Windows.Forms.Label();
            this.labelFriendPosts = new System.Windows.Forms.Label();
            this.flowLayoutPanelFeedPosts = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageNewsFeed.SuspendLayout();
            this.tabPageFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendPic)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Image = ((System.Drawing.Image)(resources.GetObject("buttonLogin.Image")));
            this.buttonLogin.Location = new System.Drawing.Point(7, 12);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(63, 53);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLogin.UseMnemonic = false;
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(803, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBoxProfilePic
            // 
            this.pictureBoxProfilePic.Location = new System.Drawing.Point(7, 71);
            this.pictureBoxProfilePic.Name = "pictureBoxProfilePic";
            this.pictureBoxProfilePic.Size = new System.Drawing.Size(152, 137);
            this.pictureBoxProfilePic.TabIndex = 2;
            this.pictureBoxProfilePic.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageNewsFeed);
            this.tabControl1.Controls.Add(this.tabPagePosts);
            this.tabControl1.Controls.Add(this.tabPageFriends);
            this.tabControl1.Controls.Add(this.tabPagePhotos);
            this.tabControl1.Controls.Add(this.tabPagePostsStatistics);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 214);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(873, 389);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageNewsFeed
            // 
            this.tabPageNewsFeed.Controls.Add(this.flowLayoutPanelFeedPosts);
            this.tabPageNewsFeed.Controls.Add(this.listBoxFeedPosts);
            this.tabPageNewsFeed.Location = new System.Drawing.Point(4, 25);
            this.tabPageNewsFeed.Name = "tabPageNewsFeed";
            this.tabPageNewsFeed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewsFeed.Size = new System.Drawing.Size(865, 360);
            this.tabPageNewsFeed.TabIndex = 0;
            this.tabPageNewsFeed.Text = "News Feed";
            this.tabPageNewsFeed.UseVisualStyleBackColor = true;
            // 
            // tabPagePosts
            // 
            this.tabPagePosts.Location = new System.Drawing.Point(4, 25);
            this.tabPagePosts.Name = "tabPagePosts";
            this.tabPagePosts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePosts.Size = new System.Drawing.Size(865, 360);
            this.tabPagePosts.TabIndex = 1;
            this.tabPagePosts.Text = "Posts";
            this.tabPagePosts.UseVisualStyleBackColor = true;
            // 
            // tabPageFriends
            // 
            this.tabPageFriends.Controls.Add(this.labelFriendPosts);
            this.tabPageFriends.Controls.Add(this.labelFriendAbout);
            this.tabPageFriends.Controls.Add(this.listBoxFriendAbout);
            this.tabPageFriends.Controls.Add(this.listBox1);
            this.tabPageFriends.Controls.Add(this.labelFriendName);
            this.tabPageFriends.Controls.Add(this.pictureBoxFriendPic);
            this.tabPageFriends.Controls.Add(this.flowLayoutPanelFriends);
            this.tabPageFriends.Location = new System.Drawing.Point(4, 25);
            this.tabPageFriends.Name = "tabPageFriends";
            this.tabPageFriends.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFriends.Size = new System.Drawing.Size(865, 360);
            this.tabPageFriends.TabIndex = 2;
            this.tabPageFriends.Text = "Friends";
            this.tabPageFriends.UseVisualStyleBackColor = true;
            // 
            // tabPagePhotos
            // 
            this.tabPagePhotos.Location = new System.Drawing.Point(4, 25);
            this.tabPagePhotos.Name = "tabPagePhotos";
            this.tabPagePhotos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePhotos.Size = new System.Drawing.Size(865, 360);
            this.tabPagePhotos.TabIndex = 3;
            this.tabPagePhotos.Text = "Photos";
            this.tabPagePhotos.UseVisualStyleBackColor = true;
            // 
            // tabPagePostsStatistics
            // 
            this.tabPagePostsStatistics.Location = new System.Drawing.Point(4, 25);
            this.tabPagePostsStatistics.Name = "tabPagePostsStatistics";
            this.tabPagePostsStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePostsStatistics.Size = new System.Drawing.Size(865, 360);
            this.tabPagePostsStatistics.TabIndex = 4;
            this.tabPagePostsStatistics.Text = "PostsStatistics";
            this.tabPagePostsStatistics.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(865, 360);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBoxCoverPic
            // 
            this.pictureBoxCoverPic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxCoverPic.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBoxCoverPic.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxCoverPic.Name = "pictureBoxCoverPic";
            this.pictureBoxCoverPic.Size = new System.Drawing.Size(873, 167);
            this.pictureBoxCoverPic.TabIndex = 4;
            this.pictureBoxCoverPic.TabStop = false;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(165, 182);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(140, 26);
            this.labelUserName.TabIndex = 5;
            this.labelUserName.Text = "Lorem Ipsum";
            this.labelUserName.Visible = false;
            this.labelUserName.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxFeedPosts
            // 
            this.listBoxFeedPosts.FormattingEnabled = true;
            this.listBoxFeedPosts.ItemHeight = 16;
            this.listBoxFeedPosts.Location = new System.Drawing.Point(740, 3);
            this.listBoxFeedPosts.Name = "listBoxFeedPosts";
            this.listBoxFeedPosts.Size = new System.Drawing.Size(119, 260);
            this.listBoxFeedPosts.TabIndex = 0;
            // 
            // flowLayoutPanelFriends
            // 
            this.flowLayoutPanelFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelFriends.Location = new System.Drawing.Point(7, 7);
            this.flowLayoutPanelFriends.Name = "flowLayoutPanelFriends";
            this.flowLayoutPanelFriends.Size = new System.Drawing.Size(250, 347);
            this.flowLayoutPanelFriends.TabIndex = 0;
            // 
            // pictureBoxFriendPic
            // 
            this.pictureBoxFriendPic.Location = new System.Drawing.Point(263, 6);
            this.pictureBoxFriendPic.Name = "pictureBoxFriendPic";
            this.pictureBoxFriendPic.Size = new System.Drawing.Size(135, 101);
            this.pictureBoxFriendPic.TabIndex = 1;
            this.pictureBoxFriendPic.TabStop = false;
            // 
            // labelFriendName
            // 
            this.labelFriendName.AutoSize = true;
            this.labelFriendName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendName.Location = new System.Drawing.Point(404, 7);
            this.labelFriendName.Name = "labelFriendName";
            this.labelFriendName.Size = new System.Drawing.Size(112, 20);
            this.labelFriendName.TabIndex = 2;
            this.labelFriendName.Text = "Loretta Ipsum";
            this.labelFriendName.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(263, 142);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(596, 212);
            this.listBox1.TabIndex = 4;
            this.listBox1.Visible = false;
            // 
            // listBoxFriendAbout
            // 
            this.listBoxFriendAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFriendAbout.FormattingEnabled = true;
            this.listBoxFriendAbout.ItemHeight = 16;
            this.listBoxFriendAbout.Location = new System.Drawing.Point(404, 55);
            this.listBoxFriendAbout.Name = "listBoxFriendAbout";
            this.listBoxFriendAbout.Size = new System.Drawing.Size(455, 52);
            this.listBoxFriendAbout.TabIndex = 6;
            this.listBoxFriendAbout.Visible = false;
            // 
            // labelFriendAbout
            // 
            this.labelFriendAbout.AutoSize = true;
            this.labelFriendAbout.Location = new System.Drawing.Point(404, 35);
            this.labelFriendAbout.Name = "labelFriendAbout";
            this.labelFriendAbout.Size = new System.Drawing.Size(49, 17);
            this.labelFriendAbout.TabIndex = 7;
            this.labelFriendAbout.Text = "About:";
            // 
            // labelFriendPosts
            // 
            this.labelFriendPosts.AutoSize = true;
            this.labelFriendPosts.Location = new System.Drawing.Point(263, 122);
            this.labelFriendPosts.Name = "labelFriendPosts";
            this.labelFriendPosts.Size = new System.Drawing.Size(47, 17);
            this.labelFriendPosts.TabIndex = 8;
            this.labelFriendPosts.Text = "Posts:";
            // 
            // flowLayoutPanelFeedPosts
            // 
            this.flowLayoutPanelFeedPosts.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanelFeedPosts.Name = "flowLayoutPanelFeedPosts";
            this.flowLayoutPanelFeedPosts.Size = new System.Drawing.Size(730, 353);
            this.flowLayoutPanelFeedPosts.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 601);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBoxProfilePic);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBoxCoverPic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Maor & Dudi\'s Facebook Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageNewsFeed.ResumeLayout(false);
            this.tabPageFriends.ResumeLayout(false);
            this.tabPageFriends.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBoxProfilePic;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageNewsFeed;
        private System.Windows.Forms.TabPage tabPagePosts;
        private System.Windows.Forms.TabPage tabPageFriends;
        private System.Windows.Forms.TabPage tabPagePhotos;
        private System.Windows.Forms.TabPage tabPagePostsStatistics;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBoxCoverPic;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.ListBox listBoxFeedPosts;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriends;
        private System.Windows.Forms.Label labelFriendName;
        private System.Windows.Forms.PictureBox pictureBoxFriendPic;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBoxFriendAbout;
        private System.Windows.Forms.Label labelFriendPosts;
        private System.Windows.Forms.Label labelFriendAbout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFeedPosts;
    }
}

