using MBaumann.CodingGames.AdventOfCode2019.Days;
using Xunit;

namespace MBaumann.CodingGames.AdventOfCode2019.Tests.Days
{
    public sealed class Day3Tests
    {
        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void Part1Tests(string p_FirstPath, string p_SecondPath, int p_Distance)
        {
            Assert.Equal(p_Distance, Day3.ComputeDistance(p_FirstPath, p_SecondPath));
        }

        [Theory]
        [InlineData("R8,U5,L5,D3", "U7,R6,D4,L4", 39)]
        [InlineData("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [InlineData("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void Part2Tests(string p_FirstPath, string p_SecondPath, int p_Distance)
        {
            Assert.Equal(p_Distance, Day3.ComputeSteps(p_FirstPath, p_SecondPath));
        }
    }
}