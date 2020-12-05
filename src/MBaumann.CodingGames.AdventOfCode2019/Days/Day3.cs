using MBaumann.CodingGames.AdventOfCode2019.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MBaumann.CodingGames.AdventOfCode2019.Days
{
    public sealed class Day3
    {
        public static int FirstPart()
        {
            string[] v_RawInput = File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day3.txt");

            return ComputeDistance(v_RawInput[0], v_RawInput[1]);
        }

        public static int SecondPart()
        {
            string[] v_RawInput = File.ReadAllLines($"Inputs{Path.DirectorySeparatorChar}Day3.txt");

            return ComputeSteps(v_RawInput[0], v_RawInput[1]);
        }

        private static readonly Point Origin = new Point(0, 0);

        internal static int ComputeDistance(string p_FirstPath, string p_SecondPath)
        {
            return Intersections(p_FirstPath, p_SecondPath).Select(p_Point => Origin.ManhattanDistance(p_Point)).Min();
        }

        private static IEnumerable<Point> Intersections(string p_FirstPath, string p_SecondPath)
        {
            void ComputePath(string p_Input, List<Point> p_Output)
            {
                foreach (string v_Move in p_Input.Split(','))
                {
                    var v_Direction = v_Move[0];
                    var v_Rest = int.Parse(v_Move.Substring(1));
                    var v_Last = p_Output.Last();

                    switch (v_Direction)
                    {
                        case 'R':
                            p_Output.Add(new Point(v_Last.X + v_Rest, v_Last.Y));
                            break;

                        case 'U':
                            p_Output.Add(new Point(v_Last.X, v_Last.Y + v_Rest));
                            break;

                        case 'L':
                            p_Output.Add(new Point(v_Last.X - v_Rest, v_Last.Y));
                            break;

                        case 'D':
                            p_Output.Add(new Point(v_Last.X, v_Last.Y - v_Rest));
                            break;
                    }
                }
            }

            List<Point> v_FirstPath = new List<Point>() { Origin };
            List<Point> v_SecondPath = new List<Point>() { Origin };
            List<Point> v_Crossings = new List<Point>();

            ComputePath(p_FirstPath, v_FirstPath);
            ComputePath(p_SecondPath, v_SecondPath);

            foreach (var v_FirstPairs in v_FirstPath.Zip(v_FirstPath.Skip(1), (f, s) => new Line(f, s)))
            {
                foreach (var v_SecondPairs in v_SecondPath.Zip(v_SecondPath.Skip(1), (f, s) => new Line(f, s)))
                {
                    if (v_FirstPairs.First != Origin || v_SecondPairs.First != Origin)
                    {
                        if (v_FirstPairs.IsCrossing(v_SecondPairs))
                        {
                            v_Crossings.Add(v_FirstPairs.Intersection(v_SecondPairs));
                        }
                    }
                }
            }

            return v_Crossings;
        }

        internal static int ComputeSteps(string p_FirstPath, string p_SecondPath)
        {
            List<int> v_Steps = new List<int>();

            foreach (var v_Intersection in Intersections(p_FirstPath, p_SecondPath))
            {

            }

            return v_Steps.Min();
        }
    }
}