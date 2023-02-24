namespace ConnectFour
{
    internal class Game
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public List<List<int>> State { get; set; }

        public Game(int gameSizeX, int gameSizeY) 
        {
            var columns = new List<List<int>>();
            for (int y = 0; y < gameSizeY; y++)
            {
                var column = new List<int>();
                columns.Add(column);
            }

            SizeX = gameSizeX;
            SizeY = gameSizeY;
            State = columns;
        }

        public string GetDiagonalArround(Point originPoint, int arround = 2)
        {
            string diagonal = "";

            //Downward Iteration
            for (int i = arround; i >= 1; i--)
            {
                var accessPoint = originPoint.GetDiagonalBottomLeft(i);

                if (IsValidX(accessPoint.X) && IsValidY(accessPoint.Y))
                {
                    diagonal += GetItemAtCoordinates(accessPoint.X, accessPoint.Y).ToString();
                }
            }

            diagonal += GetItemAtCoordinates(originPoint.X, originPoint.Y).ToString();

            //Upward Iteration
            for (int i = 1; i <= arround; i++)
            {
                var accessPoint = originPoint.GetDiagonalTopRight(i);

                if(IsValidX(accessPoint.X) && IsValidY(accessPoint.Y))
                {
                    diagonal += GetItemAtCoordinates(accessPoint.X, accessPoint.Y).ToString();
                }
            }

            return diagonal;
        }

        public int? GetItemAtCoordinates(int x, int y)
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
