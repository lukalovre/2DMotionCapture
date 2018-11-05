using System.Drawing;

namespace MoCap
{
    public static class RectangleHelper
    {
        public static PointF Center(this Rectangle rect)
        {
            return new PointF(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
        }
    }
}
