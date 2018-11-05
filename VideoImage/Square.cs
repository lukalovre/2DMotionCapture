using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using MoCap.VideoProcessing;

namespace MoCap
{
    public sealed class Square : Panel
    {
        private int m_opacity = 50;
        private const int WS_EX_TRANSPARENT = 0x20;
        private Color m_color = Color.DarkRed;
        private int m_size = NodeArea.AreaWidth;

        public PointF Center => new PointF(Location.X + m_size / 2, Location.Y + m_size / 2);
        public PointF LocationExport => new Point(Location.X + m_size/2 - m_size / 4, Location.Y + m_size / 2 - m_size / 4);

        public Square()
        {
            SetStyle(ControlStyles.Opaque, true);
            BackColor = m_color;
            Size = new Size(m_size, m_size);
            MouseClick += Square_MouseClick;

            MainForm.Instance.Controls.Add(this);
            MainForm.Squares.Add(this);
            BringToFront();
        }

        public Point SetLocation(PointF location)
        {
            Location = new Point((int)location.X - m_size / 2 + m_size / 4, (int)location.Y - m_size / 2 + m_size / 4);
            return Location;
        }

        private void Square_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                var square = sender as Square;

                MainForm.Squares.Remove(square);
                MainForm.Instance.Controls.Remove(square);
            }
        }

        public static void AddSquare(Point point)
        {
            if(MainForm.Squares.Count < VideoProcessingMain.NodeCount)
            {
                PointF mousePoint = point;

                var square = new Square();
                square.SetLocation(mousePoint);
            }
        }

        [DefaultValue(50)]
        public int Opacity
        {
            get => m_opacity;
            set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException("value must be between 0 and 100");
                }

                m_opacity = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using(var brush = new SolidBrush(Color.FromArgb(m_opacity * 255 / 100, BackColor)))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
            base.OnPaint(e);
        }
    }
}
