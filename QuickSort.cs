using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class QuickSort
    {
        private static long time;
        private static int memory = 0;

        public static int[] Sort(int[] array)
        {
            time = DateTime.Now.Ticks;
            quickSort(array, 0, array.Length - 1);
            time = DateTime.Now.Ticks - time;
            return array;
        }

        private static void quickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int p = partitionIndex(array, left, right);
                quickSort(array, left, p - 1);
                quickSort(array, p + 1, right);
            }
        }

        private static int partitionIndex(int[] array, int left, int right)
        {
            int pivot = array[right];
            int index = left;
            int temp;
            for (int i = left; i < right; i++)
            {
                if (array[i] <= pivot)
                {
                    temp = array[i];
                    array[i] = array[index];
                    array[index] = temp;
                    index++;
                }
            }
            temp = array[right];
            array[right] = array[index];
            array[index] = temp;
            return index;
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
