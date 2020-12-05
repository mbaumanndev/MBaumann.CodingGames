using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MoreLinq;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public static class Day1
    {
        public static int FirstPart()
        {
            return FindExpenses(ReadLines(), 2).Aggregate((a, b) => a * b);
        }

        public static int SecondPart()
        {
            return FindExpenses(ReadLines(), 3).Aggregate((a, b) => a * b);
        }

        internal static IEnumerable<int> FindExpenses(IEnumerable<int> p_Input, int p_Subsets)
        {
            return p_Input
                .Subsets(p_Subsets)
                .First(s => s.Sum() == 2020);
        }

        private static IEnumerable<int> ReadLines()
        {
            return File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day1.txt").Select(int.Parse);
        }
    }
}
