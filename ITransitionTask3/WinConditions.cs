namespace ITransitionTask3;

public abstract class WinConditions : Game
{
    public static string GetWinLoseDrawStr(int turnNumber, int pcTurnNumber)
    {
        return IsWin(turnNumber, pcTurnNumber) switch
        {
            true => "Win",
            false => "Lose",
            _ => "Draw"
        };
    }

    private static bool? IsWin(int playerTurnNumber, int pcTurnNumber)
    {
        var totalTurns = AllTurns.Values.Count;
        var delta = playerTurnNumber - pcTurnNumber;
        delta = delta > 0 ? delta : delta + totalTurns;

        if (playerTurnNumber == pcTurnNumber) return null;
        return delta > totalTurns / 2;
    }
}