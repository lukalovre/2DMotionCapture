using System.Drawing;

using MoCap.VideoProcessing;

namespace MoCap.Tools
{
    class FilterPreview
    {
        private static FilterPreview s_instance;
        public static FilterPreview Instance => s_instance ?? (s_instance = new FilterPreview());

        public Bitmap SimilarColorTexture;
        public Bitmap ClearImageTexture;
        private bool m_once1;

        public void SimilarColorFilter(Bitmap videoTexture)
        {
            if(m_once1)
            {
                return;
            }

            SimilarColorTexture = new Bitmap(videoTexture.Width, videoTexture.Height);

            CopyTexture(ref SimilarColorTexture, videoTexture);

            var similarColorData = new Color[SimilarColorTexture.Width * SimilarColorTexture.Height];
            // SimilarColorTexture.GetData(similarColorData);
            var sc = new SimilarColors(similarColorData, SimilarColorTexture.Width, SimilarColorTexture.Height);
            // new_data = sc.find_similar_colors(video_data[(int)(AreaSelection.Instance.Selected_Points[index].X + AreaSelection.Instance.Selected_Points[index].Y * videoTexture.Width)]);
            similarColorData = sc.FindSimilarColors(VideoProcessingMain.Colors);
            //SimilarColorTexture.SetData(similarColorData);
            m_once1 = true;
        }



        private bool m_once2;

        public void ClearImageFilter(Bitmap videoTexture)
        {
            if(m_once2)
            {
                return;
            }

            ClearImageTexture = new Bitmap(videoTexture.Width, videoTexture.Height);

            CopyTexture(ref ClearImageTexture, videoTexture);

            var clearImageData = new Color[ClearImageTexture.Width * ClearImageTexture.Height];
            // ClearImageTexture.GetData(clearImageData);
            var sc = new SimilarColors(clearImageData, ClearImageTexture.Width, ClearImageTexture.Height);
            // new_data = sc.find_similar_colors(video_data[(int)(AreaSelection.Instance.Selected_Points[index].X + AreaSelection.Instance.Selected_Points[index].Y * videoTexture.Width)]);
            clearImageData = sc.FindSimilarColors(VideoProcessingMain.Colors);

            ClearImage.clear_image(clearImageData, ClearImageTexture.Width, ClearImageTexture.Height);

            // ClearImageTexture.SetData(clearImageData);
            m_once2 = true;
        }


        private static void CopyTexture(ref Bitmap copy, Bitmap original)
        {
            var originalData = new Color[original.Width * original.Height];
            //original.GetData(originalData);

            var copyData = new Color[original.Width * original.Height];

            for(var i = 0; i < originalData.Length; i++) copyData[i] = originalData[i];

            //copy.SetData(copyData);
        }
    }
}
