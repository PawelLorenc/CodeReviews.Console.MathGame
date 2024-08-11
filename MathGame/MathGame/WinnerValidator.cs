using MathGame.enums;

namespace MathGame;

internal class WinnerValidator
{
    internal static List<string> resultsList { get; private set; } = new();
    private int roundsPlayed = 0;
    private int winCounter = 0;

    internal void ValidateWinner(GameLogic game, int input, int amountOfRounds, string name, DifficultyLevels difficulty)
    {
        if(game.Answer == input)
        {
            winCounter++;
            Communication.PrintCorrectAnswer();
        } 
        else
        {
            Communication.PrintYouWereWrong(game.Answer);
        }
        roundsPlayed++;
        if(amountOfRounds == roundsPlayed)
        {
            Communication.SummarizeGame(winCounter, roundsPlayed);

            resultsList.Add(DateTime.Now.ToString() + " " + name + " " + "Your result: " + winCounter + " out of " + amountOfRounds + " rounds" + " Difficulty level: " +  difficulty);
        }
    }
}
