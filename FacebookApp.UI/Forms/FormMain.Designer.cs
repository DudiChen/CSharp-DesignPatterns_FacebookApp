namespace FacebookApp.UI
{
    public partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.pictureBoxProfilePic = new System.Windows.Forms.PictureBox();
            this.pictureBoxCoverPic = new System.Windows.Forms.PictureBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.tabPagePostsStatistics = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart_Likes_Time = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grp_Stats = new System.Windows.Forms.GroupBox();
            this.txt_PhotosInPosts = new System.Windows.Forms.TextBox();
            this.txt_TotalLikes = new System.Windows.Forms.TextBox();
            this.txt_LikesPerPost = new System.Windows.Forms.TextBox();
            this.txt_PostsPerDay = new System.Windows.Forms.TextBox();
            this.txt_LetterPerPost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPagePhotos = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelPhotosAlbums = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxPhotosPic = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelPhotosAlbumPics = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageFriends = new System.Windows.Forms.TabPage();
            this.textBoxHometown = new System.Windows.Forms.TextBox();
            this.textBoxFriendsBirthday = new System.Windows.Forms.TextBox();
            this.labelFriendsHometown = new System.Windows.Forms.Label();
            this.labelFriendsBirthday = new System.Windows.Forms.Label();
            this.flowLayoutPanelFriendsPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFriendPosts = new System.Windows.Forms.Label();
            this.labelFriendAbout = new System.Windows.Forms.Label();
            this.listBoxFriendAbout = new System.Windows.Forms.ListBox();
            this.labelFriendName = new System.Windows.Forms.Label();
            this.pictureBoxFriendPic = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelFriends = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPagePosts = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPostsPublish = new System.Windows.Forms.Button();
            this.richTextBoxPostsPublish = new System.Windows.Forms.RichTextBox();
            this.labelPostsPublish = new System.Windows.Forms.Label();
            this.flowLayoutPanelPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageNewsFeed = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelFeedPosts = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControlFormMain = new System.Windows.Forms.TabControl();
            this.tabPageBirthdayWisher = new System.Windows.Forms.TabPage();
            this.btn_PostBirthdayWish = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBox_BirthdayWish = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.flowLayoutPanelFreindsW8Birthday = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPic)).BeginInit();
            this.tabPagePostsStatistics.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Likes_Time)).BeginInit();
            this.grp_Stats.SuspendLayout();
            this.tabPagePhotos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotosPic)).BeginInit();
            this.tabPageFriends.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendPic)).BeginInit();
            this.tabPagePosts.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPageNewsFeed.SuspendLayout();
            this.tabControlFormMain.SuspendLayout();
            this.tabPageBirthdayWisher.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLogin.BackgroundImage")));
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLogin.Location = new System.Drawing.Point(504, 12);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(149, 116);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonLogin.UseMnemonic = false;
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // pictureBoxProfilePic
            // 
            this.pictureBoxProfilePic.Enabled = false;
            this.pictureBoxProfilePic.Location = new System.Drawing.Point(7, 71);
            this.pictureBoxProfilePic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxProfilePic.Name = "pictureBoxProfilePic";
            this.pictureBoxProfilePic.Size = new System.Drawing.Size(152, 137);
            this.pictureBoxProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfilePic.TabIndex = 2;
            this.pictureBoxProfilePic.TabStop = false;
            this.pictureBoxProfilePic.Visible = false;
            // 
            // pictureBoxCoverPic
            // 
            this.pictureBoxCoverPic.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCoverPic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxCoverPic.BackgroundImage")));
            this.pictureBoxCoverPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCoverPic.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxCoverPic.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCoverPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxCoverPic.Name = "pictureBoxCoverPic";
            this.pictureBoxCoverPic.Size = new System.Drawing.Size(1157, 167);
            this.pictureBoxCoverPic.TabIndex = 4;
            this.pictureBoxCoverPic.TabStop = false;
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Enabled = false;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.Black;
            this.labelUserName.Location = new System.Drawing.Point(165, 182);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(151, 26);
            this.labelUserName.TabIndex = 5;
            this.labelUserName.Text = "Lorem Ipsum";
            this.labelUserName.Visible = false;
            this.labelUserName.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLogout.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLogout.BackgroundImage")));
            this.buttonLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLogout.Enabled = false;
            this.buttonLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonLogout.Location = new System.Drawing.Point(1069, 12);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(77, 65);
            this.buttonLogout.TabIndex = 6;
            this.buttonLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonLogout.UseMnemonic = false;
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Visible = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.checkBoxRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRememberMe.Location = new System.Drawing.Point(504, 134);
            this.checkBoxRememberMe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(149, 21);
            this.checkBoxRememberMe.TabIndex = 7;
            this.checkBoxRememberMe.Text = "Remember Me";
            this.checkBoxRememberMe.UseVisualStyleBackColor = false;
            this.checkBoxRememberMe.CheckedChanged += new System.EventHandler(this.checkBoxRememberMe_CheckedChanged);
            // 
            // tabPagePostsStatistics
            // 
            this.tabPagePostsStatistics.Controls.Add(this.tableLayoutPanel1);
            this.tabPagePostsStatistics.Location = new System.Drawing.Point(4, 25);
            this.tabPagePostsStatistics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePostsStatistics.Name = "tabPagePostsStatistics";
            this.tabPagePostsStatistics.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePostsStatistics.Size = new System.Drawing.Size(1131, 378);
            this.tabPagePostsStatistics.TabIndex = 4;
            this.tabPagePostsStatistics.Text = "PostsStatistics";
            this.tabPagePostsStatistics.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart_Likes_Time, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grp_Stats, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1124, 378);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chart_Likes_Time
            // 
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.Name = "ChartArea1";
            this.chart_Likes_Time.ChartAreas.Add(chartArea1);
            this.chart_Likes_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart_Likes_Time.Legends.Add(legend1);
            this.chart_Likes_Time.Location = new System.Drawing.Point(3, 2);
            this.chart_Likes_Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart_Likes_Time.Name = "chart_Likes_Time";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Likes";
            series1.YValuesPerPoint = 2;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Posts";
            this.chart_Likes_Time.Series.Add(series1);
            this.chart_Likes_Time.Series.Add(series2);
            this.chart_Likes_Time.Size = new System.Drawing.Size(556, 374);
            this.chart_Likes_Time.TabIndex = 0;
            this.chart_Likes_Time.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Posts Compare Time of Day";
            this.chart_Likes_Time.Titles.Add(title1);
            // 
            // grp_Stats
            // 
            this.grp_Stats.Controls.Add(this.txt_PhotosInPosts);
            this.grp_Stats.Controls.Add(this.txt_TotalLikes);
            this.grp_Stats.Controls.Add(this.txt_LikesPerPost);
            this.grp_Stats.Controls.Add(this.txt_PostsPerDay);
            this.grp_Stats.Controls.Add(this.txt_LetterPerPost);
            this.grp_Stats.Controls.Add(this.label5);
            this.grp_Stats.Controls.Add(this.label4);
            this.grp_Stats.Controls.Add(this.label3);
            this.grp_Stats.Controls.Add(this.label2);
            this.grp_Stats.Controls.Add(this.label1);
            this.grp_Stats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_Stats.Location = new System.Drawing.Point(565, 2);
            this.grp_Stats.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_Stats.Name = "grp_Stats";
            this.grp_Stats.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grp_Stats.Size = new System.Drawing.Size(556, 374);
            this.grp_Stats.TabIndex = 1;
            this.grp_Stats.TabStop = false;
            this.grp_Stats.Text = "Statistics";
            // 
            // txt_PhotosInPosts
            // 
            this.txt_PhotosInPosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PhotosInPosts.Location = new System.Drawing.Point(373, 290);
            this.txt_PhotosInPosts.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.txt_PhotosInPosts.Name = "txt_PhotosInPosts";
            this.txt_PhotosInPosts.ReadOnly = true;
            this.txt_PhotosInPosts.Size = new System.Drawing.Size(162, 22);
            this.txt_PhotosInPosts.TabIndex = 9;
            // 
            // txt_TotalLikes
            // 
            this.txt_TotalLikes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_TotalLikes.Location = new System.Drawing.Point(373, 233);
            this.txt_TotalLikes.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.txt_TotalLikes.Name = "txt_TotalLikes";
            this.txt_TotalLikes.ReadOnly = true;
            this.txt_TotalLikes.Size = new System.Drawing.Size(162, 22);
            this.txt_TotalLikes.TabIndex = 8;
            // 
            // txt_LikesPerPost
            // 
            this.txt_LikesPerPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_LikesPerPost.Location = new System.Drawing.Point(373, 166);
            this.txt_LikesPerPost.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.txt_LikesPerPost.Name = "txt_LikesPerPost";
            this.txt_LikesPerPost.ReadOnly = true;
            this.txt_LikesPerPost.Size = new System.Drawing.Size(162, 22);
            this.txt_LikesPerPost.TabIndex = 7;
            // 
            // txt_PostsPerDay
            // 
            this.txt_PostsPerDay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PostsPerDay.Location = new System.Drawing.Point(373, 108);
            this.txt_PostsPerDay.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.txt_PostsPerDay.Name = "txt_PostsPerDay";
            this.txt_PostsPerDay.ReadOnly = true;
            this.txt_PostsPerDay.Size = new System.Drawing.Size(154, 22);
            this.txt_PostsPerDay.TabIndex = 6;
            // 
            // txt_LetterPerPost
            // 
            this.txt_LetterPerPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_LetterPerPost.Location = new System.Drawing.Point(373, 50);
            this.txt_LetterPerPost.Margin = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.txt_LetterPerPost.Name = "txt_LetterPerPost";
            this.txt_LetterPerPost.ReadOnly = true;
            this.txt_LetterPerPost.Size = new System.Drawing.Size(162, 22);
            this.txt_LetterPerPost.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label5.Location = new System.Drawing.Point(21, 274);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.label5.Size = new System.Drawing.Size(328, 64);
            this.label5.TabIndex = 4;
            this.label5.Text = "Presentage of Post with Photos";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(21, 213);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.label4.Size = new System.Drawing.Size(328, 64);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Number of Likes";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(21, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.label3.Size = new System.Drawing.Size(328, 64);
            this.label3.TabIndex = 2;
            this.label3.Text = "Avg. Number of Likes per Post";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.label2.Size = new System.Drawing.Size(328, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "Avg. Posts per Day";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.label1.Size = new System.Drawing.Size(328, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Avg. Number of Letters per Post";
            // 
            // tabPagePhotos
            // 
            this.tabPagePhotos.Controls.Add(this.flowLayoutPanelPhotosAlbums);
            this.tabPagePhotos.Controls.Add(this.pictureBoxPhotosPic);
            this.tabPagePhotos.Controls.Add(this.flowLayoutPanelPhotosAlbumPics);
            this.tabPagePhotos.Location = new System.Drawing.Point(4, 25);
            this.tabPagePhotos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePhotos.Name = "tabPagePhotos";
            this.tabPagePhotos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePhotos.Size = new System.Drawing.Size(1131, 378);
            this.tabPagePhotos.TabIndex = 3;
            this.tabPagePhotos.Text = "Photos";
            this.tabPagePhotos.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelPhotosAlbums
            // 
            this.flowLayoutPanelPhotosAlbums.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelPhotosAlbums.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanelPhotosAlbums.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelPhotosAlbums.Name = "flowLayoutPanelPhotosAlbums";
            this.flowLayoutPanelPhotosAlbums.Size = new System.Drawing.Size(219, 374);
            this.flowLayoutPanelPhotosAlbums.TabIndex = 3;
            // 
            // pictureBoxPhotosPic
            // 
            this.pictureBoxPhotosPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxPhotosPic.Location = new System.Drawing.Point(653, 4);
            this.pictureBoxPhotosPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxPhotosPic.Name = "pictureBoxPhotosPic";
            this.pictureBoxPhotosPic.Size = new System.Drawing.Size(471, 370);
            this.pictureBoxPhotosPic.TabIndex = 2;
            this.pictureBoxPhotosPic.TabStop = false;
            // 
            // flowLayoutPanelPhotosAlbumPics
            // 
            this.flowLayoutPanelPhotosAlbumPics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelPhotosAlbumPics.Location = new System.Drawing.Point(227, 2);
            this.flowLayoutPanelPhotosAlbumPics.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelPhotosAlbumPics.Name = "flowLayoutPanelPhotosAlbumPics";
            this.flowLayoutPanelPhotosAlbumPics.Size = new System.Drawing.Size(421, 372);
            this.flowLayoutPanelPhotosAlbumPics.TabIndex = 1;
            // 
            // tabPageFriends
            // 
            this.tabPageFriends.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPageFriends.Controls.Add(this.textBoxHometown);
            this.tabPageFriends.Controls.Add(this.textBoxFriendsBirthday);
            this.tabPageFriends.Controls.Add(this.labelFriendsHometown);
            this.tabPageFriends.Controls.Add(this.labelFriendsBirthday);
            this.tabPageFriends.Controls.Add(this.flowLayoutPanelFriendsPosts);
            this.tabPageFriends.Controls.Add(this.labelFriendPosts);
            this.tabPageFriends.Controls.Add(this.labelFriendAbout);
            this.tabPageFriends.Controls.Add(this.listBoxFriendAbout);
            this.tabPageFriends.Controls.Add(this.labelFriendName);
            this.tabPageFriends.Controls.Add(this.pictureBoxFriendPic);
            this.tabPageFriends.Controls.Add(this.flowLayoutPanelFriends);
            this.tabPageFriends.Location = new System.Drawing.Point(4, 25);
            this.tabPageFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFriends.Name = "tabPageFriends";
            this.tabPageFriends.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageFriends.Size = new System.Drawing.Size(1131, 378);
            this.tabPageFriends.TabIndex = 2;
            this.tabPageFriends.Text = "Friends";
            this.tabPageFriends.UseVisualStyleBackColor = true;
            // 
            // textBoxHometown
            // 
            this.textBoxHometown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHometown.Location = new System.Drawing.Point(740, 7);
            this.textBoxHometown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHometown.Name = "textBoxHometown";
            this.textBoxHometown.ReadOnly = true;
            this.textBoxHometown.Size = new System.Drawing.Size(143, 22);
            this.textBoxHometown.TabIndex = 13;
            this.textBoxHometown.Visible = false;
            // 
            // textBoxFriendsBirthday
            // 
            this.textBoxFriendsBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFriendsBirthday.Location = new System.Drawing.Point(983, 7);
            this.textBoxFriendsBirthday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxFriendsBirthday.Name = "textBoxFriendsBirthday";
            this.textBoxFriendsBirthday.ReadOnly = true;
            this.textBoxFriendsBirthday.Size = new System.Drawing.Size(143, 22);
            this.textBoxFriendsBirthday.TabIndex = 11;
            this.textBoxFriendsBirthday.Visible = false;
            // 
            // labelFriendsHometown
            // 
            this.labelFriendsHometown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFriendsHometown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendsHometown.Location = new System.Drawing.Point(637, 7);
            this.labelFriendsHometown.Name = "labelFriendsHometown";
            this.labelFriendsHometown.Size = new System.Drawing.Size(97, 25);
            this.labelFriendsHometown.TabIndex = 12;
            this.labelFriendsHometown.Text = "Hometown:";
            this.labelFriendsHometown.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelFriendsHometown.Visible = false;
            // 
            // labelFriendsBirthday
            // 
            this.labelFriendsBirthday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFriendsBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendsBirthday.Location = new System.Drawing.Point(907, 7);
            this.labelFriendsBirthday.Name = "labelFriendsBirthday";
            this.labelFriendsBirthday.Size = new System.Drawing.Size(71, 25);
            this.labelFriendsBirthday.TabIndex = 10;
            this.labelFriendsBirthday.Text = "Birthday:";
            this.labelFriendsBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelFriendsBirthday.Visible = false;
            // 
            // flowLayoutPanelFriendsPosts
            // 
            this.flowLayoutPanelFriendsPosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelFriendsPosts.AutoScroll = true;
            this.flowLayoutPanelFriendsPosts.Location = new System.Drawing.Point(240, 130);
            this.flowLayoutPanelFriendsPosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelFriendsPosts.Name = "flowLayoutPanelFriendsPosts";
            this.flowLayoutPanelFriendsPosts.Size = new System.Drawing.Size(891, 244);
            this.flowLayoutPanelFriendsPosts.TabIndex = 9;
            this.flowLayoutPanelFriendsPosts.Visible = false;
            // 
            // labelFriendPosts
            // 
            this.labelFriendPosts.AutoSize = true;
            this.labelFriendPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendPosts.Location = new System.Drawing.Point(240, 111);
            this.labelFriendPosts.Name = "labelFriendPosts";
            this.labelFriendPosts.Size = new System.Drawing.Size(47, 17);
            this.labelFriendPosts.TabIndex = 8;
            this.labelFriendPosts.Text = "Posts:";
            this.labelFriendPosts.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelFriendPosts.Visible = false;
            // 
            // labelFriendAbout
            // 
            this.labelFriendAbout.AutoSize = true;
            this.labelFriendAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendAbout.Location = new System.Drawing.Point(389, 36);
            this.labelFriendAbout.Name = "labelFriendAbout";
            this.labelFriendAbout.Size = new System.Drawing.Size(49, 17);
            this.labelFriendAbout.TabIndex = 7;
            this.labelFriendAbout.Text = "About:";
            this.labelFriendAbout.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelFriendAbout.Visible = false;
            // 
            // listBoxFriendAbout
            // 
            this.listBoxFriendAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxFriendAbout.FormattingEnabled = true;
            this.listBoxFriendAbout.ItemHeight = 16;
            this.listBoxFriendAbout.Location = new System.Drawing.Point(393, 57);
            this.listBoxFriendAbout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxFriendAbout.Name = "listBoxFriendAbout";
            this.listBoxFriendAbout.Size = new System.Drawing.Size(732, 52);
            this.listBoxFriendAbout.TabIndex = 6;
            this.listBoxFriendAbout.Visible = false;
            // 
            // labelFriendName
            // 
            this.labelFriendName.AutoSize = true;
            this.labelFriendName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendName.Location = new System.Drawing.Point(389, 7);
            this.labelFriendName.Name = "labelFriendName";
            this.labelFriendName.Size = new System.Drawing.Size(112, 22);
            this.labelFriendName.TabIndex = 2;
            this.labelFriendName.Text = "Lorem Ipsum";
            this.labelFriendName.Visible = false;
            // 
            // pictureBoxFriendPic
            // 
            this.pictureBoxFriendPic.Location = new System.Drawing.Point(240, 2);
            this.pictureBoxFriendPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxFriendPic.Name = "pictureBoxFriendPic";
            this.pictureBoxFriendPic.Size = new System.Drawing.Size(135, 105);
            this.pictureBoxFriendPic.TabIndex = 1;
            this.pictureBoxFriendPic.TabStop = false;
            this.pictureBoxFriendPic.Visible = false;
            // 
            // flowLayoutPanelFriends
            // 
            this.flowLayoutPanelFriends.AutoScroll = true;
            this.flowLayoutPanelFriends.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelFriends.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanelFriends.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelFriends.Name = "flowLayoutPanelFriends";
            this.flowLayoutPanelFriends.Size = new System.Drawing.Size(231, 374);
            this.flowLayoutPanelFriends.TabIndex = 0;
            // 
            // tabPagePosts
            // 
            this.tabPagePosts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPagePosts.Controls.Add(this.panel1);
            this.tabPagePosts.Controls.Add(this.flowLayoutPanelPosts);
            this.tabPagePosts.Location = new System.Drawing.Point(4, 25);
            this.tabPagePosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePosts.Name = "tabPagePosts";
            this.tabPagePosts.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPagePosts.Size = new System.Drawing.Size(1131, 378);
            this.tabPagePosts.TabIndex = 1;
            this.tabPagePosts.Text = "Posts";
            this.tabPagePosts.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonPostsPublish);
            this.panel1.Controls.Add(this.richTextBoxPostsPublish);
            this.panel1.Controls.Add(this.labelPostsPublish);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(853, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 374);
            this.panel1.TabIndex = 1;
            // 
            // buttonPostsPublish
            // 
            this.buttonPostsPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPostsPublish.Location = new System.Drawing.Point(13, 222);
            this.buttonPostsPublish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPostsPublish.Name = "buttonPostsPublish";
            this.buttonPostsPublish.Size = new System.Drawing.Size(259, 38);
            this.buttonPostsPublish.TabIndex = 2;
            this.buttonPostsPublish.Text = "Post";
            this.buttonPostsPublish.UseVisualStyleBackColor = true;
            this.buttonPostsPublish.Click += new System.EventHandler(this.buttonPostsPublish_Click);
            // 
            // richTextBoxPostsPublish
            // 
            this.richTextBoxPostsPublish.Location = new System.Drawing.Point(13, 50);
            this.richTextBoxPostsPublish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxPostsPublish.Name = "richTextBoxPostsPublish";
            this.richTextBoxPostsPublish.Size = new System.Drawing.Size(257, 165);
            this.richTextBoxPostsPublish.TabIndex = 1;
            this.richTextBoxPostsPublish.Text = "";
            // 
            // labelPostsPublish
            // 
            this.labelPostsPublish.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPostsPublish.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostsPublish.Location = new System.Drawing.Point(0, 0);
            this.labelPostsPublish.Name = "labelPostsPublish";
            this.labelPostsPublish.Size = new System.Drawing.Size(275, 48);
            this.labelPostsPublish.TabIndex = 0;
            this.labelPostsPublish.Text = "What\'s on your mind?";
            this.labelPostsPublish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelPosts
            // 
            this.flowLayoutPanelPosts.AutoScroll = true;
            this.flowLayoutPanelPosts.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanelPosts.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanelPosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelPosts.Name = "flowLayoutPanelPosts";
            this.flowLayoutPanelPosts.Size = new System.Drawing.Size(859, 374);
            this.flowLayoutPanelPosts.TabIndex = 0;
            // 
            // tabPageNewsFeed
            // 
            this.tabPageNewsFeed.Controls.Add(this.flowLayoutPanelFeedPosts);
            this.tabPageNewsFeed.Location = new System.Drawing.Point(4, 25);
            this.tabPageNewsFeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageNewsFeed.Name = "tabPageNewsFeed";
            this.tabPageNewsFeed.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageNewsFeed.Size = new System.Drawing.Size(1131, 378);
            this.tabPageNewsFeed.TabIndex = 0;
            this.tabPageNewsFeed.Text = "News Feed";
            this.tabPageNewsFeed.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelFeedPosts
            // 
            this.flowLayoutPanelFeedPosts.AutoScroll = true;
            this.flowLayoutPanelFeedPosts.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelFeedPosts.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowLayoutPanelFeedPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFeedPosts.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanelFeedPosts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelFeedPosts.Name = "flowLayoutPanelFeedPosts";
            this.flowLayoutPanelFeedPosts.Size = new System.Drawing.Size(1125, 374);
            this.flowLayoutPanelFeedPosts.TabIndex = 1;
            // 
            // tabControlFormMain
            // 
            this.tabControlFormMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlFormMain.Controls.Add(this.tabPageNewsFeed);
            this.tabControlFormMain.Controls.Add(this.tabPagePosts);
            this.tabControlFormMain.Controls.Add(this.tabPageFriends);
            this.tabControlFormMain.Controls.Add(this.tabPagePhotos);
            this.tabControlFormMain.Controls.Add(this.tabPagePostsStatistics);
            this.tabControlFormMain.Controls.Add(this.tabPageBirthdayWisher);
            this.tabControlFormMain.Enabled = false;
            this.tabControlFormMain.Location = new System.Drawing.Point(7, 214);
            this.tabControlFormMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlFormMain.Name = "tabControlFormMain";
            this.tabControlFormMain.SelectedIndex = 0;
            this.tabControlFormMain.Size = new System.Drawing.Size(1139, 407);
            this.tabControlFormMain.TabIndex = 3;
            this.tabControlFormMain.Visible = false;
            // 
            // tabPageBirthdayWisher
            // 
            this.tabPageBirthdayWisher.Controls.Add(this.btn_PostBirthdayWish);
            this.tabPageBirthdayWisher.Controls.Add(this.label7);
            this.tabPageBirthdayWisher.Controls.Add(this.txtBox_BirthdayWish);
            this.tabPageBirthdayWisher.Controls.Add(this.tableLayoutPanel2);
            this.tabPageBirthdayWisher.Location = new System.Drawing.Point(4, 25);
            this.tabPageBirthdayWisher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageBirthdayWisher.Name = "tabPageBirthdayWisher";
            this.tabPageBirthdayWisher.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageBirthdayWisher.Size = new System.Drawing.Size(1131, 378);
            this.tabPageBirthdayWisher.TabIndex = 5;
            this.tabPageBirthdayWisher.Text = "Birthday Wisher";
            this.tabPageBirthdayWisher.UseVisualStyleBackColor = true;
            // 
            // btn_PostBirthdayWish
            // 
            this.btn_PostBirthdayWish.Enabled = false;
            this.btn_PostBirthdayWish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PostBirthdayWish.Location = new System.Drawing.Point(863, 206);
            this.btn_PostBirthdayWish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_PostBirthdayWish.Name = "btn_PostBirthdayWish";
            this.btn_PostBirthdayWish.Size = new System.Drawing.Size(259, 38);
            this.btn_PostBirthdayWish.TabIndex = 6;
            this.btn_PostBirthdayWish.Text = "Post";
            this.btn_PostBirthdayWish.UseVisualStyleBackColor = true;
            this.btn_PostBirthdayWish.Click += new System.EventHandler(this.btn_PostBirthdayWish_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(543, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 48);
            this.label7.TabIndex = 5;
            this.label7.Text = "Your Birthday wish:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_BirthdayWish
            // 
            this.txtBox_BirthdayWish.Enabled = false;
            this.txtBox_BirthdayWish.Location = new System.Drawing.Point(277, 81);
            this.txtBox_BirthdayWish.Margin = new System.Windows.Forms.Padding(4);
            this.txtBox_BirthdayWish.Name = "txtBox_BirthdayWish";
            this.txtBox_BirthdayWish.Size = new System.Drawing.Size(843, 117);
            this.txtBox_BirthdayWish.TabIndex = 4;
            this.txtBox_BirthdayWish.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanelFreindsW8Birthday, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(267, 374);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 48);
            this.label6.TabIndex = 2;
            this.label6.Text = "Friends\' Birthdays";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanelFreindsW8Birthday
            // 
            this.flowLayoutPanelFreindsW8Birthday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFreindsW8Birthday.Location = new System.Drawing.Point(4, 60);
            this.flowLayoutPanelFreindsW8Birthday.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelFreindsW8Birthday.Name = "flowLayoutPanelFreindsW8Birthday";
            this.flowLayoutPanelFreindsW8Birthday.Size = new System.Drawing.Size(259, 310);
            this.flowLayoutPanelFreindsW8Birthday.TabIndex = 3;
            this.flowLayoutPanelFreindsW8Birthday.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelFreindsW8Birthday_Paint);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1157, 633);
            this.Controls.Add(this.checkBoxRememberMe);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.tabControlFormMain);
            this.Controls.Add(this.pictureBoxProfilePic);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBoxCoverPic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maor & Dudi\'s Facebook Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCoverPic)).EndInit();
            this.tabPagePostsStatistics.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Likes_Time)).EndInit();
            this.grp_Stats.ResumeLayout(false);
            this.grp_Stats.PerformLayout();
            this.tabPagePhotos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhotosPic)).EndInit();
            this.tabPageFriends.ResumeLayout(false);
            this.tabPageFriends.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriendPic)).EndInit();
            this.tabPagePosts.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPageNewsFeed.ResumeLayout(false);
            this.tabControlFormMain.ResumeLayout(false);
            this.tabPageBirthdayWisher.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.PictureBox pictureBoxProfilePic;
        private System.Windows.Forms.PictureBox pictureBoxCoverPic;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
        private System.Windows.Forms.TabPage tabPagePostsStatistics;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Likes_Time;
        private System.Windows.Forms.GroupBox grp_Stats;
        private System.Windows.Forms.TextBox txt_PhotosInPosts;
        private System.Windows.Forms.TextBox txt_TotalLikes;
        private System.Windows.Forms.TextBox txt_LikesPerPost;
        private System.Windows.Forms.TextBox txt_PostsPerDay;
        private System.Windows.Forms.TextBox txt_LetterPerPost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPagePhotos;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPhotosAlbums;
        private System.Windows.Forms.PictureBox pictureBoxPhotosPic;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPhotosAlbumPics;
        private System.Windows.Forms.TabPage tabPageFriends;
        private System.Windows.Forms.TextBox textBoxHometown;
        private System.Windows.Forms.TextBox textBoxFriendsBirthday;
        private System.Windows.Forms.Label labelFriendsHometown;
        private System.Windows.Forms.Label labelFriendsBirthday;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriendsPosts;
        private System.Windows.Forms.Label labelFriendPosts;
        private System.Windows.Forms.Label labelFriendAbout;
        private System.Windows.Forms.ListBox listBoxFriendAbout;
        private System.Windows.Forms.Label labelFriendName;
        private System.Windows.Forms.PictureBox pictureBoxFriendPic;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFriends;
        private System.Windows.Forms.TabPage tabPagePosts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPostsPublish;
        private System.Windows.Forms.RichTextBox richTextBoxPostsPublish;
        private System.Windows.Forms.Label labelPostsPublish;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPosts;
        private System.Windows.Forms.TabPage tabPageNewsFeed;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFeedPosts;
        private System.Windows.Forms.TabControl tabControlFormMain;
        private System.Windows.Forms.TabPage tabPageBirthdayWisher;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFreindsW8Birthday;
        private System.Windows.Forms.Button btn_PostBirthdayWish;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtBox_BirthdayWish;
    }
}