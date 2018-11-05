using AForge.Video.FFMPEG;
using System.Drawing;

namespace MoCap.IO
{
    public class Video
    {
        private static Video s_instance;
        public static Video Instance => s_instance ?? (s_instance = new Video());

        public string VideoName => "test-5sec.wmv";
        private readonly VideoFileReader m_reader = new VideoFileReader();

        private Video()
        {
            m_reader.Open(VideoName);
        }

        public Bitmap NextBitmap()
        {
            return m_reader.ReadVideoFrame();
        }
    }
}
