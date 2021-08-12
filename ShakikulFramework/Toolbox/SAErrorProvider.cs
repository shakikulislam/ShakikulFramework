using System.ComponentModel;
using System.Windows.Forms;

namespace ShakikulFramework.Toolbox
{
    public partial class SAErrorProvider : Component
    {
        public SAErrorProvider()
        {
            InitializeComponent();
        }

        public SAErrorProvider(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        CancelEventArgs _cancelEventArgs = new CancelEventArgs();
        public void Set(Control control, string message)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                _cancelEventArgs.Cancel = true;
                errorProvider.SetError(control, message);
            }
            else
            {
                _cancelEventArgs.Cancel = false;
                errorProvider.SetError(control, null);
            }
        }
    }
}
