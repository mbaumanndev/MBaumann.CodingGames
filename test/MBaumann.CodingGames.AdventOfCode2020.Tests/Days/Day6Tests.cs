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
    public class Day6Tests
    {
        private const string GROUP_INPUT = @"abcx
abcy
abcz";

        private const string PLANE_INPUT = @"abc

a
b
c

ab
ac

a
a
a
a

b";

        [Fact]
        public void Part1a()
        {
            Check.That(Day6.CountForAnyoneGroup(GROUP_INPUT)).IsEqualTo(6);
        }
        
        [Fact]
        public void Part1b()
        {
            Check.That(Day6.CountForAnyonePlane(PLANE_INPUT)).IsEqualTo(11);
        }
        
        [Fact]
        public void Part2a()
        {
            Check.That(Day6.CountForEveryoneGroup(GROUP_INPUT)).IsEqualTo(3);
        }

        
        [Fact]
        public void Part2b()
        {
            Check.That(Day6.CountForEveryonePlane(PLANE_INPUT)).IsEqualTo(6);
        }
    }
}
