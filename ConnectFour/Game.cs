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

        public void PrintDiagonalArround(int originX, int originY)
        {
            const int arround = 2;

            //Forward Iteration
            for (int i = 0; i <= arround; i++)
            {
                var accessX = originX + i;
                var accessY = originY + i;

                if(IsValidX(accessX) && IsValidY(accessY))
                {
                    Console.Write(GetItemAtCoordinates(accessX, accessY));
                    Console.Write("-");
                }
            }
            Console.WriteLine();

            //Backward Iteration
            for (int i = arround; i >= 0; i--)
            {
                var accessX = originX - i;
                var accessY = originY - i;

                if (IsValidX(accessX) && IsValidY(accessY))
                {
                    Console.Write(GetItemAtCoordinates(accessX, accessY));
                    Console.Write("-");
                }
            }
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
