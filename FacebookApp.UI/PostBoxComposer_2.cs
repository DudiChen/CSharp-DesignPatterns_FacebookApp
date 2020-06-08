using FacebookApp.UI.Builders;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.UI
{
    class PostBoxComposer_2
    {
        public void ConstructPostBox(IPostBoxBuilder i_Builder, User i_From) 
        {
            i_Builder.AddPictureBox(i_From.PictureSmallURL);
            i_Builder.AddHeadline(i_From.Name);
            i_Builder.AddContent();
            i_Builder.AddTextBox();
            i_Builder.AddLikes();
            i_Builder.AddComments();
        }
    }
}
