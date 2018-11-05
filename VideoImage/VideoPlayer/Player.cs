using System.Collections.Generic;
using System.Drawing;

namespace MoCap.VideoPlayer
{
    public class Player
    {
        private static Player s_instance;
        public static Player Instance => s_instance ?? (s_instance = new Player());

        private readonly List<Bitmap> m_feed = new List<Bitmap>();
        private bool m_paused;
        public bool Paused => m_paused;
        public static int FeedPosition { get; set; }
        public int VideoFramesCount;

        public Bitmap Next(bool isLoadVideo = false)
        {
            if(m_paused)
            {
                return null;
            }

            if(FeedPosition + 1 >= m_feed.Count)
            {
                Bitmap videoFrame = IO.Video.Instance.NextBitmap();

                if(videoFrame == null)
                {
                    return null;
                }

                m_feed.Add(videoFrame);

                if(isLoadVideo)
                {
                    FeedPosition++;
                }

                return m_feed[FeedPosition - 1];
            }

            if(isLoadVideo)
            {
                FeedPosition++;
            }

            return m_feed[FeedPosition];
        }

        public Bitmap Next(out Bitmap bitmap)
        {
            bitmap = Next();

            return bitmap;
        }

        public Bitmap Previous()
        {
            if(m_paused)
            {
                return null;
            }

            if(FeedPosition - 1 >= 0)
            {
                FeedPosition--;
                return m_feed[FeedPosition];
            }

            return null;
        }

        public Bitmap Previous(out Bitmap bitmap)
        {
            return bitmap = Previous();
        }

        public void PauseClick()
        {
            m_paused = !m_paused;
        }

        public void LoadWholeVideo()
        {
            m_paused = false;

            while(Next(true) != null)
            {
                VideoFramesCount++;
            }

            FeedPosition = 0;
            m_paused = true;
        }

        public Bitmap GetBitmapFromVideo(int position)
        {
            return m_feed[position];
        }
    }
}
