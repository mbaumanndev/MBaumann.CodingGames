using System;

namespace MBaumann.CodingGames.AdventOfCode2019.Utils
{
    public struct Point
    {
        public Point(int p_X, int p_Y)
        {
            X = p_X;
            Y = p_Y;
        }

        public int X { get; }
        public int Y { get; }

        public static bool operator ==(Point p_First, Point p_Second)
        {
            return p_First.X == p_Second.X && p_First.Y == p_Second.Y;
        }

        public static bool operator !=(Point p_First, Point p_Second)
        {
            return p_First.X != p_Second.X || p_First.Y != p_Second.Y;
        }

        public static Point operator +(Point p_First, Point p_Second)
        {
            return new Point(p_First.X + p_Second.X, p_First.Y + p_Second.Y);
        }

        public static Point operator -(Point p_First, Point p_Second)
        {
            return new Point(p_First.X - p_Second.X, p_First.Y - p_Second.Y);
        }

        public static int operator *(Point p_First, Point p_Second)
        {
            return p_First.X * p_Second.Y + p_First.Y * p_Second.X;
        }

        public static Point operator *(Point p_First, int p_Factor)
        {
            return new Point(p_First.X * p_Factor, p_First.Y * p_Factor);
        }

        public static Point operator *(int p_Factor, Point p_First)
        {
            return new Point(p_First.X * p_Factor, p_First.Y * p_Factor);
        }

        public int Det(Point p_Other)
        {
            return X * p_Other.Y - Y * p_Other.X;
        }

        public int ManhattanDistance(Point p_Second)
        {
            return Math.Abs(X - p_Second.X) + Math.Abs(Y - p_Second.Y);
        }
    }
}