using AForge.Imaging.Filters;
using MoCap.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MoCap.Body
{
    class Head
    {
        private readonly Bitmap Texture;
        private Rectangle m_destinationRectangle;
        private float m_rotation;
        private Node m_neck;
        private Node m_headTop;
        private const int WIDTH = 100;
        private const int HEIGHT = 100;
        private readonly PictureBox m_pictureBox = new PictureBox();

        public Head()
        {
            Texture = Resources.Head;

            m_pictureBox.Size = new Size(WIDTH, HEIGHT);
            m_pictureBox.Image = Texture;
            m_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            m_pictureBox.Name = "Head";

            MainForm.Instance.Controls.Add(m_pictureBox);
            m_pictureBox.BringToFront();
        }

        public void Update()
        {
            var x = (int)m_neck.Position.X + MainForm.Instance.PbAnimationLocation.X - WIDTH / 2;
            var y = (int)m_neck.Position.Y + MainForm.Instance.PbAnimationLocation.Y - HEIGHT;

            m_destinationRectangle = new Rectangle(x, y, WIDTH, HEIGHT);

            m_rotation = GetRotation();

            m_pictureBox.Location = new Point(m_destinationRectangle.X, m_destinationRectangle.Y);

            RotateBilinear filter = new RotateBilinear(m_rotation, true);
            Bitmap newBitmap = Texture.Clone(new Rectangle(0, 0, m_pictureBox.Image.Width, m_pictureBox.Image.Height), PixelFormat.Format24bppRgb);
            m_pictureBox.Image = filter.Apply(newBitmap);

            m_pictureBox.Refresh();
        }

        private float GetRotation()
        {
            float rotation;
            var c = MathHelper.Distance(new PointF(m_neck.Position.X, m_neck.Position.Y), new PointF(m_headTop.Position.X, m_headTop.Position.Y));
            var b = Math.Abs(m_neck.Position.Y - m_headTop.Position.Y);

            if(m_neck.Position.X > m_headTop.Position.X)
            {
                rotation = -((float)Math.PI / 2 - (float)Math.Asin(b / c));
            }
            else
            {
                rotation = (float)Math.PI / 2 - (float)Math.Asin(b / c);
            }


            return rotation * (180 / (float)Math.PI);
        }

        internal void ConnectToBody(Node neck, Node headTop)
        {
            m_neck = neck;
            m_headTop = headTop;
        }
    }
}
