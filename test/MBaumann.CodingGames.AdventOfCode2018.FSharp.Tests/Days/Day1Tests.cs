using System;
using System.Collections.Generic;
using System.Text;
using MBaumann.CodingGames.AdventOfCode2018.FSharp.Days;
using NFluent;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2018.FSharp.Tests.Days
{
    public class Day1Tests
    {
        [Theory]
        [InlineData(new[] {"+1", "+1", "+1"}, 3)]
        [InlineData(new[] { "+1", "+1", "-2" }, 0)]
        [InlineData(new[] { "-1", "-2", "-3" }, -6)]
        public void Part1(string[] p_Input, int p_Expected)
        {
            Check.That(Day1Part1.Compute(p_Input)).IsEqualTo(p_Expected);
        }
        
        [Theory]
        [InlineData(new[] { "-1", "+1" }, 0)]
        [InlineData(new[] { "+3", "+3", "+4", "-2", "-4" }, 10)]
        [InlineData(new[] { "-6", "+3", "+8", "+5", "-6" }, 5)]
        [InlineData(new[] { "+7", "+7", "-2", "-7", "-4" }, 14)]
        public void Part2(string[] p_Input, int p_Expected)
        {
            Check.That(Day1Part2.Compute(p_Input)).IsEqualTo(p_Expected);
        }

    }
}
