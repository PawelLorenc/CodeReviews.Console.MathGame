namespace MathGame;

internal static class Utils
{
    internal static int ValidateInputIntiger(string inputIntiger)
    {
        int value;
        while (!Int32.TryParse(inputIntiger, out value))
        {
            Console.WriteLine("Provide numerical value");
            inputIntiger = Console.ReadLine();
        }
        return value;
    }

    internal static string ValidateInputString(string inputString)
    {
        if (inputString == null)
        {
            Console.WriteLine("Please provide valid name");
        }
        return inputString;
    }
}
