using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    static class MergeSort
    {
        private static long time;
        private static int memory = 0;

        public static int[] Sort(int[] array)
        {
            time = DateTime.Now.Ticks;
            mergeSort(array, 0, array.Length - 1);
            time = DateTime.Now.Ticks - time;
            return array;
        }

        private static void mergeSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                mergeSort(array, low, middle);
                mergeSort(array, middle + 1, high);
                merge(array, low, middle, high);
            }
        }

        private static void merge(int[] array, int low, int middle, int high)
        {
            int i = low;
            int k = 0;
            int j = middle + 1;
            int[] temp = new int[high - low + 1];
            memory += 32 * temp.Length;
            Array.Copy(array, low, temp, 0, temp.Length);

            while (i <= middle && j <= high)
            {
                if (array[i] <= array[j])
                {
                    temp[k++] = array[i++];
                }
                else
                {
                    temp[k++] = array[j++];
                }
            }

            if (i <= middle)
            {
                for (j = i; j <= middle; j++)
                {
                    temp[k++] = array[j];
                }
            }
            else
            {
                for (i = j; i <= high; i++)
                {
                    temp[k++] = array[i];
                }
            }
            Array.Copy(temp, 0, array, low, temp.Length);
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
