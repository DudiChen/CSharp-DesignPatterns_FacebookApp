using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using FacebookWrapper;
using System.Windows.Forms;

namespace DP._313543696._300334034
{
    // Facebook AppID: 1089225541443714
    //
    // UserName: design.patterns
    // Password: design.patternsb20b
    //
    //public partial class MainWin : Form
    //{
    //    #region Data Members
    //    private readonly string AppID = "1089225541443714";
    //    private FacebookWrapper.LoginResult m_LoginResult;
    //    private FacebookWrapper.ObjectModel.User m_LoggedInUser;
    //    #endregion

    //    #region Ctor
    //    public MainWin()
    //    {
    //        InitializeComponent();
    //    }
    //    #endregion

    //    #region Events
    //    /// <summary>
    //    /// When LogIn Button was clicked,
    //    /// Sending a log in Request to Facebook
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void stripBtn_LogIn_Click(object sender, EventArgs e)
    //    {
    //        m_LoginResult = FacebookService.Login(AppID, "user_photos, user_posts, user_friends, user_likes");

    //        if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
    //        {
    //            m_LoggedInUser = m_LoginResult.LoggedInUser;
    //            LoggedIn();
    //        }
    //        else
    //        {
    //            DialogResult input = MessageBox.Show(m_LoginResult.ErrorMessage, "Failed", MessageBoxButtons.RetryCancel);
    //            if (input == DialogResult.Retry)
    //                stripBtn_LogIn_Click(sender, e);
    //        }
    //    }

    //    /// <summary>
    //    /// When LogOut Button was clicked,
    //    /// clearing the MainWin Form, and deleting the Login Result
    //    /// </summary>
    //    /// <param name="sender"></param>
    //    /// <param name="e"></param>
    //    private void stripBtn_LogOut_Click(object sender, EventArgs e)
    //    {
    //        m_LoginResult = new LoginResult();
    //        m_LoggedInUser = new FacebookWrapper.ObjectModel.User();
    //        LoggedOut();
    //    }
    //    #endregion

    //    #region Private Methods
    //    private void LoggedIn()
    //    {
    //        this.Text = "Logged In As: " + m_LoggedInUser.Name;
    //        this.lbl_UserName.Text = m_LoggedInUser.Name;
    //        this.lbl_UserName.Visible = true;
    //        pic_ProfilePic.Load(m_LoggedInUser.PictureLargeURL);
    //        EnablingAllButtons(true);
    //    }

    //    private void LoggedOut()
    //    {
    //        this.Text = "Maor & Dudi's Facebook App";
    //        this.lbl_UserName.Visible = false;
    //        pic_ProfilePic.Image.Dispose();
    //        pic_ProfilePic.Image = null;
    //        EnablingAllButtons(false);
    //    }

    //    private void EnablingAllButtons(bool i_toEnable)
    //    {
    //        this.btn_Posts.Enabled = true;
    //        this.btn_Pictures.Enabled = true;
    //        this.btn_Freinds.Enabled = true;
    //    }
    //    #endregion

    //    private void btn_Posts_Click(object sender, EventArgs e)
    //    {
    //        PostsView posts = new PostsView(m_LoggedInUser);
    //        this.btn_Posts.ForeColor = Color.Green;
    //        posts.ShowDialog();
    //    }

    //    private void btn_Freinds_Click(object sender, EventArgs e)
    //    {
    //        FriendsView friends = new FriendsView(m_LoggedInUser);
    //        this.btn_Freinds.ForeColor = Color.Green;
    //        friends.ShowDialog();
    //    }
    //}
}
