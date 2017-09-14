using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseManager.Models
{
    public class Range
    {
        private int min;
        public int Min
        {
            get { return min; }
            set
            {
                min = value;
                if (max == 0)
                    max = min;
                SetupArray();
            }
        }

        private int max;
        public int Max
        {
            get { return max; }
            set
            {
                max = value;
                SetupArray();
            }
        }

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

        public Range()
        {
        }
    }
}
