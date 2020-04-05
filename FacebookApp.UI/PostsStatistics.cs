using System;
using System.Collections.Generic;
using System.Text;
using FacebookApp.Logic;
using System.Drawing;
using FacebookWrapper.ObjectModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FacebookApp.UI
{
    public class PostsStatistics
    {
        //private User m_LoggedInUser;
        //static Random s_RandomGenerater = new Random();


        //private void LoadChart_LikesPerTimeOfDay()
        //{
        //    DateTime time;
        //    string timeAsString;
        //    uint likes;

        //    foreach (var post in m_LoggedInUser.Posts)
        //    {
        //        // Cuz Facebook API doesn't allow us to get Like list
        //        //time = (DateTime)post.CreatedTime;
        //        //likes = (uint)post.LikedBy.Count;

        //        time = GetRandomDateTime(new DateTime(2000, 01, 01, 10, 00, 00), DateTime.Now);
        //        likes = GetRandomUnsignedNumber();
        //        timeAsString = time.Hour < 10 ? "0" + time.Hour.ToString() : time.Hour.ToString();
        //        timeAsString += ":";
        //        timeAsString += time.Minute < 10 ? "0" + time.Minute.ToString() : time.Minute.ToString();
        //        this.chart_Likes_Time.Series["Likes"].Points.AddXY(timeAsString, likes);
        //    }

        //    this.chart_Likes_Time.Series["Likes"].Sort(PointSortOrder.Ascending, "X");
        //}

        //private void LoadChart_PostsPerTimeOfDay()
        //{
        //    string timeAsString;
        //    uint[] postsPerHour = new uint[24];
        //    for (int i = 0; i < 24; i++) postsPerHour[i] = 0;

        //    foreach (var post in m_LoggedInUser.Posts)
        //    {
        //        postsPerHour[post.CreatedTime.Value.Hour]++;
        //    }

        //    for (int i = 0; i < postsPerHour.Length; i++)
        //    {
        //        timeAsString = i < 10 ? "0" + i + ":00" : i + ":00";
        //        this.chart_Likes_Time.Series["Posts"].Points.AddXY(timeAsString, postsPerHour[i]);
        //    }
        //    this.chart_Likes_Time.Series["Posts"].Sort(PointSortOrder.Ascending, "X");
        //    CreateSecondYAxisScale(this.chart_Likes_Time, "Posts");
        //}

        //private void LoadGroup_Stats()
        //{
        //    this.txt_LetterPerPost.Text = AvgNumberOfLettersInPosts() + "";
        //    this.txt_PostsPerDay.Text = AvgPostsPerDay() + "";
        //    this.txt_LikesPerPost.Text = AvgLikesPerPost() + "";
        //    this.txt_PhotosInPosts.Text = PresentageOfPostsWithPhotos() + "%";
        //    this.txt_TotalLikes.Text = TotalNumberOfLikes() + "";
        //}

        //private double AvgNumberOfLettersInPosts()
        //{
        //    double result = 0;

        //    foreach (var post in m_LoggedInUser.Posts)
        //    {
        //        if (post.Message != null)
        //            result += post.Message.Length;
        //    }
        //    result /= m_LoggedInUser.Posts.Count;

        //    return result;
        //}

        //private double AvgLikesPerPost()
        //{
        //    double result = 0;

        //    foreach (var post in m_LoggedInUser.Posts)
        //    {
        //        // Doesnt let see the like list
        //        //result += post.LikedBy.Count;
        //        result += GetRandomUnsignedNumber(250);
        //    }
        //    result /= m_LoggedInUser.Posts.Count;

        //    return result;
        //}

        //private double AvgPostsPerDay()
        //{
        //    double result = 0;
        //    DateTime createdUser = new DateTime(0);

        //    /*foreach (var album in m_LoggedInUser.Albums)
        //    {
        //        if (album.Name == "Profile Pictures")
        //            createdUser = album.CreatedTime.Value;
        //    }*/
        //    result = s_RandomGenerater.NextDouble();
        //    if (createdUser.Ticks != 0)
        //    {
        //        result = m_LoggedInUser.Albums.Count / (DateTime.Now - createdUser).Days;
        //    }

        //    return result;
        //}

        //private double PresentageOfPostsWithPhotos()
        //{
        //    double result = 0;
        //    foreach (var post in m_LoggedInUser.Posts)
        //    {
        //        if (post.PictureURL != null)
        //            result++;
        //    }
        //    return result / (m_LoggedInUser.Posts.Count) * 100;
        //}

        //private double TotalNumberOfLikes()
        //{
        //    double result = 0;
        //    foreach (var post in m_LoggedInUser.Posts)
        //    {
        //        //result += post.LikedBy.Count;
        //        result += GetRandomUnsignedNumber(150);
        //    }
        //    return result;
        //}

        //private static DateTime GetRandomDateTime(DateTime i_From, DateTime i_To)
        //{
        //    TimeSpan range = new TimeSpan(i_To.Ticks - i_From.Ticks);
        //    return (i_From + new TimeSpan((long)(range.Ticks * s_RandomGenerater.NextDouble())));
        //}

        //private static uint GetRandomUnsignedNumber(int i_Capacity = 1500)
        //{
        //    return (uint)(s_RandomGenerater.Next(0, i_Capacity + 1));
        //}
    }
}
