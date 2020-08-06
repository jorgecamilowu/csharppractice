using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 10, 3, 2, 4, 3 };
            Console.Write("Bubble Sort: ");
            BubbleSort.sort(array);
            print(array);

            array = new int[] { 5, 10, 3, 2, 4, 3 };
            Console.Write("Insertion Sort: ");
            InsertionSort.sort(array);
            print(array);

            array = new int[] { 5, 10, 3, 2, 4, 3 };
            Console.Write("Selection Sort: ");
            SelectionSort.sort(array);
            print(array);

            array = new int[] { 5, 10, 3, 2, 4, 3 };
            Console.Write("Merge Sort: ");
            MergeSort.sort(array, 0, array.Length-1);
            print(array);
        }

        private static void print(int[] list)
        {
            foreach (int ele in list)
            {
                Console.Write($"{ele} ");
            }
            Console.WriteLine();
        }
    }
}
