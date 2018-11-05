using System.Drawing;

namespace MoCap.VideoProcessing
{
    public class NodeArea
    {
        private int m_videoWidth;
        private int m_videoHeight;
        private Color[] m_videoData;
        public Rectangle AreaRectangle { get; private set; }
        private const int AREA_WIDTH = 50; // 50;
        public static int AreaWidth => AREA_WIDTH;
        private PointF m_selectedPoint;
        public Bitmap OutTexture;
        public Rectangle NodeRectangle;
        public PointF SectionPoint;

        public NodeArea(PointF selectedPoint)
        {
            m_selectedPoint = selectedPoint;
        }

        public void SetArea(Color[] videoData, int videoWidth, int videoHeight)
        {
            m_videoData = videoData;
            m_videoWidth = videoWidth;
            m_videoHeight = videoHeight;
        }

        public void AdjustRectangle(Rectangle nodeRectangle)
        {
            if(!(MathHelper.Distance(
                     new PointF(nodeRectangle.Center().X, nodeRectangle.Center().Y),
                     new PointF(AreaRectangle.Center().X, AreaRectangle.Center().Y)) > AreaWidth / 16))
            {
                return;
            }

            var x = AreaRectangle.X;
            var y = AreaRectangle.Y;

            if(nodeRectangle.Center().X - AREA_WIDTH / 2 > 0)
            {
                x = (int)nodeRectangle.Center().X - AREA_WIDTH / 2;
            }

            if(nodeRectangle.Center().Y - AREA_WIDTH / 2 > 0)
            {
                y = (int)nodeRectangle.Center().Y - AREA_WIDTH / 2;
            }

            AreaRectangle = new Rectangle(x, y, AREA_WIDTH, AREA_WIDTH);
        }

        bool m_once;

        public void Update()
        {
            if(!(m_selectedPoint.X > 0))
            {
                return;
            }

            if(m_once)
            {
                return;
            }

            var x = (int)m_selectedPoint.X - AREA_WIDTH / 2;
            var y = (int)m_selectedPoint.Y - AREA_WIDTH / 2;
            AreaRectangle = new Rectangle(x, y, AREA_WIDTH, AREA_WIDTH);
            m_once = true;
        }

        public Color[] NewArea()
        {
            var newArea = new Color[AREA_WIDTH * AREA_WIDTH];

            if(AreaRectangle.Center().X == 0)
            {
                return newArea;
            }

            for(var y = 0; y < AREA_WIDTH; y++)
            {
                for(var x = 0; x < AREA_WIDTH; x++)
                {
                    newArea[AREA_WIDTH * y + x] = m_videoData[m_videoWidth * (y + AreaRectangle.Y) + (x + AreaRectangle.X)];
                }
            }

            return newArea;
        }

        public void Draw()
        {
            //if (OutTexture != null) Game1.Instance.SpriteBatch.Draw(OutTexture, AreaRectangle, Color.White * 0.4f);
            //Game1.Instance.SpriteBatch.Draw(Resources.Outline, AreaRectangle, Color.Red * 0.3f);
            //Game1.Instance.SpriteBatch.Draw(Resources.Square, NodeRectangle, Color.White * 0.3f);
            //Game1.Instance.SpriteBatch.Draw(Resources.Sphere, new Rectangle((int)SectionPoint.X - 30, (int)SectionPoint.Y - 30, 60, 60), Color.Red);
        }
    }
}
