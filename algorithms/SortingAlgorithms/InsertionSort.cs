using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    class InsertionSort
    {
        public static void sort(int[] list)
        {
            for (int i = 1; i < list.Length; i++) 
            {
                int j = i;
                while (j > 0 && list[j-1] > list[j])
                {
                    Util.swap(list, j, j - 1);
                    j--;
                }
            }
        }
    }
}
