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
        private UserDataManager m_UserDataManager;
        private User m_LoggedInUser;
        private TabPage m_LastSelectedTab;
        private readonly string r_DefaultFormHeader = "Maor & Dudi's Facebook Application";
        private readonly string r_LoggedInString = "Logged-In As: ";
        private readonly string r_MessageAlbumsUnavailable = string.Format(
            "Albums are currently unavailable.{0}Please try again later.",
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
            m_UserDataManager = UserDataManager.Instance;
        }

        /// TODO: [buttonLogin_Click] See if at all possible to fetch User's Cover Picture.
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
                //this.pictureBoxCoverPic.Load(???);
                //toggleButtons(true);
                m_LastSelectedTab = tabPageNewsFeed;
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
                populateAndFetchUserFriends();
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

        /// TODO: [picBoxFriend_Click] Need Clear of FlowLayout Controls when choosing another friend.
        private void picBoxFriend_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            //User friend = m_UserDataManager.GetUserFriendByName(picBox.Name);
            User friend = picBox.Tag as User;
            if (friend != null)
            {
                if (m_IsFriendsPostsPopulated)
                {
                    this.flowLayoutPanelFriendsPosts.Controls.Clear();
                }
                this.pictureBoxFriendPic.Load(friend.PictureNormalURL);
                this.pictureBoxFriendPic.Visible = true;
                this.labelFriendName.Text = friend.Name;
                this.labelFriendName.Visible = true;
                this.labelFriendAbout.Visible = true;
                this.listBoxFriendAbout.Text = friend.About;
                this.listBoxFriendAbout.Visible = true;
                this.labelFriendsBirthday.Visible = true;
                this.textBoxFriendsBirthday.Text = friend.Birthday;
                this.textBoxFriendsBirthday.Visible = true;
                this.labelFriendPosts.Visible = true;

                foreach (Post post in friend.Posts)
                {
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelFriendsPosts.Controls.Add(postBox);
                }

                flowLayoutPanelFriendsPosts.Visible = true;
                m_IsPostsStatisticsPopulated = true;
            }
        }

        private void picBoxAlbum_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBoxSender = i_Sender as PictureBox;
            Album album = picBoxSender.Tag as Album;
            //User friend = m_UserDataManager.GetUserFriendByName(picBox.Name);
            if (album != null)
            {
                foreach (Photo photo in album.Photos)
                {
                    EventHandler picBoxPhotosAlbumPicClickEventHandler = new EventHandler(this.picBoxPhotosAlbumPic_Click);
                    PictureBox picBox = addPictureBoxToLayout(photo.Name, this.flowLayoutPanelFriends, picBoxPhotosAlbumPicClickEventHandler);
                    picBox.Tag = photo;
                    picBox.Load(photo.PictureNormalURL);
                }
                //this.pictureBoxFriendPic.Load(friend.PictureNormalURL);
                //this.labelFriendName.Text = friend.Name;
                //this.labelFriendName.Visible = true;
                //this.listBoxFriendAbout.Text = friend.About;
                //this.listBoxFriendAbout.Visible = true;
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

        private void richTextBox1_TextChanged(object i_Sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object i_Sender, EventArgs e)
        {

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

        private void populateNewsFeed()
        {
            if (this.flowLayoutPanelFeedPosts.Controls.Count == 0)
            {
                foreach (Post post in m_LoggedInUser.NewsFeed)
                {
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelFeedPosts.Controls.Add(postBox);
                }
            }
        }

        private void populateUserPosts()
        {
            if (this.flowLayoutPanelPosts.Controls.Count == 0)
            {
                foreach (Post post in m_LoggedInUser.Posts)
                {
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelPosts.Controls.Add(postBox);
                }
            }
        }

        private void populateAndFetchUserFriends()
        {
            if (this.flowLayoutPanelFriends.Controls.Count == 0)
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    m_UserDataManager.AddUserFriend(friend);
                    EventHandler  picBoxFriendClickEventHandler = new EventHandler(this.picBoxFriend_Click);
                    PictureBox picBox = addPictureBoxToLayout(friend.Name, this.flowLayoutPanelFriends, picBoxFriendClickEventHandler);
                    picBox.Tag = friend;
                    picBox.Load(friend.PictureNormalURL);
                }
            }
        }

        // FacebookWrapper Issue:
        // 'Facebook.FacebookOAuthException' occurred in Facebook.dll
        // Additional information: (OAuthException - #100) (#100) Tried accessing nonexisting field (likes) on node type (Album)
        // There for dummy data had to be used.
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
            // picBox.Click += new System.EventHandler(this.picBoxFriend_Click);
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
    }
}
