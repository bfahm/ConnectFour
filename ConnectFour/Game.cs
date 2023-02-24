namespace ConnectFour
{
    internal class Game
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int ConnectTarget { get; set; }
        public List<List<char>> State { get; set; }

        public Game(int gameSizeX, int gameSizeY, int connectTarget = 4) 
        {
            var columns = new List<List<char>>();
            for (int y = 0; y < gameSizeY; y++)
            {
                var column = new List<char>();
                columns.Add(column);
            }

            SizeX = gameSizeX;
            SizeY = gameSizeY;
            State = columns;
            ConnectTarget = connectTarget;
        }

        public string GetDiagonalArround(Point originPoint)
        {
            return IterateArround(originPoint,
                                  originPoint.GetDiagonalBottomLeft,
                                  originPoint.GetDiagonalTopRight,
                                  ConnectTarget);
        }

        public string GetReverseDiagonalArround(Point originPoint)
        {
            return IterateArround(originPoint,
                                  originPoint.GetDiagonalBottomRight,
                                  originPoint.GetDiagonalTopLeft,
                                  ConnectTarget); ;
        }

        public string GetRowArround(Point originPoint)
        {
            return IterateArround(originPoint,
                                  originPoint.GetRowRight,
                                  originPoint.GetRowLeft,
                                  ConnectTarget);
        }

        public string GetColumnArround(Point originPoint)
        {
            return IterateArround(originPoint,
                                  originPoint.GetColumnDown,
                                  originPoint.GetColumnUp,
                                  ConnectTarget);
        }

        private string IterateArround(Point originPoint,
                                      Func<int, Point> firstIterator,
                                      Func<int, Point> secondIterator,
                                      int arround)
        {
            string diagonal = "";

            //First Iteration
            for (int i = arround; i >= 1; i--)
            {
                var accessPoint = firstIterator(i);

                if (IsValidX(accessPoint.X) && IsValidY(accessPoint.Y))
                {
                    diagonal += GetItemAtCoordinates(accessPoint.X, accessPoint.Y).ToString();
                }
            }

            diagonal += GetItemAtCoordinates(originPoint.X, originPoint.Y).ToString();

            //Second Iteration
            for (int i = 1; i <= arround; i++)
            {
                var accessPoint = secondIterator(i);

                if (IsValidX(accessPoint.X) && IsValidY(accessPoint.Y))
                {
                    diagonal += GetItemAtCoordinates(accessPoint.X, accessPoint.Y).ToString();
                }
            }

            return diagonal;
        }

        public char? GetItemAtCoordinates(int x, int y)
        {
            var currentColumn = State?[x];
            var currentItem = currentColumn?.Count() > y ? currentColumn?[y] : null;

            return currentItem;
        }

        private bool IsValidX(int x) => IsValidCoordinate(x, SizeX);
        private bool IsValidY(int y) => IsValidCoordinate(y, SizeY);

        private bool IsValidCoordinate(int axisIdx, int axisSize)
        {
            if (axisIdx < 0)
            {
                return false;
            }

            if(axisIdx > axisSize - 1)
            {
                return false;
            }

            return true;
        }
    }
}
