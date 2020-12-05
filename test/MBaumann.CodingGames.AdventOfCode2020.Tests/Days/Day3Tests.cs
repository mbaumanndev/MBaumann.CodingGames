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
    public class Day3Tests
    {
        public const string INPUT = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

        [Theory]
        [InlineData(INPUT, "R3,D1", 7)]
        public void Part1(string p_Input, string p_Slope, int p_Expected)
        {
            Check.That(Day3.CountTrees(p_Input, p_Slope)).IsEqualTo(p_Expected);
        }

        [Theory]
        [InlineData(INPUT, "R1,D1", 2)]
        [InlineData(INPUT, "R5,D1", 3)]
        [InlineData(INPUT, "R7,D1", 4)]
        [InlineData(INPUT, "R1,D2", 2)]
        public void Part2a(string p_Input, string p_Slope, int p_Expected)
        {
            Check.That(Day3.CountTrees(p_Input, p_Slope)).IsEqualTo(p_Expected);
        }
        
        [Theory]
        [InlineData(INPUT, new []{ "R1,D1", "R3,D1", "R5,D1", "R7,D1", "R1,D2"}, 336)]
        public void Part2b(string p_Input, string[] p_Slopes, int p_Expected)
        {
            Check.That(p_Slopes.Select(s => Day3.CountTrees(p_Input, s)).Aggregate((a, b) => a * b)).IsEqualTo(p_Expected);
        }
    }
}
