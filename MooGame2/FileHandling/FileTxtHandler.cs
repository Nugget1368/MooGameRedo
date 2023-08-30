using MooGame.Player;

namespace MooGame.FileHandling
{
    /* ****************************************************************************************
	 * Gör ett uinterface där Filehandlern är anpassad för flera olika spel med andra filnamn, 
	 * andra krav på Append. Andra sätt att skriva sparfilen?
	 ****************************************************************************/
    public class FileTxtHandler<T> : IFileHandler<IPlayerData>
    {
        public void SaveResult(string savedText, string filename)
        {
            StreamWriter output = new StreamWriter(filename, append: true);
            output.WriteLine(savedText);
            output.Close();
        }

        public List<IPlayerData> showTopList(string filename)
        {
            StreamReader input = new StreamReader(filename);

            List<IPlayerData> results = new List<IPlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                IPlayerData playerData = new PlayerData(nameAndScore[0], Convert.ToInt32(nameAndScore[1]));
                int pos = results.IndexOf(playerData);
                if (pos < 0)
                {
                    results.Add(playerData);
                }
                else
                {
                    results[pos].Update(playerData.GuessTotal);
                }
            }

            input.Close();
            return results = SortSaveFile(results);
        }
        private List<IPlayerData> SortSaveFile(List<IPlayerData> results)
        {
            results.Sort((p1, p2) => p1.PlayerScore(p1.GuessTotal, p1.NGames).CompareTo(p2.PlayerScore(p2.GuessTotal, p2.NGames)));
            return results;
        }
    }
}