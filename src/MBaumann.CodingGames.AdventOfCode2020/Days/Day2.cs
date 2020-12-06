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
            return File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}2020Day2.txt")
                .Count(p_Policy => PasswordWithPolicy(p_Policy, PasswordMatchPolicy));
        }

        public static int SecondPart()
        {
            return File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}2020Day2.txt")
                .Count(p_Policy => PasswordWithPolicy(p_Policy, PasswordMatchNewPolicy));
        }

        internal static bool PasswordWithPolicy(string p_Input, Func<string, int, int, char, bool> p_Policy)
        {
            var v_Match = PASSWORD_POLICY_REGEX.Match(p_Input).Groups;

            var v_Password = v_Match[4].Value;
            var v_Min = int.Parse(v_Match[1].Value);
            var v_Max = int.Parse(v_Match[2].Value);
            var v_Char = char.Parse(v_Match[3].Value);

            return p_Policy(v_Password, v_Min, v_Max, v_Char);
        }

        internal static bool PasswordMatchPolicy(string p_Password, int p_Min, int p_Max, char p_Char)
        {
            var v_Count = p_Password.Count(c => c == p_Char);

            return v_Count >= p_Min && v_Count <= p_Max;
        }

        internal static bool PasswordMatchNewPolicy(string p_Password, int p_Min, int p_Max, char p_Char)
        {
            var v_Check1 = p_Password.ElementAt(p_Min - 1) == p_Char;
            var v_Check2 = p_Password.ElementAt(p_Max - 1) == p_Char;

            return v_Check1 ^ v_Check2;
        }
    }
}
