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
columns[1].Add(PLAYER_1_ID);
columns[2].Add(PLAYER_2_ID);
columns[2].Add(PLAYER_2_ID);
columns[2].Add(PLAYER_1_ID);
columns[3].Add(PLAYER_2_ID);
columns[3].Add(PLAYER_2_ID);
columns[3].Add(PLAYER_2_ID);
columns[3].Add(PLAYER_1_ID);
columns[4].Add(PLAYER_2_ID);
columns[4].Add(PLAYER_2_ID);
columns[4].Add(PLAYER_2_ID);
columns[4].Add(PLAYER_2_ID);
columns[4].Add(PLAYER_2_ID);

GamePrinter.Print(game, onlyCoordinates: false);
Console.WriteLine();
Console.WriteLine();
GamePrinter.Print(game, onlyCoordinates: true);

Console.WriteLine();
Console.WriteLine();

var candidate1 = game.GetDiagonalArround(new Point(2, 2));
var candidate1IsWin = WinHelper.DetermineIsWinner(candidate1, '1');
Console.WriteLine(candidate1);
Console.WriteLine(candidate1IsWin);
var candidate2 = game.GetReverseDiagonalArround(new Point(2, 2));
var candidate2IsWin = WinHelper.DetermineIsWinner(candidate2, '2');
Console.WriteLine(candidate2);
Console.WriteLine(candidate2IsWin);

Console.WriteLine();
Console.WriteLine();
