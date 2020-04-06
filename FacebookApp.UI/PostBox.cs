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
        private LinkedList<ListViewItem> m_ListViewItemsCollection;
        public PostBox(Post i_Post)
        {
            InitializeComponent();
            m_ListViewItemsCollection = new LinkedList<ListViewItem>();
            m_Post = i_Post;
            loadImage(i_Post.From.PictureSmallURL);
            setTimeAndFromHeader(i_Post.CreatedTime, i_Post.From.Name);
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

            /// NOTE: This code was used with tryDownloadImage() to fetch images - if not useful, discard
            //if (m_Post.PictureURL != null)
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    Image img;
            //    if (tryDownloadImage(m_Post.PictureURL, out img))
            //    {
            //        ImageList imageList = new ImageList();
            //        imageList.Images.Add(img);
            //        //lvi.ImageList.Images.Add(img);
            //        lvi.ImageList = imageList;
            //        lvi.Tag = m_Post;
            //        m_ListViewItemsCollection.AddLast(lvi);
            //    }
            //}
        }

        /// TODO: [tryDownloadImage] Not in use anymore - see if useful or discard code.
        private bool tryDownloadImage(string i_ImageURL, out Image o_Image)
        {

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(i_ImageURL);
            MemoryStream ms = new MemoryStream(bytes);
            o_Image = System.Drawing.Image.FromStream(ms);
            ms.Dispose();
            return (o_Image != null);
        }

        /// TODO: [listViewPost_SelectedIndexChanged] Remove if not relevant anymore.
        private void listViewPost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonPostLikes_Click(object sender, EventArgs e)
        {
            this.richTextBoxComments.Visible = false;
            if (m_Post.LikedBy.Count > 0)
            {
                foreach (User userLiked in m_Post.LikedBy)
                {
                    this.richTextBoxLikes.AppendText(string.Format("{0}{1}", userLiked.Name, Environment.NewLine));
                }
            }
            this.richTextBoxLikes.Visible = true;
        }

        private void buttonPostComments_Click(object sender, EventArgs e)
        {
            this.richTextBoxLikes.Visible = false;
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
