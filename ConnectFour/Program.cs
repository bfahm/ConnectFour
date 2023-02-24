//Console.WriteLine("Please provide the size of the game, X:");
using ConnectFour;

var gameSizeX = 5; //int.Parse(Console.ReadLine());
//Console.WriteLine("Please ddfgds the size of the game, Y:");
var gameSizeY = 5; //int.Parse(Console.ReadLine());

const int PLAYER_1_ID = 1;
const int PLAYER_2_ID = 2;

var game = new Game(gameSizeX, gameSizeY);
var columns = game.State;


columns[0].Add(PLAYER_1_ID);
columns[1].Add(PLAYER_2_ID);
columns[0].Add(PLAYER_1_ID);

PrintGame(game, onlyCoordinates: false);
Console.WriteLine();
Console.WriteLine();
PrintGame(game, onlyCoordinates: true);

void PrintGame(Game game, bool onlyCoordinates = false)
{
    for(int y = game.SizeY - 1; y >= 0; y--)
    {
        for (int x = 0; x != game.SizeX; x++)
        {
            if (onlyCoordinates)
                PrintCurrentCoordinate(x, y);
            else
                PrintCurrentValue(x, y);

            Console.Write(' ');
        }
        Console.WriteLine();
    }
}

void PrintCurrentValue(int x, int y)
{
    var currentColumn = game.State?[x];
    var currentItem = currentColumn?.Count() > y ? currentColumn?[y] : null;

    if (currentItem != null)
        Console.Write(currentItem);
    else
        Console.Write('_');
}

void PrintCurrentCoordinate(int x, int y)
{
    Console.Write($"({x}, {y})");
}
