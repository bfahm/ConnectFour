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
    }
}
