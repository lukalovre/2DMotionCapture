using System.Collections.Generic;
using System.Drawing;

namespace MoCap.Body
{
    public class Node
    {
        public PointF Position { get; private set; }

        public void SetPosition(PointF newPosition)
        {
            Position = newPosition;
        }

        public void Connect(Node node, List<Limb> limbs, int index)
        {
            limbs[index].Connect(this, node);
        }
    }
}
