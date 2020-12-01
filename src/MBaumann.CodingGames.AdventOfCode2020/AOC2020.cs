using System;
using MBaumann.CodingGames.AdventOfCode2020.Days;
using MBaumann.CodingGames.Common;

namespace MBaumann.CodingGames.AdventOfCode2020
{
    public sealed class AOC2020 : IGame
    {
        public MenuItem GetGameMenu()
        {
            return new MenuItem("Advent Of Code 2020", new[] {
                new PuzzleMenuItem("Day 1 - Part 1", () => Console.WriteLine(Day1.FirstPart())),
                new PuzzleMenuItem("Day 1 - Part 2", () => Console.WriteLine(Day1.SecondPart())),
            });
        }
    }
}
