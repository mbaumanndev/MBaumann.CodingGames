using MBaumann.CommonTools.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MBaumann.CodingGames.AdventOfCode2019.Days
{
    public static class Day2
    {
        public static void FirstPart()
        {
            // TODO: Load file
        }

        public static int[] ComputeOpCodes(int[] p_OpCodes)
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
