using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    class SelectionSort
    {
        public static void sort(int[] list)
        {
            for (int i = 0; i < list.Length-1; i++)
            {
                int j = i + 1;
                int min = list[i], minIdx = -1;
                while (j < list.Length)
                {
                    if (list[j] < min)
                    {
                        minIdx = j;
                        min = list[j];
                    }
                    //minIdx = list[j] < min ? j : minIdx;
                    j++;
                }
                if (minIdx != -1)
                {
                    Util.swap(list, i, minIdx);
                }
            }
        }
    }
}
