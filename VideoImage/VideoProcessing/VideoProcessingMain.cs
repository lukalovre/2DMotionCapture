using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MoCap.VideoProcessing
{
    public static class VideoProcessingMain
    {
        static readonly List<NodeArea> m_nodeAreas = new List<NodeArea>();
        public static Color[] VideoData;
        public static readonly List<Color> Colors = new List<Color>
                                                    {
                                                        Color.FromArgb(252, 160, 193),
                                                        Color.FromArgb(231, 107, 129),
                                                        Color.FromArgb(238, 113, 161),
                                                        Color.FromArgb(195, 110, 137),
                                                        Color.FromArgb(255, 211, 221),
                                                        Color.FromArgb(252, 187, 205),
                                                        Color.FromArgb(253, 188, 203),
                                                        Color.FromArgb(204, 146, 160),
                                                        Color.FromArgb(220, 137, 168),
                                                        Color.FromArgb(200, 74, 88),
                                                        Color.FromArgb(186, 52, 75),
                                                        Color.FromArgb(172, 66, 86),
                                                        Color.FromArgb(239, 77, 100),
                                                        Color.FromArgb(139, 71, 88),
                                                        Color.FromArgb(151, 32, 50),
                                                        Color.FromArgb(106, 24, 36),
                                                        Color.FromArgb(252, 184, 182),
                                                        Color.FromArgb(253, 185, 183),
                                                        Color.FromArgb(251, 122, 134),
                                                        Color.FromArgb(202, 31, 21),
                                                        Color.FromArgb(237, 11, 51),
                                                        Color.FromArgb(252, 39, 90),
                                                        Color.FromArgb(237, 229, 176) //boja ormara
                                                    };

        public static int NodeCount = 11;

        public static List<PointF> Process(Bitmap inputBitmap)
        {
            foreach(var square in MainForm.Squares)
            {
                m_nodeAreas.Add(new NodeArea(square.LocationExport));
            }

            foreach(var nodeArea in m_nodeAreas)
            {
                nodeArea.Update();
            }

            //TODO: this is 357 miliseconds;
            VideoData = new Color[inputBitmap.Width * inputBitmap.Height];

            for(int y = 0; y < inputBitmap.Height; y++)
            {
                for(int x = 0; x < inputBitmap.Width; x++)
                {
                    VideoData[y * inputBitmap.Width + x] = inputBitmap.GetPixel(x, y);
                }
            }

            var nodeAreaCenters = new ConcurrentDictionary<int, PointF>();
            int threadsCount = Environment.ProcessorCount;
            var tasks = new List<Task>();
            var bitmapCloneList = new List<Bitmap>();

            int nodes = NodeCount;

            while(nodes != 0)
            {
                for(int i = 0; i < threadsCount; i++)
                {
                    bitmapCloneList.Add(inputBitmap.Clone() as Bitmap);
                }

                for(int i = 0; i < threadsCount; i++)
                {
                    var processImagePart = new ProcessImagePart();
                    int index = 11 - nodes;

                    if(index >= 11)
                    {
                        break;
                    }

                    Task task = Task.Factory.StartNew(
                        () => processImagePart.ProcessPart(
                            index,
                            VideoData,
                            bitmapCloneList[index],
                            nodeAreaCenters,
                            m_nodeAreas[index]));
                    tasks.Add(task);
                    nodes--;
                }

                Task.WaitAll(tasks.ToArray());
            }

            var v = nodeAreaCenters.OrderBy(o => o.Key);
            var result = v.Select(o => o.Value).ToList();

            return result;
        }
    }

}