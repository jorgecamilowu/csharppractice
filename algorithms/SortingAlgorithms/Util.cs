using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms
{
    class Util
    {
        public static void swap(int[] list, int first, int second)
        {
            int temp = list[first];
            list[first] = list[second];
            list[second] = temp;
        }
    }
}
