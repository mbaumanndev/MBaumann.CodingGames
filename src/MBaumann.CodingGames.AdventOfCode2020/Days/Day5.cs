using System;
using System.IO;
using System.Linq;
using MoreLinq;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    internal static class Day5
    {
        public static int FirstPart()
        {
            return File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}2020Day5.txt")
                .Select(GetSeatCoords)
                .Max(e => GetSeatId(e.Item1, e.Item2));
        }

        public static int SecondPart()
        {
            var v_Seats = File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}2020Day5.txt")
                .Select(GetSeatCoords)
                .Select(e => GetSeatId(e.Item1, e.Item2))
                .ToList();

            v_Seats.Sort();
            for (var i = 0; i < v_Seats.Count - 1; i++)
                if (v_Seats[i + 1] - v_Seats[i] == 2)
                    return v_Seats[i] + 1;

            return -1;
        }

        internal static (byte, byte) GetSeatCoords(string p_BoardingPass)
        {
            byte v_Row = 127;
            byte v_Col = 7;

            for (byte i = 0; i < 7; i++)
            {
                var v_Part = p_BoardingPass[i];

                if (v_Part == 'F')
                    v_Row &= (byte) ~(1 << (6 - i));

            }
            
            for (byte i = 7; i < 10; i++)
            {
                var v_Part = p_BoardingPass[i];

                if (v_Part == 'L')
                    v_Col &= (byte) ~(1 << (9 - i));

            }

            return (v_Row, v_Col);
        }

        internal static int GetSeatId(in byte p_Row, in byte p_Col)
        {
            return p_Row * 8 + p_Col;
        }
    }
}
