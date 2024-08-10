using System.Numerics;
using System.Threading.Channels;

namespace MathGame;

internal static class Communication
{
    public static string Name { get; private set; }

    internal static string ProvideYourName()
    {
        Console.WriteLine("Provide your name: ");
        return Utils.ValidateInputString(Console.ReadLine());
    }

    internal static Operations ChooseGameModes()
    {
        int operationInt = 0;
        Console.WriteLine("Choose game mode: ");
        Console.WriteLine("[1] Addition ");
        Console.WriteLine("[2] Subtraction");
        Console.WriteLine("[3] Multiplication");
        Console.WriteLine("[4] Division");
        bool isInputValid = false;
        while (!isInputValid)
        {
            int intInput = Utils.ValidateInputIntiger(Console.ReadLine());
            if (intInput > 0 && intInput < 5)
            {
                operationInt = intInput - 1;
                isInputValid = true;
            }
            else
            {
                Console.WriteLine("Provide number from 1-4");
            }
        }
        return (Operations)operationInt;
    }
    internal static int AskAmountOfRounds()
    {
        Console.WriteLine("How many rounds do you want to play?");
        return Utils.ValidateInputIntiger(Console.ReadLine());
    }
    internal static void PrintCorrectAnswer()
    {
        Console.WriteLine("Correct naswer!");
    }
    internal static void PrintYouWereWrong(int correctAnswer)
    {
        Console.WriteLine("You were wrong, correct answer: " + correctAnswer);
    }

    internal static int AskMathQuestion(int firstNum, int secondNum, Operations operation)
    {
        string operationSign = "";
        switch (operation)
        {
            case Operations.Addition:
                operationSign = "+";
                break;
            case Operations.Subtraction:
                operationSign = "-";
                break;
            case Operations.Division:
                operationSign = "/";
                break;
            case Operations.Multiplication:
                operationSign = "*";
                break;
        }
        Console.WriteLine("What is the resulf of: " + firstNum + " " + operationSign + " " + secondNum);
        return Utils.ValidateInputIntiger(Console.ReadLine());
    }

    internal static void SummariseGame(int numberOfWins, int numberOfRounds)
    {
        Console.WriteLine("You won " + numberOfWins + " out of " + numberOfRounds + " rounds");
    }
    internal static bool ShouldDisplayResults()
    {
        Console.WriteLine("[1] If you want to display resutls");
        Console.WriteLine("Type anything else if you don'w want to display resutls");
        return Console.ReadLine() == "1";

    }
    internal static void PrintResultsFromList(List<string> results) 
    {
        foreach(string result in results)
        {
            Console.WriteLine(result);
        }
    }
    internal static bool ShouldQuitTheGame()
    {
        Console.WriteLine("If you want to quit the game press 1. If you want to keep playing, press enter.");
        return Console.ReadLine() != "1";
    }
}
