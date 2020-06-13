using System.Windows.Forms;
using FacebookApp.Logic;
using FacebookApp.UI.Forms;

namespace FacebookApp.UI
{
    public class UIManager
    {
        private FormMain m_MainForm;

        public UIManager()
        {
            m_MainForm = new FormMain();
        }

        public void Run()
        {
            Application.Run(m_MainForm);
        }
    }
}
