using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShakikulFramework.Toolbox
{
    public class SADragControl : Component
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
                if (SelectHandle.Form == _selectHandle)
                {
                    SendMessage(this.SelectControl.FindForm().Handle, 161, 2, 0);
                }

                if (SelectHandle.Selected == _selectHandle)
                {
                    SendMessage(this.SelectControl.Handle, 161, 2, 0);
                }

            }
        }

        #endregion

        #region Properties

        private SelectHandle _selectHandle = SelectHandle.Form;

        [Category("Shakikul Framework")]
        [DefaultValue(typeof(SelectHandle),"Form")]
        public SelectHandle SelectHandle
        {
            get { return _selectHandle; }
            set { _selectHandle = value; }
        }

        [Category("Shakikul Framework")]
        public Control SelectControl
        {
            get { return _control; }
            set
            {
                _control = value;
                _control.MouseDown += new MouseEventHandler(DragForm_MouseDown);
            }
        }
        #endregion

    }
}
