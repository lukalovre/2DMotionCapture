using System;
using System.Collections.Generic;
using System.Drawing;

namespace MoCap.IO
{
    class ExtractPoints
    {
        private static ExtractPoints s_instance;
        public static ExtractPoints Instance => s_instance ?? (s_instance = new ExtractPoints());

        List<PointF> m_nodeAreaCenters = new List<PointF>();

        public void WritePoints(List<PointF> nodeAreaCenters)
        {
            m_nodeAreaCenters = nodeAreaCenters;

            using(var file = new System.IO.StreamWriter(@"nodes.txt", true))
            {
                foreach(var center in nodeAreaCenters)
                {
                    var x = center.X;//- VideoProcessing.Main.inputBitmap.Width / 2;
                    var y = center.Y;//- VideoProcessing.Main.inputBitmap.Height / 2;

                    var _x = (int)(x * Math.Cos(MathHelper.PiOver2) - y * Math.Sin(MathHelper.PiOver2));
                    var _y = (int)(x * Math.Sin(MathHelper.PiOver2) + y * Math.Cos(MathHelper.PiOver2));

                    file.WriteLine(_x + " " + _y);
                }
            }
        }
    }
}
