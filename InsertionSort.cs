using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    static class InsertionSort
    {
        private static long time;
        private static int memory = 0;

        public static int[] Sort(int[] array)
        {
            time = DateTime.Now.Ticks;
            int temp, j, k;
            for (int i = 1; i < array.Length; i++)
            {
                k = array[i];
                j = i - 1;
                while (j >= 0 && k < array[j])
                {
                    temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;

                    j--;
                }
            }

            time = DateTime.Now.Ticks - time;
            return array;
        }

        public static double GetTime()
        {
            return new TimeSpan(time).TotalMilliseconds;
        }

        public static int GetMemory()
        {
            return memory;
        }
    }
}
