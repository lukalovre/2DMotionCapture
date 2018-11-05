using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace MoCap.IO
{
    public static class StartPositions
    {
        private static string s_fileName = @"StartPosition.txt";

        public static void Save(List<Square> squaresList)
        {
            if(squaresList == null)
            {
                return;
            }

            var startPositions = new List<PointF>();

            foreach(var square in squaresList)
            {
                startPositions.Add(square.LocationExport);
            }

            if(File.Exists(s_fileName))
            {
                return;
            }

            using(var file = new StreamWriter(s_fileName, true))
            {
                foreach(var node in startPositions)
                {
                    file.WriteLine(node.X + " " + node.Y);
                }
            }
        }

        public static List<PointF> Load()
        {
            if(!File.Exists(s_fileName))
            {
                return null;
            }

            var startPositions = new List<PointF>();

            foreach(var line in File.ReadLines(s_fileName))
            {
                var words = line.Split(' ');
                var x = float.Parse(words[0]);
                var y = float.Parse(words[1]);

                startPositions.Add(new PointF(x, y));
            }

            return startPositions;
        }

        public static void Delete()
        {
            if(File.Exists(s_fileName))
            {
                File.Delete(s_fileName);
                MainForm.RemoveAllSquares();
            }
        }
    }
}
