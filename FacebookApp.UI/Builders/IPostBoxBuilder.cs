using FacebookWrapper.ObjectModel;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.UI.Builders
{
    public interface IPostBoxBuilder
    {       
        PostBox CreatedPostBox { get; }

        //void AddPictureBox();
        void AddPictureBox(string i_FromURL);
        //void AddHeadline();
        void AddHeadline(string i_FromName);
        void AddContent();
        void AddLikes();
        void AddComments();
        void AddTextBox();
    }
}
