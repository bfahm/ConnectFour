namespace ConnectFour
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
        public Point GetDiagonalTopLeft(int step) => new Point(X - step, Y + step);
        public Point GetDiagonalBottomRight(int step) => new Point(X + step, Y - step);

        public Point GetColumnUp(int step) => new Point(X, Y + step);
        public Point GetColumnDown(int step) => new Point(X, Y - step);

        public Point GetRowLeft(int step) => new Point(X + step, Y);
        public Point GetRowRight(int step) => new Point(X - step, Y);
    }
}
