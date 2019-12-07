using MBaumann.CodingGames.AdventOfCode2019.Days;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2019.Tests.Days
{
    public sealed class Day1Tests
    {
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(1969, 654)]
        [InlineData(100756, 33583)]
        public void Part1Tests(int p_ModuleMass, int p_ExpectedResult)
        {
            Assert.Equal(p_ExpectedResult, Day1.ComputeNeededFuel(p_ModuleMass));
        }

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void Part2Tests(int p_ModuleMass, int p_ExpectedResult)
        {
            Assert.Equal(p_ExpectedResult, Day1.ComputeAllNeededFuel(p_ModuleMass));
        }
    }
}