//Console.WriteLine("Please provide the size of the game, X:");
var gameSizeX = 5; //int.Parse(Console.ReadLine());
//Console.WriteLine("Please ddfgds the size of the game, Y:");
var gameSizeY = 5; //int.Parse(Console.ReadLine());

const int PLAYER_1_ID = 1;
const int PLAYER_2_ID = 2;

var column = new Stack<int>();
var columns = new List<Stack<int>>();
columns.AddRange(Enumerable.Repeat(column, gameSizeY));

PrintGame();

void PrintGame()
{
    for(int y = gameSizeY-1; y >= 0; y--)
    {
        for (int x = 0; x != gameSizeX; x++)
        {
            //Console.Write('_');
            Console.Write($"({x}, {y})");
            Console.Write(' ');
        }
        Console.WriteLine();
    }
}
