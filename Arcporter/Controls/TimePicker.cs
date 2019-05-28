using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcporter.Controls
{
    public partial class TimePicker : UserControl
    {
        private Point mousePos;
        private bool mouseDown;
        private DateTime dt = new DateTime(0);

        private double _value;
        public double Value
        {
            get { return _value; }
            set
            {
                _value = FauFau.Util.Math.Clamp(value, 1d, 0d);
                int max = pnlTrack.Width - pnlThumb.Width;
                pnlThumb.Left = (int)Map(0, 1440, 0, max, _value * 1440);
                lblTime.Text = dt.AddMinutes(_value * 1440).ToShortTimeString();
            }
        }

        public TimePicker()
        {
            InitializeComponent();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = true;
                mousePos = new Point(e.X, e.Y);
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDown = false;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int max = pnlTrack.Width - pnlThumb.Width;
                int x = pnlThumb.Left + (e.X - mousePos.X);
                x = FauFau.Util.Math.Clamp(x, max, 0);
                Value = Map(0, max, 0d, 1d, x);
            }
        }

        private void OnResize(object sender, EventArgs e)
        {
            Value = Value;
        }

        static double Map(double fromStart, double fromEnd, double toStart, double toEnd, double value)
        {
            return toStart + (value - fromStart) * (toEnd - toStart) / (fromEnd - fromStart);
        }
    }
}
