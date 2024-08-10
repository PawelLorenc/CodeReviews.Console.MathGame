namespace MathGame;

internal class GameLogic
{
    public int FirstNumber { get; private set; }
    public int SecondNumber { get; private set; }
    public int Answer { get; private set; }

    public GameLogic(Operations operation) 
    {
        Random rnd = new Random();
        if (operation == Operations.Addition)
        {
            FirstNumber = rnd.Next(1, 99);
            int reminder = 100 - FirstNumber;
            SecondNumber = rnd.Next(1, reminder);
            Answer = FirstNumber + SecondNumber;
        }
        if(operation == Operations.Subtraction)
        {
            FirstNumber = rnd.Next(1, 99);
            SecondNumber = rnd.Next(1, FirstNumber);
            Answer = FirstNumber - SecondNumber;
        }
        if (operation == Operations.Multiplication || operation == Operations.Division) 
        {
            FirstNumber = rnd.Next(1, 10);
            SecondNumber = rnd.Next(1, 10);
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
}
