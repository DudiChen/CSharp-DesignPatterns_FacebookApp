using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookApp.Logic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public class PostsStatsGeneratorAdapter
    {
        private readonly PostsStatsGenerator r_PostsStatsGenerator;

        public PostsStatsGeneratorAdapter(FacebookObjectCollection<Post> i_Posts)
        {
            r_PostsStatsGenerator = new PostsStatsGenerator(i_Posts);
            r_PostsStatsGenerator.AnalyzePostsStatistics();
        }

        public string AvgLettersPerPost()
        {
            return string.Format("{0}", r_PostsStatsGenerator.AvgLettersPerPost);
        }

        public string PostsPerDay()
        {
            return string.Format("{0}", r_PostsStatsGenerator.AvgPostsPerDay);
        }

        public string LikesPerPost()
        {
            return string.Format("{0}", r_PostsStatsGenerator.AvgLikesPerPost);
        }

        public string PhotosPerPosts()
        {
            return string.Format("{0}%", r_PostsStatsGenerator.PercentageOfPostsWithPhotos);
        }

        public string TotalNumberOfLikes()
        {
            return string.Format("{0}", r_PostsStatsGenerator.TotalNumberOfLikes);
        }

        public Series PostsPerTimeOfDay()
        {
            Series result = new Series("Posts");

            for (int i = 0; i < r_PostsStatsGenerator.PostsPerHour.Length; i++)
            {
                // Cast time of day to string
                string createdTimeString = string.Format("{0}{1}:00", i < 10 ? "0" : string.Empty, i);
                //// this.chart_Likes_Time.Series["Posts"].Points.AddXY(createdTimeString, r_PostsStatsGenerator.PostsPerHour[i]);
                result.Points.AddXY(createdTimeString, r_PostsStatsGenerator.PostsPerHour[i]);
            }

            // Sort the graph in ascending order by X axis - Time of Day
            //// this.chart_Likes_Time.Series["Posts"].Sort(PointSortOrder.Ascending, "X");
            result.Sort(PointSortOrder.Ascending, "X");
            return result;
        }

        public Series LikesPerTimeOfDay()
        {
            Series result = new Series("Likes");
            foreach (PostMetaData post in r_PostsStatsGenerator.PostsMetaDataList)
            {
                string createdTimeString = string.Format("{0:H:mm}", post.PostCreationTime);
                //// POSSIBLE CHANGE:
                //// string createdTimeString = string.Format("{0}{1}:00", post.PostCreationTime.Hour < 10 ? "0" : string.Empty, post.PostCreationTime.Hour);
                result.Points.AddXY(createdTimeString, post.PostNumberOfLikes);
            }
            result.Sort(PointSortOrder.Ascending, "X");
            return result;
        }
    }
}
