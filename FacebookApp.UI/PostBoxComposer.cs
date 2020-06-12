using System;
using FacebookApp.UI.Builders;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public class PostBoxComposer
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
