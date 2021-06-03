using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShakikulFramework
{
    public partial class saScrollingLabelText : Label
    {
        public saScrollingLabelText()
        {
            InitializeComponent();

            UseCompatibleTextRendering = true;
        }

        #region ...Properties...

        private int _speed = 5;
        [Category("Shakikul Framework")]
        [DefaultValue(typeof(int), "5")]
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
                    timerLabelText.Start();
                }
                else
                {
                    timerLabelText.Stop();
                    this.TextAlign = _textAlign;
                }
                this.Invalidate();
            }

        }

        #endregion

        #region ...Override Default Properties...


        //[Browsable(false)]
        //public override bool AutoSize
        //{
        //    get { return base.AutoSize; }
        //    set { base.AutoSize = value; }
        //}


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

        #region ...Override...

        private int _position;
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(_position, 0);
            base.OnPaint(e);
        }
        #endregion

        private void timerLabelText_Tick(object sender, EventArgs e)
        {
            if (ScrollingTextEnum.LeftToRight == _scrollDirection)
            {
                if (_position > this.Width)
                {
                    _position = -this.Width;
                }
                _position += _speed;
            }

            if (ScrollingTextEnum.RightToLeft == _scrollDirection)
            {
                if (_position < -this.Width)
                {
                    _position = this.Width;
                }
                _position -= _speed;
            }

            Invalidate();
        }

    }
}
