using AForge.Video.FFMPEG;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using MoCap.VideoProcessing;

namespace VideoImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            const string VideoName = "test.wmv";
            string videoPath = Path.Combine(@"C:\Users\Luka\Source\Repos\MoCap\VideoImage\VideoImage", VideoName);

            var reader = new VideoFileReader();
            reader.Open(videoPath);

            for(int i = 0; i < 1; i++)
            {
                Bitmap videoFrame = reader.ReadVideoFrame();
                pictureBox1.Image = videoFrame;


                Main.Process(videoFrame);


                //videoFrame.Dispose();
            }
            reader.Close();
        }
    }
}
