namespace ITransitionTask3;

public class Program : Game
{
    public static void Main(string[] args)
    {
        string[] tempArgs = ["rock", "scissors", "paper", "lizard", "spock"];

        if (tempArgs.Length < 3)
            Console.WriteLine("The amount of arguments should be more than 2.");
        else if (tempArgs.Length % 2 != 1)
            Console.WriteLine("The amount of arguments is incorrect. Expected: odd (3, 5, 7 etc)");
        else
        {
            var allTurns = new Dictionary<int, string>();
            for (var i = 1; i <= tempArgs.Length; i++)
            {
                allTurns.Add(i, tempArgs[i - 1]);
            }
        
            AllTurns = allTurns;
        
            Cryptography.GeneratePcTurn();
            Cryptography.GenerateHmac();
            GameMenu.DrawMainMenu();
        }
    }
}
