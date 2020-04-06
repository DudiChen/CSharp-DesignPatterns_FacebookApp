using System;
using System.IO;

namespace FacebookApp.Logic
{
    public sealed class ApplicationSettings
    {
        private static readonly object sr_CreateLock = new object();
        private static readonly string sr_AppSettingsConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"\ApplicationSettings.xml";
        private static ApplicationSettings s_Instance = null;
        private bool m_RememberUser;
        private string m_LastAccessToken;

        #region Ctor
        private ApplicationSettings()
        {
            m_RememberUser = false;
            m_LastAccessToken = string.Empty;
        }

        private static ApplicationSettings loadApplicationSettings()
        {
            ApplicationSettings appSettings = null;

            if (File.Exists(sr_AppSettingsConfigPath))
            {
                using (Stream stream = new FileStream(sr_AppSettingsConfigPath, FileMode.Open))
                {
                    appSettings = ApplicationSettingsParser.Desirialize(stream);
                }
            }
            else
            {
                appSettings = new ApplicationSettings();
            }

            return appSettings;
        }
        #endregion

        #region Properties
        public static ApplicationSettings Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (sr_CreateLock)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = loadApplicationSettings();
                        }
                    }
                }

                return s_Instance;
            }
        }

        public bool RememberUser
        {
            get
            {
                return m_RememberUser;
            }

            set
            {
                m_RememberUser = value;
            }
        }

        public string LastAccessToken
        {
            get
            {
                return m_LastAccessToken;
            }

            set
            {
                m_LastAccessToken = value;
            }
        }

        #endregion

        #region Methods
        public void SaveApplicationSettings()
        {
            if (m_RememberUser)
            {
                using (Stream stream = new FileStream(sr_AppSettingsConfigPath, FileMode.Create))
                {
                    ApplicationSettingsParser.Serialize(stream, Instance);
                }
            }
            else
            {
                if (File.Exists(sr_AppSettingsConfigPath))
                {
                    File.Delete(sr_AppSettingsConfigPath);
                }
            }
        }
        #endregion
    }
}
