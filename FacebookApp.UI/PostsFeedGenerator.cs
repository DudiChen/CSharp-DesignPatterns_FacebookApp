using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Logic
{
    /// TODO: [PostsFeedGenerator] Verify if Class required or can be removed.
    public static class PostsFeedGenerator
    {
        public static ListView CreateFeed(LinkedList<Post> i_PostsCollection)
        {
            ListView result = new ListView();

            foreach (Post post in i_PostsCollection)
            {
                ListViewItem postHeader = new ListViewItem();
            }

            return result;
        }
    }
}
