using System.Collections.Generic;
using System.Drawing;

namespace MoCap.VideoProcessing
{
    class NodeRectangle
    {
        private List<int> m_linesX;
        private List<int> m_linesY;
        private readonly Color[] m_data;
        private readonly int m_width;
        private readonly int m_height;

        public NodeRectangle(List<int> linesX, List<int> linesY, Color[] data, int width, int height)
        {
            m_linesX = linesX;
            m_linesY = linesY;
            m_data = data;
            m_width = width;
            m_height = height;

            if(linesX.Count > 0 && linesY.Count > 0)
            {
                PumpLines();
            }
        }

        private void PumpLines()
        {
            PumpX();
            PumpY();
        }

        private void PumpX()
        {
            var pumpedLinesX = new List<int>();

            var y = m_linesX[0] / m_width;
            var start = y * m_width;
            var endStart = m_linesX[m_linesX.Count - 1] + 1;

            while(start != m_linesX[0])
            {
                pumpedLinesX.Add(start++);
            }

            foreach(int lineX in m_linesX)
            {
                pumpedLinesX.Add(lineX);
            }

            while(endStart < (y + 1) * m_width)
            {
                pumpedLinesX.Add(endStart++);
            }

            m_linesX = pumpedLinesX;
        }

        private void PumpY()
        {
            var pumpedLinesY = new List<int>();

            var x = m_linesY[0] % m_width;
            var start = 0;
            var endStart = m_linesY[m_linesY.Count - 1] + m_width;

            while(x + start * m_width <= m_linesY[0])
            {
                pumpedLinesY.Add(x + start * m_width); start++;
            }

            foreach(int lineY in m_linesY)
            {
                pumpedLinesY.Add(lineY);
            }

            var y = 0;

            while(endStart + y * m_width <= (m_height - 1) * m_width + x)
            {
                pumpedLinesY.Add(endStart + y * m_width); y++;
            }

            m_linesY = pumpedLinesY;
        }

        public Rectangle GetNodeRectangle()
        {
            var upY = 0;
            var downY = 0;
            var leftX = 0;
            var rightX = 0;

            if(m_linesX.Count > 0)
            {
                upY = FindUpY();
            }

            if(m_linesX.Count > 0)
            {
                downY = FindDownY();
            }

            if(m_linesY.Count > 0)
            {
                leftX = FindLeftX();
            }

            if(m_linesY.Count > 0)
            {
                rightX = FindRightX();
            }

            int x;
            int y;
            if(m_linesY.Count > 0)
            {
                x = leftX % m_width;
            }
            else
            {
                x = m_width / 4;
            }

            if(m_linesX.Count > 0)
            {
                y = upY / m_width + 1;
            }
            else
            {
                y = m_height / 4;
            }

            var rectangleWidth = rightX % m_width - leftX % m_width;
            var rectangleHeight = downY / m_width + 1 - upY / m_width + 1;

            if(m_linesX.Count == 0 && m_linesY.Count == 0)
            {
                rectangleWidth = m_width / 2;
                rectangleHeight = m_height / 2;
            }

            var nodeRectangle = new Rectangle(x, y, rectangleWidth, rectangleHeight);

            return nodeRectangle;
        }

        private int FindUpY()
        {
            int blankCount;
            var upCount = 1;

            do
            {
                blankCount = 0;

                for(var i = 0; i < m_linesX.Count; i++)
                {
                    var dot = m_linesX[i] - m_width * upCount;

                    if(dot < 0)
                    {
                        blankCount = m_linesX.Count; break;
                    }

                    if(m_data[dot].R != 0)
                    {
                        blankCount++;
                    }
                }
                upCount++;
            }
            while(blankCount < m_linesX.Count);

            var upY = m_linesX[0] - m_width * upCount;
            return upY;
        }

        private int FindDownY()
        {
            int blankCount;
            var downCount = 1;

            do
            {
                blankCount = 0;

                for(var i = 0; i < m_linesX.Count; i++)
                {
                    var dot = m_linesX[i] + m_width * downCount;

                    if(dot > m_data.Length - 1)
                    {
                        blankCount = m_linesX.Count; break;
                    }

                    if(m_data[dot].R != 0)
                    {
                        blankCount++;
                    }
                }
                downCount++;
            }
            while(blankCount < m_linesX.Count);

            var downY = m_linesX[0] + m_width * downCount;
            return downY;
        }

        private int FindLeftX()
        {
            int blankCount;
            var leftCount = 1;

            do
            {
                blankCount = 0;

                for(var i = 0; i < m_linesY.Count; i++)
                {
                    var dot = m_linesY[i] - leftCount;

                    if(dot < 0 || dot > m_data.Length - 1)
                    {
                        blankCount = m_linesY.Count; break;
                    }

                    if(m_data[dot].R != 0)
                    {
                        blankCount++;
                    }
                }
                leftCount++;
            }
            while(blankCount < m_linesY.Count);

            var leftX = m_linesY[0] - leftCount;
            return leftX;
        }


        private int FindRightX()
        {
            int blankCount;
            var rightCount = 1;
            do
            {
                blankCount = 0;

                for(var i = 0; i < m_linesY.Count; i++)
                {
                    var dot = m_linesY[i] + rightCount;

                    if(dot > m_data.Length - 1)
                    {
                        blankCount = m_linesY.Count; break;
                    }

                    if(m_data[dot].R != 0)
                    {
                        blankCount++;
                    }
                }
                rightCount++;
            }
            while(blankCount < m_linesY.Count);

            var rightX = m_linesY[0] + rightCount;
            return rightX;
        }
    }
}
