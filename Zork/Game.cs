using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace Zork
{
    public class Game
    {
        public World World { get; set; }

        public string StartingLocation { get; set; }

        [JsonIgnore]
        public Player Player { get; private set; }

        public string WelcomeMessage { get; set; }

        public string ExitMessage { get; set; }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Player = new Player(World);
            Player.CurrentRoom = World.RoomsByName[StartingLocation];
        }

        public void Run()
        {
            Console.WriteLine(WelcomeMessage);

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Player.CurrentRoom);
                if (Player.PreviousRoom != Player.CurrentRoom)
                {
                    Console.WriteLine(Player.CurrentRoom.Description);
                    Player.PreviousRoom = Player.CurrentRoom;
                }
                Console.Write("> ");

                command = ToCommand(Console.ReadLine().Trim());
                // command = Console.ReadLine().Trim().ToCommand();
            
                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine(ExitMessage);
                        break;
            
                    case Commands.LOOK:
                        Console.WriteLine(Player.CurrentRoom.Description);
                        break;
            
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        Directions direction = Enum.Parse<Directions>(command.ToString(), true);
                        if (Player.Move(direction) == false)
                        {
                            Console.WriteLine("The way is shut!");
                        }
                        break;
            
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
            }
        }
        private static Commands ToCommand(string commandString) => Enum.TryParse<Commands>(commandString, true, out Commands result) ? result : Commands.UNKNOWN;
    }
}
