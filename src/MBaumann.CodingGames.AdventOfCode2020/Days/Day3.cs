using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public static class Day3
    {
        private const char OPEN_SQUARE = '.';
        private const char TREE = '#';
        
        public static long FirstPart()
        {
            return CountTrees(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}Day3.txt"), "R3,D1");
        }

        public static long SecondPart()
        {
            return new[] {"R1,D1", "R3,D1", "R5,D1", "R7,D1", "R1,D2"}
                .Select(s => Day3.CountTrees(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}Day3.txt"), s))
                .Aggregate((a, b) => a * b);
        }

        public static long CountTrees(string p_Input, string p_Slope)
        {
            using var v_Reader = new StringReader(p_Input);
            string v_Line = v_Reader.ReadLine();
            var v_Height = p_Input.Split('\n').Length;
            var v_Width = v_Line.Length;
            char[,] v_Map = new char[v_Height,v_Width];

            var v_Y = 0;
            do
            {
                int v_X = 0;
                foreach (char v_Char in v_Line)
                {
                    v_Map[v_Y, v_X] = v_Char;

                    ++v_X;
                }

                ++v_Y;
            } while ((v_Line = v_Reader.ReadLine()) != null);

            var v_CurrentY = 0;
            var v_CurrentX = 0;
            var v_Slope = p_Slope.Split(',');
            var v_EncounteredTrees = 0;
            do
            {
                foreach (var v_Move in v_Slope)
                {
                    var v_Direction = v_Move[0];
                    var v_Rest = int.Parse(v_Move.Substring(1));

                    switch (v_Direction)
                    {
                        case 'R':
                            v_CurrentX = (v_CurrentX + v_Rest) % v_Width;
                            break;

                        case 'D':
                            v_CurrentY += v_Rest;
                            break;
                    }
                }

                if (v_Map[v_CurrentY, v_CurrentX] == TREE)
                    ++v_EncounteredTrees;
            } while (v_CurrentY < v_Height - 1);

            return v_EncounteredTrees;
        }
    }
}
