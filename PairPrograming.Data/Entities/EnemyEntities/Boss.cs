

namespace PairProgramming.Data.Entities.EnemyEntities
{
    public class Boss : Enemy
    {
        public void ForceChoke()
        {
            IncreaseHealth(15);
            System.Console.WriteLine($"{Name} force choked a random Storm Trooper!\n" + $"His Health is now {HealthPoints}\n");
        }
    }
}