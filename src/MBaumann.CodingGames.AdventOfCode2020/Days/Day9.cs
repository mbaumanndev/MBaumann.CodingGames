using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MoreLinq;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public sealed class Day9
    {
        public static long FirstPart()
        {
            return FindBadNumber(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day9.txt"), 25);
        }
        
        public static long SecondPart()
        {
            return FindEcryptionWeakness(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day9.txt"), 25);
        }
        
        public static long FindBadNumber(string p_Input, int p_PreambleSize)
        {
            var v_Numbers = p_Input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);

            return v_Numbers.Window(p_PreambleSize + 1)
                .AsParallel()
                .Choose(p_Block =>
                {
                    var v_Preamble = p_Block.Take(p_PreambleSize);
                    var v_Last = p_Block.ElementAt(p_PreambleSize);

                    var v_Matches = v_Preamble.Subsets(2)
                        .Where(p_Pair => p_Pair.Fold((a, b) => a != b && a + b == v_Last));

                    return (!v_Matches.Any(), v_Last);
                })
                .First();
        }

        public static long FindEcryptionWeakness(string p_Input, int p_PreambleSize)
        {
            var v_BadNumber = FindBadNumber(p_Input, p_PreambleSize);
            var v_Numbers = p_Input.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse);

            return Enumerable.Range(2, v_Numbers.Count() - 1)
                .SelectMany(p_Size => v_Numbers.Window(p_Size))
                .AsParallel()
                .Choose(p_Block =>
                {


                    return (p_Block.Sum() == v_BadNumber, p_Block.Min() + p_Block.Max());
                })
                .First();
        }
    }
}
