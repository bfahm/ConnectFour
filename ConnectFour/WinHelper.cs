namespace ConnectFour
{
    internal class WinHelper
    {
        private static bool DetermineIsWinner(string candidate, char playerIdString, int connectCount = 4)
        {
            string winString = new string(playerIdString, connectCount);
            return candidate.Contains(winString);
        }

        public static bool DetermineWinningState(Game game, Point playedPoint, char playerId)
        {
            Console.WriteLine($"Player {playerId} played at ({playedPoint.X}, {playedPoint.Y})\t");

            var diagonalArroundPointCandidate = game.GetDiagonalArround(playedPoint);
            var diagonalArroundPointCandidateIsWin = DetermineIsWinner(diagonalArroundPointCandidate, playerId);
            Console.Write($"Diagonal Win: {diagonalArroundPointCandidateIsWin}");
            //Console.Write($"  {diagonalArroundPointCandidate}");
            Console.Write($"\t");

            var reverseDiagonalArroundPointCandidate = game.GetReverseDiagonalArround(playedPoint);
            var reverseDiagonalArroundCandidateIsWin = DetermineIsWinner(reverseDiagonalArroundPointCandidate, playerId);
            Console.Write($"Reverse Win: {reverseDiagonalArroundCandidateIsWin} \t");
            //Console.Write($"  {reverseDiagonalArroundPointCandidate}");
            Console.Write($"\t");

            var columnArroundCandidate = game.GetColumnArround(playedPoint);
            var columnArroundCandidateIsWin = DetermineIsWinner(columnArroundCandidate, playerId);
            Console.Write($"Column Win: {columnArroundCandidateIsWin} \t");
            //Console.Write($"  {columnArroundCandidate}");
            Console.Write($"\t");

            var rowArroundPointCandidate = game.GetRowArround(playedPoint);
            var rowArroundPointCandidateIsWin = DetermineIsWinner(rowArroundPointCandidate, playerId);
            Console.Write($"Row Win: {rowArroundPointCandidateIsWin} \t");
            //Console.Write($"  {rowArroundPointCandidate}");
            Console.Write($"\t");

            Console.WriteLine();

            var playerWon =  diagonalArroundPointCandidateIsWin
                               || reverseDiagonalArroundCandidateIsWin
                               || columnArroundCandidateIsWin
                               || rowArroundPointCandidateIsWin;

            if (playerWon)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine($"Player {playerId} WON!!!");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            return playerWon;
        }
    }
}
