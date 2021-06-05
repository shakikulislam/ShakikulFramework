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

        #region Event

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr a, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void DragForm_MouseDown(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                ReleaseCapture();
                if (SelectHandle.Form == _SelectHandle)
                {
                    SendMessage(this.SelectControl.FindForm().Handle, 161, 2, 0);
                }

                if (SelectHandle.Selected == _SelectHandle)
                {
                    SendMessage(this.SelectControl.Handle, 161, 2, 0);
                }

            }
        }

        #endregion

        #region Properties

        private SelectHandle _SelectHandle=SelectHandle.Form;

        [Category("Shakikul Framework")]
        [DefaultValue(typeof(SelectHandle),"Form")]
        public SelectHandle SelectHandle
        {
            get { return _SelectHandle; }
            set { _SelectHandle = value; }
        }

        [Category("Shakikul Framework")]
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
