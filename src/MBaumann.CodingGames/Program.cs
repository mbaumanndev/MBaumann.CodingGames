using MBaumann.CodingGames.AdventOfCode2019;
using MBaumann.CodingGames.Common;

namespace MBaumann.CodingGames
{
    internal sealed class Program
    {
        private static Menu Menu;

        public static void Main(string[] args)
        {
            Menu = new Menu("Coding Games", new[] {
                new AOC2019().GetGameMenu(),
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