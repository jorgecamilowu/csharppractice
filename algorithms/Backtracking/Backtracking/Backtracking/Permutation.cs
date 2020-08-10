using System;
using System.Collections.Generic;
using System.Text;

/*
 * Practice referenced from Stanford University's CS106B class handout: "Exhaustive recursion and backtracking"
 * written by J Zelenski
 */
namespace Recursion
{
    class Permutation
    {
        /*
        * Pseudocode:
        * If no more characters left to rearrange, print current permutation.
        * for (every possible choice among the characters left to rearrange) {
        *   Make a choice and add that character to the permutation so far
        *   Use recursion to rearrange the remaining letters
        }
         */
        public static void StringPermute(string soFar, string rest)
        {
            if (rest.Length == 0)
            {
                Console.WriteLine(soFar);
            } else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);
                    StringPermute(soFar + rest[i], remaining);
                }
            }
        }

        /*
         * If there are no more elements remainig, print current subset.
         * else:
         *      Consider the next element of those remaining
         *      Include it to the current subset, and use recursion to build subsets from here
         *      Exclude it to the current subset, and use recursion to build subsets from here
         */
        public static void SubsetPermute(string soFar, string rest)
        {
            if (rest.Length == 0)
            {
                Console.WriteLine(soFar);
            } else
            {
                SubsetPermute(soFar + rest[0], rest.Substring(1)); // include the current element on the next iteration
                SubsetPermute(soFar, rest.Substring(1)); // exclude the current element on the next iteration
            }
        }

        /*
         * bool Solve(configuration conf) {
         *      if (no more choices) // BASE CASE
         *          return (conf is a goal state);
         *      for (all available choices) {
         *          try once choice c;
         *          ok = Solve(conf with choice c);
         *          if ok {
         *              return true;
         *          } else {
         *              unmake choice c;
         *          }
         *      }
         *      return false; // tried all choices, no solution found
         * }
         */
        public static string FindWord(string soFar, string rest, HashSet<string> lexicon) 
        {
            if (rest.Length == 0)
            {
                string word = lexicon.Contains(soFar) ? soFar : "";
                return word;
            } else
            {
                for (int i = 0; i < rest.Length; i++)
                {
                    string remaining = rest.Substring(0, i) + rest.Substring(i + 1);
                    string found = FindWord(soFar + rest[i], remaining, lexicon);
                    if (found.Length != 0)
                    {
                        return found;
                    }
                }
            }
            return ""; // empty string means failure
        }
    }
}
