using MooGame.FileHandling;
using MooGame.Player;
using MooGame.UI;

namespace MooGame;
class MainClass
{
	public static void Main(string[] args)
	{
		IUI<IPlayerData> ui = new ConsoleUI<IPlayerData>();
		IFileHandler<IPlayerData> fileHandler = new FileTxtHandler<IPlayerData>();
		IPlayGame<IPlayerData> playGame = new PlayGame<IPlayerData>(fileHandler, ui);

		bool playOn = true;
		playGame.StartGame(playOn);
	}
}