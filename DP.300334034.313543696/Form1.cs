using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP._300334034._313543696
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginResult result =
                FacebookService.Login("354679422134643", "user_friends, user_status, user_birthday");
            System.Console.WriteLine(result.ErrorMessage);

            textBoxAccessToken.Text = result.AccessToken;

            FacebookWrapper.ObjectModel.User theLoggedInUser = result.LoggedInUser;

            pictureBoxProfile.Load(theLoggedInUser.PictureNormalURL);
            //theLoggedInUser.

            //foreach (User friend in theLoggedInUser.Friends)
            //{
            //    listBoxFriends.Items.Add(friend.FirstName);
            //}

            //foreach(Checkin checkin in theLoggedInUser.Checkins)
            //{
            //    listBoxCheckins.Items.Add(checkin.Place.Location.City)
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
