using System;
using System.Collections.Generic;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Logic
{
    public class LoginManager
    {
        private LoginResult m_LoginResult = null;
        private User m_LoggedInUser = null;
        private static readonly string sr_FailedLoginMsg = "Error: Login Attempt Failed... Please Try Again...";
        private static readonly string sr_InvalidAccessTokenMsg = "Error: Invalid Access Token... Please Perform Login Again...";

        private void storeLoginData(LoginResult result)
        {
            m_LoginResult = result;
            m_LoggedInUser = result.LoggedInUser;
        }

        public bool IsLoggedIn
        {
            get
            {
                return m_LoginResult == null ? false : true;
            }
        }

        public void Login()
        {
            LoginResult result;
            try
            {
                result = FacebookService.Login(Configuration.sr_AppID, Configuration.sr_UserPermissions);
                if (!string.IsNullOrEmpty(result.AccessToken)) storeLoginData(result);
            }
            catch (Exception)
            {
                throw new Exception(sr_FailedLoginMsg);
            }
        }

        public void Connect(string i_AccessToken)
        {
            LoginResult result;
            try
            {
                result = FacebookService.Connect(i_AccessToken);
                if(!string.IsNullOrEmpty(result.AccessToken)) storeLoginData(result);
            }
            catch (Exception)
            {
                throw new Exception(sr_InvalidAccessTokenMsg);
            }
            
            
        }
        
    }
}
