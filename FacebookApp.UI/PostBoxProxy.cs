using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApp.UI
{
    public class PostBoxProxy : PostBox
    {
        public PostBoxProxy() : base()
        {
            Paint += PostBoxProxy_Paint;
        }

        private void PostBoxProxy_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }


}
