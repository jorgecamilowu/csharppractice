using System;
using System.Collections.Generic;

/*
 * Practice referenced from Cracking the Coding Interview by Gayle Laakmann Mcdowell
 */
namespace NQueens
{
    class DP
    {
        public static List<int[]> Solve(int n)
        {
            int[] board = new int[n];
            List<int[]> results = new List<int[]>();
            Queens(board, 0, results);
            return results;
        }
        private static void Queens(int[] board, int row, List<int[]> results)
        {
            if (row >= board.Length)
            {
                int[] temp = new int[board.Length];
                Array.Copy(board, temp, board.Length);
                results.Add(temp);
            }

            for (int col = 0; col < board.Length; col++)
            {
                if (IsValid(board, row, col))
                {
                    board[row] = col; // place queen
                    Queens(board, row + 1, results);
                }
            }
        }

        private static bool IsValid(int[] board, int row1, int col1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int col2 = board[row2];
                
                // check that no queens are lined up on the same columns
                if (col2 == col1) return false;

                // check that no queens are placed on the same slope (diagonals)
                int colDistance = Math.Abs(col2 - col1);
                int rowdistance = row1 - row2; // row1 > row2, no need for Abs
                if (rowdistance == colDistance) return false;
            }

            return true;
        }
    }
}
