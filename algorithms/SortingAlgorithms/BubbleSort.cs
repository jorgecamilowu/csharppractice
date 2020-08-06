using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    class BubbleSort
    {
        private static bool swapped;
        public static void sort(int[] list)
        {
            do
            {
                swapped = false;
                for (int i = 0; i < list.Length-1; i++)
                {
                    if (list[i] > list[i+1])
                    {
                        Util.swap(list, i, i + 1);
                        swapped = true;
                    }
                }
            } while (swapped);
        }


    }
}
