using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortAlgorithms
{
    class HeapSort
    {
        private static long time;
        private static int memory = 0;

        public static int[] Sort(int[] array)
        {
            time = DateTime.Now.Ticks;

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
            time = DateTime.Now.Ticks - time;
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
