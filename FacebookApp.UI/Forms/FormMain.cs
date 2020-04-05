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
        private readonly string r_DefaultFormHeader = "Maor & Dudi's Facebook Application";
        private readonly string r_LoggedInString = "Logged-In As: ";
        private User m_LoggedInUser;
        private TabPage m_LastSelectedTab;

        public FormMain()
        {
            InitializeComponent();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
            m_ApplicationSettings = ApplicationSettings.Instance;
            m_LoginManager = LoginManager.Instance;
            m_UserDataManager = UserDataManager.Instance;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_LoginManager.Login();
            if (m_LoginManager.IsLoggedIn)
            {
                m_LoggedInUser = m_LoginManager.LoggedInUser;
                StringBuilder formHeader = new StringBuilder(r_LoggedInString);
                formHeader.Append(m_LoggedInUser.Name);
                this.Text = formHeader.ToString();
                //this.buttonLogin.BackColor = System.Drawing.SystemColors.Control;
                //this.buttonLogout.BackColor = System.Drawing.Color.Red;
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

        

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.tabControl1.SelectedTab.Name.Equals(tabPageNewsFeed.Name))
            {
                populateNewsFeed();
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPagePosts.Name))
            {
                
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPageFriends.Name))
            {
                fetchUserFriends();
            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPagePhotos.Name))
            {

            }
            else if (this.tabControl1.SelectedTab.Name.Equals(tabPagePostsStatistics.Name))
            {

            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void populateNewsFeed()
        {
            if (this.flowLayoutPanelFeedPosts.Controls.Count == 0)
            {
                foreach (Post post in m_LoggedInUser.NewsFeed)
                {
                    PostBox postBox = new PostBox(post);
                    this.flowLayoutPanelFeedPosts.Controls.Add(postBox);
                    //this.listViewFeedPosts.Items.Add
                }

            //if (this.listBoxFeedPosts.Items.Count == 0)
            //{
            //    foreach (Post post in m_LoggedInUser.NewsFeed)
            //    {
                    //if (post.Message != null || post.Description != null)
                    //{
                    //    StringBuilder postFromHeader = new StringBuilder();
                    //    postFromHeader.AppendFormat("[{0:dd/MM/yyyy H:mm:ss}] ", post.CreatedTime);
                    //    if (post.From != null && !string.IsNullOrEmpty(post.From.Name))
                    //    {
                    //        postFromHeader.AppendFormat("{0}", post.From.Name);
                    //        //this.listBoxFeedPosts.Items.Add(string.Format("From: {0}", post.From.Name));
                    //        this.listBoxFeedPosts.Items.Add(postFromHeader.ToString());
                    //    }

                    //    if (post.Message != null)
                    //    {
                    //        this.listBoxFeedPosts.Items.Add(post.Message);
                    //    }

                    //    if (post.Description != null)
                    //    {
                    //        this.listBoxFeedPosts.Items.Add(post.Description);
                    //    }

                    //    this.listBoxFeedPosts.Items.Add(string.Format("{0}", Environment.NewLine));
                //    }
                //}
            }
        }

        private void fetchUserFriends()
        {
            if (this.flowLayoutPanelFriends.Controls.Count == 0)
            {
                foreach (User friend in m_LoggedInUser.Friends)
                {
                    m_UserDataManager.AddUserFriend(friend);
                    addPictureBoxToLayout(friend.Name, this.flowLayoutPanelFriends).Load(friend.PictureNormalURL);
                }
            }
        }

        private PictureBox addPictureBoxToLayout(string i_PicName, Panel i_DestPanel)
        {
            PictureBox picBox = new PictureBox();
            picBox.Name = i_PicName;
            picBox.Size = new System.Drawing.Size(75, 75);
            picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picBox.Visible = true;
            picBox.Click += new System.EventHandler(this.picBoxFriend_Click);
            i_DestPanel.Controls.Add(picBox);
            return picBox;
        }

        private void picBoxFriend_Click(object i_Sender, EventArgs e)
        {
            PictureBox picBox = i_Sender as PictureBox;
            User friend = m_UserDataManager.GetUserFriendByName(picBox.Name);
            if (friend != null)
            {
                this.pictureBoxFriendPic.Load(friend.PictureNormalURL);
                this.labelFriendName.Text = friend.Name;
                this.labelFriendName.Visible = true;
                this.listBoxFriendAbout.Text = friend.About;
                this.listBoxFriendAbout.Visible = true;
            }
            //if (m_LoggedInUser.Friends.Contains())
            //{

            //}
        }

        private void toggleAllControllers(bool i_ToggleMode)
        {
            this.pictureBoxProfilePic.Enabled = i_ToggleMode;
            this.tabControl1.Enabled = i_ToggleMode;
            this.buttonLogout.Enabled = i_ToggleMode;
            this.labelUserName.Enabled = i_ToggleMode;
            this.buttonLogin.Enabled = !i_ToggleMode;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
