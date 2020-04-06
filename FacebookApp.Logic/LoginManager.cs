using System;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace FacebookApp.Logic
{
    public sealed class LoginManager
    {
        private static readonly object sr_CreateLock = new object();
        private static readonly string sr_FailedLoginMsg = "Error: Login Attempt Failed... Please Try Again...";
        private static readonly string sr_InvalidAccessTokenMsg = "Error: Invalid Access Token... Please Perform Login Again...";
        private static LoginManager s_Instance = null;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        
        private LoginManager()
        {
            m_LoginResult = null;
            m_LoggedInUser = null;
        }

        public static LoginManager Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_CreateLock)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new LoginManager();
                        }
                    }
                }

                return s_Instance;
            }
        }

        private void storeLoginData(LoginResult result)
        {
            m_LoginResult = result;
            m_LoggedInUser = result.LoggedInUser;
        }

        public LoginResult LogginResult
        {
            get
            {
                return m_LoginResult;
            }

            set
            {
                m_LoginResult = value;
            }
        }

        public User LoggedInUser
        {
            get
            {
                return m_LoggedInUser;
            }

            set
            {
                m_LoggedInUser = value;
            }
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
                result = FacebookService.Login(Configuration.sr_ApplicationID, Configuration.sr_UserPermissions);
                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    storeLoginData(result);
                }
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
                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    storeLoginData(result);
                }
            }
            catch (Exception)
            {
                throw new Exception(sr_InvalidAccessTokenMsg);
            }
        }
    }
}
