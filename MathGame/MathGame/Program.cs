using MathGame.enums;
using System.Diagnostics;

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
                DifficultyLevels difficultyLevel = Communication.ChooseDifficulty();
                Operations gameMode = Communication.ChooseGameModes();
                int amountOfRounds = Communication.AskAmountOfRounds();
                Console.Clear();
                bool isRandomMode = gameMode == Operations.Random;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < amountOfRounds; i++)
                {
                    if (isRandomMode)
                    {
                        gameMode = GameLogic.DrawRandomGame();
                    }
                    GameLogic game = new(gameMode, difficultyLevel);
                    int answer = Communication.AskMathQuestion(game.FirstNumber, game.SecondNumber, gameMode);
                    validator.ValidateWinner(game, answer, amountOfRounds, name, difficultyLevel);
                    if (i == amountOfRounds - 1)
                    {
                        stopwatch.Stop();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    if(i == amountOfRounds - 1)
                    {
                        TimeSpan timeSpan = stopwatch.Elapsed;
                        Console.WriteLine("It took you " + timeSpan.Seconds + " s. to solve the math challange!");
                    }
                }
                keepPlaying = Communication.ShouldQuitTheGame();
                Console.Clear();
            }
        }
    }
}
