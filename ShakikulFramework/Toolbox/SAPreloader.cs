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
    public partial class SAPreloader : UserControl
    {
        public SAPreloader()
        {
            InitializeComponent();
        }

        private int ss = 1;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (circlePreloader.Value==100)
            {
                ss -= 1;
            }
            else if (circlePreloader.Value==0)
            {
                ss += 1;
            }

            circlePreloader.Value += ss;
        }
    }
}
