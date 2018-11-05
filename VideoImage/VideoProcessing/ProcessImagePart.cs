using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;

namespace MoCap.VideoProcessing
{
    internal class ProcessImagePart
    {
        private Bitmap m_outTexture;

        internal void ProcessPart(int index, Color[] videoData, Bitmap inputBitmap, ConcurrentDictionary<int, PointF> nodeAreaCenters, NodeArea nodeArea)
        {
            nodeArea.SetArea(videoData, inputBitmap.Width, inputBitmap.Height);
            var newWidth = NodeArea.AreaWidth;
            var newHeight = NodeArea.AreaWidth;

            if(nodeArea.NodeRectangle.X > 0)
            {
                nodeArea.AdjustRectangle(nodeArea.NodeRectangle);
            }

            Color[] newData = nodeArea.NewArea();

            var sc = new SimilarColors(newData, newWidth, newHeight);

            newData = sc.FindSimilarColors(VideoProcessingMain.Colors);

            ClearImage.clear_image(newData, newWidth, newHeight);

            var crossImg = new CrossImage(newData, newWidth, newHeight);
            var sectionDot = crossImg.GetSectionDot();

            nodeArea.SectionPoint = MathHelper.Add(
                new PointF(sectionDot % newWidth, sectionDot / newWidth + 1),
                new PointF(nodeArea.AreaRectangle.X, nodeArea.AreaRectangle.Y));

            var nodeRectangle = new NodeRectangle(crossImg.LinesX, crossImg.LinesY, newData, newWidth, newHeight);
            nodeArea.NodeRectangle = nodeRectangle.GetNodeRectangle();
            nodeArea.NodeRectangle.X += nodeArea.AreaRectangle.X;
            nodeArea.NodeRectangle.Y += nodeArea.AreaRectangle.Y;

            m_outTexture = new Bitmap(newWidth, newHeight);

            for(int y = 0; y < newHeight; y++)
            {
                for(int x = 0; x < newWidth; x++)
                {
                    m_outTexture.SetPixel(x, y, newData[y * newWidth + x]);
                }
            }

            nodeArea.OutTexture = m_outTexture;

            nodeAreaCenters.TryAdd(index, nodeArea.AreaRectangle.Center());
        }
    }
}
