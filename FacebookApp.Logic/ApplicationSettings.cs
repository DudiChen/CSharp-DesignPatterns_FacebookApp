using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FacebookApp.Logic
{
    /// <summary>
    /// //////////////////////////////////////////////////////
    /// ///// !!! NEED TO EDIT BEFORE SUBMITION !!! //////////
    /// //////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// </summary>
    public class ApplicationSettings
    {
        private static readonly string sr_SettingsPath = AppDomain.CurrentDomain.BaseDirectory + @"\ApplicationSettings.xml";

        public bool m_RememberUserForNextLogin { get; set; }
        public string m_LastAccessToken { get; }

        public ApplicationSettings()
        {
            m_RememberUserForNextLogin = true;
            m_LastAccessToken = string.Empty;
        }


        public static ApplicationSettings LoadApplicationSettings()
        {
            ApplicationSettings applicationSettings = null;

            if (File.Exists(sr_SettingsPath))
            {
                using (Stream stream = new FileStream(sr_SettingsPath, FileMode.Open))
                {
                    applicationSettings = ApplicationSettingsParser.Desirialize(stream);
                }
            }
            else
            {
                applicationSettings = new ApplicationSettings();
            }

            return applicationSettings;
        }

        public static void SaveApplicationSettings(object i_Caller)
        {
            using (Stream stream = new FileStream(sr_SettingsPath, FileMode.Create))
            {
                ApplicationSettingsParser.Serialize(stream, i_Caller);
            }
        }
    }
}
