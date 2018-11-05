using System.Drawing;

namespace MoCap.VideoProcessing
{
    static class ClearImage
    {
        public static void clear_image(Color[] data, int width, int height)
        {
            for (var i = 0; i < data.Length; i++)
            {
                var neighbors = 0;

                var zero = i - width - 1;
                var one = i - width;
                var two = i - width + 1;
                var three = i + 1;
                var four = i + width + 1;
                var five = i + width;
                var six = i + width - 1;
                var seven = i - 1;

                int[] list = { zero, one, two, three, four, five, six, seven };

                for (var j = 0; j < list.Length; j++)
                {
                    if (data.Length > list[j] && list[j] >= 0)
                    {
                        if (data[list[j]].B == 0) neighbors++;
                    }
                }

                if (neighbors > 3)
                {
                    data[i] = Color.Black;
                }
                else data[i] = Color.White;
            }
        }

    }
}
