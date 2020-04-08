using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FacebookApp.Logic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public class PostsStatisticsGenerator
    {
        private User m_LoggedInUser;
        private Chart chart_Likes_Time;
        private TextBox txt_LetterPerPost;
        private TextBox txt_PostsPerDay;
        private TextBox txt_LikesPerPost;
        private TextBox txt_PhotosInPosts;
        private TextBox txt_TotalLikes;

        public PostsStatisticsGenerator(
            User i_LoggedInUser,
            Chart i_ChartPostsStatistics,
            TextBox i_TextBoxLettersPerPost,
            TextBox i_TextBoxPostsPerDay,
            TextBox i_TextBoxLikesPerPost,
            TextBox i_TextBoxPhotosInPosts,
            TextBox i_TextBoxTotalLikes)
        {
            m_LoggedInUser = i_LoggedInUser;
            chart_Likes_Time = i_ChartPostsStatistics;
            txt_LetterPerPost = i_TextBoxLettersPerPost;
            txt_PostsPerDay = i_TextBoxPostsPerDay;
            txt_LikesPerPost = i_TextBoxLikesPerPost;
            txt_PhotosInPosts = i_TextBoxPhotosInPosts;
            txt_TotalLikes = i_TextBoxTotalLikes;
        }

        public void GenerateStatistics()
        {
            LoadChart_LikesPerTimeOfDay();
            LoadChart_PostsPerTimeOfDay();
            LoadGroup_Stats();
        }

        private void LoadChart_LikesPerTimeOfDay()
        {
            DateTime postsCreatedTime;
            string createdTimeAsString;
            uint postsNumberOfLikes;

            foreach (var post in m_LoggedInUser.Posts)
            {
                postsCreatedTime = GetPostsCreatedTime(post);
                postsNumberOfLikes = GetPostsNumberOfLikes(post);

                // Cast the CreatedTime's time of day to string: cuz the chart recives X axis values as strings
                createdTimeAsString = postsCreatedTime.Hour < 10 ? "0" + postsCreatedTime.Hour.ToString() : postsCreatedTime.Hour.ToString();
                createdTimeAsString += ":";
                createdTimeAsString += postsCreatedTime.Minute < 10 ? "0" + postsCreatedTime.Minute.ToString() : postsCreatedTime.Minute.ToString();

                this.chart_Likes_Time.Series["Likes"].Points.AddXY(createdTimeAsString, postsNumberOfLikes);
            }

            // Sort the graph in ascending order by X axis - Time of Day
            this.chart_Likes_Time.Series["Likes"].Sort(PointSortOrder.Ascending, "X");
        }

        private void LoadChart_PostsPerTimeOfDay()
        {
            string createdTimeAsString;
            uint[] postsInHour = new uint[24];

            // fill array with zeros
            for (int i = 0; i < 24; i++)
            {
                postsInHour[i] = 0;
            }

            foreach (var post in m_LoggedInUser.Posts)
            {
                // count how many posts user wrote in each hour of the day
                postsInHour[post.CreatedTime.Value.Hour]++;
            }

            for (int i = 0; i < postsInHour.Length; i++)
            {
                // Cast time of day to string
                createdTimeAsString = i < 10 ? "0" + i + ":00" : i + ":00";
                this.chart_Likes_Time.Series["Posts"].Points.AddXY(createdTimeAsString, postsInHour[i]);
            }

            // Sort the graph in ascending order by X axis - Time of Day
            this.chart_Likes_Time.Series["Posts"].Sort(PointSortOrder.Ascending, "X");

            // Insert this graph as a secondary line, with a unique Y axis to the main chart control
            CreateSecondYAxisScale(this.chart_Likes_Time, "Posts");
        }

        private void LoadGroup_Stats()
        {
            this.txt_LetterPerPost.Text = string.Format("{0}", AvgNumberOfLettersInPosts());
            this.txt_PostsPerDay.Text = string.Format("{0}", AvgPostsPerDay());
            this.txt_LikesPerPost.Text = string.Format("{0}", AvgLikesPerPost());
            this.txt_PhotosInPosts.Text = string.Format("{0}%", PresentageOfPostsWithPhotos());
            this.txt_TotalLikes.Text = string.Format("{0}", TotalNumberOfLikes());
        }

        #region Logic Methods
        private DateTime GetPostsCreatedTime(Post i_Post)
        {
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

        private uint GetPostsNumberOfLikes(Post i_Post)
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

        private double AvgNumberOfLettersInPosts()
        {
            double result = 0;
            try
            {
                foreach (var post in m_LoggedInUser.Posts)
                {
                    // Add the Length of all the user's posts
                    if (post.Message != null)
                    {
                        result += post.Message.Length;
                    }
                }

                // divide by the number of posts he wrote
                result /= m_LoggedInUser.Posts.Count;
            }
            catch (Exception)
            {
                result = DummyDataGenerator.AvgNumberOfLettersInPosts(m_LoggedInUser.Posts);
            }

            return result;
        }

        private double AvgLikesPerPost()
        {
            double result = 0;

            try
            {
                foreach (var post in m_LoggedInUser.Posts)
                {
                    result += post.LikedBy.Count;
                    result += DummyDataGenerator.GetRandomUnsignedNumber(250);
                }

                result /= m_LoggedInUser.Posts.Count;
            }
            catch (Exception)
            {
                result = DummyDataGenerator.AvgLikesPerPost(m_LoggedInUser.Posts);
            }

            return result;
        }

        private double AvgPostsPerDay()
        {
            double result = 0;
            DateTime userCreatedDate = new DateTime(0);

            try
            {
                // we cant get when the user created the account,
                // but we can see when the album "Profile Pictures" was created,
                foreach (var album in m_LoggedInUser.Albums)
                {
                    if(album.Name == "Profile Pictures")
                    {
                        userCreatedDate = album.CreatedTime.Value;
                    }
                }

                result = m_LoggedInUser.Albums.Count / (DateTime.Now - userCreatedDate).Days;
            }
            catch (Exception)
            {
                result = DummyDataGenerator.AvgPostsPerDay(m_LoggedInUser.Posts);
            }

            return result;
        }

        private double PresentageOfPostsWithPhotos()
        {
            double result = 0;
            try
            {
                foreach (var post in m_LoggedInUser.Posts)
                {
                    if (post.PictureURL != null)
                    {
                        result++;
                    }
                }

                result /= m_LoggedInUser.Posts.Count * 100;
            }
            catch (Exception)
            {
                result = DummyDataGenerator.PresentageOfPostsWithPhotos(m_LoggedInUser.Posts);
            }

            return result;
        }

        private double TotalNumberOfLikes()
        {
            double result = 0;
            try
            {
                foreach (var post in m_LoggedInUser.Posts)
                {
                    result += post.LikedBy.Count;
                }
            }
            catch (Exception)
            {
                result = DummyDataGenerator.TotalNumberOfLikes(m_LoggedInUser.Posts);
            }

            return result;
        }
        #endregion

        #region Graph Maintenance
        private void CreateSecondYAxisScale(Chart i_Chart, string i_Series)
        {
            // Set custom chart area position
            i_Chart.ChartAreas["ChartArea1"].Position = new ElementPosition(25, 10, 68, 85);
            i_Chart.ChartAreas["ChartArea1"].InnerPlotPosition = new ElementPosition(10, 0, 90, 90);

            // Create extra Y axis for second
            CreateYAxis(i_Chart, i_Chart.ChartAreas["ChartArea1"], i_Chart.Series[i_Series], 13, 8);
        }

        public void CreateYAxis(
            Chart i_Chart, 
            ChartArea i_Area, 
            Series i_Series, 
            float i_AxisOffset, 
            float i_LabelsSize)
        {
            // Create new chart area for original series
            ChartArea areaSeries = i_Chart.ChartAreas.Add("ChartArea_" + i_Series.Name);
            areaSeries.BackColor = Color.Transparent;
            areaSeries.BorderColor = Color.Transparent;
            areaSeries.Position.FromRectangleF(i_Area.Position.ToRectangleF());
            areaSeries.InnerPlotPosition.FromRectangleF(i_Area.InnerPlotPosition.ToRectangleF());
            areaSeries.AxisX.MajorGrid.Enabled = false;
            areaSeries.AxisX.MajorTickMark.Enabled = false;
            areaSeries.AxisX.LabelStyle.Enabled = false;
            areaSeries.AxisY.MajorGrid.Enabled = false;
            areaSeries.AxisY.MajorTickMark.Enabled = false;
            areaSeries.AxisY.LabelStyle.Enabled = false;
            areaSeries.AxisY.IsStartedFromZero = i_Area.AxisY.IsStartedFromZero;
            i_Series.ChartArea = areaSeries.Name;

            // Create new chart area for axis
            ChartArea areaAxis = i_Chart.ChartAreas.Add("AxisY_" + i_Series.ChartArea);
            areaAxis.BackColor = Color.Transparent;
            areaAxis.BorderColor = Color.Transparent;
            areaAxis.Position.FromRectangleF(i_Chart.ChartAreas[i_Series.ChartArea].Position.ToRectangleF());
            areaAxis.InnerPlotPosition.FromRectangleF(i_Chart.ChartAreas[i_Series.ChartArea].InnerPlotPosition.ToRectangleF());

            // Create a copy of specified series
            Series seriesCopy = i_Chart.Series.Add(i_Series.Name + "_Copy");
            seriesCopy.ChartType = i_Series.ChartType;
            foreach (DataPoint point in i_Series.Points)
            {
                seriesCopy.Points.AddXY(point.XValue, point.YValues[0]);
            }

            // Hide copied series
            seriesCopy.IsVisibleInLegend = false;
            seriesCopy.Color = Color.Transparent;
            seriesCopy.BorderColor = Color.Transparent;
            seriesCopy.ChartArea = areaAxis.Name;

            // Disable drid lines & tickmarks
            areaAxis.AxisX.LineWidth = 0;
            areaAxis.AxisX.MajorGrid.Enabled = false;
            areaAxis.AxisX.MajorTickMark.Enabled = false;
            areaAxis.AxisX.LabelStyle.Enabled = false;
            areaAxis.AxisY.MajorGrid.Enabled = false;
            areaAxis.AxisY.IsStartedFromZero = i_Area.AxisY.IsStartedFromZero;
            areaAxis.AxisY.LabelStyle.Font = i_Area.AxisY.LabelStyle.Font;

            // Adjust area position
            areaAxis.Position.X -= i_AxisOffset;
            areaAxis.InnerPlotPosition.X += i_LabelsSize;
        }
        #endregion
    }
}
