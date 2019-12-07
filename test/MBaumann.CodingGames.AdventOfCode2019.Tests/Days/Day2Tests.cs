using MBaumann.CodingGames.AdventOfCode2019.Days;
using System.Linq;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2019.Tests.Days
{
    public sealed class Day2Tests
    {
        [Theory]
        [InlineData("1,9,10,3,2,3,11,0,99,30,40,50", "3500,9,10,70,2,3,11,0,99,30,40,50")]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void Part1ComputerTests(string p_Input, string p_Output)
        {
            Assert.Equal(p_Output.Split(new[] { ',' }).Select(int.Parse), Day2.ComputeOpCodes(p_Input.Split(new[] { ',' }).Select(int.Parse).ToArray()));
        }
    }
}