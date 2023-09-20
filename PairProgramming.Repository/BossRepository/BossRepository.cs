using PairProgramming.Data.Entities.EnemyEntities;

namespace PairProgramming.Repository.Boss_Repository
{
    public class BossRepository
    {
        public List<Boss> _swBossDb = new List<Boss>();
        public int _count = 0;
        public BossRepository()
        {
            SeedBoss();
        }
        private void MakeId(Boss boss)
        {
            _count++;
            boss.ID =_count;
        
        }

        private bool SaveDb(Boss boss)
        {
            MakeId(boss);
            _swBossDb.Add(boss);
            return true;
        }

        public bool AddBoss(Boss boss)
        {
            return (boss is null) ? false: SaveDb(boss);
        }
        public Boss GetBoss()
        {
            return _swBossDb.FirstOrDefault()!;
        
        }
        public Boss GetBoss(int id)
        {
            return _swBossDb.SingleOrDefault(x => x.ID == id)!;
        
        }
        private void SeedBoss()
        {
            var boss = new Boss
            {
                ID = 1,
                Name = "Darth Vader"
            };

            _swBossDb.Add(boss);
        }
    }
}