using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    internal static class Day4
    {
        public static int FirstPart()
        {
            return ValidPassportsCount(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day4.txt"));
        }
        
        public static int SecondPart()
        {
            return ValidPassportsCountPart2(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day4.txt"));
        }
        public static int ValidPassportsCount(string p_Input)
        {
            return p_Input.Split(new [] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Count(IsValid);
        }

        public static int ValidPassportsCountPart2(string p_Input)
        {
            return p_Input.Split(new [] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Count(IsValidPart2);
        }

        private static readonly IReadOnlyCollection<string> EYES_COLORS = new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
        private static readonly Regex HEIGHT_REGEX = new Regex(@"^(?<inches>\d{2})in$|^(?<centimeters>\d{3})cm$", RegexOptions.Compiled | RegexOptions.ECMAScript);
        private static readonly Regex HAIR_COLOR_REGEX = new Regex(@"^#[0-9a-f]{6}$", RegexOptions.Compiled | RegexOptions.ECMAScript);
        private static readonly Regex PID_REGEX = new Regex(@"^[0-9]{9}$", RegexOptions.Compiled | RegexOptions.ECMAScript);

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

        internal static bool IsValidPart2(string p_Passport)
        {
            var v_Fields = p_Passport.Split(new[] {'\n', '\r', ' '}, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var v_Byr = int.Parse(v_Fields.First(f => f.StartsWith("byr:")).Substring(4));
                if (v_Byr is < 1920 or > 2002)
                    return false;

                var v_Iyr = int.Parse(v_Fields.First(f => f.StartsWith("iyr:")).Substring(4));
                if (v_Iyr is < 2010 or > 2020)
                    return false;

                var v_Eyr = int.Parse(v_Fields.First(f => f.StartsWith("eyr:")).Substring(4));
                if (v_Eyr is < 2020 or > 2030)
                    return false;

                var v_Hgt = v_Fields.First(f => f.StartsWith("hgt:")).Substring(4);
                var v_HgtMatch = HEIGHT_REGEX.Match(v_Hgt);
                if (!v_HgtMatch.Success)
                    return false;

                var v_Centimeters = v_HgtMatch.Groups["centimeters"];
                var v_Inches = v_HgtMatch.Groups["inches"];

                if (v_Centimeters.Success && int.Parse(v_Centimeters.Value) is < 150 or > 193)
                    return false;

                if (v_Inches.Success && int.Parse(v_Inches.Value) is < 59 or > 76)
                    return false;

                if (!v_Centimeters.Success && !v_Inches.Success)
                    return false;
                
                var v_Hcl = v_Fields.First(f => f.StartsWith("hcl:")).Substring(4);
                if (!HAIR_COLOR_REGEX.IsMatch(v_Hcl))
                    return false;

                var v_Ecl = v_Fields.First(f => f.StartsWith("ecl:")).Substring(4);
                if (!EYES_COLORS.Contains(v_Ecl))
                    return false;

                var v_Pid = v_Fields.First(f => f.StartsWith("pid:")).Substring(4);
                if (!PID_REGEX.IsMatch(v_Pid))
                    return false;

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
