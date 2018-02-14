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
    class HeapSort
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
        /// Sort function, uses the heap sort algoritm
        /// </summary>
        /// <param name="array">Array of integers</param>
        /// <returns>Returns sorted array</returns>
        public static int[] Sort(int[] array)
        {
            var watch = Stopwatch.StartNew();

            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                heapify(array, array.Length, i);
            }

            int temp;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                heapify(array, i, 0);
            }
            watch.Stop();
            time = watch.ElapsedTicks * (1000000.0 / Stopwatch.Frequency);
            return array;
        }

        private static void heapify(int[] array, int n, int i)
        {
            int parent = i;
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;

            if (leftChild < n && array[leftChild] > array[parent])
                parent = leftChild;

            if (rightChild < n && array[rightChild] > array[parent])
                parent = rightChild;

            if (parent != i)
            {
                int temp = array[i];
                array[i] = array[parent];
                array[parent] = temp;

                heapify(array, n, parent);
            }
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
