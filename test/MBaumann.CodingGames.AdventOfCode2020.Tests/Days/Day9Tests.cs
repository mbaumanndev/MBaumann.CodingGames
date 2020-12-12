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
    public class Day9Tests
    {
        private const string INPUT = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";

        [Fact]
        public void Part1()
        {
            Check.That(Day9.FindBadNumber(INPUT, 5)).IsEqualTo(127);
        }

        [Fact]
        public void Part2()
        {
            Check.That(Day9.FindEcryptionWeakness(INPUT, 5)).IsEqualTo(62);
        }
    }
}
