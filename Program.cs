using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            
             int[] randomArray = GenerateRandomArray(UserInputSize());
             int[] algorithms = UserSelectedAlgorithms();
             double minTime = SortAndGetMinTime(randomArray, algorithms);
             PrintResult(algorithms, minTime);
            
        }

        /// <summary>
        /// Prints result of sort algorithms used memory and time
        /// </summary>
        /// <param name="algorithms">Array of integers</param>
        /// <param name="minTime"></param>
        private static void PrintResult(int[] algorithms, double minTime)
        {
            for (int i = 0; i < algorithms.Length; i++)
            {
                switch (algorithms[i])
                {
                    case 1:
                        if (InsertionSort.GetTime() == minTime)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("Insertion Sort Agorithm");
                        Console.WriteLine("Running time: {0} miliseconds", InsertionSort.GetTime());
                        Console.WriteLine("Memory usage: {0} bytes", InsertionSort.GetMemory());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        if (BubbleSort.GetTime() == minTime)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("Bubble Sort Agorithm");
                        Console.WriteLine("Running time: {0} miliseconds", BubbleSort.GetTime());
                        Console.WriteLine("Memory usage: {0} bytes", BubbleSort.GetMemory());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        if (QuickSort.GetTime() == minTime)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("Quick Sort Agorithm");
                        Console.WriteLine("Running time: {0} miliseconds", QuickSort.GetTime());
                        Console.WriteLine("Memory usage: {0} bytes", QuickSort.GetMemory());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        if (HeapSort.GetTime() == minTime)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("Heap Sort Agorithm");
                        Console.WriteLine("Running time: {0} miliseconds", HeapSort.GetTime());
                        Console.WriteLine("Memory usage: {0} bytes", HeapSort.GetMemory());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        if (MergeSort.GetTime() == minTime)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine("Merge Sort Agorithm");
                        Console.WriteLine("Running time: {0} miliseconds", MergeSort.GetTime());
                        Console.WriteLine("Memory usage: {0} bytes", MergeSort.GetMemory());
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        /// <summary>
        /// Sorts arrays and returns min time
        /// </summary>
        /// <param name="randomArray">Array of integers</param>
        /// <param name="algorithms">Selected algorithms</param>
        /// <returns></returns>
        private static double SortAndGetMinTime(int[] randomArray, int[] algorithms)
        {
            int[] copyArray = new int[randomArray.Length];

            double min = double.MaxValue;

            for (int i = 0; i < algorithms.Length; i++)
            {
                switch (algorithms[i])
                {
                    case 1:
                        Array.Copy(randomArray, copyArray, randomArray.Length);
                        InsertionSort.Sort(copyArray);
                        if (InsertionSort.GetTime() < min)
                        {
                            min = InsertionSort.GetTime();
                        }
                        break;
                    case 2:
                        Array.Copy(randomArray, copyArray, randomArray.Length);
                        BubbleSort.Sort(copyArray);
                        if (BubbleSort.GetTime() < min)
                        {
                            min = BubbleSort.GetTime();
                        }
                        break;
                    case 3:
                        Array.Copy(randomArray, copyArray, randomArray.Length);
                        QuickSort.Sort(copyArray);
                        if (QuickSort.GetTime() < min)
                        {
                            min = QuickSort.GetTime();
                        }
                        break;
                    case 4:
                        Array.Copy(randomArray, copyArray, randomArray.Length);
                        HeapSort.Sort(copyArray);
                        if (HeapSort.GetTime() < min)
                        {
                            min = HeapSort.GetTime();
                        }
                        break;
                    case 5:
                        Array.Copy(randomArray, copyArray, randomArray.Length);
                        MergeSort.Sort(copyArray);
                        if (MergeSort.GetTime() < min)
                        {
                            min = MergeSort.GetTime();
                        }
                        break;
                }
            }
            return min;
        }

        /// <summary>
        /// User selects algorithms to sort
        /// </summary>
        /// <returns></returns>
        private static int[] UserSelectedAlgorithms()
        {
            Console.WriteLine("Select which algorithm you want to perform:");
            Console.WriteLine("1. Insertion Sort \n" +
                              "2. Bubble Sort \n" +
                              "3. Quick sort \n" +
                              "4. Heap sort \n" +
                              "5. Merge sort \n" +
                              "6. All of above");
            Console.WriteLine("Enter the number(f.e. 2) or a range(f.e. 1-4) or several algorithms(f.e. 2,4,5)");
            int[] numbers;
            string userInput;
            do
            {
                userInput = Console.ReadLine();
                if (Regex.IsMatch(userInput, "^[1-6]$"))
                {
                    if(int.Parse(userInput) == 6)
                    {
                        numbers = new int[] { 1, 2, 3, 4, 5 };
                    }
                    else
                    {
                        numbers = new int[] { Int32.Parse(userInput) };
                    }                  
                    break;
                }
                else if (Regex.IsMatch(userInput, "^[1-4]-[2-5]"))
                {
                    var arr = Array.ConvertAll(userInput.Split('-'), Int32.Parse);
                    if (arr.Min() == arr.Max())
                    {
                        numbers = new int[] { arr.Min() };
                    }
                    else
                    {
                        numbers = new int[arr.Max() - arr.Min() + 1];
                        for (int i = arr.Min(); i <= arr.Max(); i++)
                        {
                            numbers[i - arr.Min()] = i;
                        }
                    }
                    break;
                }
                else if (Regex.IsMatch(userInput, "^(([1-5][,]){1,4}?)[1-5]$"))
                {
                    numbers = Array.ConvertAll(userInput.Split(','), Int32.Parse);
                    numbers = numbers.Distinct().ToArray();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Please enter a correct value");
                }
            }
            while (true);
            return numbers;
        }

        /// <summary>
        /// Generates random array of integers
        /// </summary>
        /// <param name="size">Size of array</param>
        /// <returns></returns>
        private static int[] GenerateRandomArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        /// <summary>
        /// User inputs the size of array that he/she wantss
        /// </summary>
        /// <returns></returns>
        private static int UserInputSize()
        {
            string userInput;
            int size;
            Console.WriteLine("Please enter the size of an array that you want to sort:");
            do
            {
                userInput = Console.ReadLine();
                try
                {
                    size = Int32.Parse(userInput);
                    if (size >= 2)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Please enter a correct value");
                }
            }
            while (true);
            return size;
        }
    }
}
