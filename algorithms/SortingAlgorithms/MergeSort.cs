using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace SortingAlgorithms
{
    class MergeSort
    {
        public static void sort(int[] list, int start, int end)
        {
            if (start >= end) return;

            int mid = (start + end) / 2;
            sort(list, start, mid);
            sort(list, mid + 1, end);
            merge(list, start, end);
        }

        private static void merge(int[] list, int start, int end)
        {
            if (start == end) return;
            int mid = (start + end) / 2;
            int[] temp = new int[list.Length];

            int i = start, j = mid + 1, k = start;

            while (i < mid+1 && j < end+1)
            {
                if (list[i] < list[j])
                {
                    temp[k++] = list[i++];
                }
                else
                {
                    temp[k++] = list[j++];
                }
            }

            /* At this point, one of the halves will have finished before the other one, 
               finish passing the half that still has unresolved elements.
               Note that only one of the following while loops will run */
            while (i < mid+1)
            {
                temp[k++] = list[i++];
            }
            while (j < end+1)
            {
                temp[k++] = list[j++];
            }

            // replace first with temp
            Array.Copy(temp, start, list, start, end - start + 1);
        }
    }
}
