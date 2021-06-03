using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakikulFramework.Toolbox
{
    public class saDragControl : Component
    {
        private Control _control;


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr a, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                saDragControl.ReleaseCapture();
                saDragControl.SendMessage(this.SelectControl.FindForm().Handle, 161, 2, 0);
            }
        }

        #region Properties

        public Control SelectControl
        {
            get { return _control; }
            set
            {
                _control = value;
                _control.MouseDown+=new MouseEventHandler(DragForm_MouseDown);
            }
        }
        #endregion

    }
}
