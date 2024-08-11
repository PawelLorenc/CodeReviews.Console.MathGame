using MathGame.enums;

namespace MathGame;

internal class GameLogic
{
    internal int FirstNumber { get; private set; }
    internal int SecondNumber { get; private set; }
    internal int Answer { get; private set; }

    internal GameLogic(Operations operation, DifficultyLevels difficulty) 
    {
        Random rnd = new Random();
        int difficultyInt = (int)difficulty + 1;
        if (operation == Operations.Addition)
        {
            FirstNumber = rnd.Next(1, 99 * difficultyInt);
            int reminder = 100 * difficultyInt - FirstNumber;
            SecondNumber = rnd.Next(1, reminder);
            Answer = FirstNumber + SecondNumber;
        }
        if(operation == Operations.Subtraction)
        {
            FirstNumber = rnd.Next(1, 99 * difficultyInt);
            SecondNumber = rnd.Next(1, FirstNumber);
            Answer = FirstNumber - SecondNumber;
        }
        if (operation == Operations.Multiplication || operation == Operations.Division) 
        {
            FirstNumber = rnd.Next(1, 10 * difficultyInt);
            SecondNumber = rnd.Next(1, 10 * difficultyInt);
            if(operation == Operations.Division)
            {
                FirstNumber = FirstNumber * SecondNumber;
                Answer = FirstNumber / SecondNumber;
            }
            else
            {
                Answer = FirstNumber * SecondNumber;
            }
        }
    }
    internal static Operations DrawRandomGame()
    {
        Random rnd = new Random();
        int random = rnd.Next(0, 3);
        return (Operations) random;
    }
}
