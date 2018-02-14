using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgorithms
{
    /// <summary>
    /// Class for Merge Sort algorithm
    /// </summary>
    static class MergeSort
    {
        /// <summary>
        /// Execution time of Sort function
        /// </summary>
        private static double time;

        /// <summary>
        /// Sort function usage memory
        /// </summary>
        private static int memory = 0;

        /// <summary>
        /// Sort function, uses the merge sort algoritm
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <returns>Returns sorted array</returns>
        public static int[] Sort(int[] array)
        {
            var watch = Stopwatch.StartNew();
            mergeSort(array, 0, array.Length - 1);
            watch.Stop();
            time = watch.ElapsedTicks * (1000000.0 / Stopwatch.Frequency);
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

        /// <summary>
        /// Returns the time 
        /// </summary>
        /// <returns></returns>
        public static double GetTime()
        {
            return (double)time;
        }

        /// <summary>
        /// Returns the memory
        /// </summary>
        /// <returns></returns>
        public static int GetMemory()
        {
            return memory;
        }
    }
}
