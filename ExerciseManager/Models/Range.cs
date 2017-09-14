using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseManager.Models
{
    public class Range
    {
        public int Min { get; set; }

        public int Max { get; set; }

        public int Count { get { return rangearray.Length; } }

        public int[] RangeArray
        {
            get { return rangearray; }
        }

        private int[] rangearray;

        public Range(int minmax)
        {
            Min = minmax;
            Max = minmax;
            rangearray = new int[1] { minmax };
        }

        public Range(int min, int max)
        {
            if (max > min &&
                max > 0 &&
                min > 0)
            {
                Min = min;
                Max = max;
                SetupArray();
            }
        }

        private void SetupArray()
        {
            int count = Max - Min + 1;
            rangearray = new int[count];

            int countingmin = Min;
            for (int i = 0; i < count; i++)
            {
                rangearray[i] = countingmin;
                countingmin++;
            }
        }
    }
}
