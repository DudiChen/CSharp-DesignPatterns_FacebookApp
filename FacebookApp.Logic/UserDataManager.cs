using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Logic
{
    public sealed class UserDataManager
    {
        /// TODO: [UserDataManager] Review if any User Data Collection are not required and can be discarded.
        private static UserDataManager s_Instance = null;
        private static readonly object sr_CreationLock = new object();
        private readonly Dictionary<string, User> r_FriendsCollection;
        private readonly LinkedList<Post> r_UserPostsCollection;
        private readonly Dictionary<User, LinkedList<Post>> r_FriendsPostsCacheCollection;
        //private Dictionary<string, Post> r_UserPostsCollection;

        private UserDataManager()
        {
            r_FriendsCollection = new Dictionary<string, User>();
            r_UserPostsCollection = new LinkedList<Post>();
            //r_UserPostsCollection = new Dictionary<string, Post>();
            r_FriendsPostsCacheCollection = new Dictionary<User, LinkedList<Post>>();
        }

        public static UserDataManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_CreationLock)
                    {
                        if(s_Instance == null)
                        {
                            s_Instance = new UserDataManager();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public void AddUserFriend(User i_Friend)
        {
            r_FriendsCollection.Add(i_Friend.Name, i_Friend);
        }

        public void AddUserPost(Post i_Post)
        {
            r_UserPostsCollection.AddLast(i_Post);
        }

        public User GetUserFriendByName(string i_Name)
        {
            User result;
            if (r_FriendsCollection.TryGetValue(i_Name, out result))
                return result;
            else
                return null;
        }
    }
}
