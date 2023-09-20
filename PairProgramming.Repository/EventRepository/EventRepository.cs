using PairProgramming.Data.Entities.EventEntities;
using PairProgramming.Repository.Boss_Repository;

namespace PairProgramming.Repository.Event_Repository
{
    public class EventRepository
    {
        private readonly BossRepository _swBossRepo = new BossRepository();

        private readonly List<Event> _swEventRepo = new List<Event>();

        int _count = 0;

        public EventRepository()
        {
            SeedEvents();
        }
        public bool AddEvent(Event eventL)
        {
            if (eventL is null)
            {
                return false;
            }
            else
            {
                _count++;
                eventL.ID = _count;
                _swEventRepo.Add(eventL);
                return true;
            }
        }

        public List<Event> GetEvents()
        {
            return _swEventRepo;
        }

        public Event GetChallenge(int eventID)
        {


            foreach (var eventL in _swEventRepo)
            {
                if (eventL.ID == eventID)
                    return eventL;
                else
                    return null!;
            }
            return null!;
        }


        private void SeedEvents()
        {
            var level1 = new LevelEvent
            {
                ID =1,
                EventDescription = 
                "There are three Rooms\n"+
                "The Left and Right ones are unlocked\n"+
                "Find Middle Room Clearence\n",
                EventTasks = new List<string>
                {
                    "Find Middle Room Clearence\n"
                }
            };

            var level2 = new LevelEvent
            {
                ID =2,
                EventDescription = "Find the hacker and put hack the Death Star Computer",
                EventTasks = new List<string>
                {
                    "Find the Hacker\n",
                    "Hack the Death Star Computer\n"
                }
            };

             var level3 = new BossFight
            {
                ID =3,
                EventDescription = "Defeat Darth Vader!!!",
                EventTasks = new List<string>
                {
                    "Defeat Darth Vader"
                }
            };


            _swEventRepo.Add(level1);
            _swEventRepo.Add(level2);
            _swEventRepo.Add(level3);
        }
    }
}