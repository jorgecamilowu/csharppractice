using System;
using System.Collections.Generic;

namespace NQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            BruteForce.Print(BruteForce.Solve(4));

            List<int[]> dpresults = DP.Solve(4);
            foreach (int[] item in dpresults)
            {
                foreach (int ele in item)
                {
                    Console.Write("{0} ", ele);
                }
                Console.WriteLine();
            }

            List<int[,]> btresults = BackTracking.Solve(4);
            BackTracking.Print(btresults);
        }
    }
}
