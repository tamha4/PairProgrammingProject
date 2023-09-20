using PairProgramming.Data.Entities.EventEntities;
using PairProgramming.Data.Entities.EventEntities;
using PairProgramming.Data.Entities.DeathStarEntities;
using PairProgramming.Repository.Event_Repository;




namespace PairProgramming.Repository.Level_Repository
{
    public class LevelReopsitory
    {
        private readonly EventRepository _swDeathStarEventRepo = new EventRepository();
        private readonly List<Level> _swDeathStarLevelDb = new List<Level>();
        int _count =0;
        public LevelReopsitory()
        {
            SeedLevels();
        }
        public bool AddLevel(Level level)
        {
            if (level is null)
            {
                return false;
            }
            else
            {
                _count++;
                level.ID = _count;
                _swDeathStarLevelDb.Add(level);
                return true;
            }
            
        }
        public List<Level> GetLevels()
            {
                return _swDeathStarLevelDb;
            }
        public Level GetLevel(int id)
        {
            foreach (Level level in _swDeathStarLevelDb)
            {
                if (level.ID == id)
                    return level;
            }
            return null!;
        }
         private void SeedLevels()
        {
            var level = new Level()
            {
                ID = 1,
                Name = "Main Level: Docking Bay",
                Events = _swDeathStarEventRepo.GetEvents()
                             .Where(c => c.GetType() == typeof(LevelEvent)).ToList()
            };

            var level2 = new Level()
            {
                ID = 2,
                Name = "Second Level: Darth Vadar's Lair",
                Events = _swDeathStarEventRepo.GetEvents()
                             .Where(c => c.GetType() == typeof(BossFight)).ToList()
            };

            _swDeathStarLevelDb.Add(level);
            _swDeathStarLevelDb.Add(level2);
        }
    }
}