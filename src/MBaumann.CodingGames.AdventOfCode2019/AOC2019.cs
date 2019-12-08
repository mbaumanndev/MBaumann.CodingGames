using MBaumann.CodingGames.AdventOfCode2019.Days;
using MBaumann.CodingGames.Common;
using System;

namespace MBaumann.CodingGames.AdventOfCode2019
{
    public sealed class AOC2019 : IGame
    {
        public MenuItem GetGameMenu()
        {
            return new MenuItem("Advent Of Code 2019", new[] {
                new MenuItem("Day 1 - Part 1", () => Console.WriteLine(Day1.FirstPart())),
                new MenuItem("Day 1 - Part 2", () => Console.WriteLine(Day1.SecondPart())),
                new MenuItem("Day 2 - Part 1", () => Console.WriteLine(Day2.FirstPart())),
                new MenuItem("Day 2 - Part 2", () => Console.WriteLine(Day2.SecondPart())),
            });
        }
    }
}