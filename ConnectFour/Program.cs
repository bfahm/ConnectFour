//Console.WriteLine("Please provide the size of the game, X:");
using ConnectFour;

var gameSizeX = 5; //int.Parse(Console.ReadLine());
//Console.WriteLine("Please ddfgds the size of the game, Y:");
var gameSizeY = 5; //int.Parse(Console.ReadLine());

const char PLAYER_1_ID = '1';
const char PLAYER_2_ID = '2';

var game = new Game(gameSizeX, gameSizeY);
var columns = game.State;

var currentTurn = PLAYER_1_ID;
void switchTurn() => currentTurn = currentTurn == PLAYER_2_ID ? PLAYER_1_ID : PLAYER_2_ID;

var someoneWon = false;

while (!someoneWon)
{
    Console.WriteLine($"Player {currentTurn}, select column: ");
    var playAtX= int.Parse(Console.ReadLine());
    columns[playAtX].Add(currentTurn);

    GamePrinter.Print(game, onlyCoordinates: false);
    Console.WriteLine();
    Console.WriteLine();
    someoneWon = WinHelper.DetermineWinningState(game, new Point(playAtX, game.GetPlayedAtY(playAtX)), currentTurn);
    Console.WriteLine();
    Console.WriteLine();
    
    switchTurn();
}
