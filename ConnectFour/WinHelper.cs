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
            Console.Write($"Player {playerId} \t");

            var diagonalArroundPointCandidate = game.GetDiagonalArround(playedPoint);
            var diagonalArroundPointCandidateIsWin = DetermineIsWinner(diagonalArroundPointCandidate, playerId);
            //Console.WriteLine(diagonalArroundPointCandidate);
            Console.Write($"Diagonal Win: {diagonalArroundPointCandidateIsWin} \t");

            var reverseDiagonalArroundPointCandidate = game.GetReverseDiagonalArround(playedPoint);
            var reverseDiagonalArroundCandidateIsWin = DetermineIsWinner(reverseDiagonalArroundPointCandidate, playerId);
            //Console.WriteLine(reverseDiagonalArroundPointCandidate);
            Console.Write($"Reverse Win: {reverseDiagonalArroundCandidateIsWin} \t");
            
            var columnArroundCandidate = game.GetColumnArround(playedPoint);
            var columnArroundCandidateIsWin = DetermineIsWinner(columnArroundCandidate, playerId);
            //Console.WriteLine(columnArroundCandidate);
            Console.Write($"Column Win: {columnArroundCandidateIsWin} \t");
            
            var rowArroundPointCandidate = game.GetRowArround(playedPoint);
            var rowArroundPointCandidateIsWin = DetermineIsWinner(rowArroundPointCandidate, playerId);
            //Console.WriteLine(rowArroundPointCandidate);
            Console.Write($"Row Win: {rowArroundPointCandidateIsWin} \t");

            Console.WriteLine();

            return diagonalArroundPointCandidateIsWin
                   || reverseDiagonalArroundCandidateIsWin
                   || columnArroundCandidateIsWin
                   || rowArroundPointCandidateIsWin;
        }
    }
}
