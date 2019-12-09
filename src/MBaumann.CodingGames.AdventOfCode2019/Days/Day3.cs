using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MBaumann.CodingGames.AdventOfCode2019.Days
{
    public sealed class Day3
    {
        public int FirstPart()
        {
            string[] v_RawInput = File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day3.txt");

            return ComputeDistance(v_RawInput[0], v_RawInput[1]);
        }

        public static int ComputeDistance(string p_FirstPath, string p_SecondPath)
        {
            return 0;
        }
    }
}
