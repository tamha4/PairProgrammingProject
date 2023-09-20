
namespace PairPrograming.Data.Entities
{
    public class StarWarsCharacter{ // this is the blueprint for starwars character

        public StarWarsCharacter(){}

        public StarWarsCharacter(string name){
            Name = Name;
        }

        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public int Health {get; set;}
        public bool AliveStatus {
            get{
                if(Health >= 100){
                    return true;
                }
                return false;
            }
        }
        //Like a function
        public virtual void Attack(StarWarsCharacter character, int attackValue, string attackName){
            // decrease character health
            character.Health -= attackValue;
            System.Console.WriteLine($"{this.Name} attacked {character.Name} with {attackName}, it did {attackValue} damage.");
        }
    }
   
    
}