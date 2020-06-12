using System;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    /// <summary>
    /// A standart Post UI
    /// 
    /// In Builder Patters PostBox is the 'Product'
    /// </summary>
    public partial class PostBox : UserControl
    {
        #region Fields

        private System.Windows.Forms.PictureBox m_Picture;
        private System.Windows.Forms.Label m_Headline;
        private System.Windows.Forms.RichTextBox m_Content;
        private System.Windows.Forms.Button m_Likes;
        private System.Windows.Forms.Button m_Comments;
        private System.Windows.Forms.RichTextBox m_TxtboxLikesComments;
        private System.Windows.Forms.BindingSource m_BinddingDataPost;

        #endregion

        #region Properties
        
        public PictureBox Picture
        {
            get
            {
                return m_Picture;
            }
            set
            {
                m_Picture = value;
                this.Controls.Add(m_Picture);
            }
        }
        public Label Headline
        {
            get
            {
                return m_Headline;
            }
            set
            {
                m_Headline = value;
                this.Controls.Add(m_Headline);
            }
        }
        public RichTextBox Content
        {
            get
            {
                return m_Content;
            }
            set 
            { 
                m_Content = value;
                this.Controls.Add(m_Content);
            }
        }
        public Button Likes
        {
            get
            {
                return m_Likes;
            }
            set
            {
                m_Likes = value;
                this.Controls.Add(m_Likes);
            }
        }
        public Button Comments
        {
            get
            {
                return m_Comments;
            }
            set
            {
                m_Comments = value;
                this.Controls.Add(m_Comments);
            }
        }
        public RichTextBox TxtboxLikesComments
        {
            get
            {
                return m_TxtboxLikesComments;
            }
            set
            {
                m_TxtboxLikesComments = value;
                this.Controls.Add(m_TxtboxLikesComments);
            }
        }
        //public BindingSource BinddingDataPost { get => m_BinddingDataPost; set => m_BinddingDataPost = value; }
        #endregion

        #region Constructor
        public PostBox()
        {
            
        }
        #endregion
    }
}
