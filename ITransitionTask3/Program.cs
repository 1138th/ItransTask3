namespace ITransitionTask3;

public class Program : Game
{
    public static void Main(string[] args)
    {
        if (args.Length < 3)
            Console.WriteLine("The amount of arguments should be more than 2.");
        else if (args.Length % 2 != 1)
            Console.WriteLine("The amount of arguments is incorrect. Expected: odd (3, 5, 7 etc)");
        else
        {
            var allTurns = new Dictionary<int, string>();
            for (var i = 1; i <= args.Length; i++)
            {
                allTurns.Add(i, args[i - 1]);
            }
        
            AllTurns = allTurns;
        
            Cryptography.GeneratePcTurn();
            Cryptography.GenerateHmac();
            GameMenu.DrawMainMenu();
        }
    }
}
