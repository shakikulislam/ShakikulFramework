using System.Drawing;
using System.Windows.Forms;
using ShakikulFramework.Properties;

namespace ShakikulFramework
{
    public partial class FormAlert : Form
    {
        public FormAlert()
        {
            InitializeComponent();
        }

        public enum Action
        {
            Wait,
            Start,
            Close,
            Stand
        }

        public enum MessageType
        {
            Success, Warning, Error, Information, Delete
        }

        private Action _action;
        private int _x, _y;
        
        private void pictureBoxClose_Click(object sender, System.EventArgs e)
        {
            timerAlert.Interval = 1;
            _action = Action.Close;
        }

        private void timerAlert_Tick(object sender, System.EventArgs e)
        {
            switch (_action)
            {
                case Action.Wait:
                    timerAlert.Interval = 5000;
                    _action = Action.Close;
                    break;
                case Action.Start:
                    timerAlert.Interval = 1;
                    Opacity += 0.1;
                    if (_x<this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity==1.0)
                        {
                            _action = Action.Wait;
                        }
                    }
                    break;
                case Action.Close:
                    timerAlert.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (this.Opacity==0.0)
                    {
                        this.Close();
                    }
                    break;  
                case Action.Stand:
                    timerAlert.Interval = 1;
                    Opacity += 0.1;
                    if (_x<this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        
                    }
                    break;             
            }
        }
        
        private void Alert(string message, string messageTitle, MessageType type, Action action)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;

            string formName;

            for (int i = 1; i < Screen.PrimaryScreen.WorkingArea.Height / this.Height; i++)
            {
                formName = "Alert" + i;
                FormAlert formAlert = (FormAlert)Application.OpenForms[formName];

                if (formAlert == null)
                {
                    this.Name = formName;
                    _x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width) + 15;
                    _y = (Screen.PrimaryScreen.WorkingArea.Height - (this.Height * i)) - (5 * i);
                    this.Location = new Point(_x, _y);
                    break;
                }
            }
            
            //_x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5;
            labelMessageTitle.Text = messageTitle;
            labelMessage.Text = message;

            switch (type)
            {
                case MessageType.Success:
                    pictureBoxIcon.Image = Resources.Success;
                    BackColor = Color.SeaGreen;
                    break;
                case MessageType.Error:
                    pictureBoxIcon.Image = Resources.Error;
                    BackColor = Color.DarkRed;
                    break;
                case MessageType.Information:
                    pictureBoxIcon.Image = Resources.Info;
                    BackColor = Color.RoyalBlue;
                    break;
                case MessageType.Warning:
                    pictureBoxIcon.Image = Resources.Warning;
                    BackColor = Color.DarkOrange;
                    break;
                case MessageType.Delete:
                    pictureBoxIcon.Image = Resources.Delete;
                    BackColor = Color.Red;
                    break;
            }

            TopMost = true;
            Show();

            _action = action;

            timerAlert.Interval = 1;
            timerAlert.Start();
        }

        public void ShowAlert(string message, string messageTitle, MessageType type, Action action)
        {
            var alert=new FormAlert();
            alert.Alert(message, messageTitle, type, action);
        }

    }
}
