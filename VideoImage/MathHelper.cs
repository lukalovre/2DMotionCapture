using System;
using System.Drawing;

namespace MoCap
{
    public static class MathHelper
    {
        public static float ToRadians(float degrees)
        {
            float radians = (float)(Math.PI / 180) * degrees;
            return radians;
        }

        public static float PiOver2 => (float)Math.PI / 2;

        public static float Distance(PointF a, PointF b)
        {
            return (float)Math.Sqrt(Math.Pow(a.X - b.X, 2 ) + Math.Pow(a.Y - b.Y, 2));
        }

        public static PointF Add(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }
    }
}
