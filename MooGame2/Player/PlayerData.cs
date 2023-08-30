using System.Collections;

namespace MooGame.Player
{
    public class PlayerData : IPlayerData
    {
        public string Name { get; set; }
        public int NGames { get; private set; } = 1;
        public int GuessTotal { get; private set; }
        public string Guess { get; private set; }

        /***********************/

        public PlayerData(string name, int guesses)
        {
            Name = name;
            NGames = 1;
            GuessTotal = guesses;
        }
        public void SetName(string name)
        {
            Name = name;
        }

        public void ResetGuessTotal()
        {
            GuessTotal = 0;
        }

        public void Update(int guesses)
        {
            GuessTotal += guesses;
            NGames++;
        }
        public void SetGuess(string guess)
        {
            GuessTotal++;
            Guess = guess;
        }
        public double PlayerScore(int totalGuesses, int numOfGames)
        {
            return (double)totalGuesses / numOfGames;
        }
        public override bool Equals(object p)
        {
            //???????
            return Name.Equals(((PlayerData)p).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}