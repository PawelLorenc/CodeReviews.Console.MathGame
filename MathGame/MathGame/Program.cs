namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Communication.ProvideYourName();
            Console.Clear();
            bool keepPlaying = true;
            while (keepPlaying)
            {
                WinnerValidator validator = new WinnerValidator();
                if(WinnerValidator.resultsList.Count > 0) 
                { 
                    if(Communication.ShouldDisplayResults())
                    {
                        Console.Clear();
                        Communication.PrintResultsFromList(WinnerValidator.resultsList);
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                Operations gameMode = Communication.ChooseGameModes();
                int amountOfRounds = Communication.AskAmountOfRounds();
                Console.Clear();
                for (int i = 0; i < amountOfRounds; i++)
                {
                    GameLogic game = new(gameMode);
                    int answer = Communication.AskMathQuestion(game.FirstNumber, game.SecondNumber, gameMode);
                    validator.ValidateWinner(game, answer, amountOfRounds, name);
                    Console.ReadKey();
                    Console.Clear();
                }
                keepPlaying = Communication.ShouldQuitTheGame();
                Console.Clear();
            }
        }
    }
}
