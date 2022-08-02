
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShakikulFramework.Toolbox
{
    public class SaPanel:Panel
    {
        private int borderRadius = 50;
        private float gradientAngle = 90F;
        private Color gradientColor1 = Color.RoyalBlue;
        private Color gradientColor2 = Color.Navy;
        

        // Properties

        #region Properties

        [Category("Shakikul Islam")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value>=0)
                {
                    int radius = value;
                    if (value>this.Width)
                    {
                        radius = this.Width;
                    }

                    if (value > this.Height)
                    {
                        radius = this.Height;
                    }

                    borderRadius = radius;
                    this.Invalidate();
                }
                
            }
        }

        [Category("Shakikul Islam")]
        public float GradientAngle
        {
            get { return gradientAngle; }
            set
            {
                gradientAngle = value;
                this.Invalidate();
            }
        }

        [Category("Shakikul Islam")]
        public Color GradientColor1
        {
            get { return gradientColor1; }
            set
            {
                gradientColor1 = value;
                this.Invalidate();
            }
        }

        [Category("Shakikul Islam")]
        public Color GradientColor2
        {
            get { return gradientColor2; }
            set
            {
                gradientColor2 = value;
                this.Invalidate();
            }
        }
        

        #endregion

        // Constructor
        public SaPanel()
        {
            this.BackColor=Color.White;
            this.ForeColor=Color.Black;
            this.Size=new Size(100,100);

            this.Resize+=new EventHandler(saPanel_resize);
        }


        // Method
        private GraphicsPath GetPanelPath(RectangleF rectangle, float radius)
        {
            GraphicsPath graphicsPath=new GraphicsPath();
            graphicsPath.StartFigure();
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Height - radius, radius,radius, 0, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Height - radius, radius,radius, 90, 90);
            graphicsPath.AddArc(rectangle.X, rectangle.Y, radius,radius, 180, 90);
            graphicsPath.AddArc(rectangle.Width - radius, rectangle.Y, radius, radius, 270, 90);
            graphicsPath.CloseFigure();
            return graphicsPath;
        }

        // Overridden Method

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Gradient
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            LinearGradientBrush gradientBrush=new LinearGradientBrush(this.ClientRectangle,this.gradientColor1,this.gradientColor2,this.GradientAngle);

            e.Graphics.FillRectangle(gradientBrush,ClientRectangle);

            // Border Radius
            RectangleF rectangleF = new RectangleF(0, 0, this.Width, this.Height);

            if (borderRadius>1)
            {
                using (GraphicsPath graphicsPath=GetPanelPath(rectangleF,borderRadius))
                using (Pen pen=new Pen(this.Parent.BackColor))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else
            {
                this.Region = new Region(rectangleF);
            }

            if (true)
            {
                using (GraphicsPath graphicsPath = GetPanelPath(rectangleF, borderRadius))
                using (Pen pen = new Pen(this.Parent.BackColor))
                {
                    this.Region = new Region(graphicsPath);
                    e.Graphics.DrawPath(pen, graphicsPath);
                }
            }
            else
            {
                this.Region = new Region(rectangleF);
            }

        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Invalidate();
        }


        private void saPanel_resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
            }

            if (borderRadius > this.Width)
            {
                borderRadius = this.Width;
            }
        }
    }
}
