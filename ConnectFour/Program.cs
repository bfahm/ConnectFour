using ConnectFour;

//Console.WriteLine("Please provide the size of the game, X:");
var gameSizeX = 10; //int.Parse(Console.ReadLine());
//Console.WriteLine("Please ddfgds the size of the game, Y:");
var gameSizeY = 10; //int.Parse(Console.ReadLine());

const char PLAYER_1_ID = '1';
const char PLAYER_2_ID = '2';

var game = new Game(gameSizeX, gameSizeY);

var currentTurn = PLAYER_1_ID;
void switchTurn() => currentTurn = currentTurn == PLAYER_2_ID ? PLAYER_1_ID : PLAYER_2_ID;

var someoneWon = false;

Console.WriteLine();
while (!someoneWon)
{
    GamePrinter.Print(game, onlyCoordinates: false);
    
    Console.WriteLine($"Player {currentTurn}, select column: ");

    var playedAtX = game.PlayAtX(Console.ReadLine(), currentTurn);
    Console.Clear();

    if (playedAtX == null)
    {
        Console.WriteLine("Invalid column choice!");
    }
    else
    {
        someoneWon = WinHelper.DetermineWinningState(game, new Point((int)playedAtX, game.GetPlayedAtY((int)playedAtX)), currentTurn);
        switchTurn();
    }
}
