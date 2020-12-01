using System;
using MBaumann.CodingGames.AdventOfCode2020.Days;
using NFluent;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2020.Tests.Days
{
    public class Day1Tests
    {
        [Theory]
        [InlineData( new []{ 1721, 979, 366, 299, 675, 1456 }, 1721, 299)]
        public void Part1(int[] p_Input, int p_Expectedleft, int p_ExpectedRight)
        {
            Check.That(Day1.FindExpenses(p_Input)).IsEqualTo((p_Expectedleft, p_ExpectedRight));
        }

        [Theory]
        [InlineData( new []{ 1721, 979, 366, 299, 675, 1456 }, 979, 366, 675)]
        public void Part2(int[] p_Input, int p_Expectedleft, int p_ExpectedMiddle, int p_ExpectedRight)
        {
            Check.That(Day1.FindExpenses2(p_Input)).IsEqualTo((p_Expectedleft, p_ExpectedMiddle, p_ExpectedRight));
        }
    }
}
