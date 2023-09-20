using PairProgramming.Data.Entities.EnemyEntities;
using PairProgramming.Data.Entities.DeathStarEntities;
using PairProgramming.Data.Entities.PlayerEnties;
using PairProgramming.Data.Entities.EventEntities;
using PairProgramming.Data.Entities.PlayerEnties;

namespace PairProgramming.Data.Utilities
{
    public static class GameUtilities
    {
        public static List<PlayerItem> InitializePlayerStartupItems()
        {
            string[] listOfStuff = File.ReadAllLines(@"C:\ElevenFiftyProjects_175\codingFoundations\dotnetProjects\assignments\consoleGame\PairPrograming.Data\PlayerItems.txt");

             List<PlayerItem> playerStartingItems = new List<PlayerItem>();

             for (int i = 0; i < listOfStuff.Length; i++)
            {
                if (listOfStuff[i] == "|")
                {
                    var playerItem = new PlayerItem
                    {
                        ID = int.Parse(listOfStuff[++i]),
                        Name = listOfStuff[++i],
                        TimesCanBeUsed = int.Parse(listOfStuff[++i])
                    };

                    playerStartingItems.Add(playerItem);
                }
            }
            return playerStartingItems;
        }
        public static void FoundBlasterCharge(int roundValue, Player player)
        {
            player.LoadBlasterCharge(roundValue);
        }

        public static void TellTheStory(string storySection)
        {
            System.Console.WriteLine(storySection);
        }

        public static void DisplayFloorChallengeInfo(PairProgramming.Data.Entities.DeathStarEntities.DeathStar _deathStar)
        {
            foreach (Level level in _deathStar.LevelsInDeathStar)
            {
                foreach (Event lEvent in level.Events)
                {
                    System.Console.WriteLine(lEvent.EventDescription);
                }
            }
        }
    }
}