using MBaumann.CodingGames.AdventOfCode2023.FSharp.Days;
using NFluent;

namespace MBamann.CodingGames.AdventOfCode2023.FSharp.Tests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData("1abc2", "12")]
        [InlineData("pqr3stu8vwx", "38")]
        [InlineData("a1b2c3d4e5f", "15")]
        [InlineData("treb7uchet", "77")]
        public void Part1(string sequence, string expected)
        {
            Check.That(Day1.FindCalibrationValue(sequence)).IsEqualTo(expected);
        }

        [Theory]
        [InlineData("two1nine", "29")]
        [InlineData("eightwothree", "83")]
        [InlineData("abcone2threexyz", "13")]
        [InlineData("xtwone3four", "24")]
        [InlineData("4nineeightseven2", "42")]
        [InlineData("zoneight234", "14")]
        [InlineData("7pqrstsixteen", "76")]
        public void Part2(string sequence, string expected)
        {
            var converted = Day1.FindCalibrationValue2(sequence);
            Check.That(Day1.FindCalibrationValue(converted)).IsEqualTo(expected);
        }
    }
}