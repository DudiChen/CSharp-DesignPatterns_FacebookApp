using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI.Builders
{
    public interface IPostBoxBuilder
    {       
        PostBox CreatedPostBox { get; }

        void AddPictureBox(string i_FromURL);

        void AddHeadline(string i_FromName);

        void AddContent();

        void AddLikes();

        void AddComments();

        void AddTextBox();
    }
}
