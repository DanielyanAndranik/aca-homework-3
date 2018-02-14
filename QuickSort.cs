using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgorithms
{
    /// <summary>
    /// Class for Quick Sort algorithm
    /// </summary>
    static class QuickSort
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
        /// Sort function, uses the quick sort algoritm
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <returns>Returns sorted array</returns>
        public static int[] Sort(int[] array)
        {
            var watch = Stopwatch.StartNew();
            quickSort(array, 0, array.Length - 1);
            watch.Stop();
            time = watch.ElapsedTicks * (1000000.0 / Stopwatch.Frequency);
            return array;
        }

        /// <summary>
        /// Split array into two subarrays 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void quickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int p = partitionIndex(array, left, right);
                quickSort(array, left, p - 1);
                quickSort(array, p + 1, right);
            }
        }

        /// <summary>
        /// Return index of pivot
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <param name="left">Left index of array</param>
        /// <param name="right">Right index of array</param>
        /// <returns></returns>
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
