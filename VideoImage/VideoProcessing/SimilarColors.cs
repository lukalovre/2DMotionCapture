using System;
using System.Collections.Generic;
using System.Drawing;

namespace MoCap.VideoProcessing
{
    internal class SimilarColors
    {
        private readonly int m_width;
        private readonly int m_height;
        private readonly Color[] m_data;

        public SimilarColors(Color[] data, int width, int height)
        {
            m_data = data;
            m_width = width;
            m_height = height;
        }

        public Color[] FindSimilarColors(List<Color> color)
        {
            var outData = new Color[m_width * m_height];

            for (var i = 0; i < (m_width * m_height); i++)
            {
                var similar = false;

                for (var j = 0; j < color.Count; j++)
                {
                    if (AreColorsSimilar(color[j], m_data[i]))
                    {
                        similar = true;
                        break;
                    }
                }

                if(similar)
                {
                    outData[i] = Color.Black;
                }
                else
                {
                    outData[i] = Color.White;
                }
            }

            return outData;
        }

        private static bool AreColorsSimilar(Color c1, Color c2)
        {
            const int Tolerance = 25; //18; //35;
            return Math.Abs(c1.R - c2.R) < Tolerance &&
                   Math.Abs(c1.G - c2.G) < Tolerance &&
                   Math.Abs(c1.B - c2.B) < Tolerance;
        }
    }
}
