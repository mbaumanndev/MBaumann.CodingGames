using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public static class Day1
    {
        public static int FirstPart()
        {
            var v_Tuple = ReadLines(FindExpenses);

            return v_Tuple.Item1 * v_Tuple.Item2;
        }

        public static int SecondPart()
        {
            var v_Tuple = ReadLines(FindExpenses2);

            return v_Tuple.Item1 * v_Tuple.Item2 * v_Tuple.Item3;
        }

        public static (int, int) FindExpenses(IEnumerable<int> p_Input)
        {
            foreach (var i in p_Input)
            {
                foreach (var j in p_Input)
                {
                    if (i + j == 2020)
                        return (i, j);
                }
            }

            throw new ApplicationException();
        }


        public static (int, int, int) FindExpenses2(IEnumerable<int> p_Input)
        {
            foreach (var i in p_Input)
            {
                foreach (var j in p_Input)
                {
                    foreach (var k in p_Input)
                    {
                        if (i + j + k == 2020)
                            return (i, j, k);
                    }
                }
            }

            throw new ApplicationException();
        }

        private static (int, int) ReadLines(Func<IEnumerable<int>, (int, int)> p_Action)
        {
            var v_Values = File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day1.txt").Select(int.Parse).ToList();

            return p_Action(v_Values);
        }

        private static (int, int, int) ReadLines(Func<IEnumerable<int>, (int, int, int)> p_Action)
        {
            var v_Values = File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day1.txt").Select(int.Parse).ToList();

            return p_Action(v_Values);
        }
    }
}
