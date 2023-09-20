using PairProgramming.Data.Entities.EventEntities;

namespace PairProgramming.Data.Entities.DeathStarEntities
{
    public class Level
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Event> Events {get; set;} = new List<Event>();
    }
}