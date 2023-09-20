using System.Security.Cryptography.X509Certificates;
using PairProgramming.Data.Entities.EventEntities;
using PairProgramming.Data.Entities.PlayerEnties;

namespace PairProgramming.Data.Entities.DeathStarEntities
{
    public class DeathStar
    {
        public DeathStar()
        {
            Name = "The Death Star";
            Location = "Orbiting a helpless planet";
            Player = new Player("C3PO");
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public Player Player { get; set; }
        public List<Level> LevelsInDeathStar {get; set;} = new List<Level>();

         public override string ToString()
        {
           var str = $"ID: {ID}\n"+
                     $"Name: {Name}\n"+
                     $"Location: {Location}\n"+
                     $"Player: {Player.Name}"+
                     "----- Levels in The Death Star -----\n";
            foreach (Level level in LevelsInDeathStar)
            {
                str+= $"LevelID: {level.ID}\n"+
                      $"Level Name: {level.Name}\n"+
                      "===== Level Events =====\n";
                foreach (Event levelEvent in level.Events)
                {
                    str += $"Level Event ID: {level.ID}\n"+
                           $"Level Event Description: {levelEvent.EventDescription}";
                    foreach (string task in levelEvent.EventTasks)
                    {
                        str+=$"{task}";
                    }
                    str += $"Level Event Complete: {levelEvent.IsComplete}";
                }
            }

            return str;
        }
    }
}