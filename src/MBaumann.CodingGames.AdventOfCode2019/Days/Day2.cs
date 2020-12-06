using MBaumann.CommonTools.Linq;
using System;
using System.IO;
using System.Linq;

namespace MBaumann.CodingGames.AdventOfCode2019.Days
{
    public static class Day2
    {
        public static int FirstPart()
        {
            int[] v_Input = GetInput();

            return RunProgram(v_Input, 12, 2);
        }

        public static int SecondPart()
        {
            int[] v_Input = GetInput();

            for (int i = 0; i < 99; i++)
                for (int j = 0; j < 99; j++)
                    if (RunProgram(v_Input, i, j) == 19690720)
                        return 100 * i + j;

            throw new ApplicationException();
        }

        private static int[] GetInput()
        {
            string v_RawInput = File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2019Day2.txt");
            return v_RawInput.Split(new[] { ',' }).Select(int.Parse).ToArray();
        }

        internal static int RunProgram(int[] p_OpCodes, int p_Noun, int p_Verb)
        {
            int[] v_OpCodes = (int[])p_OpCodes.Clone();

            v_OpCodes[1] = p_Noun;
            v_OpCodes[2] = p_Verb;

            return ComputeOpCodes(v_OpCodes).First();
        }

        internal static int[] ComputeOpCodes(int[] p_OpCodes)
        {
            foreach (var v_Item in p_OpCodes.Batch(4))
            {
                var v_Operator = v_Item.ElementAt(0);

                if (v_Operator == 99)
                    break;

                int v_FirstIndex = v_Item.ElementAt(1);
                int v_SecondIndex = v_Item.ElementAt(2);
                int v_DestinationIndex = v_Item.ElementAt(3);

                if (v_Operator == 1)
                {
                    p_OpCodes[v_DestinationIndex] = p_OpCodes[v_FirstIndex] + p_OpCodes[v_SecondIndex];
                }
                else if (v_Operator == 2)
                {
                    p_OpCodes[v_DestinationIndex] = p_OpCodes[v_FirstIndex] * p_OpCodes[v_SecondIndex];
                }
            }

            return p_OpCodes;
        }
    }
}