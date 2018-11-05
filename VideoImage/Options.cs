using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace MoCap
{
    public class Options
    {
        private static Options s_instance;
        public static Options Instance => s_instance ?? (s_instance = new Options());

        private static string m_name = "Options.txt";
        private string m_path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), m_name);

        public Dictionary<int, List<PointF>> BodyPositions => MainForm.Instance.s_bodyPositions;
        public bool IsAutoPlay;
        public bool IsReverse;
        public bool IsLoop;
        public bool IsHead;
        public int TrackBarAnimationValue;
        public int TrackBarStartValue;
        public int TrackBarEndValue;
        public int TrackBarAnimationSpeedValue;
        public int ProgressBarVideoValue;

        public void Save()
        {
            IsAutoPlay = MainForm.Instance.IsAutoPlay;
            IsReverse = MainForm.Instance.IsReverse;
            IsLoop = MainForm.Instance.IsLoop;
            IsHead = MainForm.Instance.IsHead;
            TrackBarAnimationValue = MainForm.Instance.TrackBarAnimationValue;
            TrackBarStartValue = MainForm.Instance.TrackBarStartValue;
            TrackBarEndValue = MainForm.Instance.TrackBarEndValue;
            TrackBarAnimationSpeedValue = MainForm.Instance.TrackBarAnimationSpeedValue;
            ProgressBarVideoValue = MainForm.Instance.ProgressBarVideoValue;

            Task task = Task.Factory.StartNew(SaveTask);
            Task.WaitAll(task);
        }

        public void Load()
        {
            Task task = Task.Factory.StartNew(LoadTask);
            Task.WaitAll(task);

            MainForm.Instance.IsAutoPlay = Instance.IsAutoPlay;
            MainForm.Instance.IsReverse = Instance.IsReverse;
            MainForm.Instance.IsLoop = Instance.IsLoop;
            MainForm.Instance.IsHead = Instance.IsHead;
            MainForm.Instance.TrackBarAnimationValue = Instance.TrackBarAnimationValue;
            MainForm.Instance.TrackBarStartValue = Instance.TrackBarStartValue;
            MainForm.Instance.TrackBarEndValue = Instance.TrackBarEndValue;
            MainForm.Instance.TrackBarAnimationSpeedValue = Instance.TrackBarAnimationSpeedValue;
            MainForm.Instance.ProgressBarVideoValue = Instance.ProgressBarVideoValue;
        }

        private void SaveTask()
        {
            var serializer = new JsonSerializer();

            using(StreamWriter sw = new StreamWriter(m_path))
            {
                using(JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, Instance);
                }
            }
        }

        private void LoadTask()
        {
            if(File.Exists(m_path))
            {
                string output = File.ReadAllText(m_path);
                s_instance = JsonConvert.DeserializeObject<Options>(output);
            }
        }
    }
}
