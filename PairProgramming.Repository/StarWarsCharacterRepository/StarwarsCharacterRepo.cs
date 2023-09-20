

using PairPrograming.Data.Entities;

namespace PairProgramming.Repository.StarWarsCharacterRepository
{
    public class StarwarsCharacterRepo
    {
        private readonly List<StarWarsCharacter> _swCharacterDb = new List<StarWarsCharacter>();
        int _counter = 0;
        public StarwarsCharacterRepo()
        {
            Seed();
        }

        private void Seed()
        {
            var chewbacca = new StarWarsCharacter("Chewbacca");
            var lukeSkywalker = new StarWarsCharacter("Luke Skywalker");
            var hanSolo = new StarWarsCharacter("Han Solo");
            var princessLeia = new StarWarsCharacter("Princess Leia");
            var darthJarJar = new StarWarsCharacter("Darth Jar Jar");

            List<StarWarsCharacter> characters = new List<StarWarsCharacter>();
            characters.Add(chewbacca);
            characters.Add(lukeSkywalker);
            characters.Add(hanSolo);
            characters.Add(princessLeia);
            characters.Add(darthJarJar);
            CreateStarWarsCharacter(characters);
        }

        // Create method // use to add starwar charactesr
        public bool CreateStarWarsCharacter(StarWarsCharacter character){
            if(character is null){
                return false;
            }else{
                _counter++;
                character.Id = _counter;
                _swCharacterDb.Add(character);
                return true;
            }
        }

        public bool CreateStarWarsCharacter(List<StarWarsCharacter> character){
            if(character is null){
                return false;
                }else{
                    foreach(var sw in character){
                        _counter++;
                        sw.Id = _counter;
                        _swCharacterDb.Add(sw);
                }
                return true;
            }
        }

        public StarWarsCharacter GetStarWarsCharacter(string characterName){
            //search the enrire database
            foreach(var  sw in _swCharacterDb){
                if(sw.Name == characterName)
                return sw;
            }
            return null;
        }
    }
}