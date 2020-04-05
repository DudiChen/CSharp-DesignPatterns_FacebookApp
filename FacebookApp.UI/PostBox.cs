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
            insertContent();
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

        private void insertContent()
        {
            createPostImageViewItems();
            insertPostImageViewItems();
        }

        private void createPostImageViewItems()
        {
            if (m_Post.Message != null)
            {
                ListViewItem lvi = new ListViewItem(m_Post.Message);
                lvi.Tag = m_Post;
                m_ListViewItemsCollection.AddLast(lvi);
            }

            if (m_Post.Description != null)
            {
                ListViewItem lvi = new ListViewItem(m_Post.Description);
                lvi.Tag = m_Post;
                m_ListViewItemsCollection.AddLast(lvi);
            }

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

        private void insertPostImageViewItems()
        {
            //this.listViewPost.FullRowSelect = true;
            //this.listViewPost.GridLines = true;
            foreach (ListViewItem lvi in m_ListViewItemsCollection)
            {
                //this.listViewPost.Items.Add(lvi);
                TextBox tB = new TextBox();
                //tB.Text = lvi.SubItems[0].Text;
                //this.flowLayoutPanelPost.Controls.Add(tB);
                this.dataGridView1.Rows.Add(lvi.SubItems[0].Text);
            }
        }

        private bool tryDownloadImage(string i_ImageURL, out Image o_Image)
        {

            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(i_ImageURL);
            MemoryStream ms = new MemoryStream(bytes);
            ////Image img = System.Drawing.Image.FromStream(ms);
            o_Image = System.Drawing.Image.FromStream(ms);
            ms.Dispose();
            return (o_Image != null);
            ////return img;
        }

        private void listViewPost_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
