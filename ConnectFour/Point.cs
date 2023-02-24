﻿namespace ConnectFour
{
    internal class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point GetDiagonalTopRight(int step) => new Point(X + step, Y + step);
        public Point GetDiagonalBottomLeft(int step) => new Point(X - step, Y - step);
    }
}