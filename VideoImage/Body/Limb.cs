using System;
using System.Drawing;

namespace MoCap.Body
{
    public class Limb
    {
        private Node m_nodeA;
        private Node m_nodeB;

        public PointF A => new PointF(m_nodeA.Position.X, m_nodeA.Position.Y);
        public PointF B => new PointF(m_nodeB.Position.X, m_nodeB.Position.Y);

        public void Connect(Node a, Node b)
        {
            m_nodeA = a;
            m_nodeB = b;
        }

        public float GetRotation()
        {
            float rotation;

            double x = Math.Abs(A.X - B.X);
            double y = Math.Abs(A.Y - B.Y);

            var distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            if(B.Y > A.Y)
            {
                rotation = (float)Math.Asin(x / distance);
            }
            else
            {
                rotation = (float)Math.Asin(y / distance) + MathHelper.ToRadians(90);
            }

            if(B.X > A.X)
            {
                rotation = -rotation;
            }

            return rotation;
        }
    }
}
