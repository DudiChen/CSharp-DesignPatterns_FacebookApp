using System;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public partial class PostBox : UserControl
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

        //private System.Windows.Forms.PictureBox m_Picture;
        //private System.Windows.Forms.Label m_Headline;
        //private System.Windows.Forms.RichTextBox m_Content;
        //private System.Windows.Forms.Button m_Likes;
        //private System.Windows.Forms.Button m_Comments;
        private System.Windows.Forms.RichTextBox m_TxtboxLikesComments;
        //private System.Windows.Forms.BindingSource m_BinddingDataPost;

        #endregion

        #region Properties

        //public PictureBox Picture { get => m_Picture; set => m_Picture = value; }
        //public Label Headline { get => m_Headline; set => m_Headline = value; }
        //public RichTextBox Content { get => m_Content; set => m_Content = value; }
        //public Button Likes { get => m_Likes; set => m_Likes = value; }
        //public Button Comments { get => m_Comments; set => m_Comments = value; }
        //public BindingSource BinddingDataPost { get => m_BinddingDataPost; set => m_BinddingDataPost = value; }
        public RichTextBox TxtboxLikesComments
        {
            get
            {
                return m_TxtboxLikesComments;
            }
            set
            {
                m_TxtboxLikesComments = value;
            }
        }

        #endregion

        #region Constructor
        public PostBox()
        {
            
        }
        #endregion
    }
}
