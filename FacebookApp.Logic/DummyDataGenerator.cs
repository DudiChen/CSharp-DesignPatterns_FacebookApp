using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Logic
{
    public static class DummyDataGenerator
    {
        static readonly Random sr_RandomGenerator = new Random();

        public static double AvgNumberOfLettersInPosts(FacebookObjectCollection<Post> i_PostsCollection)
        {
            double result = 0;
            foreach (Post post in i_PostsCollection)
            {
                if (post.Message != null)
                    result += post.Message.Length;
            }
            result /= i_PostsCollection.Count;

            return result;
        }

        public static double AvgLikesPerPost(FacebookObjectCollection<Post> i_PostsCollection)
        {
            double result = 0;

            foreach (var post in i_PostsCollection)
            {
                // Doesnt let see the like list
                //result += post.LikedBy.Count;
                result += GetRandomUnsignedNumber(250);
            }
            result /= i_PostsCollection.Count;

            return result;
        }

        public static double AvgPostsPerDay(FacebookObjectCollection<Post> i_PostsCollection)
        {
            double result = 0;
            DateTime createdUser = new DateTime(0);

            /*foreach (var album in m_LoggedInUser.Albums)
            {
                if (album.Name == "Profile Pictures")
                    createdUser = album.CreatedTime.Value;
            }*/
            result = sr_RandomGenerator.NextDouble();
            if (createdUser.Ticks != 0)
            {
                result = i_PostsCollection.Count / (DateTime.Now - createdUser).Days;
            }

            return result;
        }

        public static double PresentageOfPostsWithPhotos(FacebookObjectCollection<Post> i_PostsCollection)
        {
            double result = 0;
            foreach (var post in i_PostsCollection)
            {
                if (post.PictureURL != null)
                    result++;
            }
            return result / (i_PostsCollection.Count) * 100;
        }

        public static double TotalNumberOfLikes(FacebookObjectCollection<Post> i_PostsCollection)
        {
            double result = 0;
            foreach (var post in i_PostsCollection)
            {
                //result += post.LikedBy.Count;
                result += GetRandomUnsignedNumber(150);
            }
            return result;
        }

        public static DateTime GetRandomDateTime(DateTime i_From, DateTime i_To)
        {
            TimeSpan range = new TimeSpan(i_To.Ticks - i_From.Ticks);
            return (i_From + new TimeSpan((long)(range.Ticks * sr_RandomGenerator.NextDouble())));
        }

        public static uint GetRandomUnsignedNumber(int i_Capacity = 150)
        {
            return (uint)(sr_RandomGenerator.Next(0, i_Capacity + 1));
        }
    }
}
