//Console.WriteLine("Please provide the size of the game, X:");
var gameSizeX = 5; //int.Parse(Console.ReadLine());
//Console.WriteLine("Please ddfgds the size of the game, Y:");
var gameSizeY = 5; //int.Parse(Console.ReadLine());

const int PLAYER_1_ID = 1;
const int PLAYER_2_ID = 2;

var columns = new List<List<int>>();
for(int y = 0; y < gameSizeY; y++)
{
    var column = new List<int>();
    columns.Add(column);
}


columns[0].Add(PLAYER_1_ID);
columns[1].Add(PLAYER_2_ID);
columns[0].Add(PLAYER_1_ID);

PrintGame(true);

void PrintGame(bool onlyCoordinates = false)
{
    for(int y = gameSizeY-1; y >= 0; y--)
    {
        for (int x = 0; x != gameSizeX; x++)
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
    var currentColumn = columns?[x];
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
