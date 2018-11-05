using System.Collections.Generic;
using System.Drawing;

namespace MoCap.VideoProcessing
{
    class CrossImage
    {
        private readonly Color[] m_data;
        private readonly int m_width;
        private readonly int m_height;
        public List<int> LinesX;
        public List<int> LinesY;

        public CrossImage(Color[] data, int width, int height)
        {
            m_data = data;
            m_width = width;
            m_height = height;
        }

        public int GetSectionDot()
        {
            var sectionDot = 0;
            LinesX = MaxLineX();
            LinesY = MaxLineY();

            for(var i = 0; i < LinesX.Count; i++)
            {
                for(var j = 0; j < LinesY.Count; j++)
                {
                    if(i == LinesY[j])
                    {
                        sectionDot = i;
						break;
                    }
                }

            }

	        if(sectionDot == 0 && LinesX.Count > 0 && LinesY.Count > 0)
	        {
		        var a = new PointF(LinesX[0] % m_width, LinesX[0] / m_width);
		        var b = new PointF(0, LinesX[0] / m_width);

		        var c = new PointF(LinesY[0] % m_width, LinesY[0] / m_width);
		        var d = new PointF(LinesY[0] % m_width, 0);

		        var dy1 = b.Y - a.Y;
		        var dx1 = b.X - a.X;
		        var dy2 = d.Y - c.Y;
		        var dx2 = d.X - c.X;

		        var x = ((c.Y - a.Y) * dx1 * dx2 + dy1 * dx2 * a.X - dy2 * dx1 * c.X) / (dy1 * dx2 - dy2 * dx1);
		        var y = a.Y + (dy1 / dx1) * (x - a.X);
		        //  section_point = new PointF(x, y);
		        return (int)(m_width * y + x);
	        }
	        else
	        {
		        return sectionDot;
	        }

        }

        private List<int> MaxLineX()
        {
            var maxGlobal = new List<int>();

            for(var y = 0; y < m_height; y++)
            {
                var maxLine = new List<int>();
                var tempCounter = new List<int>();
                var counter = 0;

                for(var x = 0; x < m_width; x++)
                {
                    if(m_data[y * m_width + x].B == 0)
                    {
                        counter++;
                        tempCounter.Add(y * m_width + x);
                    }
                    else if(counter > 0)
                    {
                        if(counter > maxLine.Count)
                        {
                            maxLine = new List<int>(tempCounter);
                        }

                        counter = 0;
                        tempCounter.Clear();
                    }
                }

	            if(maxLine.Count > maxGlobal.Count)
	            {
		            maxGlobal = new List<int>(maxLine);
	            }
            }

	        for(var i = 0; i < maxGlobal.Count; i++)
	        {
		        m_data[i] = Color.Red;
	        }

            return maxGlobal;
        }

        private List<int> MaxLineY()
        {
            var maxGlobal = new List<int>();

            for(var x = 0; x < m_width; x++)
            {
                var maxLine = new List<int>();
                var tempCounter = new List<int>();
                var counter = 0;

                for(var y = 0; y < m_height; y++)
                {
                    if(m_data[y * m_width + x].B == 0)
                    {
                        counter++;
                        tempCounter.Add(y * m_width + x);
                    }
                    else if(counter > 0)
                    {
                        if(counter > maxLine.Count)
                        {
                            maxLine = new List<int>(tempCounter);
                        }

                        counter = 0;
                        tempCounter.Clear();
                    }
                }

	            if(maxLine.Count > maxGlobal.Count)
	            {
		            maxGlobal = new List<int>(maxLine);
	            }
            }

	        for(var i = 0; i < maxGlobal.Count; i++)
	        {
		        m_data[i] = Color.Red;
	        }

            return maxGlobal;
        }
    }
}
