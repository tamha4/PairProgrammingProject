using PairProgramming.Data.Entities.DeathStarEntities;
using PairProgramming.Repository.Level_Repository;

namespace PairProgramming.Repository.Death_Star_Repository
{
    public class DeathStarRepository
    {
        private readonly LevelReopsitory _swDeathStarLevelRepo = new LevelReopsitory();

        private readonly List<DeathStar> _deathStarDb = 
                new List<DeathStar>();
        int _count = 0;
        public DeathStarRepository()
        {
            SeedData();
        }
        public bool AddDeathStar(DeathStar deathStar)
        {
            if(deathStar is null)
            {
                return false;
            }
            else
            {
                _count++;
                deathStar.ID = _count;
                _deathStarDb.Add(deathStar);
                return true;
            }
        }
        public List<DeathStar> GetDeathStars()
        {
            return _deathStarDb;
        }

        public DeathStar GetDeathStar()
        {
            return _deathStarDb.FirstOrDefault()!;
        }

        public bool FinishedGame(List<Level> rooms)
        {
             if(rooms.Count == 0)
            {
                return true;
            }
            return false;
        }
        private void SeedData()
        {
            var deathStar = new DeathStar();
            deathStar.LevelsInDeathStar = _swDeathStarLevelRepo.GetLevels();
            AddDeathStar(deathStar);
        }
    }
}