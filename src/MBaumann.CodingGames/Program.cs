using MBaumann.CodingGames.AdventOfCode2018.FSharp;
using MBaumann.CodingGames.AdventOfCode2019;
using MBaumann.CodingGames.AdventOfCode2020;
using MBaumann.CodingGames.Common;

namespace MBaumann.CodingGames
{
    internal sealed class Program
    {
        private static Menu Menu;

        public static void Main(string[] args)
        {
            Menu = new Menu("Coding Games", new[] {
                (new FSAOC.AOC2018() as IGame).GetGameMenu(),
                new AOC2019().GetGameMenu(),
                new AOC2020().GetGameMenu(),
                new MenuItem("Exit", Exit)
            });

            Menu.LaunchMenu();
        }

        private static void Exit()
        {
            Menu.Close();
        }
    }
}