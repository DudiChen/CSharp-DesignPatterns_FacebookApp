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
    public class PostsStatsGeneratorAdapter : IFormsPostStatsGeneratorAdapter
    {
        private readonly PostsStatsGenerator r_PostsStatsGenerator;
        private Chart chart_Likes_Time;
        private TextBox txt_LetterPerPost;
        private TextBox txt_PostsPerDay;
        private TextBox txt_LikesPerPost;
        private TextBox txt_PhotosInPosts;
        private TextBox txt_TotalLikes;

        public PostsStatsGeneratorAdapter(
            FacebookObjectCollection<Post> i_Posts,
            Chart i_ChartPostsStatistics,
            TextBox i_TextBoxLettersPerPost,
            TextBox i_TextBoxPostsPerDay,
            TextBox i_TextBoxLikesPerPost,
            TextBox i_TextBoxPhotosInPosts,
            TextBox i_TextBoxTotalLikes)
        {
            r_PostsStatsGenerator = new PostsStatsGenerator(i_Posts);
            chart_Likes_Time = i_ChartPostsStatistics;
            txt_LetterPerPost = i_TextBoxLettersPerPost;
            txt_PostsPerDay = i_TextBoxPostsPerDay;
            txt_LikesPerPost = i_TextBoxLikesPerPost;
            txt_PhotosInPosts = i_TextBoxPhotosInPosts;
            txt_TotalLikes = i_TextBoxTotalLikes;
        }

        public void GeneratePostsStatistics()
        {
            r_PostsStatsGenerator.AnalyzePostsStatistics();
            populateChart();
        }

        private void populateChart()
        {
            populateChartLikesPerTimeOfDay();
            populateChartPostsPerTimeOfDay();
            //// populateGeneralStats();
            chart_Likes_Time.Invoke(new Action(() => populateGeneralStats()));
        }

        private void populateChartLikesPerTimeOfDay()
        {
            foreach (PostMetaData post in r_PostsStatsGenerator.PostsMetaDataList)
            {
                //// TODO: The X (createdTime) axis value order is not sorted, and doesn't seem to co-relate with the Y (likePerHour) axis.
                string createdTimeString = string.Format("{0:H:mm}", post.PostCreationTime);
                //// POSSIBLE CHANGE:
                //// string createdTimeString = string.Format("{0}{1}:00", post.PostCreationTime.Hour < 10 ? "0" : string.Empty, post.PostCreationTime.Hour);
                
                //// chart_Likes_Time.Series["Likes"].Points.AddXY(createdTimeString, post.PostNumberOfLikes);
                chart_Likes_Time.Invoke(new Action(() => chart_Likes_Time.Series["Likes"].Points.AddXY(createdTimeString, post.PostNumberOfLikes)));
            }

            //// chart_Likes_Time.Series["Likes"].Sort(PointSortOrder.Ascending, "X");
            chart_Likes_Time.Invoke(new Action(() => chart_Likes_Time.Series["Likes"].Sort(PointSortOrder.Ascending, "X")));
        }

        private void populateChartPostsPerTimeOfDay()
        {
            for (int i = 0; i < r_PostsStatsGenerator.PostsPerHour.Length; i++)
            {
                // Cast time of day to string
                string createdTimeString = string.Format("{0}{1}:00", i < 10 ? "0" : string.Empty, i);
                //// this.chart_Likes_Time.Series["Posts"].Points.AddXY(createdTimeString, r_PostsStatsGenerator.PostsPerHour[i]);
                chart_Likes_Time.Invoke(new Action(() => chart_Likes_Time.Series["Posts"].Points.AddXY(createdTimeString, r_PostsStatsGenerator.PostsPerHour[i])));
            }

            // Sort the graph in ascending order by X axis - Time of Day
            //// this.chart_Likes_Time.Series["Posts"].Sort(PointSortOrder.Ascending, "X");
            chart_Likes_Time.Invoke(new Action(() => chart_Likes_Time.Series["Posts"].Sort(PointSortOrder.Ascending, "X")));
            
            // Insert this graph as a secondary line, with a unique Y axis to the main chart control
            //// createSecondYAxisScale(this.chart_Likes_Time, "Posts");
            chart_Likes_Time.Invoke(new Action(() => createSecondYAxisScale(this.chart_Likes_Time, "Posts")));
        }

        private void populateGeneralStats()
        {
            this.txt_LetterPerPost.Text = string.Format("{0}", r_PostsStatsGenerator.AvgLettersPerPost);
            this.txt_PostsPerDay.Text = string.Format("{0}", r_PostsStatsGenerator.AvgPostsPerDay);
            this.txt_LikesPerPost.Text = string.Format("{0}", r_PostsStatsGenerator.AvgLikesPerPost);
            this.txt_PhotosInPosts.Text = string.Format("{0}%", r_PostsStatsGenerator.PercentageOfPostsWithPhotos);
            this.txt_TotalLikes.Text = string.Format("{0}", r_PostsStatsGenerator.TotalNumberOfLikes);
        }

        private void createSecondYAxisScale(Chart i_Chart, string i_Series)
        {
            // Set custom chart area position
            i_Chart.ChartAreas["ChartArea1"].Position = new ElementPosition(25, 10, 68, 85);
            //// //// i_Chart.Invoke(new Action(() => i_Chart.ChartAreas["ChartArea1"].Position = new ElementPosition(25, 10, 68, 85)));
            i_Chart.ChartAreas["ChartArea1"].InnerPlotPosition = new ElementPosition(10, 0, 90, 90);
            //// //// i_Chart.Invoke(new Action(() => i_Chart.ChartAreas["ChartArea1"].InnerPlotPosition = new ElementPosition(10, 0, 90, 90)));

            // Create extra Y axis for second
            createYAxis(i_Chart, i_Chart.ChartAreas["ChartArea1"], i_Chart.Series[i_Series], 13, 8);
            //// i_Chart.Invoke(new Action(() => createYAxis(i_Chart, i_Chart.ChartAreas["ChartArea1"], i_Chart.Series[i_Series], 13, 8)));
        }

        private void createYAxis(
            Chart i_Chart,
            ChartArea i_Area,
            Series i_Series,
            float i_AxisOffset,
            float i_LabelsSize)
        {
            // Create new chart area for original series
            ChartArea areaSeries = i_Chart.ChartAreas.Add("ChartArea_" + i_Series.Name);
            //// //// string chartAreaName = string.Format("ChartArea_{0}", i_Series.Name);
            //// //// i_Chart.Invoke(new Action(() => i_Chart.ChartAreas.Add(chartAreaName)));
            //// //// ChartArea areaSeries = i_Chart.ChartAreas[chartAreaName];
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
    }
}
