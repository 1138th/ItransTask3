using ConsoleTables;

namespace ITransitionTask3;

public class HelpSheet : Game
{
    private ConsoleTable table;

    public HelpSheet()
    {
        table = new ConsoleTable("v PC \\ User >");
        table.AddColumn(AllTurns.Values.ToArray());
        foreach (var turn in AllTurns)
        {
            table.AddRow(GetRowData(turn));
        }
        
    }

    public void PrintTable()
    {
        Console.WriteLine();
        table.Write(Format.Alternative);
        Console.WriteLine();
    }

    private static string[] GetRowData(KeyValuePair<int, string> turn)
    {
        var rowValues = new List<string> { turn.Value };
        for (var i = 1; i <= AllTurns.Count; i++)
        {
            rowValues.Add(WinConditions.GetWinLoseDrawStr(turn.Key, i));
        }

        return rowValues.ToArray();
    }
}