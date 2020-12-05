using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    class Day4
    {
        public static int FirstPart()
        {
            return ValidPassportsCount(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}Day4.txt"));
        }
        public static int ValidPassportsCount(string p_Input)
        {
            return p_Input.Split(new [] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Count(IsValid);
        }

        private static bool IsValid(string p_Passport)
        {
            var v_Fields = p_Passport.Split(new[] {'\n', ' '}, StringSplitOptions.RemoveEmptyEntries);
            
            if (!v_Fields.Any(f => f.StartsWith("byr")))
                return false;
            if (!v_Fields.Any(f => f.StartsWith("iyr")))
                return false;
            if (!v_Fields.Any(f => f.StartsWith("eyr")))
                return false;
            if (!v_Fields.Any(f => f.StartsWith("hgt")))
                return false;
            if (!v_Fields.Any(f => f.StartsWith("hcl")))
                return false;
            if (!v_Fields.Any(f => f.StartsWith("ecl")))
                return false;
            if (!v_Fields.Any(f => f.StartsWith("pid")))
                return false;

            return true;
        }

    }
}
