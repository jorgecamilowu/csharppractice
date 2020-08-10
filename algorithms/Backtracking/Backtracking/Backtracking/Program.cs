using System;
using System.Collections.Generic;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //string word = "123";
            //Permutation.StringPermute("", word);
            //Permutation.SubsetPermute("", word);

            HashSet<string> lexicon = new HashSet<string>();
            lexicon.Add("hello");
            string word = "ollhe";
            string output = Permutation.FindWord("", word, lexicon);
            Console.WriteLine(output);
        }
    }
}
