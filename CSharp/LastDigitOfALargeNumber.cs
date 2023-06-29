using System.Numerics;

namespace CSharp;

public class LastDigitOfALargeNumber
{
    private static readonly int[] TwosLastDigits = { 2, 4, 8, 6 };
    private static readonly int[] ThreesLastDigits = { 3, 9, 7, 1 };
    private static readonly int[] FoursLastDigits = { 4, 6 };
    private static readonly int[] SevensLastDigits = { 7, 9, 3, 1 };
    private static readonly int[] EightsLastDigits = { 8, 4, 2, 6 };
    private static readonly int[] NinesLastDigits = { 9, 1 };
    
    public static int GetLastDigit(BigInteger number1, BigInteger number2)
    {
        // 0 ^ 0 = 1
        if (number1 == 0 && number2 == 0)
            return 1;

        // 0 ^ x = 0
        if (number1 == 0)
            return 0;

        // x ^ 0 = 1
        if (number2 == 0)
            return 1;

        // Last digit of a ^ b depends on the last digit of a
        // meaning we can simply lookup the last digit for a specific power
        var lastDigit = (byte)(number1 % 10);
        return lastDigit switch
        {
            0 => 0,
            1 => 1,
            2 => TwosLastDigits[Modulo(number2, 4)],
            3 => ThreesLastDigits[Modulo(number2, 4)],
            4 => FoursLastDigits[Modulo(number2, 2)],
            5 => 5,
            6 => 6,
            7 => SevensLastDigits[Modulo(number2, 4)],
            8 => EightsLastDigits[Modulo(number2, 4)],
            9 => NinesLastDigits[Modulo(number2, 2)],
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private static byte Modulo(BigInteger number, int modulo)
    {
        return (byte)((number - 1) % modulo);
    }
}