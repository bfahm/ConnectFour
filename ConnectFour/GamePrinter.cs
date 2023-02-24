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
            var currentItem = game.GetItemAtCoordinates(x, y);
            Console.Write(currentItem?.ToString() ?? "_");
        }

        static void PrintCurrentCoordinate(int x, int y)
        {
            Console.Write($"({x}, {y})");
        }
    }
}
