
namespace PairProgramming.Data.Entities.PlayerEnties
{
    public class PlayerItem
    {
        public PlayerItem()
        {

        }

        public PlayerItem(int id, string name, int timesCanBeUsed = 2)
        {
            ID = id;
            Name = name;
            TimesCanBeUsed = timesCanBeUsed;
        }
        
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TimesCanBeUsed { get; set; }
        public bool IsUseable
        {
            get
            {
                return (TimesCanBeUsed > 0) ? true : false;
            }
        }
    }
}