using System;
using System.Net.Mime;
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
        private ApplicationSettings m_ApplicationSettings;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        
        private LoginManager()
        {
            m_LoginResult = null;
            m_LoggedInUser = null;
            m_ApplicationSettings = ApplicationSettings.Instance;
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

        private void storeLoginData(LoginResult i_LoginResult)
        {
            m_LoginResult = i_LoginResult;
            m_LoggedInUser = i_LoginResult.LoggedInUser;
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
                result = FacebookService.Login(m_ApplicationSettings.ApplicationID, m_ApplicationSettings.UserPermissions);
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
            try
            {
                LoginResult result = FacebookService.Connect(i_AccessToken);
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
