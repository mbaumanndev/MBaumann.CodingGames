using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public static class Day2
    {
        private static readonly Regex PASSWORD_POLICY_REGEX = new Regex(@"(\d+)-(\d+) ([a-z]{1}): ([a-z]+)", RegexOptions.Compiled);
        internal static int FirstPart()
        {
            return File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day2.txt").Count(PasswordMatchPolicy);
        }

        public static int SecondPart()
        {
            return File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day2.txt").Count(PasswordMatchNewPolicy);
        }

        public static bool PasswordMatchPolicy(string p_Input)
        {
            var v_Match = PASSWORD_POLICY_REGEX.Match(p_Input).Groups;

            var v_Password = v_Match[4].Value;
            var v_Min = int.Parse(v_Match[1].Value);
            var v_Max = int.Parse(v_Match[2].Value);
            var v_Char = char.Parse(v_Match[3].Value);

            var v_Count = v_Password.Count(c => c == v_Char);

            return v_Count >= v_Min && v_Count <= v_Max;
        }

        public static bool PasswordMatchNewPolicy(string p_Input)
        {
            var v_Match = PASSWORD_POLICY_REGEX.Match(p_Input).Groups;

            var v_Password = v_Match[4].Value;
            var v_Min = int.Parse(v_Match[1].Value);
            var v_Max = int.Parse(v_Match[2].Value);
            var v_Char = char.Parse(v_Match[3].Value);

            var v_Check1 = v_Password.ElementAt(v_Min - 1) == v_Char;
            var v_Check2 = v_Password.ElementAt(v_Max - 1) == v_Char;

            return v_Check1 ^ v_Check2;
        }
    }
}
