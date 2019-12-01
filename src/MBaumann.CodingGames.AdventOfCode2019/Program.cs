using MBaumann.CodingGames.AdventOfCode2019.Days;
using System;

namespace MBaumann.CodingGames.AdventOfCode2019
{
    static class Program
    {
        static void Main(string[] args)
        {
            bool v_ShowMenu;
            do
            {
                v_ShowMenu = DisplayMenu();
            } while (v_ShowMenu);
        }

        private static bool DisplayMenu()
        {
            Console.Clear();

            Console.WriteLine(Day1.FirstPart());
            Console.WriteLine(Day1.SecondPart());

            return false;
        }
    }
}
