using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    internal class Day6
    {
        public static int FirstPart()
        {
            return CountForAnyonePlane(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day6.txt"));
        }

        internal static int SecondPart()
        {
            return CountForEveryonePlane(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day6.txt"));
        }

        public static int CountForAnyoneGroup(string p_Input)
        {
            return p_Input.Replace("\n", String.Empty)
                .Replace("\r", String.Empty)
                .AsEnumerable()
                .Distinct()
                .Count();
        }

        public static int CountForAnyonePlane(string p_Input)
        {
            return p_Input.Split(new[] {Environment.NewLine + Environment.NewLine},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(CountForAnyoneGroup)
                .Sum();
        }

        internal static int CountForEveryoneGroup(string p_Input)
        {
            var v_LinesCount = p_Input.Count(c => c == '\n') + 1;

            return p_Input.Replace("\n", String.Empty)
                .Replace("\r", String.Empty)
                .GroupBy(c => c)
                .Count(g => g.Count() == v_LinesCount);
        }

        internal static int CountForEveryonePlane(string p_Input)
        {
            return p_Input.Split(new[] {Environment.NewLine + Environment.NewLine},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(CountForEveryoneGroup)
                .Sum();
        }
    }
}
