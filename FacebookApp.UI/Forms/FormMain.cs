using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookApp.Logic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public partial class FormMain : Form
    {
        private ApplicationSettings m_ApplicationSettings;
        private LoginManager m_LoginManager;
        private User m_LoggedInUser;
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
        private readonly string r_MessageErrorOccuredTitle = "Error Occured";
        private bool m_IsPostsStatisticsPopulated = false;
        private bool m_IsFriendsPostsPopulated = false;

        public FormMain()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            m_ApplicationSettings = ApplicationSettings.Instance;
            m_LoginManager = LoginManager.Instance;
        }

        private void buttonLogin_Click(object i_Sender, EventArgs e)
        {
            m_LoginManager.Login();
            if (m_LoginManager.IsLoggedIn)
            {
                m_LoggedInUser = m_LoginManager.LoggedInUser;
                StringBuilder formHeader = new StringBuilder(r_LoggedInString);
                formHeader.Append(m_LoggedInUser.Name);
                this.Text = formHeader.ToString();
                toggleAllControllers(true);
                this.labelUserName.Text = m_LoggedInUser.Name;
                this.labelUserName.Visible = true;
                this.pictureBoxProfilePic.Load(m_LoggedInUser.PictureNormalURL);
                loadUserCoverPictureBox();
                populateNewsFeed();
            }
        }

        private void tabControl1_SelectedIndexChanged(object i_Sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab.Name.Equals(tabPageNewsFeed.Name))
            {
                populateNewsFeed();
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPagePosts.Name))
            {
                populateUserPosts();
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPageFriends.Name))
            {
                populateUserFriends();
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPagePhotos.Name))
            {
                populateUserPhotos();
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPagePostsStatistics.Name))
            {
                populatePostsStatistics();
            }
            /// TODO: [Extra Feature] Add 2nd Extra Feature.
        }

        private void label1_Click(object i_Sender, EventArgs e)
        {

        }

        private void picBoxFriend_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            User friend = picBox.Tag as User;
            if (friend != null)
            {
                this.flowLayoutPanelFriendsPosts.Controls.Clear();
                this.pictureBoxFriendPic.Load(friend.PictureNormalURL);
                this.pictureBoxFriendPic.Visible = true;
                this.labelFriendName.Text = friend.Name;
                this.labelFriendName.Visible = true;
                this.labelFriendAbout.Visible = true;
                this.listBoxFriendAbout.Text = friend.About;
                this.listBoxFriendAbout.Visible = true;
                this.labelFriendsHometown.Visible = true;
                this.textBoxHometown.Text = getUserHometown(friend);
                this.textBoxHometown.Visible = true;
                this.labelFriendsBirthday.Visible = true;
                this.textBoxFriendsBirthday.Text = friend.Birthday;
                this.textBoxFriendsBirthday.Visible = true;
                this.labelFriendPosts.Visible = true;

                int i = 0;
                foreach (Post post in friend.Posts)
                {
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelFriendsPosts.Controls.Add(postBox);
                    i++;
                    if (i == Configuration.k_MaxPostsShown) break;
                }

                flowLayoutPanelFriendsPosts.Visible = true;
            }
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

        private void toggleAllControllers(bool i_ToggleMode)
        {
            this.pictureBoxProfilePic.Enabled = i_ToggleMode;
            this.tabControl1.Enabled = i_ToggleMode;
            this.buttonLogout.Enabled = i_ToggleMode;
            this.labelUserName.Enabled = i_ToggleMode;
            this.buttonLogin.Enabled = !i_ToggleMode;
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
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelFeedPosts.Controls.Add(postBox);
                    i++;
                    if (i == Configuration.k_MaxPostsShown) break;
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
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelPosts.Controls.Add(postBox);
                    i++;
                    if (i == Configuration.k_MaxPostsShown) break;
                }
            }
        }

        private void populateUserFriends()
        {
            if (this.flowLayoutPanelFriends.Controls.Count == 0)
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    EventHandler  picBoxFriendClickEventHandler = new EventHandler(this.picBoxFriend_Click);
                    PictureBox picBox = addPictureBoxToLayout(friend.Name, this.flowLayoutPanelFriends, picBoxFriendClickEventHandler);
                    picBox.Tag = friend;
                    picBox.Load(friend.PictureNormalURL);
                }
            }
        }

        // FOR ASSIGNMENT CHECKER:
        // Facebook API Issue Encountered:
        // 'Facebook.FacebookOAuthException' occurred in Facebook.dll
        // Additional information: (OAuthException - #100) (#100) Tried accessing nonexisting field (likes) on node type (Album)
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
                    MessageBox.Show(r_MessageAlbumsUnavailable, r_MessageErrorOccuredTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            i_DestPanel.Controls.Add(picBox);
            return picBox;
        }

        private void populatePostsStatistics()
        {
            if (!m_IsPostsStatisticsPopulated)
            {
                PostsStatisticsGenerator postsStatsGenerator = new PostsStatisticsGenerator(
                    m_LoggedInUser,
                    this.chart_Likes_Time,
                    this.txt_LetterPerPost,
                    this.txt_PostsPerDay,
                    this.txt_LikesPerPost,
                    this.txt_PhotosInPosts,
                    this.txt_TotalLikes);
                postsStatsGenerator.GenerateStatistics();
                m_IsPostsStatisticsPopulated = true;
            }
        }

        private void loadUserCoverPictureBox()
        {
            try
            {
                if (!string.IsNullOrEmpty(m_LoggedInUser.Cover.SourceURL))
                    this.pictureBoxCoverPic.Load(m_LoggedInUser.Cover.SourceURL);
            }
            catch (Exception)
            {
                MessageBox.Show(r_MessageCoverPhotoUnavailable, r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// TODO: Add buttonLogout_Click functionality.
        private void buttonLogout_Click(object i_Sender, EventArgs e)
        {
            // Save LastAccessToken if RememberMe == true
            // Save Application Settings
            // Clear All User Data
            // Change MainForm Title back to defualt header
            // Enable buttonLogin, Disable buttonLogout
            // If LoginForm was completed close MainForm and Re-Activate LoginForm
        }

        private void buttonPostsPublish_Click(object i_Sender, EventArgs e)
        {
            publishNewPost();
        }

        // FOR ASSIGNMENT CHECKER:
        // Facebook API Issue Encountered:
        // 'Facebook.FacebookOAuthException' occurred in Facebook.dll
        // Additional information: (OAuthException - #200) (#200) If posting to a group, requires app being installed in the group, 
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
                    MessageBox.Show(r_MessagePublishPostUnavailable, r_MessageErrorOccuredTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.richTextBoxPostsPublish.Text = string.Empty;
        }
    }
}
