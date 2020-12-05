using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBaumann.CodingGames.AdventOfCode2020.Days;
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

        [Fact]
        public void Part1()
        {
            Check.That(Day4.ValidPassportsCount(INPUT)).IsEqualTo(2);
        }
    }
}
