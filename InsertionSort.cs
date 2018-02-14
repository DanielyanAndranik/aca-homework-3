using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgorithms
{
    /// <summary>
    /// Class fo instertion Sort algorithm
    /// </summary>
    static class InsertionSort
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
        /// Sort function, uses the insertion sort algoritm
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <returns>Returns sorted array</returns>
        public static int[] Sort(int[] array)
        {
            var watch = Stopwatch.StartNew();
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

            watch.Stop();
            time = watch.ElapsedTicks * (1000000.0 / Stopwatch.Frequency);
            return array;
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
