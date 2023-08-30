using MooGame.Player;
namespace MooGame.UI
{
    /********************************************************************
	 * Motivation: En del av UI:ns jobb är att presentera spelarstatistik,
	 * därför tänker jag att IPlayerData får implimenteras direkt i UI:ns metoder
	 *****************************************************************************/
    public class ConsoleUI<T> : IUI<IPlayerData>
    {
        public string EnterName()
        {
            Console.WriteLine("Enter your user name:\n");
            string name = Console.ReadLine();
            while (name == "" || name == null)
            {
                Console.WriteLine("Enter your user name:\n");
                name = Console.ReadLine();
            }
            return name;
        }

        public bool Result(string checkResult)
        {
            Console.WriteLine(checkResult + "\n");
            if (checkResult != "BBBB,")
            {
                Console.WriteLine("Try again:");
                return false;
            }
            return true;
        }

        public string PlayerInput()
        {
            string input = "";
            while (input == "" || input == null)
            {
                input = Input();
            }
            return input;
        }
        private string Input()
        {
            string input = Console.ReadLine();
            return input;
        }

        public void HighScore(List<IPlayerData> playerData)
        {
            Console.WriteLine("Player   games	average");
            foreach (var player in playerData)
            {
                Console.WriteLine($"{string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NGames, player.PlayerScore(player.GuessTotal, player.NGames))}");
            }
        }

        //Man vill generelt visa playerScore mm. så för in hela playern i GameOver
        //Men egentligen för just detta fall hade det räckt med GuessTotal från IPlayerData
        public bool GameOver(IPlayerData playerData)
        {
            Console.WriteLine("Correct, it took " + playerData.GuessTotal + " guesses\nContinue?");
            if (PlayerInput().Substring(0, 1) == "n")
            {
                return false;
            }
            return true;
        }
    }
}