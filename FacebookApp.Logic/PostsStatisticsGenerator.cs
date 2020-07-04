using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Logic
{
    public class PostsStatisticsGenerator : IEnumerable<PostMetaData>
    {
        private FacebookObjectCollection<Post> m_Posts;

        private uint m_NumberOfPostsWithPhotos = 0;

        private List<PostMetaData> PostsMetaDataList;

        public uint[] PostsPerHour { get; private set; }

        public uint TotalNumberOfLikes { get; private set; }

        public double AvgLettersPerPost { get; private set; }

        public double AvgPostsPerDay { get; private set; }

        public double AvgLikesPerPost { get; private set; }

        public double PercentageOfPostsWithPhotos { get; private set; }

        public PostsStatisticsGenerator(FacebookObjectCollection<Post> i_Posts)
        {
            m_Posts = i_Posts;
            PostsMetaDataList = new List<PostMetaData>();
            PostsPerHour = new uint[24];
            for (int i = 0; i < PostsPerHour.Length; i++)
            {
                PostsPerHour[i] = 0;
            }
        }

        private void fetchPostsMetaData()
        {
            foreach(Post post in m_Posts)
            {
                DateTime createdTime = GetPostCreatedTime(post);
                uint length = post.Message != null ? (uint)post.Message.Length : 0;
                uint likes = GetPostNumberOfLikes(post);
                if (post.PictureURL != null)
                {
                    m_NumberOfPostsWithPhotos++;
                }

                PostsMetaDataList.Add(new PostMetaData(createdTime, likes, length));
                TotalNumberOfLikes += likes;
                PostsPerHour[createdTime.Hour]++;
            }

            PostsMetaDataList.Sort((PostMetaData i_Post1, PostMetaData i_Post2) => DateTime.Compare(i_Post1.PostCreationTime, i_Post2.PostCreationTime));
        }

        public void AnalyzePostsStatistics()
        {
            fetchPostsMetaData();
            calcAvgNumberOfLettersInPosts();
            calcAvgPostsPerDay();
            calcAvgLikesPerPost();
            calcPercentageOfPostsWithPhotos();
        }

        #region Logic Methods
        protected /*virtual*/ DateTime GetPostCreatedTime(Post i_Post)
        {   // TODO: remove comme   nt if we found better TemplateMethod implementation
            DateTime result;
            try
            {
                // if Facebook allow, get post's created time,
                result = (DateTime)i_Post.CreatedTime;
            }
            catch (Exception)
            {
                // if not, insert Random Time between 01/01/2000 10:00 to now,
                result = DummyDataGenerator.GetRandomDateTime(new DateTime(2000, 01, 01, 10, 00, 00), DateTime.Now);
            }

            return result;
        }

        private uint GetPostNumberOfLikes(Post i_Post)
        {
            uint result;
            try
            {
                // if Facebook allow, get post's number of likes
                result = (uint)i_Post.LikedBy.Count;
            }
            catch (Exception)
            {
                // else, insert a random number between 0 to 150
                result = DummyDataGenerator.GetRandomUnsignedNumber(150);
            }

            return result;
        }

        private void calcAvgNumberOfLettersInPosts()
        {
            AvgLettersPerPost = 0;
            if (PostsMetaDataList.Count > 0)
            {
                long sumPostsLength = 0;
                foreach (PostMetaData post in PostsMetaDataList)
                {
                    // Add the Length of all the user's posts
                    sumPostsLength += post.PostLength;
                }

                // divide by the number of posts he wrote
                AvgLettersPerPost = sumPostsLength / PostsMetaDataList.Count;
            }
        }

        private void calcAvgLikesPerPost()
        {
            AvgLikesPerPost = 0;
            if (PostsMetaDataList.Count > 0)
            {
                AvgLikesPerPost = TotalNumberOfLikes / PostsMetaDataList.Count;
            }
        }

        private void calcAvgPostsPerDay()
        {
            DateTime userFirstPostTime = PostsMetaDataList[0].PostCreationTime;
            AvgPostsPerDay = PostsMetaDataList.Count / (DateTime.Now - userFirstPostTime).TotalDays;
        }

        private void calcPercentageOfPostsWithPhotos()
        {
            PercentageOfPostsWithPhotos = ((double)m_NumberOfPostsWithPhotos / (double)PostsMetaDataList.Count) * 100;
        }

        public IEnumerator<PostMetaData> GetEnumerator()
        {
            return PostsMetaDataList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }

    //public class PostsStatisticsGeneratorForAmericans : PostsStatisticsGenerator
    //{
    //    public PostsStatisticsGeneratorForAmericans(FacebookObjectCollection<Post> i_Posts) : base(i_Posts) 
    //    {
    //
    //    }
    //
    //    protected override DateTime GetPostCreatedTime(Post i_Post)
    //    {
    //        DateTime result;
    //        try
    //        {
    //            // if Facebook allow, get post's created time,
    //            result = (DateTime)i_Post.CreatedTime;
    //        }
    //        catch (Exception)
    //        {
    //            // if not, insert Random Time between 01/01/2000 10:00 to now,
    //            result = DummyDataGenerator.GetRandomDateTime(new DateTime(2000, 01, 01, 10, 00, 00), DateTime.Now);
    //        }
    //
    //        return result;
    //    }
    //}
}
