using PairProgramming.Data.Entities.EnemyEntities;
using PairProgramming.Data.Utilities;

namespace PairProgramming.Data.Entities.PlayerEnties
{
    public class Player
    {
         public Player()
        {
            SetUpPlayerInitialization();
        }

        public Player(string name)
        {
            Name = name;
            SetUpPlayerInitialization();
        }

        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int HealthPoints { get; set; } = 100;
        public bool IsDead
        {
            get
            {
                return (HealthPoints <= 0) ? true : false;
            }
        }

        public List<PlayerItem> Items;

        public void DecreaseHealth(int pointValue = 5)
        {
            if (HealthPoints >= 0)
                HealthPoints -= pointValue;
        }

        public void IncreaseHealth(int pointValue = 5)
        {
            if (HealthPoints > 0)
                HealthPoints += pointValue;
        }

        public void ShootBlaster(Enemy enemy, int attackPower = 15)
        {
            if (Blaster.IsUseable)
            {
                Blaster.TimesCanBeUsed--;
                System.Console.WriteLine($"You shot the Plasma Pistol at {enemy.Name}!\n" +
                                         $"You have {Blaster.TimesCanBeUsed} charges left!");

                if (enemy.HealthPoints > 0)
                {
                    enemy.DecreaseHealth(attackPower);
                }
            }
            else
            {
                System.Console.WriteLine("I better find some Blaster Charges!!!");
            }
        }

        public void LoadBlasterCharge(int roundValue)
        {
            Blaster.TimesCanBeUsed += roundValue;
        }

        private PlayerItem Blaster;
        private PlayerItem GrappleHook;
        private PlayerItem Communicator;
        private PlayerItem LightSaber;

        private void SetUpPlayerInitialization()
        {
            Items = GameUtilities.InitializePlayerStartupItems();
            LightSaber = Items[0];
            GrappleHook = Items[1];
            Communicator = Items[2];
            Blaster = Items[3];
        }
    }
}