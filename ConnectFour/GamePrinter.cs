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
            Console.WriteLine();
            PrintColumnNumbers(game);
        }

        static void PrintColumnNumbers(Game game)
        {
            for(int i = 0 ;i < game.SizeX; i++)
            {
                Console.Write(i);
                Console.Write(' ');
            }
            Console.Write("\t\t << Column Numbers");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void PrintCurrentValue(Game game, int x, int y)
        {
            var currentItem = game.GetItemAtCoordinates(x, y);
            Console.Write(currentItem ?? '_');
        }

        static void PrintCurrentCoordinate(int x, int y)
        {
            Console.Write($"({x}, {y})");
        }
    }
}
