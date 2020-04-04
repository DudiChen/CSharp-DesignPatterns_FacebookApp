using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Logic
{
    public sealed class ApplicationSettings
    {
        private static ApplicationSettings s_Instance = null;
        private static readonly object sr_CreateLock = new object();
        private static readonly string sr_AppSettingsConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"\ApplicationSettings.xml";
        private bool m_RememberUser;
        private string m_LastAccessToken;

        private ApplicationSettings()
        {
            m_LastAccessToken = string.Empty;
            m_RememberUser = true;
        }

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

        private void SaveApplicationSettings(object i_Caller)
        {
            using (Stream stream = new FileStream(sr_AppSettingsConfigPath, FileMode.Create))
            {
                ApplicationSettingsParser.Serialize(stream, i_Caller);
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
    }
}
