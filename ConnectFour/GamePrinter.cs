namespace ConnectFour
{
    internal static class GamePrinter
    {
        public static void Print(Game game, bool onlyCoordinates = false)
        {
            for (int y = game.SizeY - 1; y >= 0; y--)
            {
                for (int x = 0; x != game.SizeX; x++)
                {
                    if (onlyCoordinates)
                        PrintCurrentCoordinate(x, y);
                    else
                        PrintCurrentValue(game, x, y);

                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        static void PrintCurrentValue(Game game, int x, int y)
        {
            var currentColumn = game.State?[x];
            var currentItem = currentColumn?.Count() > y ? currentColumn?[y] : null;

            if (currentItem != null)
                Console.Write(currentItem);
            else
                Console.Write('_');
        }

        static void PrintCurrentCoordinate(int x, int y)
        {
            Console.Write($"({x}, {y})");
        }
    }
}
