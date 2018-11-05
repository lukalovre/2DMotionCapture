namespace MoCap.Body
{
    public class AnimateBody
    {
        public void Update()
        {
            //VideoProcessing.Main.Update();

            //   if (System.IO.File.Exists("nodes.txt"))
            // {
            //    ReadPoints();
            //    var points = m_lolAreaCenters[(m_animation) % m_lolAreaCenters.Count];
            //    for (var i = 0; i < NUMBER_OF_NODES && points.Count > 0; i++)
            //    {
            //        var x = points[i].X;//- VideoProcessing.Main.Instance.videoTexture.Width / 2;
            //        var y = points[i].Y;// - VideoProcessing.Main.Instance.videoTexture.Height / 2;

            //        const float Scale = 1f;
            //        m_head.Scale = Scale;
            //        var __x = (int)(x * Scale);
            //        var __y = (int)(y * Scale);

            //        m_nodes[i].SetPosition(new PointF(__x, __y));
            //    }
            //    foreach (var node in m_nodes)
            //    {
            //        var distance = Math.Abs(m_neck.Position.X - m_abdomen.Position.X);
            //        var positionOfCenter = m_abdomen.Position.X > m_neck.Position.X ? m_abdomen.Position.X - distance / 2 : m_abdomen.Position.X + distance / 2;
            //        var distanceOfTwoCenters = Math.Abs(0 - positionOfCenter);
            //        var xModdifier = 0 > positionOfCenter ? distanceOfTwoCenters : -distanceOfTwoCenters;
            //        node.SetPosition(new PointF(node.Position.X + xModdifier, node.Position.Y));
            //    }

            //    // reverse part
            //    var pointsR = m_lolAreaCenters[m_lolAreaCenters.Count - 1 - ((m_animation++) % m_lolAreaCenters.Count)];
            //    for (var i = 0; i < NUMBER_OF_NODES && points.Count > 0; i++)
            //    {
            //        var x = pointsR[i].X;// - VideoProcessing.Main.Instance.videoTexture.Width / 2;
            //        var y = pointsR[i].Y;// - VideoProcessing.Main.Instance.videoTexture.Height / 2;

            //        var scale = 1f;
            //        m_head.Scale = scale;
            //        var __x = (int)(x * scale);
            //        var __y = (int)(y * scale);

            //        pointsR[i] = new Point(__x, __y);
            //    }
            //    for (var i = 0; i < pointsR.Count; i++)
            //    {
            //        float distance = Math.Abs(pointsR[0].X - pointsR[4].X);
            //        var positionOfCenter = pointsR[4].X > pointsR[0].X ? pointsR[4].X - distance / 2 : pointsR[4].X + distance / 2;
            //        var distanceOfTwoCenters = Math.Abs(0 - positionOfCenter);
            //        var xModdifier = 0 > positionOfCenter ? distanceOfTwoCenters : -distanceOfTwoCenters;
            //        pointsR[i] = new Point(pointsR[i].X + (int)xModdifier, pointsR[i].Y);
            //    }
            //    m_handLeft.SetPosition(new PointF(pointsR[3].X, pointsR[3].Y));
            //    m_elbowLeft.SetPosition(new PointF(pointsR[2].X, pointsR[2].Y));
            //    m_kneeLeft.SetPosition(new PointF(pointsR[5].X, pointsR[5].Y));
            //    m_footLeft.SetPosition(new PointF(pointsR[6].X, pointsR[6].Y));


            //    if (!m_once && (m_animation - 1) % m_lolAreaCenters.Count != 0)
            //        using (var file = new System.IO.StreamWriter(@"run.txt", true))
            //        {
            //            file.WriteLine((int)m_handLeft.Position.X + " " + (int)m_handLeft.Position.Y);
            //            file.WriteLine((int)m_elbowLeft.Position.X + " " + (int)m_elbowLeft.Position.Y);
            //            file.WriteLine((int)m_neck.Position.X + " " + (int)m_neck.Position.Y);
            //            file.WriteLine((int)m_headTop.Position.X + " " + (int)m_headTop.Position.Y);
            //            file.WriteLine((int)m_elbowRight.Position.X + " " + (int)m_elbowRight.Position.Y);
            //            file.WriteLine((int)m_handRight.Position.X + " " + (int)m_handRight.Position.Y);
            //            file.WriteLine((int)m_abdomen.Position.X + " " + (int)m_abdomen.Position.Y);
            //            file.WriteLine((int)m_kneeLeft.Position.X + " " + (int)m_kneeLeft.Position.Y);
            //            file.WriteLine((int)m_footLeft.Position.X + " " + (int)m_footLeft.Position.Y);
            //            file.WriteLine((int)m_kneeRight.Position.X + " " + (int)m_kneeRight.Position.Y);
            //            file.WriteLine((int)m_footRight.Position.X + " " + (int)m_footRight.Position.Y);

            //            if ((m_animation) % m_lolAreaCenters.Count == 0) m_once = true;
            //        }
            //}

            //m_head.Update();
        }
    }
}
