using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public partial class PostBox : UserControl
    {
        private Post m_Post;
        private readonly string r_MessageLikesUnavailable = string.Format(
        "Posts Likes are currently unavailable.{0}Please try again later.",
        Environment.NewLine);
        private readonly string r_MessageCommentsUnavailable = string.Format(
            "Posts Comments are currently unavailable.{0}Please try again later.",
            Environment.NewLine);
        private readonly string r_MessageErrorOccuredTitle = "Error Occured";
        private string m_FromName = string.Empty;

        public PostBox(Post i_Post)
        {
            InitializeComponent();
            m_Post = i_Post;

            if (i_Post.From != null)
            {
                m_FromName = i_Post.From.Name;
                loadImage(i_Post.From.PictureSmallURL);
            }
            
            setTimeAndFromHeader(i_Post.CreatedTime, m_FromName);
            insertPostContent();
        }

        private void loadImage(string i_ImageURL)
        {
            this.pictureBoxPostProfilePic.Load(i_ImageURL);
        }

        private void setTimeAndFromHeader(DateTime? i_TimePosted, string i_FromPosted)
        {
            StringBuilder timeAndFromHeader = new StringBuilder();
            if (i_TimePosted != null)
            {
                timeAndFromHeader.AppendFormat("[{0:dd/MM/yyyy H:mm:ss}] ", i_TimePosted);
            }

            timeAndFromHeader.AppendFormat("{0}", i_FromPosted);

            this.labelPostTimeAndFrom.Text = timeAndFromHeader.ToString();
        }

        private void insertPostContent()
        {
            if (m_Post.Message != null)
            {
                this.richTextBoxPost.AppendText(string.Format("{0}{1}{1}", m_Post.Message, Environment.NewLine));
            }

            if (m_Post.Description != null)
            {
                this.richTextBoxPost.AppendText(string.Format("{0}{1}{1}", m_Post.Description, Environment.NewLine));
            }
        }

        private void buttonPostLikes_Click(object i_Sender, EventArgs e)
        {
            this.richTextBoxComments.Visible = false;
            try
            {
                if (m_Post.LikedBy.Count > 0)
                {
                    foreach (User userLiked in m_Post.LikedBy)
                    {
                        this.richTextBoxLikes.AppendText(string.Format("{0}{1}", userLiked.Name, Environment.NewLine));
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(r_MessageLikesUnavailable, r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.richTextBoxLikes.Visible = true;
        }

        private void buttonPostComments_Click(object i_Sender, EventArgs e)
        {
            this.richTextBoxLikes.Visible = false;
            try
            {
                if (m_Post.Comments.Count > 0)
                {
                    foreach (Comment comment in m_Post.Comments)
                    {
                        string createTimeString = formatDateTime(comment.CreatedTime);
                        this.richTextBoxLikes.AppendText(string.Format("{0} {1}:{2}{3}{2}",
                            createTimeString,
                            comment.From.Name,
                            Environment.NewLine,
                            comment.Message));
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(r_MessageCommentsUnavailable, r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.richTextBoxLikes.Visible = true;
        }

        private string formatDateTime(DateTime? i_dateTime)
        {
            if (i_dateTime != null)
            {
                return string.Format("[{0:dd/MM/yyyy H:mm:ss}]", i_dateTime);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
