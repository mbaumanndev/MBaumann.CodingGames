using System;
using System.IO;

namespace MBaumann.CodingGames.AdventOfCode2019.Days
{
    public static class Day1
    {
        public static int FirstPart()
        {
            return ReadLines(ComputeNeededFuel);
        }

        public static int SecondPart()
        {
            return ReadLines(ComputeAllNeededFuel);
        }

        private static int ReadLines(Func<int, int> p_Action)
        {
            int v_Result = 0;

            foreach (string v_Line in File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day1.txt"))
            {
                int v_ModuleMass = int.Parse(v_Line);

                v_Result += p_Action(v_ModuleMass);
            }

            return v_Result;
        }

        public static int ComputeNeededFuel(int p_ModuleMass)
        {
            double v_Temp = p_ModuleMass / 3.0;
            int v_Floor = (int)Math.Floor(v_Temp);
            return v_Floor - 2;
        }

        public static int ComputeAllNeededFuel(int p_ModuleOrFuelMass)
        {
            int v_FuelMass = ComputeNeededFuel(p_ModuleOrFuelMass);

            if (v_FuelMass > 0)
                return v_FuelMass + ComputeAllNeededFuel(v_FuelMass);
            else
                return 0;
        }
    }
}