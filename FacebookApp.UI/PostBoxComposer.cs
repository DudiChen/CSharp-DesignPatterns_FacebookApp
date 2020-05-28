using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.UI
{
    public class PostBoxComposer
    {
        #region Fields

        #region Const
        private static readonly string r_MessageLikesUnavailable = string.Format(
            "Posts Likes are currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private static readonly string r_MessageCommentsUnavailable = string.Format(
            "Posts Comments are currently unavailable.{0}Please try again later.",
            Environment.NewLine);

        private static readonly string r_MessageErrorOccuredTitle = "Error Occured";
        #endregion

        #endregion

        #region Constructor
        private PostBoxComposer()
        {

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Generate a PostBox using Builder Pattern
        /// </summary>
        /// <param name="i_Post"></param>
        /// <returns></returns>
        public static PostBox Generate(Post i_Post)
        {
            PostBox result = new PostBox();
            CreateView(ref result);
            result.Controls.Add(CreatePicture(i_Post));
            result.Controls.Add(CreateHeadline(i_Post));
            result.Controls.Add(CreateContent(i_Post));
            result.Controls.Add(CreateLikeCommentsTextbox(ref result, i_Post));
            result.Controls.Add(CreateLikes(i_Post, result.TxtboxLikesComments));
            result.Controls.Add(CreateComments(i_Post, result.TxtboxLikesComments));

            return result;
        }
        #endregion

        #region Private Methods

        private static PictureBox CreatePicture(Post i_Post)
        {
            PictureBox result = new PictureBox();

            result.Location = new System.Drawing.Point(3, 3);
            result.Margin = new System.Windows.Forms.Padding(2);
            result.Name = "m_Pic";
            result.Size = new System.Drawing.Size(38, 30);
            result.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            result.TabIndex = 0;
            result.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)(result)).BeginInit();

            return result;
        }

        private static Label CreateHeadline(Post i_Post)
        {
            Label result = new Label();

            result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            result.Location = new System.Drawing.Point(45, 11);
            result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            result.Name = "m_Headline";
            result.Size = new System.Drawing.Size(379, 22);
            result.Text = CreateHeadline_Value(i_Post.CreatedTime, i_Post.From.Name);

            return result;
        }

        private static RichTextBox CreateContent(Post i_Post)
        {
            RichTextBox result = new RichTextBox();

            result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            result.Location = new System.Drawing.Point(0, 36);
            result.Margin = new System.Windows.Forms.Padding(2);
            result.Name = "m_Content";
            result.ReadOnly = true;
            result.Size = new System.Drawing.Size(424, 107);
            result.TabIndex = 2;
            result.Text = CreateContent_Value(i_Post);

            return result;
        }

        private static RichTextBox CreateLikeCommentsTextbox(ref PostBox i_View, Post i_Post)
        {
            RichTextBox result = new RichTextBox();

            result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            result.Location = new System.Drawing.Point(424, 36);
            result.Margin = new System.Windows.Forms.Padding(2);
            result.Name = "m_TxtboxLikesComments";
            result.Size = new System.Drawing.Size(188, 107);
            result.TabIndex = 5;
            result.Text = "";

            i_View.TxtboxLikesComments = result;
            return result;
        }

        private static Button CreateLikes(Post i_Post, RichTextBox i_ControlToFil)
        {
            Button result = new Button();

            result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            result.Location = new System.Drawing.Point(424, 11);
            result.Margin = new System.Windows.Forms.Padding(2);
            result.Name = "m_Likes";
            result.Size = new System.Drawing.Size(84, 22);
            result.TabIndex = 3;
            result.Text = "Likes";
            result.UseVisualStyleBackColor = true;
            result.Click += ((sender, e) =>
            {
                try
                {
                    i_ControlToFil.Clear();
                    foreach(User user in i_Post.LikedBy)
                    {
                        i_ControlToFil.AppendText(string.Format("{0}{1}", user.Name, Environment.NewLine));
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                    r_MessageLikesUnavailable,
                    r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            });
            return result;
        }

        private static Button CreateComments(Post i_Post, RichTextBox i_ControlToFill)
        {
            Button result = new Button();

            result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            result.Location = new System.Drawing.Point(527, 11);
            result.Margin = new System.Windows.Forms.Padding(2);
            result.Name = "m_Comments";
            result.Size = new System.Drawing.Size(84, 22);
            result.TabIndex = 4;
            result.Text = "Comments";
            result.UseVisualStyleBackColor = true;
            result.Click += ((sender, e) =>
            {
                try
                {
                    i_ControlToFill.Clear();
                    foreach (Comment comment in i_Post.Comments)
                    {
                        i_ControlToFill.AppendText(
                            string.Format(
                                "{0} {1}:{2}{3}{2}",
                                CreateComments_Value(comment.CreatedTime),
                                comment.From.Name,
                                Environment.NewLine,
                                comment.Message));
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show(
                    r_MessageCommentsUnavailable,
                    r_MessageErrorOccuredTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            });

            return result;
        }

        private static void CreateView(ref PostBox i_View)
        {
            i_View.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            i_View.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            i_View.Margin = new System.Windows.Forms.Padding(2);
            i_View.Name = "PostBox";
            i_View.Size = new System.Drawing.Size(614, 142);
            i_View.ResumeLayout(false);
        } 

        #region Helpers
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
        #endregion

        #endregion

    }
}
