using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookApp.Logic;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.UI
{
    public partial class FormMain : Form
    {
        private ApplicationSettings m_ApplicationSettings;
        private LoginManager m_LoginManager;
        private readonly string r_DefaultFormHeader = "Maor & Dudi's Facebook Application";
        private readonly string r_LoggedInString = "Logged-In As: ";

        public FormMain()
        {
            InitializeComponent();
            m_ApplicationSettings = ApplicationSettings.Instance;
            m_LoginManager = LoginManager.Instance;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_LoginManager.Login();
            if (m_LoginManager.IsLoggedIn)
            {
                User loggedInUser = m_LoginManager.LoggedInUser;
                StringBuilder formHeader = new StringBuilder(r_LoggedInString);
                formHeader.Append(loggedInUser.UserName);
                this.Text = formHeader.ToString();
                this.labelUserName.Text = loggedInUser.UserName;
                this.labelUserName.Visible = true;
                this.pictureBoxProfilePic.Load(loggedInUser.PictureNormalURL);

                //toggleButtons(true);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
