using System;
using System.IO;

namespace FacebookApp.Logic
{
    [Serializable]
    public sealed class ApplicationSettings
    {
        private static readonly object sr_CreateLock = new object();
        private static readonly string sr_AppSettingsConfigPath = AppDomain.CurrentDomain.BaseDirectory + @"\ApplicationSettings.out";
        private static readonly ApplicationSettingsParser sr_Parser = new ApplicationSettingsXmlParser();
        private static ApplicationSettings s_Instance = null;
        private readonly int r_MaxPostsShown = 15;
        private readonly string r_ApplicationID = "1089225541443714";
        private readonly string[] r_UserPermissions =
            {
                "public_profile", "user_gender", "user_birthday", "user_hometown", "user_age_range", "user_likes",
                "user_photos", "user_posts", "user_friends", "user_location", "user_tagged_places", "publish_to_groups",
                "groups_access_member_info", "publish_pages"
            };

        private bool m_RememberUser;
        private string m_LastAccessToken;

        #region Ctor
        private ApplicationSettings()
        {
            m_RememberUser = false;
            m_LastAccessToken = string.Empty;
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

        public int MaxPostsShown
        {
            get
            {
                return r_MaxPostsShown;
            }
        }

        public string ApplicationID
        {
            get
            {
                return r_ApplicationID;
            }
        }

        public string[] UserPermissions
        {
            get
            {
                return r_UserPermissions;
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

        private static ApplicationSettings loadApplicationSettings()
        {
            ApplicationSettings appSettings = null;

            if (File.Exists(sr_AppSettingsConfigPath))
            {
                using (Stream stream = new FileStream(sr_AppSettingsConfigPath, FileMode.Open))
                {
                    appSettings = sr_Parser.Desirialize(stream);
                }
            }
            else
            {
                appSettings = new ApplicationSettings();
            }

            return appSettings;
        }

        public void SaveApplicationSettings()
        {
            if (m_RememberUser)
            {
                using (Stream stream = new FileStream(sr_AppSettingsConfigPath, FileMode.Create))
                {
                    sr_Parser.Serialize(stream, Instance);
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
