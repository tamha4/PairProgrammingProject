using static System.Console;
using PairProgramming.Data.Entities.DeathStarEntities;
using PairProgramming.Repository.Death_Star_Repository;
using PairProgramming.Data.Utilities;
using PairProgramming.Data.Entities;
using PairProgramming.Data.Entities.EventEntities;

namespace PairProgramming.UI
{
    public class ProgramUI
    {
        private readonly DeathStarRepository _swDeathStarRepo = new DeathStarRepository();
        private DeathStar _deathStar;
        private int _eventCounter;
        private bool IsRunning = true;
        public bool _hasMiddleRoomClearence;
        public bool _hasHacker;


        public ProgramUI()
        {
            // SeedData();
            _deathStar = _swDeathStarRepo.GetDeathStar();
        }

        private void SeedData()
        {
        }

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            while (IsRunning)
            {
                Clear();
                System.Console.WriteLine("███████╗████████╗ █████╗ ██████╗     ██╗    ██╗ █████╗ ██████╗ ███████╗");
                System.Console.WriteLine("██╔════╝╚══██╔══╝██╔══██╗██╔══██╗    ██║    ██║██╔══██╗██╔══██╗██╔════╝");
                System.Console.WriteLine("███████╗   ██║   ███████║██████╔╝    ██║ █╗ ██║███████║██████╔╝███████╗");
                System.Console.WriteLine("╚════██║   ██║   ██╔══██║██╔══██╗    ██║███╗██║██╔══██║██╔══██╗╚════██║");
                System.Console.WriteLine("███████║   ██║   ██║  ██║██║  ██║    ╚███╔███╔╝██║  ██║██║  ██║███████║");
                System.Console.WriteLine("╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝     ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝");
                
                System.Console.WriteLine("Welcome to the StarWars Game\n" +
                                        "1. Start Game\n" +
                                        "2. End Game\n");

                var userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        StartGame();
                        break;
                    case "2":
                        IsRunning = CloseGame();
                        break;
                    default:
                        WriteLine("Invalid Selection.");
                        break;
                }

            }
        }

        private bool CloseGame()
        {
            WriteLine("Thanks for playing!");
            PressAnyKeyToContinue();
            return false;
        }

        private void PressAnyKeyToContinue()
        {
            WriteLine("Press any key to continue.");
            ReadKey();
        }

        private void StartGame()
        {
            Clear();

            while (!_deathStar.Player.IsDead && IsRunning)
            {
                GameUtilities.TellTheStory($"You sensed a disturbence in the force. Darth Vader is up to something and you need to stop him." +
                                          $"You land you x wing in the Death Star... Press any Key to Continue...");

                ReadKey();
                while (_hasMiddleRoomClearence == false)
                {
                    LoadFirstEvent();
                }

                GameUtilities.TellTheStory("You use the clearence key to open the Middle Room Door!");

                GameUtilities.TellTheStory("You go up the elevator, your on the Next Level!");

                while (_hasHacker == false)
                {
                    LoadSecondEvent();
                }

                LoadFinalEvent();

                ReadKey();
            }

            if (_deathStar.Player.IsDead)
            {
                IsRunning = CloseGame();
            }
        }

        private void LoadFinalEvent()
        {
            Clear();
            ClearEventCounter();



            GameUtilities.TellTheStory("You successfully hacked the computer. the room is dark. Darth Vader emerges.\n" +
                                       "1. Prepare to defend yourself!\n" +
                                       "2. Surrender?\n" +
                                       "3. Try to escape!\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    ShootDarthVader();
                    break;

                case "2":
                    AskQuestions();
                    break;

                case "3":
                    TryToEscape();
                    break;

                default:
                    WriteLine("Invalid Selection");
                    break;
            }
        }

        private void TryToEscape()
        {
            Clear();
            BossFight currentEvent = (BossFight)_deathStar.LevelsInDeathStar[1].Events[0];
            GameUtilities.TellTheStory("You try to escape. Darth Vader Slams the door closed with the force.\n" +
                                       "Darth Vader says, 'The force is weak with you'");
            currentEvent.Boss!.Attack(_deathStar.Player, 1000, "Do not underestimate the power of the force.");
            _hasHacker = false;
        }


        private void AskQuestions()
        {
            Clear();
           BossFight currentEvent = (BossFight)_deathStar.LevelsInDeathStar[1].Events[0];
            GameUtilities.TellTheStory("You ask him who he is...\n'I am your father' says Darth Vader\nYou try to escape. Darth Vader Slams the door closed with the force.\n" +
                                       "Darth Vader says, 'The force is weak with you'");
            
            currentEvent.Boss!.Attack(_deathStar.Player, 1000, "Do not underestimate the power of the force.");
            _hasHacker = false;
        }


        private void ShootDarthVader()
        {
            Clear();
            BossFight currentEvent = (BossFight)_deathStar.LevelsInDeathStar[1].Events[0];
            GameUtilities.TellTheStory("You shoot Darth Vader");
            _deathStar.Player.ShootBlaster(currentEvent.Boss!, 50);
            if (_deathStar.Player.IsDead == false)
            {
                while (currentEvent.Boss!.HealthPoints > 0)
                {
                    GameUtilities.TellTheStory("Will you shoot again y/n");
                    var userInput = ReadLine();
                    if (userInput != "Y".ToLower())
                    {
                        Clear();
                        GameUtilities.TellTheStory("You try to escape. Darth Vader Slams the door closed with the force.\n" +
                                       "Darth Vader says, 'The force is weak with you'");
                        currentEvent.Boss!.Attack(_deathStar.Player, 1000, "Do not underestimate the power of the force.");
                        _hasHacker = false;
                        break;
                    }
                    else
                    {
                        _deathStar.Player.ShootBlaster(currentEvent.Boss, 20);
                    }
                }
                if (currentEvent.Boss.IsDead)
                {

                    WriteLine("You killed Darth Vader and saved the galaxy!");
                    IsRunning = CloseGame();
                }
            }
            else
            {
                IsRunning = CloseGame();
            }
        }

        private void LoadSecondEvent()
        {
            Clear();
            ClearEventCounter();
            var currentEvent = _deathStar.LevelsInDeathStar[(int)PairProgramming.Data.Entities.Index.FirstEvent].Events[++_eventCounter];
            GameUtilities.TellTheStory("There is a large computer in the hall way. Looks like it is password protected. You need to find the hacker.");
            GameUtilities.TellTheStory(currentEvent.EventDescription);
            GameUtilities.TellTheStory("Which room will you select this time?\n" +
                                       "1. The Room down the loading dock and to the Left?\n" +
                                       "2. The Room by the generator room and to the Right?\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    LoadTheRoomLeft();
                    break;
                case "2":
                    LoadTheRoomRight();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    break;
            }


        }

        private void LoadTheRoomLeft()
        {
            bool hasLeftRoom = false;
            while (!hasLeftRoom)
            {
                Clear();
                GameUtilities.TellTheStory("You Entered an empty Storm Trooper Bararcks What will you do next?\n" +
                                        "1. Look under the bunk beds.\n" +
                                        "2. The mini fridge\n" +
                                        "3. Leave the room.");
                var userInput = ReadLine();
                switch (userInput)
                {
                    case "1":
                        Clear();
                        GameUtilities.TellTheStory("You look underneath the bunk beds... You find a StromTrooper's Teddy Bear... 'Ha! funny!' you say");
                        PressAnyKeyToContinue();
                        break;

                    case "2":
                        Clear();
                        GameUtilities.TellTheStory("You look inside the mini fridge... Random Drinks...");
                        PressAnyKeyToContinue();
                        break;

                    case "3":
                        Clear();
                        GameUtilities.TellTheStory("You exit the room.");
                        PressAnyKeyToContinue();
                        hasLeftRoom = true;
                        LoadSecondEvent();
                        break;

                    default:
                        WriteLine("Invalid Selection.");
                        break;
                }
            }
        }


        private void LoadTheRoomRight()
        {
            bool hasLeftRoom = false;
            while (!hasLeftRoom)
            {
                Clear();
                GameUtilities.TellTheStory("You enterd the room. Its the generator maintence room. \n" +
                "1. Behind the Empire Propaganda Poster?\n" +
                "2. A Box next to the Control Panel.\n" +
                "3. Leave the room.");

                var userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        Clear();
                        GameUtilities.TellTheStory("You look inside...NOTHING.");
                        PressAnyKeyToContinue();
                        break;

                    case "2":
                        Clear();
                        GameUtilities.TellTheStory("You pick up the box and open it. The Hacker is inside!");
                        _hasHacker = true;
                        hasLeftRoom = true;
                        PressAnyKeyToContinue();
                        break;

                    case "3":
                        Clear();
                        GameUtilities.TellTheStory("You exit the room!");
                        PressAnyKeyToContinue();
                        hasLeftRoom = true;
                        LoadSecondEvent();
                        break;

                    default:
                        WriteLine("Invalid Selection");
                        break;
                }
            }
        }


        private void ClearEventCounter()
        {
            _eventCounter = 0;
        }

        private void LoadFirstEvent()
        {
            ClearEventCounter();
            Clear();

            var currentEvent = _deathStar.LevelsInDeathStar[(int)PairProgramming.Data.Entities.Index.FirstEvent].Events[++_eventCounter];

            GameUtilities.TellTheStory(currentEvent.EventDescription);

            GameUtilities.TellTheStory("Which Room will you select?\n" +
                                         "1. Room on the Left\n" +
                                         "2. Room on the Right\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    YouChoseTheLeftRoom();
                    break;
                case "2":
                    YouChoseTheRightRoom();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }

        private void YouChoseTheRightRoom()
        {
            bool hasLeftRoom = false;
            while (!hasLeftRoom)
            {
                Clear();
                GameUtilities.TellTheStory("You Entered the Right Room. Its a garbage compactor! You are stuck and need to find a weight out!\n" +
                "1. Swim Under the trash!\n" +
                "2. Panic and do nothing\n" +
                "3. Use your light saber to cut the door open");

                var userInput = ReadLine();
                switch (userInput)
                {
                    case "1":
                        Clear();
                        GameUtilities.TellTheStory("You swam under the trash and found a monster! You swim back to the surface. 'I better find a way out' you say");
                        PressAnyKeyToContinue();
                        break;
                    case "2":
                        Clear();
                        GameUtilities.TellTheStory("Really!? you are panicing right now!?");
                        PressAnyKeyToContinue();
                        break;
                    case "3":
                        Clear();
                        GameUtilities.TellTheStory("Your light saber easily cuts through the door and you are able to escape!");
                        PressAnyKeyToContinue();
                        hasLeftRoom = true;
                        LoadFirstEvent();
                        break;
                    default:
                        WriteLine("Invalid Selection");
                        break;
                }
            }
        }


        private void YouChoseTheLeftRoom()
        {
            bool hasLeftRoom = false;

            while (!hasLeftRoom)
            {
                Clear();
                GameUtilities.TellTheStory("You Entered the left room\nIt seems to be the janitors closet.\nWhere do you want to look.\n" +
                 "1. In the tool box\n" +
                 "2. In the mop bucket\n" +
                 "3. Inside the the janitor jacket hanging on the door\n" +
                 "4. Leave the room\n");

                var userInput = ReadLine();

                switch (userInput)
                {
                    case "1":
                        GameUtilities.TellTheStory("You check the tool box... oh wow some tools!");
                        PressAnyKeyToContinue();
                        break;

                    case "2":
                        GameUtilities.TellTheStory("You check the Mop bucket...Nothing but some dirty Water!");
                        PressAnyKeyToContinue();
                        break;

                    case "3":
                        GameUtilities.TellTheStory("You feel the pockets of the Janitor jacket...You found the Clearence Key!");
                        _hasMiddleRoomClearence = true;
                        GameUtilities.TellTheStory("You Exit the room");
                        hasLeftRoom = true;
                        PressAnyKeyToContinue();
                        break;

                    case "4":
                        GameUtilities.TellTheStory("You exit the Room!");
                        PressAnyKeyToContinue();
                        hasLeftRoom = true;
                        LoadFirstEvent();
                        break;

                    default:
                        WriteLine("Invalid Selection!");
                        break;
                }
            }
        }
    }
}