namespace ConnectFour
{
    internal class Game
    {
        public int SizeX { get; }
        public int SizeY { get; }
        public int ConnectTarget { get; }
        
        private List<List<char>> State;

        public Game(int gameSizeX, int gameSizeY, int connectTarget = 4) 
        {
            var columns = new List<List<char>>();
            for (int x = 0; x < gameSizeX; x++)
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

        public int? PlayAtX(string? x, char asPlayer)
        {
            bool parsed = int.TryParse(x, out int parsedX);
            if(!parsed || parsedX > SizeX - 1)
            {
                return null;
            }
            
            State[parsedX].Add(asPlayer);
            return parsedX;
        }

        public int GetPlayedAtY(int x)
        {
            var playedColumn = State?[x];
            return (playedColumn?.Count() - 1) ?? 0;
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
