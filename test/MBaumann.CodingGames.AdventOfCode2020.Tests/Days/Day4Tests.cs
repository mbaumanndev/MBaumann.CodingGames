using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBaumann.CodingGames.AdventOfCode2020.Days;
using Newtonsoft.Json;
using NFluent;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2020.Tests.Days
{
    public sealed class Day4Tests
    {
        private const string INPUT = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";

        private const string INPUT_INVALID = @"eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007";
        
        private const string INPUT_VALID = @"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";

        [Fact]
        public void Part1()
        {
            Check.That(Day4.ValidPassportsCount(INPUT)).IsEqualTo(2);
        }
        
        [Fact]
        public void Part2a()
        {
            Check.That(Day4.ValidPassportsCountPart2(INPUT_INVALID)).IsEqualTo(0);
        }
        
        [Fact]
        public void Part2b()
        {
            Check.That(Day4.ValidPassportsCountPart2(INPUT_VALID)).IsEqualTo(4);
        }

        [Fact]
        public void Day4ShouldWork()
        {
            Check.That(Day4.ValidPassportsCountPart2(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}Day4.txt")))
                .IsEqualTo(131);
        }

        [Theory]
        [InlineData("byr:1988 hgt:160cm eyr:2023 hcl:#866857 pid:788805179 iyr:2022 ecl:amb", false)]
        [InlineData("hgt:164cm eyr:2023 byr:2008 ecl:grn pid:420168481 hcl:#b6652a iyr:2012", false)]
        [InlineData(@"ecl:hzl eyr:2031 cid:145 hgt:186cm hcl:#cfa07d
byr:1941 iyr:2010 pid:722056139", false)]
        public void PassportMustMatchExpected(string p_Passport, bool p_Expected)
        {
            Check.That(Day4.IsValidPart2(p_Passport)).IsEqualTo(p_Expected);
        }

        [Fact]
        public void Day4Debug()
        {
            var v_Input = File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}Day4.txt")
                .Split(new[] {"\n\n"}, StringSplitOptions.RemoveEmptyEntries);
            var v_JsonCheck =
                JsonConvert.DeserializeObject<JsonCheck>(
                    File.ReadAllText($"Files{Path.DirectorySeparatorChar}day4.json"));

            var v_Counter = 0;

            foreach (var v_Passport in v_Input)
            {
                var v_IsValid = Day4.IsValidPart2(v_Passport);
                var v_Check = v_JsonCheck.Input[v_Counter];
                var v_Expected = v_Check.IsValid;

                if (v_IsValid != v_Expected)
                {
                    Day4.IsValidPart2(v_Passport);
                }

                v_Counter++;
            }
        }

        public class JsonCheck
        {
            public Input[] Input { get; set; }

            public int Count { get; set; }
        }

        public class Input
        {
            public string V { get; set; }

            public bool IsValid { get; set; }

            public string Check { get; set; }
        }
    }
}
