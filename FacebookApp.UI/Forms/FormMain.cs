using System;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FacebookApp.Logic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public partial class FormMain : Form
    {
        private readonly string r_DefaultFormHeader = "Maor & Dudi's Facebook Application";
        private readonly string r_LoggedInString = "Logged-In As: ";
        private readonly string r_MessageAlbumsUnavailable = string.Format(
            "Albums are currently unavailable.{0}Please try again later.",
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
            m_LoginManager.LogoutSuccessful += new EventHandler(loginManager_LogoutSuccessful);
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
                //populateNewsFeed();
                new Thread(populateNewsFeed).Start();
                showAllMainFormControls(true);
            }
        }

        private void tabControlFormMain_SelectedIndexChanged(object i_Sender, EventArgs e)
        {
            if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPageNewsFeed.Name))
            {
                ////populateNewsFeed();
                new Thread(populateNewsFeed).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPagePosts.Name))
            {
                ////populateUserPosts();
                new Thread(populateUserPosts).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPageFriends.Name))
            {
                ////populateUserFriends();
                new Thread(populateUserFriends).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPagePhotos.Name))
            {
                ////populateUserPhotos();
                new Thread(populateUserPhotos).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPagePostsStatistics.Name))
            {
                //// populatePostsStatistics();
                new Thread(populatePostsStatistics).Start();
            }
            else if (this.tabControlFormMain.SelectedTab.Name.Equals(tabPageBirthdayWisher.Name))
            {
                ////populateBirthdayWisher();
                new Thread(populateBirthdayWisher).Start();
            }
        }

        private void label1_Click(object i_Sender, EventArgs e)
        {
        }

        private void picBoxFriendBirthDay_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            User friend = picBox.Tag as User;

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
            User friend = picBox.Tag as User;
            if (friend != null)
            {
                this.flowLayoutPanelFriendsPosts.Controls.Clear();
                picBoxFriendClickSetControlsAttributes(friend);

                int i = 0;
                foreach (Post post in friend.Posts)
                {
                    //CHECK Builder
                    PostBox postBox = PostBoxComposer.Generate(post, friend.Name, friend.PictureSmallURL);
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
            this.pictureBoxFriendPic.Load(i_Friend.PictureNormalURL);
            this.labelFriendName.Text = i_Friend.Name;
            this.listBoxFriendAbout.Text = i_Friend.About;
            this.textBoxHometown.Text = getUserHometown(i_Friend);
            this.textBoxFriendsBirthday.Text = i_Friend.Birthday;
        }

        private void picBoxFriendClickShowControls(bool i_ToggleMode)
        {
            this.pictureBoxFriendPic.Visible = i_ToggleMode;
            this.labelFriendName.Visible = i_ToggleMode;
            this.labelFriendAbout.Visible = i_ToggleMode;
            this.listBoxFriendAbout.Visible = i_ToggleMode;
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
            Album album = picBoxSender.Tag as Album;
            if (album != null)
            {
                foreach (Photo photo in album.Photos)
                {
                    EventHandler picBoxPhotosAlbumPicClickEventHandler = new EventHandler(this.picBoxPhotosAlbumPic_Click);
                    PictureBox picBox = addPictureBoxToLayout(photo.Name, this.flowLayoutPanelFriends, picBoxPhotosAlbumPicClickEventHandler);
                    picBox.Tag = photo;
                    picBox.Load(photo.PictureNormalURL);
                }
            }
        }

        private void picBoxPhotosAlbumPic_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBoxSender = i_Sender as PictureBox;
            Photo photo = picBoxSender.Tag as Photo;
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
                    //CHECK Builder
                    PostBox postBox = PostBoxComposer.Generate(post);
                    //// this.flowLayoutPanelFeedPosts.Controls.Add(postBox);
                    flowLayoutPanelFeedPosts.Invoke(new Action(() => this.flowLayoutPanelFeedPosts.Controls.Add(postBox)));
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
                    //CHECK Builder
                    PostBox postBox = PostBoxComposer.Generate(post);
                    //// this.flowLayoutPanelPosts.Controls.Add(postBox);
                    flowLayoutPanelPosts.Invoke(new Action(() => flowLayoutPanelPosts.Controls.Add(postBox)));
                    i++;
                    if (i == m_ApplicationSettings.MaxPostsShown)
                    {
                        break;
                    }
                }
            }
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

                ////flowLayoutPanelFriends.Visible = true;
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
                        PictureBox picBox = addPictureBoxToLayout(album.Name, this.flowLayoutPanelFriends, picBoxAlbumClickEventHandler);
                        picBox.Tag = album;
                        picBox.Load(album.CoverPhotoThumbURL);
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
                    // in real scenrio i will only show the friends with birtday today,
                    // but because we only have 2 friends to show, i will not filter them
                    //if (friend.Birthday.Contains(todayDate))
                    //{
                    EventHandler picBoxFriendClickEventHandler = new EventHandler(this.picBoxFriendBirthDay_Click);
                    PictureBox picBox = addPictureBoxToLayout(friend.Name, this.flowLayoutPanelFreindsW8Birthday, picBoxFriendClickEventHandler);
                    picBox.Tag = friend;
                    picBox.Load(friend.PictureNormalURL);
                    //User: design.patterns
                    //Pass: design.patterns20b20
                    //}
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
            ////i_DestPanel.Controls.Add(picBox);
            i_DestPanel.Invoke(new Action(() => i_DestPanel.Controls.Add(picBox)));
            return picBox;
        }

        private void populatePostsStatistics()
        {
            if (!m_IsPostsStatisticsPopulated)
            {
                ////PostsStatisticsGenerator postsStatsGenerator = new PostsStatisticsGenerator(
                ////    m_LoggedInUser,
                ////    this.chart_Likes_Time,
                ////    this.txt_LetterPerPost,
                ////    this.txt_PostsPerDay,
                ////    this.txt_LikesPerPost,
                ////    this.txt_PhotosInPosts,
                ////    this.txt_TotalLikes);
                ////postsStatsGenerator.GenerateStatistics();

                IFormsPostStatsGeneratorAdapter postsStatsGenerator = new PostsStatsGeneratorAdapter(
                    m_LoggedInUser.Posts,
                    this.chart_Likes_Time,
                    this.txt_LetterPerPost,
                    this.txt_PostsPerDay,
                    this.txt_LikesPerPost,
                    this.txt_PhotosInPosts,
                    this.txt_TotalLikes);
                postsStatsGenerator.GeneratePostsStatistics();

                m_IsPostsStatisticsPopulated = true;
            }
        }

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
            //birthdayWish.Message = txtBox_BirthdayWish;
            // and doesnt allow me any other way to post on wall
            birthdayFriend.WallPosts.Add(birthdayWish);
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

        private void flowLayoutPanelFreindsW8Birthday_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
