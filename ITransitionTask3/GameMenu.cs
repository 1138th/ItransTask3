namespace ITransitionTask3;

public class GameMenu : Game
{
    private const string IncorrectCommandMessage = "The provided command is not shown on screen. Try another.";

    public static void DrawMainMenu()
    {
        var helpSheet = new HelpSheet();
        var isPlayerWantsToPlay = true;

        do
        {
            PrintMenu();

            var input = Console.ReadLine();

            if (int.TryParse(input, out _))
            {
                var intInput = int.Parse(input);
                if (AllTurns.ContainsKey(intInput))
                {
                    PrintAfterMoveInfo(intInput);
                }
                else if (intInput == 0)
                {
                    isPlayerWantsToPlay = false;
                }
                else
                {
                    Console.WriteLine(IncorrectCommandMessage);
                }
            }
            else if (input.Equals("?"))
            {
                helpSheet.PrintTable();
            }
            else
            {
                Console.WriteLine(IncorrectCommandMessage);
            }
        } while (isPlayerWantsToPlay);
    }

    private static void PrintMenu()
    {
        Console.WriteLine("HMAC: " + Cryptography.HMAC);
        Console.WriteLine("Available moves:");
        foreach (var turn in AllTurns)
        {
            Console.WriteLine("\t{0} - {1}", turn.Key, turn.Value);
        }

        Console.WriteLine("\t0 - exit");
        Console.WriteLine("\t? - help");
        Console.WriteLine("Enter your move: ");
    }

    private static void PrintAfterMoveInfo(int playerTurn)
    {
        string winLoseDrawStr = WinConditions.GetWinLoseDrawStr(playerTurn, Cryptography.PcTurn);

        Console.WriteLine("Your move: " + AllTurns[playerTurn]);
        Console.WriteLine("Computer move: " + AllTurns[Cryptography.PcTurn]);
        Console.WriteLine(winLoseDrawStr.Equals("Draw") ? "It's a Draw!" : "You {0}!", winLoseDrawStr);
        Console.WriteLine("HMAC key: " + Cryptography.HMACKey);

        Cryptography.GeneratePcTurn();
        Cryptography.GenerateHmac();
        Console.WriteLine("------------------------------------------------------------------------------------------");
    }
}