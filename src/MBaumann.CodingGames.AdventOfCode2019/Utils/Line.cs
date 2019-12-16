using MBaumann.CommonTools.Extensions;
using System;

namespace MBaumann.CodingGames.AdventOfCode2019.Utils
{
    public struct Line
    {
        public Line(Point p_First, Point p_Second)
        {
            First = p_First;
            Second = p_Second;
        }

        private static readonly Point DEFAULT = new Point(int.MaxValue, int.MaxValue);

        public Point First { get; }
        public Point Second { get; }

        public bool IsCrossing(Line p_Other)
        {
            return Intersection(p_Other) != DEFAULT;
        }

        public Point Intersection(Line p_Other)
        {
            if (p_Other.First.X.IsBetween(First.X, Second.X) && First.Y.IsBetween(p_Other.First.Y, p_Other.Second.Y))
                return new Point(p_Other.First.X, First.Y);
            if (First.X.IsBetween(p_Other.First.X, p_Other.Second.X) && p_Other.First.Y.IsBetween(First.Y, Second.Y))
                return new Point(First.X, p_Other.First.Y);
            return DEFAULT;
        }

        public int Length()
        {
            return Math.Abs(Second.X - First.X) + Math.Abs(Second.Y - First.Y);
        }
    }
}