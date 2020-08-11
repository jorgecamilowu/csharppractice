using System;
using System.Collections.Generic;

/*
 * Practice referenced from Stanford University's CS106B class handout: "Exhaustive recursion and backtracking"
 * written by J Zelenski
 */
namespace NQueens
{
    class BackTracking
    {
        public static List<int[,]> Solve(int n)
        {
            int[,] board = new int[n,n];
            List<int[,]> results = new List<int[,]>();
            Queens(board, 0, results);
            return results;
        }
        private static bool Queens(int[,] board, int col, List<int[,]> results)
        {
            if (col >= board.GetLength(0))
            {
                int[,] temp = new int[board.GetLength(0), board.GetLength(1)];
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        temp[i, j] = board[i, j];
                    }
                }
                results.Add(temp);
            }

            for (int row = 0; row < board.GetLength(0); row++)
            {
                if (IsValid(board, row, col))
                {
                    board[row, col] = 1;
                    if (Queens(board, col + 1, results)) return true;
                    board[row, col] = 0;
                }
            }

            return false;
        }

        private static bool IsValid(int[,] board, int row, int col)
        {
            int i, j;
            // Check this row on left side
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1) return false;
            }

            // Check southwest diagonal
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1) return false;
            }

            // Check northwest diagonal
            for (i = row, j = col; j >= 0 && i < board.GetLength(0); i++, j--)
            {
                if (board[i, j] == 1) return false;
            }

            return true;
        }

        public static void Print(List<int[,]> list)
        {
            foreach (int[,] item in list)
            {
                Console.WriteLine();
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    for (int j = 0; j < item.GetLength(1); j++)
                    {
                        Console.Write("{0} ", item[i,j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Solutions: {0}", list.Count);
        }
    }
}
