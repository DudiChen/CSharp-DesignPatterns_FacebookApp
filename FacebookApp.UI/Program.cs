using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FacebookApp.UI
{
    public static class Program
    {
        // The main entry point for the application.
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UIManager ui = new UIManager();
            ui.Run();
        }
    }
}
