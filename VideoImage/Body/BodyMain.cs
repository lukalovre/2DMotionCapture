using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MoCap.Body
{
    public class BodyMain
    {
        private readonly Node m_handLeft = new Node();
        private readonly Node m_elbowLeft = new Node();
        private readonly Node m_neck = new Node();
        private readonly Node m_headTop = new Node();
        private readonly Node m_elbowRight = new Node();
        private readonly Node m_handRight = new Node();
        private readonly Node m_abdomen = new Node();
        private readonly Node m_kneeLeft = new Node();
        private readonly Node m_footLeft = new Node();
        private readonly Node m_kneeRight = new Node();
        private readonly Node m_footRight = new Node();
        private readonly Head m_head;
        private readonly List<Node> m_nodes = new List<Node>();

        private readonly bool showHead;
        private readonly Color m_color;
        private const int LINE_WIDTH = 5;
        public int NumberOfNodes => m_nodes.Count;
        private readonly List<Limb> Limbs = new List<Limb>();

        public BodyMain(Color color, bool head = false)
        {
            m_color = color;
            this.showHead = head;

            m_nodes.Add(m_handLeft);
            m_nodes.Add(m_elbowLeft);
            m_nodes.Add(m_neck);
            m_nodes.Add(m_headTop);
            m_nodes.Add(m_elbowRight);
            m_nodes.Add(m_handRight);
            m_nodes.Add(m_abdomen);
            m_nodes.Add(m_kneeLeft);
            m_nodes.Add(m_footLeft);
            m_nodes.Add(m_kneeRight);
            m_nodes.Add(m_footRight);

            int numberOfLimbs = m_nodes.Count - 1;

            for(int i = 0; i < numberOfLimbs; i++)
            {
                Limbs.Add(new Limb());
            }

            m_handLeft.Connect(m_elbowLeft, Limbs, 0);
            m_elbowLeft.Connect(m_neck, Limbs, 1);
            m_abdomen.Connect(m_kneeLeft, Limbs, 2);
            m_kneeLeft.Connect(m_footLeft, Limbs, 3);
            m_neck.Connect(m_headTop, Limbs, 4);
            m_neck.Connect(m_abdomen, Limbs, 5);
            m_neck.Connect(m_elbowRight, Limbs, 6);
            m_elbowRight.Connect(m_handRight, Limbs, 7);
            m_abdomen.Connect(m_kneeRight, Limbs, 8);
            m_kneeRight.Connect(m_footRight, Limbs, 9);

            if(showHead)
            {
                m_head = new Head();
                m_head.ConnectToBody(m_neck, m_headTop);
            }
        }

        public void Update(List<PointF> points)
        {
            //TODO: make this reference Squares
            //TODO: make squares to pointF list

            for(var i = 0; i < m_nodes.Count && points.Count > 0; i++)
            {
                var x = points[i].X;
                var y = points[i].Y;
                m_nodes[i].SetPosition(new PointF(x, y));
            }

            if(showHead)
            {
                m_head.Update();
            }
        }

        public void Draw(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var myPen = new Pen(m_color) { Width = LINE_WIDTH };

            foreach(var limb in Limbs)
            {
                graphics.DrawLine(myPen, limb.A.X, limb.A.Y, limb.B.X, limb.B.Y);
            }
        }
    }
}
