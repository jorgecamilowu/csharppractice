using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

/*
 * Practice referenced from Stanford University's CS106B class handout: "Exhaustive recursion and backtracking"
 * written by J Zelenski
 * 
 * BruteForce method:
 * Calculates all possible permutations and then filters out valid ones
 */
namespace NQueens
{
    class BruteForce
    {
        public static List<List<int>> Solve(int n)
        {
            List<int> init = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                init.Add(i);
            }

            List<List<int>> allPermutations = new List<List<int>>();
            List<List<int>> results = new List<List<int>>();
            Permute(new List<int>(), init, allPermutations);
            foreach (List<int> item in allPermutations)
            {
                if (IsValid(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        private static bool IsValid(List<int> solution)
        {
            for (int row1 = 0; row1 < solution.Count; row1++)
            {
                for (int row2 = row1 + 1; row2 < solution.Count; row2++)
                {
                    int x = Math.Abs(row2 - row1);
                    int y = Math.Abs(solution[row2] - solution[row1]);
                    if (x == y) return false;
                }
            }
            return true;
        }

        private static void Permute(List<int> soFar, List<int> rest, List<List<int>> permutations)
        {
            if (rest.Count == 0)
            {
                permutations.Add(new List<int>(soFar));
            }
            else
            {
                for (int i = 0; i < rest.Count; i++)
                {
                    List<int> remaining = new List<int>(rest);
                    List<int> updatedSoFar = new List<int>(soFar);
                    remaining.RemoveAt(i);
                    updatedSoFar.Add(rest[i]);
                    Permute(updatedSoFar, remaining, permutations);
                }
            }
        }
        public static void Print(List<List<int>> list)
        {
            int count = 0;
            foreach (List<int> item in list)
            {
                foreach (int ele in item)
                {
                    Console.Write("{0} " ,ele);
                }
                Console.WriteLine();
                count++;
            }
            Console.WriteLine("Possible solutions: {0}", count);
        }
    }
}
