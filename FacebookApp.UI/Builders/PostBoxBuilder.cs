using System;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI.Builders
{
    internal class PostBoxBuilder : IPostBoxBuilder
    {
        #region Fields

        #region ReadOnly
        private static readonly string r_MessageLikesUnavailable = string.Format(
            "Posts Likes are currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private static readonly string r_MessageCommentsUnavailable = string.Format(
            "Posts Comments are currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private static readonly string r_MessageErrorOccuredTitle = "Error Occured";
        #endregion

        private Post m_Post;
        private PostBox m_PostBox;

        #endregion

        #region Properties
        public PostBox CreatedPostBox
        { 
            get
            {
                return m_PostBox;
            }
        }
        #endregion

        #region Constructor
        public PostBoxBuilder(Post i_Post)
        {
            m_Post = i_Post;
            m_PostBox = new PostBox();
            defineView(m_PostBox);
        }
        #endregion

        #region Public Methods

        public void AddPictureBox(string i_FromURL)
        {
            PictureBox picBox = new PictureBox();
            picBox.Location = new System.Drawing.Point(3, 3);
            picBox.Margin = new System.Windows.Forms.Padding(2);
            picBox.Name = "m_Pic";
            picBox.Size = new System.Drawing.Size(38, 30);
            picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 0;
            picBox.TabStop = false;
            picBox.Load(i_FromURL);
            m_PostBox.Picture = picBox;
        }

        public void AddHeadline(string i_FromName)
        {
            Label headline = new Label();
            headline.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right);
            headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            headline.Location = new System.Drawing.Point(45, 11);
            headline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            headline.Name = "m_Headline";
            headline.Size = new System.Drawing.Size(379, 22);
            headline.Text = CreateHeadline_Value(m_Post.CreatedTime, i_FromName);   // This line throw Exception when asking posts from 'Friends' tab
            m_PostBox.Headline = headline;
        }

        public void AddContent()
        {
            RichTextBox content = new RichTextBox();

            content.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right);
            content.Location = new System.Drawing.Point(0, 36);
            content.Margin = new System.Windows.Forms.Padding(2);
            content.Name = "m_Content";
            content.ReadOnly = true;
            content.Size = new System.Drawing.Size(424, 107);
            content.TabIndex = 2;
            content.Text = CreateContent_Value(m_Post);

            m_PostBox.Content = content;
        }

        public void AddTextBox()
        {
            RichTextBox textBox = new RichTextBox();

            textBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right);
            textBox.Location = new System.Drawing.Point(424, 36);
            textBox.Margin = new System.Windows.Forms.Padding(2);
            textBox.Name = "m_TxtboxLikesComments";
            textBox.Size = new System.Drawing.Size(188, 107);
            textBox.TabIndex = 5;
            textBox.Text = string.Empty;

            m_PostBox.TxtboxLikesComments = textBox;
        }

        public void AddLikes()
        {
            Button btnLikes = new Button();

            btnLikes.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right);
            btnLikes.Location = new System.Drawing.Point(424, 11);
            btnLikes.Margin = new System.Windows.Forms.Padding(2);
            btnLikes.Name = "m_Likes";
            btnLikes.Size = new System.Drawing.Size(84, 22);
            btnLikes.TabIndex = 3;
            btnLikes.Text = "Likes";
            btnLikes.UseVisualStyleBackColor = true;
            btnLikes.Click += (sender, e) =>
            {
                m_PostBox.TxtboxLikesComments.Clear();
                try
                {
                    foreach (User user in m_Post.LikedBy)
                    {
                        m_PostBox.TxtboxLikesComments.AppendText(string.Format("{0}{1}", user.Name, Environment.NewLine));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(
                    r_MessageLikesUnavailable,
                    r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            };

            m_PostBox.Likes = btnLikes;
        }

        public void AddComments()
        {
            Button btnComments = new Button();

            btnComments.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right);
            btnComments.Location = new System.Drawing.Point(527, 11);
            btnComments.Margin = new System.Windows.Forms.Padding(2);
            btnComments.Name = "m_Comments";
            btnComments.Size = new System.Drawing.Size(84, 22);
            btnComments.TabIndex = 4;
            btnComments.Text = "Comments";
            btnComments.UseVisualStyleBackColor = true;
            btnComments.Click += (sender, e) =>
            {
                try
                {
                    m_PostBox.TxtboxLikesComments.Clear();
                    foreach (Comment comment in m_Post.Comments)
                    {
                        m_PostBox.TxtboxLikesComments.AppendText(
                            string.Format(
                                "{0} {1}:{2}{3}{2}",
                                CreateComments_Value(comment.CreatedTime),
                                comment.From.Name,
                                Environment.NewLine,
                                comment.Message));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(
                    r_MessageCommentsUnavailable,
                    r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            };

            m_PostBox.Comments = btnComments;
        }

        #endregion

        #region Private Methods
        private static string CreateHeadline_Value(DateTime? i_TimePosted, string i_FromPosted)
        {
            StringBuilder timeAndFromHeader = new StringBuilder();
            if (i_TimePosted != null)
            {
                timeAndFromHeader.AppendFormat("[{0:dd/MM/yyyy H:mm:ss}] ", i_TimePosted);
            }

            timeAndFromHeader.AppendFormat("{0}", i_FromPosted);

            return timeAndFromHeader.ToString();
        }

        private static string CreateContent_Value(Post i_Post)
        {
            string result = string.Empty;

            if (i_Post.Message != null)
            {
                result += string.Format("{0}{1}{1}", i_Post.Message, Environment.NewLine);
            }

            if (i_Post.Description != null)
            {
                result += string.Format("{0}{1}{1}", i_Post.Description, Environment.NewLine);
            }

            return result;
        }

        private static string CreateComments_Value(DateTime? i_dateTime)
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

        private void defineView(PostBox i_View)
        {
            i_View.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            i_View.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            i_View.Margin = new System.Windows.Forms.Padding(2);
            i_View.Name = "PostBox";
            i_View.Size = new System.Drawing.Size(614, 142);
            i_View.Dock = DockStyle.Bottom;
            i_View.ResumeLayout(false);
        }
        #endregion
    }
}
