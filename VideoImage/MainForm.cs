using MoCap.Body;
using MoCap.Properties;
using MoCap.VideoProcessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace MoCap
{
    public partial class MainForm : Form
    {
        public static MainForm Instance;
        public static readonly List<Square> Squares = new List<Square>();
        private static BodyMain s_bodyMain;
        private static BodyMain s_bodyAnimated;
        public Dictionary<int, List<PointF>> s_bodyPositions = new Dictionary<int, List<PointF>>();
        private int m_animationIndex;
        private int m_previousAnimationIndex;
        private int m_timerAnimationInterval = 13;
        public Point PbAnimationLocation => pbAnimation.Location;
        private static int m_timeSeconds;

        public bool IsAutoPlay
        {
            get => cbAutoPlay.Checked;
            set => cbAutoPlay.Checked = value;
        }

        public bool IsReverse
        {
            get => checkBoxReverse.Checked;
            set => checkBoxReverse.Checked = value;
        }

        public bool IsLoop
        {
            get => checkBoxLoop.Checked;
            set => checkBoxLoop.Checked = value;
        }

        public bool IsHead
        {
            get => checkBoxHead.Checked;
            set => checkBoxHead.Checked = value;
        }

        public int TrackBarAnimationValue
        {
            get => trackBarAnimation.Value;
            set
            {
                if(value > trackBarAnimation.Maximum)
                {
                    trackBarAnimation.Maximum = value;
                    trackBarAnimation.Value = value;
                }
            }
        }

        public int TrackBarStartValue
        {
            get => trackBarStart.Value;
            set
            {
                if(value > trackBarStart.Maximum)
                {
                    trackBarStart.Maximum = value;
                    trackBarStart.Value = value;
                }
            }
        }

        public int TrackBarEndValue
        {
            get => trackBarEnd.Value;
            set
            {
                if(value > trackBarEnd.Maximum)
                {
                    trackBarEnd.Maximum = value;
                    trackBarEnd.Value = value;
                }
            }
        }

        public int TrackBarAnimationSpeedValue
        {
            get => trackBarAnimationSpeed.Value;
            set => trackBarAnimationSpeed.Value = value;
        }

        public int ProgressBarVideoValue
        {
            get => progressBarVideo.Value;
            set => progressBarVideo.Value = value;
        }

        public MainForm()
        {
            Instance = this;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            s_bodyMain = new BodyMain(Color.White);
            s_bodyAnimated = new BodyMain(Color.Black, head: true);

            List<PointF> startPositions = IO.StartPositions.Load();

            if(startPositions != null)
            {
                foreach(var startPosition in startPositions)
                {
                    var square = new Square();
                    square.SetLocation(startPosition);
                }
            }

            VideoPlayer.Player.Instance.LoadWholeVideo();
            this.Text = Path.GetFileNameWithoutExtension(IO.Video.Instance.VideoName);

            if(startPositions != null)
            {
                BtnNextClick(null, null);
            }
            else
            {
                pbMain.Image = VideoPlayer.Player.Instance.GetBitmapFromVideo(0);
            }

            VideoPlayer.Player.Instance.PauseClick();

            timerAnimation.Start();

            checkBoxHead.Checked = false;
            this.Controls["Head"].Visible = checkBoxHead.Checked;

            progressBarVideo.Maximum = VideoPlayer.Player.Instance.VideoFramesCount;

            Options.Instance.Load();
            UpdateValues();
        }

        private void PbMainMouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Square.AddSquare(e.Location);
            }
        }

        public static void RemoveAllSquares()
        {
            foreach(Square square in Squares)
            {
                Instance.Controls.Remove(square);
            }
            Squares.Clear();
        }

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void BtnRestartStartPositionsClick(object sender, EventArgs e)
        {
            IO.StartPositions.Delete();
        }

        private void BtnSaveStartPositionClick(object sender, EventArgs e)
        {
            IO.StartPositions.Save(Squares);
        }

        private void PbMainPaint(object sender, PaintEventArgs e)
        {
            s_bodyMain.Draw(e.Graphics);

            foreach(var square in Squares)
            {
                square.Invalidate();
            }
        }

        private void PbAnimationPaint(object sender, PaintEventArgs e)
        {
            s_bodyAnimated.Draw(e.Graphics);
        }

        private void BtnNextClick(object sender, EventArgs e)
        {
            try
            {
                if(VideoPlayer.Player.Instance.Paused)
                {
                    VideoPlayer.Player.Instance.PauseClick();
                }

                List<PointF> bodyPositions = new List<PointF>();
                Bitmap bitmap = Resources.Square;

                s_bodyPositions.TryGetValue(VideoPlayer.Player.FeedPosition, out List<PointF> points);

                if(points == null)
                {
                    VideoPlayer.Player.Instance.Next(out bitmap);

                    if(bitmap == null)
                    {
                        return;
                    }

                    bodyPositions = VideoProcessingMain.Process(bitmap);

                    s_bodyPositions.Add(VideoPlayer.Player.FeedPosition, bodyPositions);
                    s_bodyPositions.TryGetValue(VideoPlayer.Player.FeedPosition, out points);

                    progressBarVideo.Value = s_bodyPositions.Count;
                }

                s_bodyMain?.Update(points);
                UpdateSquares(points);
                s_bodyAnimated?.Update(points);

                pbMain.Image = VideoPlayer.Player.Instance.GetBitmapFromVideo(VideoPlayer.Player.FeedPosition);
                pbAnimation.Refresh();
                VideoPlayer.Player.FeedPosition++;

                UpdateValues(next: true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void UpdateSquares(List<PointF> points)
        {
            for(int i = 0; i < Squares.Count; i++)
            {
                Squares[i].SetLocation(points[i]);
            }
        }

        private void UpdateValues(bool next = false)
        {
            trackBarAnimation.Maximum = s_bodyPositions.Count;
            trackBarStart.Maximum = s_bodyPositions.Count;
            trackBarEnd.Maximum = s_bodyPositions.Count;

            if(trackBarAnimationSpeed.Value == 0)
            {
                trackBarAnimationSpeed.Value = m_timerAnimationInterval;
            }

            timerAnimation.Interval = trackBarAnimationSpeed.Value;

            labelAnimationFrames.Text = Resources.Frames + s_bodyPositions.Count;

            if(next)
            {
                trackBarAnimation.Value = s_bodyPositions.Count;

                if(trackBarEnd.Value == s_bodyPositions.Count - 1)
                {
                    trackBarEnd.Value = s_bodyPositions.Count;
                }
            }
        }

        private void BtnPreviousClick(object sender, EventArgs e)
        {
            if(VideoPlayer.Player.Instance.Paused)
            {
                VideoPlayer.Player.Instance.PauseClick();
            }

            VideoPlayer.Player.Instance.Previous(out Bitmap bitmap);

            if(bitmap != null)
            {
                pbMain.Image = bitmap;
                //ProcessBitmap(bitmap, 0);
            }
        }

        private void BtnPlayClick(object sender, EventArgs e)
        {
            VideoPlayer.Player.Instance.PauseClick();
            var thread = new Thread(Play) { IsBackground = true };
            thread.Start();
        }

        private void Play()
        {
            while(VideoPlayer.Player.Instance.Next(out Bitmap bitmap) != null)
            {
                pbMain.Invoke(
                    (MethodInvoker)delegate
                    {
                        pbMain.Image = bitmap;
                        //ProcessBitmap(cloneBitmap, 0);
                        pbMain.Refresh();
                    });
            }
        }

        private void BtnRewindClick(object sender, EventArgs e)
        {
            VideoPlayer.Player.Instance.PauseClick();
            var thread = new Thread(Rewind) { IsBackground = true };
            thread.Start();
        }

        private void Rewind()
        {
            while(VideoPlayer.Player.Instance.Previous(out Bitmap bitmap) != null)
            {
                pbMain.Invoke(
                    (MethodInvoker)delegate
                    {
                        pbMain.Image = bitmap;
                        //ProcessBitmap(bitmap, 0);
                        pbMain.Refresh();
                    });
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Right:
                    BtnNextClick(null, null);
                    break;
                case Keys.Left:
                    BtnPreviousClick(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void AnimationTimer(object sender, EventArgs e)
        {
            if(m_previousAnimationIndex != m_animationIndex || cbAutoPlay.Checked)
            {

                m_previousAnimationIndex = m_animationIndex;

                if(s_bodyPositions == null)
                {
                    return;
                }

                s_bodyPositions.TryGetValue(m_animationIndex, out List<PointF> points);

                if(cbAutoPlay.Checked)
                {
                    if(m_animationIndex >= trackBarEnd.Value - 1 && !checkBoxReverse.Checked)
                    {
                        if(checkBoxLoop.Checked)
                        {
                            checkBoxReverse.Checked = true;
                        }
                        else
                        {
                            m_animationIndex = trackBarStart.Value;
                        }
                    }
                    else if(m_animationIndex <= trackBarStart.Value && checkBoxReverse.Checked)
                    {
                        if(checkBoxLoop.Checked)
                        {
                            checkBoxReverse.Checked = false;
                        }
                        else
                        {
                            m_animationIndex = trackBarEnd.Value;
                        }
                    }
                    else
                    {
                        if(checkBoxReverse.Checked)
                        {
                            m_animationIndex--;
                        }
                        else
                        {
                            m_animationIndex++;
                        }
                    }
                }

                trackBarAnimation.Value = m_animationIndex;

                if(points != null)
                {
                    s_bodyAnimated?.Update(points);
                    pbAnimation.Refresh();
                }
            }
        }

        private void BtnAutoClick(object sender, EventArgs e)
        {
            System.Timers.Timer timerSeconds = new System.Timers.Timer();
            timerSeconds.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timerSeconds.Interval = 1000;
            timerSeconds.Enabled = true;

            while(progressBarVideo.Value != progressBarVideo.Maximum - 1)
            {
                BtnNextClick(null, null);
            }

            timerSeconds.Enabled = false;
            labelTimeSeconds.Text = m_timeSeconds.ToString() + " sec";
        }

        private void TrackBarAnimationScroll(object sender, EventArgs e)
        {
            m_animationIndex = trackBarAnimation.Value;
            VideoPlayer.Player.FeedPosition = trackBarAnimation.Value;

            s_bodyPositions.TryGetValue(m_animationIndex, out List<PointF> points);

            if(points != null)
            {
                s_bodyMain?.Update(points);

                for(int i = 0; i < Squares.Count; i++)
                {
                    Squares[i].SetLocation(points[i]);
                }

                pbMain.Refresh();
            }


            pbMain.Image = VideoPlayer.Player.Instance.GetBitmapFromVideo(m_animationIndex);

        }

        private void TrackBarStartScroll(object sender, EventArgs e)
        {
            if(trackBarStart.Value > trackBarEnd.Value + 1)
            {
                trackBarStart.Value = trackBarEnd.Value;
            }
        }

        private void TrackBarEndScroll(object sender, EventArgs e)
        {
            if(trackBarEnd.Value < trackBarStart.Value + 1)
            {
                trackBarEnd.Value = trackBarStart.Value;
            }
        }

        private void TrackBarAnimationSpeedScroll(object sender, EventArgs e)
        {
            if(trackBarAnimationSpeed.Value > 0)
            {
                timerAnimation.Interval = trackBarAnimationSpeed.Value;
            }
        }

        private void CheckBoxHeadCheckedChanged(object sender, EventArgs e)
        {
            this.Controls["Head"].Visible = checkBoxHead.Checked;
        }

        private void ButtonSaveProjectClick(object sender, EventArgs e)
        {
            Options.Instance.Save();
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            m_timeSeconds++;
        }
    }
}
