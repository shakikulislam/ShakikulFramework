using System;
using System.Windows.Forms;

namespace ShakikulFramework.Toolbox
{
    public partial class MessageBoxInput : Form
    {
        public static MessageBoxInput MessageBox;
        private static string _inputText;

        public MessageBoxInput()
        {
            InitializeComponent();
        }
        
        public static string Show(string message, string title="")
        {
            MessageBox = new MessageBoxInput {Text = title, labelMessage = {Text = message}};
            MessageBox.ShowDialog();
            return _inputText;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _inputText = textBoxInput.Text;
            MessageBox.Dispose();
        }

        private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                e.SuppressKeyPress = true;
                buttonOk.PerformClick();
            }
        }
    }
}
