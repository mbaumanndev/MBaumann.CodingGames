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
    public class Day2Tests
    {
        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", true)]
        public void Part1(string p_Password, bool p_ExpectedResult)
        {
            Check.That(Day2.PasswordWithPolicy(p_Password, Day2.PasswordMatchPolicy)).IsEqualTo(p_ExpectedResult);
        }

        
        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", false)]
        public void Part2(string p_Password, bool p_ExpectedResult)
        {
            Check.That(Day2.PasswordWithPolicy(p_Password, Day2.PasswordMatchNewPolicy)).IsEqualTo(p_ExpectedResult);
        }
    }
}
