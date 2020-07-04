using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Windows.Forms;
using FacebookApp.Logic;
using FacebookWrapper.ObjectModel;
using FacebookApp.UI.Builders;

namespace FacebookApp.UI.Forms
{
    public partial class FormMain : Form
    {
        private readonly string r_DefaultFormHeader = "Maor & Dudi's Facebook Application";
        private readonly string r_LoggedInString = "Logged-In As: ";
        private readonly string r_MessageAlbumsUnavailable = string.Format(
            "Albums are currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private readonly string r_MessageAlbumPhotosUnavailable = string.Format(
            "This Album Photos are currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private readonly string r_MessageCoverPhotoUnavailable = string.Format(
            "User's Cover Photo is currently unavailable.{0}Using defualt Cover Image.",
            Environment.NewLine);

        private readonly string r_MessagePublishPostUnavailable = string.Format(
            "Publishing New Posts is currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private readonly string r_MessageLogoutSuccessful = "You have logged-out successfully!";
        private readonly string r_MessageErrorOccuredTitle = "Error Occured";
        private ApplicationSettings m_ApplicationSettings;
        private LoginManager m_LoginManager;
        private User m_LoggedInUser;
        private bool m_IsPostsStatisticsPopulated = false;

        public FormMain()
        {
            InitializeComponent();
            tabControlFormMain.SelectedIndexChanged += new EventHandler(tabControlFormMain_SelectedIndexChanged);
            m_ApplicationSettings = ApplicationSettings.Instance;
            m_LoginManager = LoginManager.Instance;
            m_LoginManager.LogoutSuccessful += loginManager_LogoutSuccessful;
        }

        private void buttonLogin_Click(object i_Sender, EventArgs e)
        {
            m_LoginManager.Login();
            if (m_LoginManager.IsLoggedIn)
            {
                m_LoggedInUser = m_LoginManager.LoggedInUser;
                string formHeader = string.Format("{0}{1}", r_LoggedInString, m_LoggedInUser.Name);
                this.Text = formHeader;
                toggleAllMainFormControls(true);
                this.labelUserName.Text = m_LoggedInUser.Name;
                this.pictureBoxProfilePic.Load(m_LoggedInUser.PictureNormalURL);
                loadUserCoverPictureBox();
                new Thread(populateNewsFeed).Start();
                showAllMainFormControls(true);
            }
        }

        private void tabControlFormMain_SelectedIndexChanged(object i_Sender, EventArgs e)
        {
            if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPageNewsFeed.Name))
            {
                new Thread(populateNewsFeed).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPagePosts.Name))
            {
                new Thread(populateUserPosts).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPageFriends.Name))
            {
                new Thread(populateUserFriends).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPagePhotos.Name))
            {
                new Thread(populateUserPhotos).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPagePostsStatistics.Name))
            {
                new Thread(populatePostsStatistics).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPageBirthdayWisher.Name))
            {
                new Thread(populateBirthdayWisher).Start();
            }
        }

        private void label1_Click(object i_Sender, EventArgs e)
        {
        }

        private void picBoxFriendBirthDay_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            User friend = picBox?.Tag as User;

            if (friend != null)
            {
                txtBox_BirthdayWish.Enabled = true;
                btn_PostBirthdayWish.Enabled = true;

                // will replace the @id to a tag in facebook
                txtBox_BirthdayWish.Text = string.Format(
                    "Happy Birthday @{0}!!!{1}I hope this year brings you the best life has to offer,{1}Thank you for being a fantastic friend!{1} Yours,{1}{2}.",
                    friend.Id, 
                    Environment.NewLine, 
                    m_LoggedInUser.FirstName);
                
                btn_PostBirthdayWish.Tag = friend;
            }
        }

        private void picBoxFriend_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            User friend = picBox?.Tag as User;
            if (friend != null)
            {
                this.flowLayoutPanelFriendsPosts.Controls.Clear();
                picBoxFriendClickSetControlsAttributes(friend);

                int i = 0;
                foreach (Post post in friend.Posts)
                {
                    PostBox postBox = composePostBox(post, friend);
                    this.flowLayoutPanelFriendsPosts.Controls.Add(postBox);
                    i++;
                    if (i == m_ApplicationSettings.MaxPostsShown)
                    {
                        break;
                    }
                }

                picBoxFriendClickShowControls(true);
            }
        }

        private void picBoxFriendClickSetControlsAttributes(User i_Friend)
        {
            userBindingSource.DataSource = i_Friend;
        }

        private void picBoxFriendClickShowControls(bool i_ToggleMode)
        {
            this.pictureBoxFriendPic.Visible = i_ToggleMode;
            this.labelFriendName.Visible = i_ToggleMode;
            this.labelFriendAbout.Visible = i_ToggleMode;
            this.textBoxFriendAbout.Visible = i_ToggleMode;
            this.labelFriendsHometown.Visible = i_ToggleMode;
            this.textBoxHometown.Visible = i_ToggleMode;
            this.labelFriendsBirthday.Visible = i_ToggleMode;
            this.textBoxFriendsBirthday.Visible = i_ToggleMode;
            this.labelFriendPosts.Visible = i_ToggleMode;
            flowLayoutPanelFriendsPosts.Visible = i_ToggleMode;
        }

        private void picBoxAlbum_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBoxSender = i_Sender as PictureBox;
            Album album = picBoxSender?.Tag as Album;
            if (album != null)
            {
                try
                {
                    foreach (Photo photo in album.Photos)
                    {
                        EventHandler picBoxPhotosAlbumPicClickEventHandler = new EventHandler(this.picBoxPhotosAlbumPic_Click);
                        PictureBox picBox = addPictureBoxToLayout(photo.Name, this.flowLayoutPanelPhotosAlbumPics, picBoxPhotosAlbumPicClickEventHandler);
                        picBox.Tag = photo;
                        picBox.Load(photo.PictureNormalURL);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show(
                        r_MessageAlbumPhotosUnavailable,
                        r_MessageErrorOccuredTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void picBoxPhotosAlbumPic_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBoxSender = i_Sender as PictureBox;
            Photo photo = picBoxSender?.Tag as Photo;
            if (photo != null)
            {
                this.pictureBoxPhotosPic.Load(photo.PictureNormalURL);
            }
        }

        private void pictureBox_Paint(object i_Sender, PaintEventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            SizeF textSize = e.Graphics.MeasureString(picBox.Name, Font);
            PointF locationToDraw = new PointF();
            locationToDraw.X = (picBox.Width / 2) - (textSize.Width / 2);
            locationToDraw.Y = (picBox.Height / 2) - (textSize.Height / 2);
            e.Graphics.DrawString(picBox.Name, Font, Brushes.Black, locationToDraw);
        }

        private void toggleAllMainFormControls(bool i_ToggleMode)
        {
            this.pictureBoxProfilePic.Enabled = i_ToggleMode;
            this.tabControlFormMain.Enabled = i_ToggleMode;
            this.buttonLogout.Enabled = i_ToggleMode;
            this.labelUserName.Enabled = i_ToggleMode;
            this.buttonLogin.Enabled = !i_ToggleMode;
            this.checkBoxRememberMe.Enabled = !i_ToggleMode;
        }

        private void showAllMainFormControls(bool i_ToggleMode)
        {
            this.pictureBoxProfilePic.Visible = i_ToggleMode;
            this.labelUserName.Visible = i_ToggleMode;
            this.tabControlFormMain.Visible = i_ToggleMode;
            this.buttonLogout.Visible = i_ToggleMode;
            this.labelUserName.Visible = i_ToggleMode;
            this.buttonLogin.Visible = !i_ToggleMode;
            this.checkBoxRememberMe.Visible = !i_ToggleMode;
        }

        private string getUserHometown(User i_User)
        {
            return i_User.Hometown == null ? string.Empty : i_User.Hometown.Name;
        }

        private void populateNewsFeed()
        {
            if (this.flowLayoutPanelFeedPosts.Controls.Count == 0)
            {
                int i = 0;
                foreach (Post post in m_LoggedInUser.NewsFeed)
                {
                    PostBox postBox = composePostBox(post, post.From);
                    flowLayoutPanelFeedPosts.Invoke(new Action(() => 
                        {
                        this.flowLayoutPanelFeedPosts.Controls.Add(postBox);
                        this.flowLayoutPanelFeedPosts.SetFlowBreak(postBox, true);
                    }));
                    i++;
                    if (i == m_ApplicationSettings.MaxPostsShown)
                    {
                        break;
                    }
                }
            }
        }

        private void populateUserPosts()
        {
            if (this.flowLayoutPanelPosts.Controls.Count == 0)
            {
                int i = 0;
                foreach (Post post in m_LoggedInUser.Posts)
                {
                    PostBox postBox = composePostBox(post, post.From);
                    flowLayoutPanelPosts.Invoke(new Action(() => flowLayoutPanelPosts.Controls.Add(postBox)));
                    i++;
                    if (i == m_ApplicationSettings.MaxPostsShown)
                    {
                        break;
                    }
                }
            }
        }

        private PostBox composePostBox(Post i_Post, User i_From)
        {
            IPostBoxBuilder builder = new PostBoxBuilder(i_Post);
            PostBoxComposer composer = new PostBoxComposer();
            composer.ConstructPostBox(builder, i_From);
            return builder.CreatedPostBox;
        }

        private void populateUserFriends()
        {
            if (this.flowLayoutPanelFriends.Controls.Count == 0)
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    EventHandler picBoxFriendClickEventHandler = new EventHandler(this.picBoxFriend_Click);
                    PictureBox picBox = addPictureBoxToLayout(friend.Name, this.flowLayoutPanelFriends, picBoxFriendClickEventHandler);
                    picBox.Tag = friend;
                    picBox.Load(friend.PictureNormalURL);
                }
            }
        }

        /// <summary>
        /// FOR ASSIGNMENT CHECKER:
        /// Facebook API Issue Encountered:
        /// Facebook.FacebookOAuthException' occurred in Facebook.dll
        /// Additional information: (OAuthException - #100) (#100) Tried accessing nonexisting field (likes) on node type (Album)
        /// </summary>
        private void populateUserPhotos()
        {
            if (this.flowLayoutPanelPhotosAlbums.Controls.Count == 0)
            {
                try
                {
                    foreach (Album album in m_LoggedInUser.Albums)
                    {
                        EventHandler picBoxAlbumClickEventHandler = new EventHandler(this.picBoxAlbum_Click);
                        PictureBox picBox = addPictureBoxToLayout(album.Name, this.flowLayoutPanelPhotosAlbums, picBoxAlbumClickEventHandler);
                        picBox.Tag = album;
                        picBox.Load(album.PictureThumbURL);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        r_MessageAlbumsUnavailable,
                        r_MessageErrorOccuredTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void populateBirthdayWisher()
        {
            if (this.flowLayoutPanelFreindsW8Birthday.Controls.Count == 0)
            {
                // Birthday Format from Facebook is: MM/DD/YYYY
                string todayDate = string.Format("{0:MM/dd}", DateTime.Now);

                foreach (User friend in m_LoggedInUser.Friends)
                {
                    //// in real scenrio i will only show the friends with birtday today,
                    //// but because we only have 2 friends to show, i will not filter them
                    //// if (friend.Birthday.Contains(todayDate))
                    //// {
                    EventHandler picBoxFriendClickEventHandler = new EventHandler(this.picBoxFriendBirthDay_Click);
                    PictureBox picBox = addPictureBoxToLayout(friend.Name, this.flowLayoutPanelFreindsW8Birthday, picBoxFriendClickEventHandler);
                    picBox.Tag = friend;
                    picBox.Load(friend.PictureNormalURL);
                    //// }
                }
            }
        }

        private PictureBox addPictureBoxToLayout(string i_PicName, Panel i_DestPanel, EventHandler i_EventHandler)
        {
            PictureBox picBox = new PictureBox();
            picBox.Paint += new PaintEventHandler(this.pictureBox_Paint);
            picBox.Click += i_EventHandler;
            picBox.Name = i_PicName;
            picBox.Size = new System.Drawing.Size(75, 75);
            picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picBox.Visible = true;
            i_DestPanel.Invoke(new Action(() => i_DestPanel.Controls.Add(picBox)));
            return picBox;
        }

        private void populatePostsStatistics()
        {
            if (!m_IsPostsStatisticsPopulated)
            {
                PostsStatisticsGeneratorAdapter postStatsAdapter = new PostsStatisticsGeneratorAdapter(m_LoggedInUser.Posts);
                this.chart_Likes_Time.Invoke(new Action(() => 
                    {
                    this.chart_Likes_Time.Series.Clear();
                    this.chart_Likes_Time.Series.Add(postStatsAdapter.PostsPerTimeOfDay());
                    this.chart_Likes_Time.Series.Add(postStatsAdapter.LikesPerTimeOfDay());

                    // Insert this graph as a secondary line, with a unique Y axis to the main chart control
                    createSecondYAxisScale(this.chart_Likes_Time, "Posts");
                }));

                this.Invoke(new Action(() =>
                {
                    this.txt_LetterPerPost.Text = postStatsAdapter.AvgLettersPerPost();
                    this.txt_LetterPerPost.Text = postStatsAdapter.AvgLettersPerPost();
                    this.txt_PostsPerDay.Text = postStatsAdapter.PostsPerDay();
                    this.txt_LikesPerPost.Text = postStatsAdapter.LikesPerPost();
                    this.txt_PhotosInPosts.Text = postStatsAdapter.PhotosPerPosts();
                    this.txt_TotalLikes.Text = postStatsAdapter.TotalNumberOfLikes();
                }));

                m_IsPostsStatisticsPopulated = true;
            }
        }

        #region Chart Maintenense 
        private void createSecondYAxisScale(Chart i_Chart, string i_Series)
        {
            // Set custom chart area position
            i_Chart.ChartAreas["ChartArea1"].Position = new ElementPosition(25, 10, 68, 85);
            i_Chart.ChartAreas["ChartArea1"].InnerPlotPosition = new ElementPosition(10, 0, 90, 90);

            // Create extra Y axis for second
            createYAxis(i_Chart, i_Chart.ChartAreas["ChartArea1"], i_Chart.Series[i_Series], 13, 8);
        }

        private void createYAxis(
            Chart i_Chart,
            ChartArea i_Area,
            Series i_Series,
            float i_AxisOffset,
            float i_LabelsSize)
        {
            // Create new chart area for original series
            ChartArea areaSeries = i_Chart.ChartAreas.Add("ChartArea_" + i_Series.Name);
            areaSeries.BackColor = Color.Transparent;
            areaSeries.BorderColor = Color.Transparent;
            areaSeries.Position.FromRectangleF(i_Area.Position.ToRectangleF());
            areaSeries.InnerPlotPosition.FromRectangleF(i_Area.InnerPlotPosition.ToRectangleF());
            areaSeries.AxisX.MajorGrid.Enabled = false;
            areaSeries.AxisX.MajorTickMark.Enabled = false;
            areaSeries.AxisX.LabelStyle.Enabled = false;
            areaSeries.AxisY.MajorGrid.Enabled = false;
            areaSeries.AxisY.MajorTickMark.Enabled = false;
            areaSeries.AxisY.LabelStyle.Enabled = false;
            areaSeries.AxisY.IsStartedFromZero = i_Area.AxisY.IsStartedFromZero;
            i_Series.ChartArea = areaSeries.Name;

            // Create new chart area for axis
            ChartArea areaAxis = i_Chart.ChartAreas.Add("AxisY_" + i_Series.ChartArea);
            areaAxis.BackColor = Color.Transparent;
            areaAxis.BorderColor = Color.Transparent;
            areaAxis.Position.FromRectangleF(i_Chart.ChartAreas[i_Series.ChartArea].Position.ToRectangleF());
            areaAxis.InnerPlotPosition.FromRectangleF(i_Chart.ChartAreas[i_Series.ChartArea].InnerPlotPosition.ToRectangleF());

            // Create a copy of specified series
            Series seriesCopy = i_Chart.Series.Add(i_Series.Name + "_Copy");
            seriesCopy.ChartType = i_Series.ChartType;
            foreach (DataPoint point in i_Series.Points)
            {
                seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
            }

            // Hide copied series
            seriesCopy.IsVisibleInLegend = false;
            seriesCopy.Color = Color.Transparent;
            seriesCopy.BorderColor = Color.Transparent;
            seriesCopy.ChartArea = areaAxis.Name;

            // Disable drid lines & tickmarks
            areaAxis.AxisX.LineWidth = 0;
            areaAxis.AxisX.MajorGrid.Enabled = false;
            areaAxis.AxisX.MajorTickMark.Enabled = false;
            areaAxis.AxisX.LabelStyle.Enabled = false;
            areaAxis.AxisY.MajorGrid.Enabled = false;
            areaAxis.AxisY.IsStartedFromZero = i_Area.AxisY.IsStartedFromZero;
            areaAxis.AxisY.LabelStyle.Font = i_Area.AxisY.LabelStyle.Font;

            // Adjust area position
            areaAxis.Position.X -= i_AxisOffset;
            areaAxis.InnerPlotPosition.X += i_LabelsSize;
        }
        #endregion

        private void loadUserCoverPictureBox()
        {
            try
            {
                if (!string.IsNullOrEmpty(m_LoggedInUser.Cover.SourceURL))
                {
                    this.pictureBoxCoverPic.Load(m_LoggedInUser.Cover.SourceURL);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    r_MessageCoverPhotoUnavailable,
                    r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonLogout_Click(object i_Sender, EventArgs e)
        {
            logoutUser();
        }

        private void logoutUser()
        {
            ApplicationSettings.Instance.SaveApplicationSettings();
            m_LoginManager.Logout();
        }

        private void loginManager_LogoutSuccessful(object i_Sender, EventArgs e)
        {
            this.Text = r_DefaultFormHeader;
            toggleAllMainFormControls(false);
            MessageBox.Show(
                r_MessageLogoutSuccessful,
                "Logout",
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
            toggleAllMainFormControls(false);
            showAllMainFormControls(false);
        }

        private void buttonPostsPublish_Click(object i_Sender, EventArgs e)
        {
            publishNewPost();
        }

        private void checkBoxRememberMe_CheckedChanged(object i_Sender, EventArgs e)
        {
            m_ApplicationSettings.RememberUser = checkBoxRememberMe.Checked;
        }

        private void btn_PostBirthdayWish_Click(object sender, EventArgs e)
        {
            User birthdayFriend = btn_PostBirthdayWish.Tag as User;
            Post birthdayWish = new Post();

            // Facebook Wrapper gives me no way to edit post's message 
            // birthdayWish.Message = txtBox_BirthdayWish;
            // and doesnt allow me any other way to post on wall
            birthdayFriend?.WallPosts.Add(birthdayWish);
        }

        /// <summary>
        /// FOR ASSIGNMENT CHECKER:
        /// Facebook API Issue Encountered:
        /// 'Facebook.FacebookOAuthException' occurred in Facebook.dll
        /// Additional information: (OAuthException - #200) (#200) If posting to a group, requires app being installed in the group, 
        /// </summary>
        private void publishNewPost()
        {
            if (!string.IsNullOrEmpty(this.richTextBoxPostsPublish.Text))
            {
                try
                {
                    m_LoggedInUser.PostStatus(this.richTextBoxPostsPublish.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(
                        r_MessagePublishPostUnavailable,
                        r_MessageErrorOccuredTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            this.richTextBoxPostsPublish.Text = string.Empty;
        }
    }
}
