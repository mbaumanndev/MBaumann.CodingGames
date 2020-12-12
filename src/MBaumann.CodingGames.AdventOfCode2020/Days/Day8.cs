using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MBaumann.CodingGames.AdventOfCode2020.Days
{
    public sealed class Day8
    {
        public static int FirstPart()
        {
            _ = GetAccValue(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day8.txt"), out int v_Value);
            return v_Value;
        }
        
        public static int SecondPart()
        {
            _ = GetAccValue(CorrectInput(File.ReadAllText($"Inputs{Path.DirectorySeparatorChar}2020Day8.txt")), out int v_Value);
            return v_Value;
        }
        
        public static int GetAccValue(string p_Input, out int p_Value)
        {
            p_Value = 0;
            
            List<(string, int)> v_Ops = new();
            List<int> v_VisitedIndexes = new();
            
            foreach (var v_Item in p_Input.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(' ')))
            {
                v_Ops.Add((v_Item[0], int.Parse(v_Item[1])));
            }

            var v_NextOp = 0;
            do
            {
                v_VisitedIndexes.Add(v_NextOp);
                var v_Op = v_Ops[v_NextOp];

                switch (v_Op.Item1)
                {
                    case "acc":
                        p_Value += v_Op.Item2;
                        v_NextOp++;
                        break;
                    case "jmp":
                        v_NextOp += v_Op.Item2;
                        break;
                    
                    case "nop":
                        v_NextOp++;
                        break;
                }
            } while (!v_VisitedIndexes.Contains(v_NextOp) && v_NextOp < v_Ops.Count);

            return v_NextOp;
        }


        public static string CorrectInput(string p_Input)
        {
            int v_Value = 0;
            
            List<(string, int)> v_Ops = new();
            
            foreach (var v_Item in p_Input.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(' ')))
            {
                v_Ops.Add((v_Item[0], int.Parse(v_Item[1])));
            }

            for (int i = 0; i < v_Ops.Count; i++)
            {
                var v_Op = v_Ops[i];

                if (v_Op.Item1 != "acc")
                {
                    v_Ops[i] = (v_Op.Item1 == "jmp" ? "nop" : "jmp", v_Op.Item2);

                    var v_Input = GetFixed(v_Ops);
                    if (GetAccValue(v_Input, out _) == v_Ops.Count)
                        return v_Input;

                }

                v_Ops[i] = v_Op;
            }

            return String.Empty;
        }

        private static string GetFixed(IEnumerable<(string, int)> p_Ops)
        {
            return String.Join(Environment.NewLine, p_Ops.Select(op => String.Join(" ", new object[]{ op.Item1, op.Item2.ToString("+0;-#") })));
        }
    }
}
