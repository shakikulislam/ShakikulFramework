using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakikulFramework.Toolbox
{
    public partial class SAScrollingLabel : Label
    {
        public SAScrollingLabel()
        {
            InitializeComponent();
        }


        #region ...Properties...

        private int _speed = 1;
        [Category("Shakikul Framework")]
        [DefaultValue(typeof(int), "1")]
        public int ScrollSpeed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                Invalidate();
            }
        }

        private ScrollingTextEnum _scrollDirection = ScrollingTextEnum.None;
        [Category("Shakikul Framework")]
        [DefaultValue(typeof(ScrollingTextEnum), "None")]
        public ScrollingTextEnum ScrollDirection
        {
            get { return _scrollDirection; }
            set
            {
                _scrollDirection = value;
                if (ScrollingTextEnum.None != _scrollDirection)
                {
                    timerScrollingLabel.Start();
                }
                else
                {
                    timerScrollingLabel.Stop();
                    //this.TextAlign = _textAlign;
                }
                this.Invalidate();
            }

        }

        private Control _control;
        [Category("Shakikul Framework")]
        public Control SelectControl
        {
            get { return _control; }
            set { _control = value; }
        }

        #endregion

        #region ...Override Default Properties...

        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;

        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public override ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                this.Invalidate();
            }
        }
        #endregion

        private void timerScrollingLabel_Tick(object sender, EventArgs e)
        {
            if (_control == null) return;

            if (ScrollingTextEnum.LeftToRight == _scrollDirection)
            {
                this.Location = new Point(this.Location.X + _speed, this.Location.Y);

                if (this.Location.X > _control.Width)
                {
                    this.Location = new Point(-this.Width,this.Location.Y);
                }
            }

            if (ScrollingTextEnum.RightToLeft == _scrollDirection)
            {
                this.Location = new Point(this.Location.X - _speed,this.Location.Y);

                if (this.Location.X < -this.Width)
                {
                    this.Location = new Point(_control.Width, this.Location.Y);
                }
            }

            Invalidate();
        }
    }
}
