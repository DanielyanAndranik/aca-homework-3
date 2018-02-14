using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgorithms
{
    /// <summary>
    /// Class for Bubble Sort Algorithm
    /// </summary>
    static class BubbleSort
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
        /// Sort function, uses the bubble sort algoritm
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <returns>Returns sorted array</returns>
        public static int[] Sort(int[] array)
        {
            var watch = Stopwatch.StartNew();
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
            return time;
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
