namespace ConnectFour
{
    internal class WinHelper
    {
        public static bool DetermineIsWinner(string candidate, char playerIdString, int connectCount = 4)
        {
            string winString = new string(playerIdString, connectCount);
            return candidate.Contains(winString);
        }
    }
}
