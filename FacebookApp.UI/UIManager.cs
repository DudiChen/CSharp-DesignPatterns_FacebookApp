using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using FacebookApp.Logic;
using System.Windows.Forms;

namespace FacebookApp.UI
{
    class UIManager
    {
        private ApplicationSettings m_ApplicationSettings;
        private LoginManager m_LoginManager;
        private FormMain m_MainForm;

        public UIManager()
        {
            m_ApplicationSettings = new ApplicationSettings();

        }

    }
}
