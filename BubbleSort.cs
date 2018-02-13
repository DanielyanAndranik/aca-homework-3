using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    static class BubbleSort
    {
        private static long time;
        private static int memory = 0;
        public static int[] Sort(int[] array)
        {
            time = DateTime.Now.Ticks;
            int temp;
            for(int i = 0; i < array.Length; i++)
            {
                for(int j = 0; j < array.Length - i - 1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
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
