using System.Security.Cryptography;
using System.Text;

namespace ITransitionTask3;

public class Cryptography : Game
{
    private static int _pcTurn;
    private static string _hmac;
    private static string _hmacKey;

    public static int PcTurn => _pcTurn;
    public static string HMAC => _hmac;
    public static string HMACKey => _hmacKey;

    internal static void GeneratePcTurn()
    {
        _pcTurn = RandomNumberGenerator.GetInt32(1, AllTurns.Count + 1);
    }

    private static byte[] GenerateKey()
    {
        var rng = RandomNumberGenerator.Create();
        var randBytes = new byte[32];
        rng.GetBytes(randBytes);
        _hmacKey = BitConverter.ToString(randBytes).Replace("-", string.Empty);
        var key = Encoding.UTF8.GetBytes(_hmacKey);
        return key;
    }

    internal static void GenerateHmac()
    {
        var hmacSha256 = new HMACSHA256(GenerateKey());
        hmacSha256.Initialize();
        var pcTurnData = Encoding.UTF8.GetBytes(AllTurns[_pcTurn]);
        var hmac = hmacSha256.ComputeHash(pcTurnData);
        _hmac = BitConverter.ToString(hmac).Replace("-", string.Empty);
    }
}